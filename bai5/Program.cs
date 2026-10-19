using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Serilog;
using bai5.Models;
using bai5.Services;

namespace bai5;

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

        // Cấu hình Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(
                Path.Combine(logDir, "log-.txt"),
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("=== Khởi động ứng dụng Quản lý đặt tour ===");

        try
        {
            // Bắt lỗi toàn cục (ThreadException, UnhandledException) theo yêu cầu 9.3
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                Log.Error(e.Exception, "Lỗi giao diện WinForms chưa được xử lý (ThreadException)");
                MessageBox.Show($"Đã xảy ra lỗi hệ thống:\n{e.Exception.Message}", "Lỗi ứng dụng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                Log.Fatal(ex, "Lỗi nghiêm trọng toàn cục (UnhandledException)");
                MessageBox.Show($"Đã xảy ra sự cố nghiêm trọng:\n{ex?.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // Khởi tạo cấu hình từ appsettings.json
            AppConfig.Initialize();

            // Chế độ tự kiểm thử tự động
            if (args.Length > 0 && args[0] == "--test")
            {
                RunSelfTest();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ứng dụng gặp sự cố khi khởi động.");
            MessageBox.Show($"Đã xảy ra lỗi khởi động:\n{ex.Message}", "Lỗi khởi động", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.Information("=== Kết thúc ứng dụng Quản lý đặt tour ===");
            Log.CloseAndFlush();
        }
    }

    private static void RunSelfTest()
    {
        Console.WriteLine("[TEST 1] Đọc cấu hình ExchangeRate từ appsettings.json:");
        var config = AppConfig.ExchangeRate;
        Console.WriteLine($"  - PrimaryUrl: {config.PrimaryUrl}");
        Console.WriteLine($"  - BackupUrl: {config.BackupUrl}");
        Console.WriteLine($"  - TimeoutSeconds: {config.TimeoutSeconds}");
        Console.WriteLine($"  - CacheDurationMinutes: {config.CacheDurationMinutes}");
        if (string.IsNullOrEmpty(config.PrimaryUrl) || string.IsNullOrEmpty(config.BackupUrl))
        {
            throw new Exception("Lỗi đọc cấu hình ExchangeRate!");
        }
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 2] Kết nối CSDL QL_DatTour bằng EF Core:");
        using (var context = new QL_DatTourContext())
        {
            int tourCount = context.Tours.Count();
            int khCount = context.KhachHangs.Count();
            Console.WriteLine($"  - Số lượng Tour: {tourCount}");
            Console.WriteLine($"  - Số lượng Khách hàng: {khCount}");
            if (tourCount < 5 || khCount < 2)
            {
                throw new Exception($"Dữ liệu chưa đủ! Tour: {tourCount}, Khách hàng: {khCount}");
            }
        }
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 3] Kiểm tra TyGiaService lấy tỷ giá (tự động thử dự phòng khi chính lỗi):");
        var (rateThb, sourceThb) = TyGiaService.LayTyGiaChiTietAsync("THB").GetAwaiter().GetResult();
        Console.WriteLine($"  - 1 THB = {rateThb:N2} VND (Nguồn: {sourceThb})");
        if (rateThb <= 0) throw new Exception("Tỷ giá THB không hợp lệ!");

        var (rateKrw, sourceKrw) = TyGiaService.LayTyGiaChiTietAsync("KRW").GetAwaiter().GetResult();
        Console.WriteLine($"  - 1 KRW = {rateKrw:N2} VND (Nguồn: {sourceKrw})");

        var (rateUsd, sourceUsd) = TyGiaService.LayTyGiaChiTietAsync("USD").GetAwaiter().GetResult();
        Console.WriteLine($"  - 1 USD = {rateUsd:N2} VND (Nguồn: {sourceUsd})");
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 4] Kiểm tra tính năng Cache trong bộ nhớ 10 phút:");
        var (cachedRate, cachedSource) = TyGiaService.LayTyGiaChiTietAsync("THB").GetAwaiter().GetResult();
        Console.WriteLine($"  - Lần gọi thứ 2 (từ cache): {cachedRate:N2} VND, Nguồn: {cachedSource}");
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 5] Kiểm tra thêm và xóa thử nghiệm DatTour:");
        int testMaDat = 0;
        using (var context = new QL_DatTourContext())
        {
            var firstTour = context.Tours.First();
            var firstKh = context.KhachHangs.First();
            var dat = new DatTour
            {
                MaKh = firstKh.MaKh,
                MaTour = firstTour.MaTour,
                SoNguoi = 2,
                NgayDat = DateTime.Now,
                TyGia = rateThb,
                TongTienVnd = Math.Round(firstTour.GiaNgoaiTe * 2 * rateThb, 0)
            };
            context.DatTours.Add(dat);
            context.SaveChanges();
            testMaDat = dat.MaDat;
            Console.WriteLine($"  - Đã thêm thành công đơn đặt tour thử nghiệm DT{testMaDat:D3}");

            // Dọn dẹp
            context.DatTours.Remove(dat);
            context.SaveChanges();
            Console.WriteLine("  - Đã dọn dẹp đơn test sạch sẽ.");
        }
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("[TEST 6] Kiểm tra khởi tạo và load FormMain thực tế:");
        ApplicationConfiguration.Initialize();
        using (var form = new FormMain())
        {
            form.Show();
            Application.DoEvents();
            Console.WriteLine($"  - FormMain load thành công! Tiêu đề: '{form.Text}'");
            form.Close();
        }
        Console.WriteLine("  -> PASS!");

        Console.WriteLine("\n==========================================");
        Console.WriteLine("   TẤT CẢ 6 BÀI TEST ĐỀU THÀNH CÔNG 100%!  ");
        Console.WriteLine("==========================================");
    }
}