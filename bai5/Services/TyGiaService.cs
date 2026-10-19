using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;

namespace bai5.Services;

public static class TyGiaService
{
    private static readonly ConcurrentDictionary<string, (decimal Rate, DateTime ExpiryTime, string Source)> _cache = new(StringComparer.OrdinalIgnoreCase);

    public static string LastSource { get; private set; } = string.Empty;

    /// <summary>
    /// Lấy tỷ giá ngoại tệ sang VND (yêu cầu của đề bài: TyGiaService.LayTyGiaAsync(string ngoaiTe))
    /// </summary>
    public static async Task<decimal> LayTyGiaAsync(string ngoaiTe)
    {
        var (rate, source) = await LayTyGiaChiTietAsync(ngoaiTe);
        LastSource = source;
        return rate;
    }

    /// <summary>
    /// Lấy tỷ giá chi tiết kèm nguồn (chính, dự phòng, cache)
    /// </summary>
    public static async Task<(decimal Rate, string Source)> LayTyGiaChiTietAsync(string ngoaiTe)
    {
        if (string.IsNullOrWhiteSpace(ngoaiTe))
        {
            return (1m, "Mặc định");
        }

        string code = ngoaiTe.Trim().ToLowerInvariant();

        if (code == "vnd")
        {
            return (1m, "Mặc định (VND)");
        }

        // Kiểm tra bộ nhớ đệm (Cache)
        if (_cache.TryGetValue(code, out var cached) && DateTime.Now < cached.ExpiryTime)
        {
            Log.Information("Lấy tỷ giá {NgoaiTe} từ bộ nhớ đệm (Cache): {TyGia:N4} VND", code.ToUpper(), cached.Rate);
            return (cached.Rate, cached.Source);
        }

        var config = AppConfig.ExchangeRate;
        int timeoutSec = config.TimeoutSeconds > 0 ? config.TimeoutSeconds : 10;
        int cacheMinutes = config.CacheDurationMinutes > 0 ? config.CacheDurationMinutes : 10;

        string primaryUrl = config.PrimaryUrl.Replace("{code}", code);
        string backupUrl = config.BackupUrl.Replace("{code}", code);

        decimal? rate = null;
        string sourceUsed = string.Empty;

        // 1. Thử địa chỉ chính
        try
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(timeoutSec) };
            string json = await http.GetStringAsync(primaryUrl);
            rate = ParseRate(json, code);
            var uri = new Uri(primaryUrl);
            sourceUsed = uri.Host;
            Log.Information("Lấy tỷ giá {NgoaiTe} thành công từ địa chỉ chính ({Source}): {TyGia:N4} VND", code.ToUpper(), sourceUsed, rate.Value);
        }
        catch (Exception ex)
        {
            // Serilog ghi Warning khi địa chỉ chính lỗi (kèm lý do)
            Log.Warning(ex, "Địa chỉ chính lấy tỷ giá thất bại ({Url}). Lý do: {Reason}. Đang tự động chuyển sang địa chỉ dự phòng...", primaryUrl, ex.Message);
        }

        // 2. Nếu địa chỉ chính lỗi, tự động thử địa chỉ dự phòng
        if (rate == null)
        {
            try
            {
                using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(timeoutSec) };
                string json = await http.GetStringAsync(backupUrl);
                rate = ParseRate(json, code);
                var uri = new Uri(backupUrl);
                sourceUsed = uri.Host;
                Log.Information("Lấy tỷ giá {NgoaiTe} thành công từ địa chỉ dự phòng ({Source}): {TyGia:N4} VND", code.ToUpper(), sourceUsed, rate.Value);
            }
            catch (Exception ex)
            {
                // Cả hai đều lỗi mới báo người dùng
                Log.Error(ex, "Cả hai địa chỉ lấy tỷ giá cho {NgoaiTe} đều thất bại!", code.ToUpper());
                throw new Exception($"Không thể kết nối lấy tỷ giá cho '{code.ToUpper()}' từ cả địa chỉ chính và dự phòng. Vui lòng kiểm tra lại mạng hoặc cấu hình URL.");
            }
        }

        // Lưu vào cache
        _cache[code] = (rate.Value, DateTime.Now.AddMinutes(cacheMinutes), sourceUsed);

        return (rate.Value, sourceUsed);
    }

    private static decimal ParseRate(string json, string code)
    {
        using var doc = JsonDocument.Parse(json);
        if (doc.RootElement.TryGetProperty(code, out var codeElem) &&
            codeElem.TryGetProperty("vnd", out var vndElem))
        {
            return vndElem.GetDecimal();
        }

        throw new JsonException($"Không tìm thấy trường '{code}.vnd' trong dữ liệu JSON tỷ giá.");
    }

    /// <summary>
    /// Xóa cache khi cần kiểm tra lại
    /// </summary>
    public static void XoaCache()
    {
        _cache.Clear();
    }
}
