using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using bai4.Models;

namespace bai4;

public partial class FormHoaDon : Form
{
    private bool _filterByDate = true;

    public FormHoaDon()
    {
        InitializeComponent();
    }

    private void FormHoaDon_Load(object sender, EventArgs e)
    {
        dtpNgay.Value = DateTime.Today;
        LoadDanhSachHoaDon();
    }

    public void LoadDanhSachHoaDon()
    {
        using var context = new QL_TraSuaContext();

        var query = context.HoaDons.AsQueryable();

        if (_filterByDate)
        {
            var selectedDate = dtpNgay.Value.Date;
            query = query.Where(h => h.NgayLap.Date == selectedDate);
        }

        var list = query
            .OrderByDescending(h => h.NgayLap)
            .Select(h => new
            {
                h.MaHd,
                NgayLap = h.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                h.HinhThucTt,
                h.TongTien,
                TrangThai = (h.DaThanhToan == true ? "Đã thanh toán" : "Chưa thanh toán"),
                RawDaThanhToan = h.DaThanhToan
            })
            .ToList();

        dgvHoaDon.DataSource = list;

        // Định dạng cột hóa đơn
        if (dgvHoaDon.Columns["MaHd"] is { } colMaHd)
        {
            colMaHd.HeaderText = "Mã HD";
            colMaHd.Width = 70;
        }
        if (dgvHoaDon.Columns["NgayLap"] is { } colNgayLap)
        {
            colNgayLap.HeaderText = "Thời gian lập";
            colNgayLap.Width = 140;
        }
        if (dgvHoaDon.Columns["HinhThucTt"] is { } colHinhThuc)
        {
            colHinhThuc.HeaderText = "Hình thức TT";
            colHinhThuc.Width = 120;
        }
        if (dgvHoaDon.Columns["TongTien"] is { } colTongTien)
        {
            colTongTien.HeaderText = "Tổng tiền";
            colTongTien.DefaultCellStyle.Format = "#,##0 đ";
            colTongTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        if (dgvHoaDon.Columns["TrangThai"] is { } colTrangThai)
        {
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.Width = 120;
        }
        if (dgvHoaDon.Columns["RawDaThanhToan"] is { } colRaw)
        {
            colRaw.Visible = false;
        }

        // Tính doanh thu và tổng số đơn
        decimal doanhThu = list.Where(h => h.RawDaThanhToan == true).Sum(h => h.TongTien);
        lblTongSoDon.Text = $"Tổng số đơn: {list.Count}";

        if (_filterByDate)
        {
            lblDoanhThuNgay.Text = $"Doanh thu ngày: {doanhThu:N0} đ";
        }
        else
        {
            lblDoanhThuNgay.Text = $"Tổng doanh thu: {doanhThu:N0} đ";
        }

        if (list.Count == 0)
        {
            dgvChiTietHoaDon.DataSource = null;
        }
    }

    private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvHoaDon.CurrentRow == null || dgvHoaDon.CurrentRow.Index < 0)
        {
            dgvChiTietHoaDon.DataSource = null;
            return;
        }

        int maHd = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["MaHd"].Value);
        LoadChiTietHoaDon(maHd);
    }

    private void LoadChiTietHoaDon(int maHd)
    {
        using var context = new QL_TraSuaContext();

        var chiTiets = context.ChiTietHoaDons
            .Where(ct => ct.MaHd == maHd)
            .Include(ct => ct.MaMonNavigation)
            .Select(ct => new
            {
                TenMon = ct.MaMonNavigation != null ? ct.MaMonNavigation.TenMon : $"Món #{ct.MaMon}",
                ct.SoLy,
                ct.DonGia,
                ThanhTien = ct.SoLy * ct.DonGia
            })
            .ToList();

        dgvChiTietHoaDon.DataSource = chiTiets;

        if (dgvChiTietHoaDon.Columns["TenMon"] is { } colTenMon)
        {
            colTenMon.HeaderText = "Tên món";
        }
        if (dgvChiTietHoaDon.Columns["SoLy"] is { } colSoLy)
        {
            colSoLy.HeaderText = "SL";
            colSoLy.Width = 60;
            colSoLy.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        if (dgvChiTietHoaDon.Columns["DonGia"] is { } colDonGia)
        {
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.Width = 100;
            colDonGia.DefaultCellStyle.Format = "#,##0 đ";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        if (dgvChiTietHoaDon.Columns["ThanhTien"] is { } colThanhTien)
        {
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.Width = 110;
            colThanhTien.DefaultCellStyle.Format = "#,##0 đ";
            colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }

    private void dtpNgay_ValueChanged(object sender, EventArgs e)
    {
        _filterByDate = true;
        LoadDanhSachHoaDon();
    }

    private void btnHomNay_Click(object sender, EventArgs e)
    {
        _filterByDate = true;
        dtpNgay.Value = DateTime.Today;
        LoadDanhSachHoaDon();
    }

    private void btnXemTatCa_Click(object sender, EventArgs e)
    {
        _filterByDate = false;
        LoadDanhSachHoaDon();
    }
}
