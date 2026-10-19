using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Serilog;
using bai5.Models;
using bai5.Services;

namespace bai5;

public partial class FormMain : Form
{
    private readonly CultureInfo _culture = new("vi-VN");
    private int _selectedMaTour = 0;
    private int _selectedMaKh = 0;
    private decimal _currentTyGia = 1m;
    private Tour? _currentSelectedTour = null;

    public FormMain()
    {
        InitializeComponent();
    }

    private async void FormMain_Load(object sender, EventArgs e)
    {
        // Hiển thị phiên bản trên tiêu đề theo yêu cầu đề bài
        Text = $"Quản lý đặt tour - {AppConfig.StoreName} v{AppConfig.Version}";

        LoadNgoaiTeComboBox();
        LoadThangKhoiHanhComboBox();

        LoadDanhSachTour();
        LoadDanhSachKhachHang();
        LoadCombosDatTour();
        LoadDanhSachDatTour();

        if (cboTour.Items.Count > 0)
        {
            cboTour.SelectedIndex = 0;
            await CapNhatThongTinTourVaTyGia();
        }
    }

    private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabMain.SelectedTab == tabTour)
        {
            LoadDanhSachTour();
        }
        else if (tabMain.SelectedTab == tabKhachHang)
        {
            LoadDanhSachKhachHang();
        }
        else if (tabMain.SelectedTab == tabDatTour)
        {
            LoadCombosDatTour();
            LoadDanhSachDatTour();
        }
    }

    #region Tab 1: Tour CRUD & Tìm kiếm

    private void LoadNgoaiTeComboBox()
    {
        if (cboNgoaiTe.Items.Count > 0)
        {
            cboNgoaiTe.SelectedIndex = 0;
        }
    }

    private void LoadDanhSachTour()
    {
        using var context = new QL_DatTourContext();

        var query = context.Tours.Include(t => t.DatTours).AsQueryable();

        string keyword = txtTimTour.Text.Trim();
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(t => t.TenTour.Contains(keyword) || t.DiemDen.Contains(keyword));
        }

        var list = query
            .OrderBy(t => t.TenTour)
            .Select(t => new
            {
                t.MaTour,
                t.TenTour,
                t.DiemDen,
                NgoaiTe = t.NgoaiTe.Trim(),
                t.GiaNgoaiTe,
                NgayKhoiHanh = t.NgayKhoiHanh.ToString("dd/MM/yyyy"),
                t.SoChoToiDa,
                DaDat = t.DatTours.Sum(d => d.SoNguoi),
                ConLai = t.SoChoToiDa - t.DatTours.Sum(d => d.SoNguoi),
                RawNgay = t.NgayKhoiHanh
            })
            .ToList();

        dgvTour.DataSource = list;

        // Định dạng cột
        if (dgvTour.Columns["MaTour"] is { } colMa) { colMa.HeaderText = "Mã"; colMa.Width = 60; }
        if (dgvTour.Columns["TenTour"] is { } colTen) { colTen.HeaderText = "Tên tour"; colTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
        if (dgvTour.Columns["DiemDen"] is { } colDiem) { colDiem.HeaderText = "Điểm đến"; colDiem.Width = 120; }
        if (dgvTour.Columns["NgoaiTe"] is { } colNt) { colNt.HeaderText = "Ngoại tệ"; colNt.Width = 80; }
        if (dgvTour.Columns["GiaNgoaiTe"] is { } colGia)
        {
            colGia.HeaderText = "Giá ngoại tệ";
            colGia.DefaultCellStyle.Format = "#,##0.00";
            colGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGia.Width = 110;
        }
        if (dgvTour.Columns["NgayKhoiHanh"] is { } colNgay) { colNgay.HeaderText = "Khởi hành"; colNgay.Width = 100; }
        if (dgvTour.Columns["SoChoToiDa"] is { } colMax)
        {
            colMax.HeaderText = "Chỗ tối đa";
            colMax.Width = 85;
            colMax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        if (dgvTour.Columns["DaDat"] is { } colDaDat)
        {
            colDaDat.HeaderText = "Đã đặt";
            colDaDat.Width = 75;
            colDaDat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        if (dgvTour.Columns["ConLai"] is { } colConLai)
        {
            colConLai.HeaderText = "Còn lại";
            colConLai.Width = 75;
            colConLai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        if (dgvTour.Columns["RawNgay"] is { } colRaw) { colRaw.Visible = false; }
    }

    private void dgvTour_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvTour.Rows.Count) return;

        var row = dgvTour.Rows[e.RowIndex];
        _selectedMaTour = Convert.ToInt32(row.Cells["MaTour"].Value);
        txtTenTour.Text = row.Cells["TenTour"].Value?.ToString() ?? "";
        txtDiemDen.Text = row.Cells["DiemDen"].Value?.ToString() ?? "";
        cboNgoaiTe.SelectedItem = row.Cells["NgoaiTe"].Value?.ToString() ?? "USD";
        nudGiaNgoaiTe.Value = Convert.ToDecimal(row.Cells["GiaNgoaiTe"].Value);

        if (row.Cells["RawNgay"].Value is DateOnly d)
        {
            dtpNgayKhoiHanh.Value = d.ToDateTime(TimeOnly.MinValue);
        }

        nudSoChoToiDa.Value = Convert.ToDecimal(row.Cells["SoChoToiDa"].Value);
    }

    private void btnThemTour_Click(object sender, EventArgs e)
    {
        string tenTour = txtTenTour.Text.Trim();
        string diemDen = txtDiemDen.Text.Trim();
        string ngoaiTe = cboNgoaiTe.SelectedItem?.ToString() ?? "USD";

        if (string.IsNullOrEmpty(tenTour) || string.IsNullOrEmpty(diemDen))
        {
            MessageBox.Show("Vui lòng nhập tên tour và điểm đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var context = new QL_DatTourContext();
        var tour = new Tour
        {
            TenTour = tenTour,
            DiemDen = diemDen,
            NgoaiTe = ngoaiTe,
            GiaNgoaiTe = nudGiaNgoaiTe.Value,
            NgayKhoiHanh = DateOnly.FromDateTime(dtpNgayKhoiHanh.Value),
            SoChoToiDa = (int)nudSoChoToiDa.Value
        };

        context.Tours.Add(tour);
        context.SaveChanges();

        MessageBox.Show($"Đã thêm tour '{tenTour}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearTourInputs();
        LoadDanhSachTour();
    }

    private void btnSuaTour_Click(object sender, EventArgs e)
    {
        if (_selectedMaTour <= 0)
        {
            MessageBox.Show("Vui lòng chọn tour cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string tenTour = txtTenTour.Text.Trim();
        string diemDen = txtDiemDen.Text.Trim();
        string ngoaiTe = cboNgoaiTe.SelectedItem?.ToString() ?? "USD";

        if (string.IsNullOrEmpty(tenTour) || string.IsNullOrEmpty(diemDen))
        {
            MessageBox.Show("Vui lòng nhập tên tour và điểm đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var context = new QL_DatTourContext();
        var tour = context.Tours.Find(_selectedMaTour);
        if (tour == null)
        {
            MessageBox.Show("Không tìm thấy tour cần sửa trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        tour.TenTour = tenTour;
        tour.DiemDen = diemDen;
        tour.NgoaiTe = ngoaiTe;
        tour.GiaNgoaiTe = nudGiaNgoaiTe.Value;
        tour.NgayKhoiHanh = DateOnly.FromDateTime(dtpNgayKhoiHanh.Value);
        tour.SoChoToiDa = (int)nudSoChoToiDa.Value;

        context.SaveChanges();

        MessageBox.Show($"Đã cập nhật tour '{tenTour}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearTourInputs();
        LoadDanhSachTour();
    }

    private void btnXoaTour_Click(object sender, EventArgs e)
    {
        if (_selectedMaTour <= 0)
        {
            MessageBox.Show("Vui lòng chọn tour cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var context = new QL_DatTourContext();
        var tour = context.Tours.Find(_selectedMaTour);
        if (tour == null) return;

        bool hasBookings = context.DatTours.Any(d => d.MaTour == _selectedMaTour);
        if (hasBookings)
        {
            MessageBox.Show($"Tour '{tour.TenTour}' đã có khách đặt nên không thể xóa!", "Cảnh báo ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tour '{tour.TenTour}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        context.Tours.Remove(tour);
        context.SaveChanges();

        MessageBox.Show("Đã xóa tour thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearTourInputs();
        LoadDanhSachTour();
    }

    private void btnLamMoiTour_Click(object sender, EventArgs e)
    {
        ClearTourInputs();
    }

    private void ClearTourInputs()
    {
        _selectedMaTour = 0;
        txtTenTour.Clear();
        txtDiemDen.Clear();
        if (cboNgoaiTe.Items.Count > 0) cboNgoaiTe.SelectedIndex = 0;
        nudGiaNgoaiTe.Value = 0;
        dtpNgayKhoiHanh.Value = DateTime.Today;
        nudSoChoToiDa.Value = 20;
        dgvTour.ClearSelection();
    }

    private void txtTimTour_TextChanged(object sender, EventArgs e)
    {
        LoadDanhSachTour();
    }

    private void btnTimTour_Click(object sender, EventArgs e)
    {
        LoadDanhSachTour();
    }

    private void btnHienTatCaTour_Click(object sender, EventArgs e)
    {
        txtTimTour.Clear();
        LoadDanhSachTour();
    }

    #endregion

    #region Tab 2: Khách hàng CRUD & Tìm kiếm

    private void LoadDanhSachKhachHang()
    {
        using var context = new QL_DatTourContext();

        var query = context.KhachHangs.Include(k => k.DatTours).AsQueryable();

        string keyword = txtTimKH.Text.Trim();
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(k => k.HoTen.Contains(keyword) || k.SoDienThoai.Contains(keyword));
        }

        var list = query
            .OrderBy(k => k.HoTen)
            .Select(k => new
            {
                k.MaKh,
                k.HoTen,
                k.SoDienThoai,
                k.Email,
                SoDonDat = k.DatTours.Count
            })
            .ToList();

        dgvKhachHang.DataSource = list;

        if (dgvKhachHang.Columns["MaKh"] is { } colMa) { colMa.HeaderText = "Mã KH"; colMa.Width = 80; }
        if (dgvKhachHang.Columns["HoTen"] is { } colTen) { colTen.HeaderText = "Họ tên"; colTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
        if (dgvKhachHang.Columns["SoDienThoai"] is { } colSdt) { colSdt.HeaderText = "Số điện thoại"; colSdt.Width = 140; }
        if (dgvKhachHang.Columns["Email"] is { } colEmail) { colEmail.HeaderText = "Email"; colEmail.Width = 200; }
        if (dgvKhachHang.Columns["SoDonDat"] is { } colDon)
        {
            colDon.HeaderText = "Số đơn đặt";
            colDon.Width = 100;
            colDon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }

    private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvKhachHang.Rows.Count) return;

        var row = dgvKhachHang.Rows[e.RowIndex];
        _selectedMaKh = Convert.ToInt32(row.Cells["MaKh"].Value);
        txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
        txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
        txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
    }

    private void btnThemKH_Click(object sender, EventArgs e)
    {
        string hoTen = txtHoTen.Text.Trim();
        string sdt = txtSoDienThoai.Text.Trim();
        string email = txtEmail.Text.Trim();

        if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
        {
            MessageBox.Show("Vui lòng nhập họ tên và số điện thoại khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var context = new QL_DatTourContext();
        var kh = new KhachHang
        {
            HoTen = hoTen,
            SoDienThoai = sdt,
            Email = email
        };

        context.KhachHangs.Add(kh);
        context.SaveChanges();

        MessageBox.Show($"Đã thêm khách hàng '{hoTen}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearKHInputs();
        LoadDanhSachKhachHang();
    }

    private void btnSuaKH_Click(object sender, EventArgs e)
    {
        if (_selectedMaKh <= 0)
        {
            MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string hoTen = txtHoTen.Text.Trim();
        string sdt = txtSoDienThoai.Text.Trim();
        string email = txtEmail.Text.Trim();

        if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
        {
            MessageBox.Show("Vui lòng nhập họ tên và số điện thoại khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var context = new QL_DatTourContext();
        var kh = context.KhachHangs.Find(_selectedMaKh);
        if (kh == null) return;

        kh.HoTen = hoTen;
        kh.SoDienThoai = sdt;
        kh.Email = email;

        context.SaveChanges();

        MessageBox.Show($"Đã cập nhật khách hàng '{hoTen}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearKHInputs();
        LoadDanhSachKhachHang();
    }

    private void btnXoaKH_Click(object sender, EventArgs e)
    {
        if (_selectedMaKh <= 0)
        {
            MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var context = new QL_DatTourContext();
        var kh = context.KhachHangs.Find(_selectedMaKh);
        if (kh == null) return;

        bool hasBookings = context.DatTours.Any(d => d.MaKh == _selectedMaKh);
        if (hasBookings)
        {
            MessageBox.Show($"Khách hàng '{kh.HoTen}' đã có đơn đặt tour trong hệ thống nên không thể xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{kh.HoTen}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        context.KhachHangs.Remove(kh);
        context.SaveChanges();

        MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearKHInputs();
        LoadDanhSachKhachHang();
    }

    private void btnLamMoiKH_Click(object sender, EventArgs e)
    {
        ClearKHInputs();
    }

    private void ClearKHInputs()
    {
        _selectedMaKh = 0;
        txtHoTen.Clear();
        txtSoDienThoai.Clear();
        txtEmail.Clear();
        dgvKhachHang.ClearSelection();
    }

    private void txtTimKH_TextChanged(object sender, EventArgs e)
    {
        LoadDanhSachKhachHang();
    }

    private void btnTimKH_Click(object sender, EventArgs e)
    {
        LoadDanhSachKhachHang();
    }

    private void btnHienTatCaKH_Click(object sender, EventArgs e)
    {
        txtTimKH.Clear();
        LoadDanhSachKhachHang();
    }

    #endregion

    #region Tab 3: Đặt tour & API Tỷ giá & Báo cáo Doanh thu

    private void LoadCombosDatTour()
    {
        using var context = new QL_DatTourContext();

        // 1. Khách hàng
        var khachHangs = context.KhachHangs
            .OrderBy(k => k.HoTen)
            .Select(k => new
            {
                k.MaKh,
                Display = $"{k.HoTen} - {k.SoDienThoai}"
            })
            .ToList();

        cboKhachHang.DataSource = khachHangs;
        cboKhachHang.DisplayMember = "Display";
        cboKhachHang.ValueMember = "MaKh";

        // 2. Tour
        var tours = context.Tours
            .OrderBy(t => t.TenTour)
            .Select(t => new
            {
                t.MaTour,
                t.TenTour
            })
            .ToList();

        cboTour.DataSource = tours;
        cboTour.DisplayMember = "TenTour";
        cboTour.ValueMember = "MaTour";
    }

    private void LoadThangKhoiHanhComboBox()
    {
        var thangItems = new List<string> { "-- Tất cả tháng --" };
        for (int i = 1; i <= 12; i++)
        {
            thangItems.Add($"Tháng {i}");
        }
        cboThangKhoiHanh.DataSource = thangItems;
        cboThangKhoiHanh.SelectedIndex = 0;
    }

    private async void cboTour_SelectedIndexChanged(object sender, EventArgs e)
    {
        await CapNhatThongTinTourVaTyGia();
    }

    private async Task CapNhatThongTinTourVaTyGia()
    {
        if (cboTour.SelectedValue is not int maTour) return;

        using var context = new QL_DatTourContext();
        _currentSelectedTour = context.Tours
            .Include(t => t.DatTours)
            .FirstOrDefault(t => t.MaTour == maTour);

        if (_currentSelectedTour == null) return;

        // Tính số chỗ còn lại = SoChoToiDa trừ tổng số người đã đặt tour đó
        int bookedSeats = _currentSelectedTour.DatTours.Sum(d => d.SoNguoi);
        int remainingSeats = _currentSelectedTour.SoChoToiDa - bookedSeats;

        if (remainingSeats <= 0)
        {
            lblSoChoConLai.Text = $"(Hết chỗ: đã đặt {bookedSeats}/{_currentSelectedTour.SoChoToiDa} chỗ)";
            lblSoChoConLai.ForeColor = Color.Red;
            nudSoNguoi.Maximum = 0;
            nudSoNguoi.Value = 0;
            btnDatTour.Enabled = false;
        }
        else
        {
            lblSoChoConLai.Text = $"(Còn lại {remainingSeats} / {_currentSelectedTour.SoChoToiDa} chỗ)";
            lblSoChoConLai.ForeColor = Color.DimGray;
            nudSoNguoi.Maximum = remainingSeats;
            if (nudSoNguoi.Value <= 0 || nudSoNguoi.Value > remainingSeats)
            {
                nudSoNguoi.Value = 1;
            }
            btnDatTour.Enabled = true;
        }

        string ngoaiTe = _currentSelectedTour.NgoaiTe.Trim();
        lblGiaNguoi.Text = $"{_currentSelectedTour.GiaNgoaiTe.ToString("N0", _culture)} {ngoaiTe}";

        // Tự động gọi API lấy tỷ giá hiện hành (hoặc từ cache)
        try
        {
            lblTyGia.Text = "Đang lấy tỷ giá...";
            lblNguonTyGia.Text = "Đang kết nối...";

            var (rate, source) = await TyGiaService.LayTyGiaChiTietAsync(ngoaiTe);
            _currentTyGia = rate;

            lblTyGia.Text = $"1 {ngoaiTe} = {rate.ToString("N0", _culture)} VND";
            lblNguonTyGia.Text = $"Tỷ giá lấy từ: {source}";
        }
        catch (Exception ex)
        {
            _currentTyGia = 1m;
            lblTyGia.Text = "Lỗi lấy tỷ giá";
            lblNguonTyGia.Text = "Không có kết nối";
            MessageBox.Show(ex.Message, "Lỗi lấy tỷ giá ngoại tệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        TinhTongTienVND();
    }

    private void nudSoNguoi_ValueChanged(object sender, EventArgs e)
    {
        TinhTongTienVND();
    }

    private void TinhTongTienVND()
    {
        if (_currentSelectedTour == null || nudSoNguoi.Value <= 0)
        {
            lblTongTienVND.Text = "0 đ";
            return;
        }

        // Tổng tiền VND = giá/người * số người * tỷ giá
        decimal tongTien = Math.Round(_currentSelectedTour.GiaNgoaiTe * nudSoNguoi.Value * _currentTyGia, 0);
        lblTongTienVND.Text = $"{tongTien.ToString("N0", _culture)} đ";
    }

    private async void btnDatTour_Click(object sender, EventArgs e)
    {
        if (cboKhachHang.SelectedValue is not int maKh || cboTour.SelectedValue is not int maTour)
        {
            MessageBox.Show("Vui lòng chọn khách hàng và tour!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int soNguoi = (int)nudSoNguoi.Value;
        if (soNguoi <= 0)
        {
            MessageBox.Show("Số người đặt phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var context = new QL_DatTourContext();
        var tour = context.Tours.Include(t => t.DatTours).FirstOrDefault(t => t.MaTour == maTour);
        if (tour == null) return;

        int bookedSeats = tour.DatTours.Sum(d => d.SoNguoi);
        int remaining = tour.SoChoToiDa - bookedSeats;

        // Chặn đặt vượt số chỗ còn lại kèm thông báo
        if (soNguoi > remaining)
        {
            MessageBox.Show($"Số lượng khách đặt ({soNguoi} người) vượt quá số chỗ còn lại ({remaining} chỗ) của tour!", "Không đủ chỗ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        decimal tongTienVnd = Math.Round(tour.GiaNgoaiTe * soNguoi * _currentTyGia, 0);

        var datTour = new DatTour
        {
            MaKh = maKh,
            MaTour = maTour,
            SoNguoi = soNguoi,
            NgayDat = DateTime.Now,
            TyGia = _currentTyGia, // Lưu tỷ giá tại thời điểm đặt để đơn cũ không đổi theo thời gian
            TongTienVnd = tongTienVnd
        };

        context.DatTours.Add(datTour);
        context.SaveChanges();

        // Ghi log
        Log.Information("Lập đơn đặt tour DT{MaDat:D3} thành công: Khách #{MaKh}, Tour #{MaTour}, {SoNguoi} người, Tỷ giá {TyGia:N4}, Tổng tiền {TongTien:N0} VND",
            datTour.MaDat, maKh, maTour, soNguoi, _currentTyGia, tongTienVnd);

        MessageBox.Show($"Đặt tour thành công cho mã đơn DT{datTour.MaDat:D3}!\nTổng tiền: {tongTienVnd.ToString("N0", _culture)} đ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Làm mới dữ liệu
        LoadDanhSachDatTour();
        await CapNhatThongTinTourVaTyGia();
    }

    private void LoadDanhSachDatTour()
    {
        using var context = new QL_DatTourContext();

        var query = context.DatTours
            .Include(d => d.MaKhNavigation)
            .Include(d => d.MaTourNavigation)
            .AsQueryable();

        // Lọc theo từ khóa tìm kiếm (tên khách hoặc tên tour)
        string keyword = txtTimDatTour.Text.Trim();
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(d => d.MaKhNavigation.HoTen.Contains(keyword) || d.MaTourNavigation.TenTour.Contains(keyword));
        }

        // Lọc theo tháng khởi hành
        if (cboThangKhoiHanh.SelectedIndex > 0)
        {
            int selectedMonth = cboThangKhoiHanh.SelectedIndex;
            query = query.Where(d => d.MaTourNavigation.NgayKhoiHanh.Month == selectedMonth);
        }

        var list = query
            .OrderByDescending(d => d.NgayDat)
            .Select(d => new
            {
                MaHienThi = $"DT{d.MaDat:D3}",
                KhachHang = d.MaKhNavigation.HoTen,
                Tour = d.MaTourNavigation.TenTour,
                d.SoNguoi,
                TyGiaHienThi = d.MaTourNavigation.NgoaiTe.Trim() == "VND" ? "1" : $"{d.TyGia.ToString("N0", _culture)} {d.MaTourNavigation.NgoaiTe.Trim()}/VND",
                TongTienVND = $"{d.TongTienVnd.ToString("N0", _culture)} đ",
                NgayDat = d.NgayDat.HasValue ? d.NgayDat.Value.ToString("dd/MM/yyyy HH:mm") : "",
                RawTongTien = d.TongTienVnd
            })
            .ToList();

        dgvDatTour.DataSource = list;

        // Tùy chỉnh cột DataGridView theo mẫu đề bài
        if (dgvDatTour.Columns["MaHienThi"] is { } colMa) { colMa.HeaderText = "Mã"; colMa.Width = 70; }
        if (dgvDatTour.Columns["KhachHang"] is { } colKh) { colKh.HeaderText = "Khách hàng"; colKh.Width = 160; }
        if (dgvDatTour.Columns["Tour"] is { } colTour) { colTour.HeaderText = "Tour"; colTour.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
        if (dgvDatTour.Columns["SoNguoi"] is { } colSoNguoi)
        {
            colSoNguoi.HeaderText = "Số người";
            colSoNguoi.Width = 80;
            colSoNguoi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        if (dgvDatTour.Columns["TyGiaHienThi"] is { } colTyGia)
        {
            colTyGia.HeaderText = "Tỷ giá";
            colTyGia.Width = 130;
            colTyGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        if (dgvDatTour.Columns["TongTienVND"] is { } colTong)
        {
            colTong.HeaderText = "Tổng tiền (VND)";
            colTong.Width = 130;
            colTong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        if (dgvDatTour.Columns["NgayDat"] is { } colNgay)
        {
            colNgay.HeaderText = "Ngày đặt";
            colNgay.Width = 140;
        }
        if (dgvDatTour.Columns["RawTongTien"] is { } colRaw) { colRaw.Visible = false; }

        // Cập nhật nhãn tổng doanh thu của các dòng đang hiển thị
        decimal tongDoanhThu = list.Sum(x => x.RawTongTien);
        lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu.ToString("N0", _culture)} đ";
    }

    private void txtTimDatTour_TextChanged(object sender, EventArgs e)
    {
        LoadDanhSachDatTour();
    }

    private void cboThangKhoiHanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDanhSachDatTour();
    }

    private void btnTimDatTour_Click(object sender, EventArgs e)
    {
        LoadDanhSachDatTour();
    }

    private void btnTatCaDatTour_Click(object sender, EventArgs e)
    {
        txtTimDatTour.Clear();
        cboThangKhoiHanh.SelectedIndex = 0;
        LoadDanhSachDatTour();
    }

    #endregion
}
