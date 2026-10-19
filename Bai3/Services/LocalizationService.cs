using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace Bai3.Services;

public class UserSettings
{
    public string Language { get; set; } = "vi-VN";
}

public static class LocalizationService
{
    public const string Vietnamese = "vi-VN";
    public const string English = "en-US";

    private static string _currentLanguage = Vietnamese;
    private static CultureInfo _currentCulture = new CultureInfo("vi-VN");

    public static string CurrentLanguage => _currentLanguage;
    public static CultureInfo CurrentCulture => _currentCulture;
    public static bool IsVietnamese => _currentLanguage == Vietnamese;

    private static readonly string SettingsDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "KeHoachDaNgoai");

    private static readonly string SettingsFilePath = Path.Combine(SettingsDirectory, "usersettings.json");
    private static readonly string DirectSettingsFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "usersettings.json");

    private static readonly Dictionary<string, (string Vi, string En)> Strings = new()
    {
        // Header & Form
        { "AppTitle", ("Kế hoạch dã ngoại cuối tuần", "Weekend Picnic Planner") },
        { "Language", ("Ngôn ngữ", "Language") },

        // Input Group
        { "TripInfo", ("Thông tin chuyến đi", "Trip Information") },
        { "TripName", ("Tên chuyến", "Trip Name") },
        { "Destination", ("Địa điểm", "Destination") },
        { "DepartureDate", ("Ngày đi", "Departure Date") },
        { "PeopleCount", ("Số người", "People") },
        { "Budget", ("Ngân sách", "Budget") },
        { "Transport", ("Phương tiện", "Transport") },
        { "IsCompleted", ("Đã hoàn thành", "Completed") },
        { "Notes", ("Ghi chú", "Notes") },

        // Buttons
        { "BtnAdd", ("Thêm", "Add") },
        { "BtnEdit", ("Sửa", "Edit") },
        { "BtnDelete", ("Xóa", "Delete") },
        { "BtnReset", ("Làm mới", "Reset") },
        { "BtnCheckWeather", ("Xem thời tiết", "Check Weather") },
        { "BtnSearch", ("Tìm", "Search") },
        { "BtnShowAll", ("Tất cả", "Show All") },

        // Search & Filter
        { "SearchPlaceholder", ("Tìm theo tên hoặc địa điểm...", "Search by name or destination...") },
        { "FilterUncompleted", ("Chỉ hiện chuyến chưa hoàn thành", "Show only uncompleted trips") },
        { "FilterByDate", ("Lọc theo ngày đi", "Filter by date") },
        { "FromDate", ("Từ", "From") },
        { "ToDate", ("Đến", "To") },

        // Grid columns
        { "ColId", ("Mã", "ID") },
        { "ColTripName", ("Tên chuyến", "Trip Name") },
        { "ColDestination", ("Địa điểm", "Destination") },
        { "ColDate", ("Ngày đi", "Date") },
        { "ColPeople", ("Số người", "People") },
        { "ColBudget", ("Ngân sách", "Budget") },
        { "ColTransport", ("Phương tiện", "Transport") },
        { "ColCompleted", ("Hoàn thành", "Completed") },
        { "ColNotes", ("Ghi chú", "Notes") },

        // Weather
        { "WeatherTitle", ("Dự báo thời tiết ngày {0} - {1}", "Weather Forecast for {0} - {1}") },
        { "WeatherEmpty", ("Chưa chọn chuyến đi để xem thời tiết", "No trip selected to view weather") },
        { "WeatherBeyond", ("Chưa có dữ liệu dự báo (chỉ hỗ trợ tối đa 16 ngày tới)", "No forecast data available (supports up to 16 days ahead)") },
        { "WeatherLoading", ("Đang tải dự báo thời tiết...", "Loading weather forecast...") },
        { "Temperature", ("Nhiệt độ: {0:F0}°C - {1:F0}°C", "Temperature: {0:F0}°C - {1:F0}°C") },
        { "RainProbability", ("Khả năng mưa: {0}%", "Rain probability: {0}%") },
        { "RainWarning", ("Nên mang áo mưa hoặc cân nhắc dời lịch", "Bring a raincoat or consider rescheduling") },
        { "GoodWeather", ("Thời tiết thuận lợi cho chuyến dã ngoại!", "Great weather for your picnic!") },

        // Dialogs & Messages
        { "MsgSelectTripToEdit", ("Vui lòng chọn một chuyến đi để sửa!", "Please select a trip to edit!") },
        { "MsgSelectTripToDelete", ("Vui lòng chọn một chuyến đi để xóa!", "Please select a trip to delete!") },
        { "MsgConfirmDelete", ("Bạn có chắc chắn muốn xóa chuyến đi \"{0}\" không?", "Are you sure you want to delete trip \"{0}\"?") },
        { "MsgConfirmTitle", ("Xác nhận xóa", "Confirm Delete") },
        { "MsgAddSuccess", ("Thêm chuyến đi mới thành công!", "Trip added successfully!") },
        { "MsgEditSuccess", ("Cập nhật chuyến đi thành công!", "Trip updated successfully!") },
        { "MsgDeleteSuccess", ("Đã xóa chuyến đi thành công!", "Trip deleted successfully!") },
        { "MsgNameRequired", ("Vui lòng nhập tên chuyến đi!", "Please enter trip name!") },
        { "MsgDestinationRequired", ("Vui lòng nhập địa điểm!", "Please enter destination!") },
        { "MsgDateInvalid", ("Ngày đi không được nhỏ hơn ngày hôm nay khi thêm mới!", "Departure date cannot be earlier than today for a new trip!") },
        { "MsgPeopleInvalid", ("Số người phải lớn hơn hoặc bằng 1!", "Number of people must be at least 1!") },
        { "MsgBudgetInvalid", ("Ngân sách phải lớn hơn hoặc bằng 0!", "Budget must be greater than or equal to 0!") },
        { "MsgLocationNotFound", ("Không tìm thấy địa điểm \"{0}\". Gợi ý: Thử tên không dấu như \"{1}\".", "Location \"{0}\" not found. Suggestion: Try unaccented name like \"{1}\".") },
        { "MsgNetworkError", ("Không thể kết nối đến máy chủ thời tiết. Vui lòng kiểm tra lại kết nối mạng.", "Cannot connect to weather server. Please check your internet connection.") },
        { "MsgSuccessTitle", ("Thông báo", "Notification") },
        { "MsgErrorTitle", ("Lỗi", "Error") },
        { "MsgWarningTitle", ("Cảnh báo", "Warning") }
    };

    public static string Get(string key, params object[] args)
    {
        if (Strings.TryGetValue(key, out var pair))
        {
            string template = IsVietnamese ? pair.Vi : pair.En;
            if (args != null && args.Length > 0)
            {
                return string.Format(_currentCulture, template, args);
            }
            return template;
        }
        return key;
    }

    public static void SetLanguage(string lang)
    {
        if (lang != Vietnamese && lang != English)
        {
            lang = Vietnamese;
        }

        _currentLanguage = lang;
        _currentCulture = new CultureInfo(lang);

        SaveSettings();
    }

    public static void LoadSettings()
    {
        try
        {
            string? filePathToRead = null;
            if (File.Exists(DirectSettingsFilePath))
            {
                filePathToRead = DirectSettingsFilePath;
            }
            else if (File.Exists(SettingsFilePath))
            {
                filePathToRead = SettingsFilePath;
            }

            if (filePathToRead != null)
            {
                string json = File.ReadAllText(filePathToRead);
                var settings = JsonSerializer.Deserialize<UserSettings>(json);
                if (settings != null && !string.IsNullOrWhiteSpace(settings.Language))
                {
                    _currentLanguage = settings.Language == English ? English : Vietnamese;
                    _currentCulture = new CultureInfo(_currentLanguage);
                    return;
                }
            }
        }
        catch
        {
            // Fallback default
        }

        _currentLanguage = Vietnamese;
        _currentCulture = new CultureInfo(Vietnamese);
    }

    public static void SaveSettings()
    {
        try
        {
            var settings = new UserSettings { Language = _currentLanguage };
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });

            // Write to %LocalAppData%\usersettings.json directly
            File.WriteAllText(DirectSettingsFilePath, json);

            // Also write to %LocalAppData%\KeHoachDaNgoai\usersettings.json
            if (!Directory.Exists(SettingsDirectory))
            {
                Directory.CreateDirectory(SettingsDirectory);
            }
            File.WriteAllText(SettingsFilePath, json);
        }
        catch
        {
            // Silently ignore save errors
        }
    }

    public static string FormatCurrency(decimal amount)
    {
        if (IsVietnamese)
        {
            return amount.ToString("#,##0", _currentCulture);
        }
        return amount.ToString("N0", _currentCulture);
    }

    public static string FormatDate(DateOnly date)
    {
        if (IsVietnamese)
        {
            return date.ToString("dd/MM/yyyy", _currentCulture);
        }
        return date.ToString("MM/dd/yyyy", _currentCulture);
    }

    public static string[] GetVehicleList()
    {
        if (IsVietnamese)
        {
            return new[] { "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa" };
        }
        return new[] { "Motorbike", "Car", "Bus", "Train" };
    }

    public static string TranslateVehicleToDatabase(string displayVehicle)
    {
        return displayVehicle switch
        {
            "Motorbike" => "Xe máy",
            "Car" => "Ô tô",
            "Bus" => "Xe khách",
            "Train" => "Tàu hỏa",
            _ => displayVehicle
        };
    }

    public static string TranslateVehicleFromDatabase(string dbVehicle)
    {
        if (string.IsNullOrWhiteSpace(dbVehicle)) return string.Empty;

        // Normalize accents if needed
        string norm = dbVehicle.Trim();
        if (norm.Equals("O to", StringComparison.OrdinalIgnoreCase) || norm.Equals("Ô tô", StringComparison.OrdinalIgnoreCase))
            norm = "Ô tô";

        if (!IsVietnamese)
        {
            return norm switch
            {
                "Xe máy" => "Motorbike",
                "Ô tô" => "Car",
                "Xe khách" => "Bus",
                "Tàu hỏa" => "Train",
                _ => dbVehicle
            };
        }

        return norm;
    }
}
