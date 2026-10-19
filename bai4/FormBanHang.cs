using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using bai4.Models;

namespace bai4;

public partial class FormBanHang : Form
{
    private readonly BindingList<CartItem> _gioHang = new();
    private readonly CultureInfo _culture = new("vi-VN");
    private int _currentPendingMaHd = 0;

    public FormBanHang()
    {
        InitializeComponent();
    }

    private void FormBanHang_Load(object sender, EventArgs e)
    {
        InitGridView();
        LoadThongTinTaiKhoan();
        LoadDanhMuc();
    }

    private void InitGridView()
    {
        dgvGioHang.AutoGenerateColumns = false;
        dgvGioHang.Columns.Clear();

        dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "TenMon",
            HeaderText = "Tên món",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });

        dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "SoLuong",
            HeaderText = "SL",
            Width = 60,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        });

        dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "DonGia",
            HeaderText = "Đơn giá",
            Width = 100,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "#,##0",
                Alignment = DataGridViewContentAlignment.MiddleRight
            }
        });

        dgvGioHang.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ThanhTien",
            HeaderText = "Thành tiền",
            Width = 110,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "#,##0",
                Alignment = DataGridViewContentAlignment.MiddleRight
            }
        });

        dgvGioHang.DataSource = _gioHang;
        UpdateTongTien();
    }

    private void LoadThongTinTaiKhoan()
    {
        var pay = AppConfig.Payment;
        lblThongTinTK.Text = $"Chủ TK: {pay.AccountName}\nNgân hàng: {pay.BankId.ToUpper()}\nSTK: {pay.AccountNo}";
    }

    public void LoadDanhMuc()
    {
        using var context = new QL_TraSuaContext();
        var danhMucs = context.DanhMucMons
            .OrderBy(d => d.TenDm)
            .ToList();

        cboDanhMuc.DataSource = danhMucs;
        cboDanhMuc.DisplayMember = "TenDm";
        cboDanhMuc.ValueMember = "MaDm";

        if (danhMucs.Count > 0)
        {
            cboDanhMuc.SelectedIndex = 0;
            if (cboDanhMuc.SelectedValue is int maDm)
            {
                LoadMonTheoDanhMuc(maDm);
            }
        }
    }

    private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboDanhMuc.SelectedValue is int maDm)
        {
            LoadMonTheoDanhMuc(maDm);
        }
    }

    private void LoadMonTheoDanhMuc(int maDm)
    {
        using var context = new QL_TraSuaContext();
        var mons = context.MonUongs
            .Where(m => m.MaDm == maDm && m.DangBan == true)
            .OrderBy(m => m.TenMon)
            .Select(m => new MonUongDisplayItem
            {
                MaMon = m.MaMon,
                TenMon = m.TenMon,
                GiaBan = m.GiaBan,
                Culture = _culture
            })
            .ToList();

        lstMonUong.DataSource = mons;
    }

    private void btnThemVaoDon_Click(object sender, EventArgs e)
    {
        if (lstMonUong.SelectedItem is not MonUongDisplayItem selectedMon)
        {
            MessageBox.Show("Vui lòng chọn món cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int soLy = (int)nudSoLy.Value;
        if (soLy <= 0)
        {
            MessageBox.Show("Số ly phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var existingItem = _gioHang.FirstOrDefault(x => x.MaMon == selectedMon.MaMon);
        if (existingItem != null)
        {
            existingItem.SoLuong += soLy;
            dgvGioHang.Refresh();
        }
        else
        {
            _gioHang.Add(new CartItem
            {
                MaMon = selectedMon.MaMon,
                TenMon = selectedMon.TenMon,
                SoLuong = soLy,
                DonGia = selectedMon.GiaBan
            });
        }

        nudSoLy.Value = 1;
        UpdateTongTien();
    }

    private void btnXoaDong_Click(object sender, EventArgs e)
    {
        if (dgvGioHang.CurrentRow == null || dgvGioHang.CurrentRow.Index < 0)
        {
            MessageBox.Show("Vui lòng chọn dòng cần xóa khỏi đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var item = dgvGioHang.CurrentRow.DataBoundItem as CartItem;
        if (item != null)
        {
            _gioHang.Remove(item);
            UpdateTongTien();
        }
    }

    private void UpdateTongTien()
    {
        decimal tongTien = _gioHang.Sum(x => x.ThanhTien);
        lblTongTien.Text = $"Tổng tiền: {tongTien.ToString("N0", _culture)} đ";

        // Cập nhật nhãn số tiền ở cột thanh toán nếu đang có đơn
        if (tongTien > 0)
        {
            lblSoTien.Text = $"Số tiền:    {tongTien.ToString("N0", _culture)} đ";
        }
        else
        {
            lblSoTien.Text = "Số tiền:    0 đ";
            lblNoiDung.Text = "Nội dung:";
            picQR.Image?.Dispose();
            picQR.Image = null;
        }
    }

    private async void btnChuyenKhoan_Click(object sender, EventArgs e)
    {
        if (_gioHang.Count == 0)
        {
            MessageBox.Show("Giỏ hàng đang trống! Vui lòng chọn món trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        decimal tongTien = _gioHang.Sum(x => x.ThanhTien);
        if (tongTien <= 0)
        {
            MessageBox.Show("Tổng tiền đơn hàng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (var context = new QL_TraSuaContext())
        {
            _currentPendingMaHd = (context.HoaDons.Max(h => (int?)h.MaHd) ?? 0) + 1;
        }

        string noiDung = $"TRASUA HD{_currentPendingMaHd}";
        lblSoTien.Text = $"Số tiền:    {tongTien.ToString("N0", _culture)} đ";
        lblNoiDung.Text = $"Nội dung:  {noiDung}";

        var pay = AppConfig.Payment;
        lblThongTinTK.Text = $"Chủ TK: {pay.AccountName}\nNgân hàng: {pay.BankId.ToUpper()}\nSTK: {pay.AccountNo}";

        // Ghi log Serilog (mã HD, số tiền - không ghi số tài khoản đầy đủ)
        Log.Information("Tạo mã QR VietQR cho đơn hàng {MaHD} với số tiền {TongTien:N0} đ", _currentPendingMaHd, tongTien);

        string template = string.IsNullOrWhiteSpace(pay.Template) ? "compact2" : pay.Template;
        string amountStr = ((long)tongTien).ToString();
        string url = $"https://img.vietqr.io/image/{pay.BankId}-{pay.AccountNo}-{template}.png?amount={amountStr}&addInfo={Uri.EscapeDataString(noiDung)}&accountName={Uri.EscapeDataString(pay.AccountName)}";

        try
        {
            Cursor = Cursors.WaitCursor;
            btnChuyenKhoan.Enabled = false;

            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(10);
            byte[] bytes = await httpClient.GetByteArrayAsync(url);

            using var ms = new MemoryStream(bytes);
            picQR.Image?.Dispose();
            picQR.Image = Image.FromStream(ms);
        }
        catch (Exception ex)
        {
            // Ghi log Serilog lỗi khi tải ảnh QR thất bại
            Log.Error(ex, "Lỗi khi tải ảnh QR VietQR cho đơn hàng {MaHD}", _currentPendingMaHd);

            picQR.Image?.Dispose();
            picQR.Image = null;

            MessageBox.Show(
                $"Không thể tải mã QR do lỗi kết nối mạng!\n\nThông tin chuyển khoản thủ công:\n• Ngân hàng: {pay.BankId}\n• STK: {pay.AccountNo}\n• Chủ TK: {pay.AccountName}\n• Số tiền: {tongTien.ToString("N0", _culture)} đ\n• Nội dung: {noiDung}\n\nQuý khách có thể chuyển khoản bằng tay hoặc bấm nút 'Tiền mặt' để chuyển sang thanh toán tiền mặt.",
                "Lỗi kết nối mã QR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        finally
        {
            Cursor = Cursors.Default;
            btnChuyenKhoan.Enabled = true;
        }
    }

    private void btnDaNhanTien_Click(object sender, EventArgs e)
    {
        if (_gioHang.Count == 0)
        {
            MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        decimal tongTien = _gioHang.Sum(x => x.ThanhTien);

        var confirm = MessageBox.Show(
            $"Xác nhận đã nhận đủ số tiền {tongTien.ToString("N0", _culture)} đ qua chuyển khoản ngân hàng?",
            "Xác nhận thanh toán",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        try
        {
            using var context = new QL_TraSuaContext();

            var hoaDon = new HoaDon
            {
                NgayLap = DateTime.Now,
                TongTien = tongTien,
                HinhThucTt = "Chuyển khoản",
                DaThanhToan = true
            };

            foreach (var item in _gioHang)
            {
                hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
                {
                    MaMon = item.MaMon,
                    SoLy = item.SoLuong,
                    DonGia = item.DonGia
                });
            }

            // Lưu HoaDon + ChiTietHoaDon trong cùng một lần SaveChanges
            context.HoaDons.Add(hoaDon);
            context.SaveChanges();

            Log.Information("Lưu thành công hóa đơn HD{MaHD} hình thức Chuyển khoản, tổng tiền {TongTien:N0} đ", hoaDon.MaHd, tongTien);

            MessageBox.Show(
                $"Đã lưu hóa đơn HD{hoaDon.MaHd} thành công!\nTổng tiền: {tongTien.ToString("N0", _culture)} đ",
                "Thanh toán thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ResetDonHang();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi lưu hóa đơn chuyển khoản");
            MessageBox.Show($"Đã xảy ra lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnTienMat_Click(object sender, EventArgs e)
    {
        if (_gioHang.Count == 0)
        {
            MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        decimal tongTien = _gioHang.Sum(x => x.ThanhTien);

        var confirm = MessageBox.Show(
            $"Xác nhận thanh toán TIỀN MẶT số tiền {tongTien.ToString("N0", _culture)} đ?",
            "Xác nhận thanh toán tiền mặt",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        try
        {
            using var context = new QL_TraSuaContext();

            var hoaDon = new HoaDon
            {
                NgayLap = DateTime.Now,
                TongTien = tongTien,
                HinhThucTt = "Tiền mặt",
                DaThanhToan = true
            };

            foreach (var item in _gioHang)
            {
                hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
                {
                    MaMon = item.MaMon,
                    SoLy = item.SoLuong,
                    DonGia = item.DonGia
                });
            }

            // Lưu HoaDon + ChiTietHoaDon trong cùng một lần SaveChanges
            context.HoaDons.Add(hoaDon);
            context.SaveChanges();

            Log.Information("Lưu thành công hóa đơn HD{MaHD} hình thức Tiền mặt, tổng tiền {TongTien:N0} đ", hoaDon.MaHd, tongTien);

            MessageBox.Show(
                $"Đã lưu hóa đơn HD{hoaDon.MaHd} thành công!\nHình thức: Tiền mặt\nTổng tiền: {tongTien.ToString("N0", _culture)} đ",
                "Thanh toán thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ResetDonHang();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi lưu hóa đơn tiền mặt");
            MessageBox.Show($"Đã xảy ra lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ResetDonHang()
    {
        _gioHang.Clear();
        _currentPendingMaHd = 0;
        picQR.Image?.Dispose();
        picQR.Image = null;
        lblSoTien.Text = "Số tiền:    0 đ";
        lblNoiDung.Text = "Nội dung:";
        nudSoLy.Value = 1;
        UpdateTongTien();
    }

    private void menuThucDon_Click(object sender, EventArgs e)
    {
        using var form = new FormThucDon();
        form.ShowDialog(this);
        // Sau khi đóng form thực đơn, làm mới lại danh mục và món
        LoadDanhMuc();
    }

    private void menuHoaDon_Click(object sender, EventArgs e)
    {
        using var form = new FormHoaDon();
        form.ShowDialog(this);
    }

    private void menuCaiDat_Click(object sender, EventArgs e)
    {
        var pay = AppConfig.Payment;
        MessageBox.Show(
            $"CẤU HÌNH THANH TOÁN (từ appsettings.json):\n\n" +
            $"• Tên quán: {pay.StoreName}\n" +
            $"• Ngân hàng: {pay.BankId}\n" +
            $"• Số tài khoản: {pay.AccountNo}\n" +
            $"• Tên chủ tài khoản: {pay.AccountName}\n" +
            $"• Giao diện VietQR: {pay.Template}\n\n" +
            $"Bạn có thể sửa thông tin trên trong file appsettings.json mà không cần sửa mã nguồn.",
            "Cấu hình thanh toán",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}

public class MonUongDisplayItem
{
    public int MaMon { get; set; }
    public string TenMon { get; set; } = string.Empty;
    public decimal GiaBan { get; set; }
    public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

    public override string ToString()
    {
        return $"{TenMon} - {GiaBan.ToString("N0", Culture)}";
    }
}
