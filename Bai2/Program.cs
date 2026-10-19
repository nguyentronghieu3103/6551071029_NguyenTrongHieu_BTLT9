using System;
using System.IO;
using System.Windows.Forms;
using Serilog;

namespace Bai2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 7. Cấu hình Serilog ghi log ra file
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    path: Path.Combine(logDirectory, "app-log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            Log.Information("Ứng dụng 'Quản lý nhà trọ' bắt đầu khởi động.");

            // 7. Đăng ký xử lý lỗi toàn cục: Application.SetUnhandledExceptionMode, Application.ThreadException, AppDomain.CurrentDomain.UnhandledException
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += (sender, e) =>
            {
                Log.Error(e.Exception, "Lỗi chưa bắt trên luồng UI (Application.ThreadException): {Message}", e.Exception.Message);
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Fatal(ex, "Lỗi nghiêm trọng miền ứng dụng (AppDomain.UnhandledException): {Message}", ex.Message);
                }
                else
                {
                    Log.Fatal("Lỗi không xác định miền ứng dụng: {Object}", e.ExceptionObject);
                }
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new FormKhachThue());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Lỗi nghiêm trọng làm dừng ứng dụng");
                MessageBox.Show("Đã xảy ra lỗi nghiêm trọng, ứng dụng cần đóng lại.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.Information("Ứng dụng kết thúc.");
                Log.CloseAndFlush();
            }
        }
    }
}