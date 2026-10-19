using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using Serilog;
using bai4.Models;

namespace bai4;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // Khởi tạo thư mục logs nếu chưa có
        string logDir = Path.Combine(AppContext.BaseDirectory, "logs");
        if (!Directory.Exists(logDir))
        {
            Directory.CreateDirectory(logDir);
        }

        // Cấu hình Serilog (Ghi log ra file và console)
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(
                Path.Combine(logDir, "log-.txt"),
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("=== Khởi động ứng dụng Bán hàng quán trà sữa ===");

        try
        {
            // Khởi tạo cấu hình từ appsettings.json
            AppConfig.Initialize();

            if (args.Length > 0 && args[0] == "--test")
            {
                RunSelfTest();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new FormBanHang());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ứng dụng gặp sự cố nghiêm trọng không thể khắc phục.");
            MessageBox.Show($"Đã xảy ra lỗi khi khởi chạy ứng dụng:\n{ex.Message}", "Lỗi khởi động", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.Information("=== Ứng dụng Bán hàng quán trà sữa kết thúc ===");
            Log.CloseAndFlush();
        }
    }

    private static void RunSelfTest()
    {
        Console.WriteLine("[TEST 1] Đọc cấu hình Payment từ appsettings.json:");
        var pay = AppConfig.Payment;
        Console.WriteLine($"  - Tên quán: {pay.StoreName}");
        Console.WriteLine($"  - BankId: {pay.BankId}");
        Console.WriteLine($"  - AccountNo: {pay.AccountNo}");
        Console.WriteLine($"  - AccountName: {pay.AccountName}");
        Console.WriteLine($"  - Template: {pay.Template}");
        if (string.IsNullOrEmpty(pay.BankId) || string.IsNullOrEmpty(pay.AccountNo))
        {
            throw new Exception("Lỗi đọc cấu hình thanh toán!");
        }
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 2] Kết nối CSDL QL_TraSua bằng EF Core:");
        using (var context = new QL_TraSuaContext())
        {
            var dmCount = context.DanhMucMons.Count();
            var monCount = context.MonUongs.Count();
            Console.WriteLine($"  - Số lượng danh mục: {dmCount}");
            Console.WriteLine($"  - Số lượng món uống: {monCount}");
            if (dmCount < 4 || monCount < 12)
            {
                throw new Exception($"Dữ liệu chưa đủ! Danh mục: {dmCount}, Món: {monCount}");
            }
        }
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 3] Tải ảnh VietQR qua HttpClient (async):");
        string noiDung = "TRASUA HD9999";
        decimal testAmount = 50000;
        string url = $"https://img.vietqr.io/image/{pay.BankId}-{pay.AccountNo}-{pay.Template}.png?amount={testAmount:0}&addInfo={Uri.EscapeDataString(noiDung)}&accountName={Uri.EscapeDataString(pay.AccountName)}";
        Console.WriteLine($"  - URL: {url}");
        Log.Information("Tạo mã QR VietQR cho đơn hàng {MaHD} với số tiền {TongTien:N0} đ", 9999, testAmount);

        using (var http = new HttpClient())
        {
            http.Timeout = TimeSpan.FromSeconds(10);
            var bytes = http.GetByteArrayAsync(url).GetAwaiter().GetResult();
            Console.WriteLine($"  - Kích thước ảnh tải về: {bytes.Length} bytes");
            if (bytes.Length == 0) throw new Exception("Không tải được ảnh QR!");
        }
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 4] Thử nghiệm lưu hóa đơn + chi tiết cùng lúc (1 lần SaveChanges):");
        int testMaHd = 0;
        using (var context = new QL_TraSuaContext())
        {
            var firstMon = context.MonUongs.First();
            var hoaDon = new HoaDon
            {
                NgayLap = DateTime.Now,
                TongTien = firstMon.GiaBan * 2,
                HinhThucTt = "Chuyển khoản",
                DaThanhToan = true
            };
            hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
            {
                MaMon = firstMon.MaMon,
                SoLy = 2,
                DonGia = firstMon.GiaBan
            });

            context.HoaDons.Add(hoaDon);
            context.SaveChanges();
            testMaHd = hoaDon.MaHd;
            Console.WriteLine($"  - Đã lưu thành công hóa đơn test Mã HD = {testMaHd}");
        }

        // Đọc lại kiểm tra
        using (var context = new QL_TraSuaContext())
        {
            var checkHd = context.HoaDons.Find(testMaHd);
            var countCt = context.ChiTietHoaDons.Count(c => c.MaHd == testMaHd);
            Console.WriteLine($"  - Kiểm tra lại: HD {checkHd?.MaHd}, Số chi tiết: {countCt}");
            if (checkHd == null || countCt == 0) throw new Exception("Lỗi lưu hóa đơn!");

            // Xóa dữ liệu test
            var cts = context.ChiTietHoaDons.Where(c => c.MaHd == testMaHd).ToList();
            context.ChiTietHoaDons.RemoveRange(cts);
            context.HoaDons.Remove(checkHd);
            context.SaveChanges();
            Console.WriteLine("  - Đã dọn dẹp hóa đơn test sạch sẽ.");
        }
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 5] Kiểm tra Serilog ghi log ra file:");
        string logPattern = Path.Combine(AppContext.BaseDirectory, "logs");
        var logFiles = Directory.GetFiles(logPattern, "log-*.txt");
        Console.WriteLine($"  - Tìm thấy {logFiles.Length} file log.");
        if (logFiles.Length == 0) throw new Exception("Không tìm thấy file log Serilog!");
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("\n==========================================");
        Console.WriteLine("   TẤT CẢ 5 BÀI TEST ĐỀU THÀNH CÔNG 100%!  ");
        Console.WriteLine("==========================================");
    }
}