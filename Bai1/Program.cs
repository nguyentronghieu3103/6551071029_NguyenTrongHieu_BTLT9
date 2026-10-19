using System;
using System.IO;
using System.Windows.Forms;
using Serilog;
using Bai1.Configuration;

namespace Bai1;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // 1. Tải cấu hình từ appsettings.json và appsettings.{DOTNET_ENVIRONMENT}.json
        ConfigurationHelper.LoadConfiguration();

        // 2. Cấu hình Serilog ghi log theo ngày vào thư mục Logs cạnh file .exe
        string logsDir = Path.Combine(AppContext.BaseDirectory, "Logs");
        if (!Directory.Exists(logsDir))
        {
            Directory.CreateDirectory(logsDir);
        }

        string logPath = Path.Combine(logsDir, "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(
                path: logPath,
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("Ứng dụng Sổ chi tiêu cá nhân khởi động.");

        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormChiTieu());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ứng dụng gặp sự cố nghiêm trọng không xử lý được!");
            MessageBox.Show("Ứng dụng gặp sự cố: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.Information("Ứng dụng Sổ chi tiêu cá nhân kết thúc.");
            Log.CloseAndFlush();
        }
    }
}