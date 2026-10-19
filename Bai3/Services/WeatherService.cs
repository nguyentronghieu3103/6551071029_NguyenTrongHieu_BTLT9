using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Bai3.Models;

namespace Bai3.Services;

public class WeatherService
{
    private static readonly HttpClient _httpClient = new()
    {
        Timeout = TimeSpan.FromSeconds(8)
    };

    public static string RemoveDiacritics(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }
        return sb.ToString().Normalize(NormalizationForm.FormC).Replace('đ', 'd').Replace('Đ', 'D');
    }

    public static async Task<WeatherForecastResult> GetForecastAsync(string diaDiem, DateOnly ngayDi, CancellationToken cancellationToken = default)
    {
        var result = new WeatherForecastResult
        {
            DestinationName = diaDiem,
            Date = ngayDi
        };

        if (string.IsNullOrWhiteSpace(diaDiem))
        {
            result.Success = false;
            result.ErrorMessage = "Vui lòng nhập địa điểm để tra cứu thời tiết!";
            return result;
        }

        try
        {
            // Bước 1: Geocoding API
            string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(diaDiem.Trim())}&count=1&language=vi";
            using var geoResponse = await _httpClient.GetAsync(geoUrl, cancellationToken);
            geoResponse.EnsureSuccessStatusCode();

            string geoJson = await geoResponse.Content.ReadAsStringAsync(cancellationToken);
            var geoData = JsonSerializer.Deserialize<GeocodingResponse>(geoJson);

            if (geoData?.Results == null || geoData.Results.Count == 0)
            {
                result.Success = false;
                result.LocationNotFound = true;
                result.LocationSuggestedName = RemoveDiacritics(diaDiem.Trim());
                return result;
            }

            var location = geoData.Results[0];
            double lat = location.Latitude;
            double lon = location.Longitude;

            // Bước 2: Forecast API
            string forecastUrl = string.Format(
                CultureInfo.InvariantCulture,
                "https://api.open-meteo.com/v1/forecast?latitude={0:F4}&longitude={1:F4}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16",
                lat, lon);

            using var forecastResponse = await _httpClient.GetAsync(forecastUrl, cancellationToken);
            forecastResponse.EnsureSuccessStatusCode();

            string forecastJson = await forecastResponse.Content.ReadAsStringAsync(cancellationToken);
            var forecastData = JsonSerializer.Deserialize<ForecastResponse>(forecastJson);

            if (forecastData?.Daily?.Time == null || forecastData.Daily.Time.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Không nhận được dữ liệu dự báo từ máy chủ!";
                return result;
            }

            string targetDateStr = ngayDi.ToString("yyyy-MM-dd");
            int dateIndex = forecastData.Daily.Time.IndexOf(targetDateStr);

            if (dateIndex == -1)
            {
                result.Success = false;
                result.IsBeyondForecastRange = true;
                return result;
            }

            // Lấy các giá trị cùng chỉ số
            int code = forecastData.Daily.WeatherCode[dateIndex];
            double maxTemp = forecastData.Daily.Temperature2mMax[dateIndex];
            double minTemp = forecastData.Daily.Temperature2mMin[dateIndex];
            int precipProb = 0;
            if (dateIndex < forecastData.Daily.PrecipitationProbabilityMax.Count)
            {
                precipProb = forecastData.Daily.PrecipitationProbabilityMax[dateIndex] ?? 0;
            }

            result.WeatherCode = code;
            result.MaxTemperature = maxTemp;
            result.MinTemperature = minTemp;
            result.PrecipitationProbability = precipProb;
            result.Category = GetWeatherCategory(code);

            var (descVi, descEn) = GetWeatherDescriptions(code);
            result.WeatherDescriptionVi = descVi;
            result.WeatherDescriptionEn = descEn;
            result.Success = true;
            return result;
        }
        catch (TaskCanceledException)
        {
            result.Success = false;
            result.ErrorMessage = "Yêu cầu tra cứu thời tiết quá thời gian (Timeout). Vui lòng thử lại!";
            return result;
        }
        catch (HttpRequestException ex)
        {
            result.Success = false;
            result.ErrorMessage = "Lỗi kết nối mạng: Không thể kết nối tới máy chủ dự báo thời tiết. " + ex.Message;
            return result;
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorMessage = "Đã xảy ra lỗi khi tra cứu thời tiết: " + ex.Message;
            return result;
        }
    }

    public static WeatherCategory GetWeatherCategory(int code)
    {
        return code switch
        {
            0 => WeatherCategory.Clear,
            1 or 2 or 3 => WeatherCategory.Cloudy,
            45 or 48 => WeatherCategory.Fog,
            >= 51 and <= 67 => WeatherCategory.Rain,
            >= 71 and <= 77 => WeatherCategory.Rain,
            >= 80 and <= 82 => WeatherCategory.Rain,
            >= 85 and <= 86 => WeatherCategory.Rain,
            >= 95 and <= 99 => WeatherCategory.Thunderstorm,
            _ => WeatherCategory.Cloudy
        };
    }

    public static (string Vi, string En) GetWeatherDescriptions(int code)
    {
        return code switch
        {
            0 => ("Trời quang đãng", "Clear sky"),
            1 => ("Hầu như không mây", "Mainly clear"),
            2 => ("Có mây rải rác", "Partly cloudy"),
            3 => ("Trời nhiều mây u ám", "Overcast"),
            45 => ("Sương mù", "Fog"),
            48 => ("Sương mù đọng sương", "Depositing rime fog"),
            51 => ("Mưa phùn nhẹ", "Light drizzle"),
            53 => ("Mưa phùn vừa", "Moderate drizzle"),
            55 => ("Mưa phùn nặng hạt", "Dense drizzle"),
            56 or 57 => ("Mưa phùn băng giá", "Freezing drizzle"),
            61 => ("Mưa nhỏ", "Slight rain"),
            63 => ("Mưa vừa", "Moderate rain"),
            65 => ("Mưa to", "Heavy rain"),
            66 or 67 => ("Mưa đá / băng", "Freezing rain"),
            71 or 73 or 75 or 77 => ("Tuyết rơi", "Snow fall"),
            80 => ("Mưa rào nhẹ", "Light rain showers"),
            81 => ("Mưa rào vừa", "Moderate rain showers"),
            82 => ("Mưa rào dữ dội", "Violent rain showers"),
            85 or 86 => ("Mưa tuyết rào", "Snow showers"),
            95 => ("Có dông sét", "Thunderstorm"),
            96 or 99 => ("Dông sét kèm mưa đá", "Thunderstorm with hail"),
            _ => ("Thời tiết bình thường", "Normal weather")
        };
    }
}
