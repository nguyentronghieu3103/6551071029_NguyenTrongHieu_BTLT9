using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using bai4.Models;

namespace bai4;

public partial class FormThucDon : Form
{
    private int _selectedMaMon = 0;

    public FormThucDon()
    {
        InitializeComponent();
    }

    private void FormThucDon_Load(object sender, EventArgs e)
    {
        LoadDanhMuc();
        LoadDanhSachMon();
    }

    private void LoadDanhMuc()
    {
        using var context = new QL_TraSuaContext();
        var danhMucs = context.DanhMucMons.OrderBy(d => d.TenDm).ToList();

        // Nạp ComboBox thêm/sửa
        cboDanhMuc.DataSource = danhMucs;
        cboDanhMuc.DisplayMember = "TenDm";
        cboDanhMuc.ValueMember = "MaDm";

        // Nạp ComboBox lọc
        var locList = danhMucs.Select(d => new { d.MaDm, d.TenDm }).ToList();
        locList.Insert(0, new { MaDm = 0, TenDm = "-- Tất cả danh mục --" });
        cboLocDanhMuc.DataSource = locList;
        cboLocDanhMuc.DisplayMember = "TenDm";
        cboLocDanhMuc.ValueMember = "MaDm";
        cboLocDanhMuc.SelectedIndex = 0;
    }

    private void LoadDanhSachMon()
    {
        using var context = new QL_TraSuaContext();

        var query = context.MonUongs
            .Include(m => m.MaDmNavigation)
            .AsQueryable();

        string keyword = txtTimKiem.Text.Trim();
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(m => m.TenMon.Contains(keyword));
        }

        if (cboLocDanhMuc.SelectedValue is int maDm && maDm > 0)
        {
            query = query.Where(m => m.MaDm == maDm);
        }

        var list = query
            .OrderBy(m => m.MaDm)
            .ThenBy(m => m.TenMon)
            .Select(m => new
            {
                m.MaMon,
                m.TenMon,
                TenDanhMuc = m.MaDmNavigation.TenDm,
                m.GiaBan,
                TrangThai = (m.DangBan == true ? "Đang bán" : "Ngừng bán"),
                m.MaDm,
                DangBanBool = m.DangBan ?? true
            })
            .ToList();

        dgvMonUong.DataSource = list;

        // Tùy chỉnh cột
        if (dgvMonUong.Columns["MaMon"] is { } colMaMon)
        {
            colMaMon.HeaderText = "Mã món";
            colMaMon.Width = 80;
        }
        if (dgvMonUong.Columns["TenMon"] is { } colTenMon)
        {
            colTenMon.HeaderText = "Tên món";
        }
        if (dgvMonUong.Columns["TenDanhMuc"] is { } colTenDm)
        {
            colTenDm.HeaderText = "Danh mục";
            colTenDm.Width = 140;
        }
        if (dgvMonUong.Columns["GiaBan"] is { } colGiaBan)
        {
            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.DefaultCellStyle.Format = "#,##0 đ";
            colGiaBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGiaBan.Width = 120;
        }
        if (dgvMonUong.Columns["TrangThai"] is { } colTrangThai)
        {
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.Width = 110;
        }

        if (dgvMonUong.Columns["MaDm"] is { } colMaDm) colMaDm.Visible = false;
        if (dgvMonUong.Columns["DangBanBool"] is { } colDangBanBool) colDangBanBool.Visible = false;
    }

    private void dgvMonUong_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvMonUong.Rows.Count) return;

        var row = dgvMonUong.Rows[e.RowIndex];
        _selectedMaMon = Convert.ToInt32(row.Cells["MaMon"].Value);
        txtTenMon.Text = row.Cells["TenMon"].Value?.ToString() ?? "";
        cboDanhMuc.SelectedValue = Convert.ToInt32(row.Cells["MaDm"].Value);
        nudGiaBan.Value = Convert.ToDecimal(row.Cells["GiaBan"].Value);
        chkDangBan.Checked = Convert.ToBoolean(row.Cells["DangBanBool"].Value);
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        string tenMon = txtTenMon.Text.Trim();
        if (string.IsNullOrEmpty(tenMon))
        {
            MessageBox.Show("Vui lòng nhập tên món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenMon.Focus();
            return;
        }

        if (cboDanhMuc.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var context = new QL_TraSuaContext();

        var mon = new MonUong
        {
            TenMon = tenMon,
            MaDm = (int)cboDanhMuc.SelectedValue,
            GiaBan = nudGiaBan.Value,
            DangBan = chkDangBan.Checked
        };

        context.MonUongs.Add(mon);
        context.SaveChanges();

        MessageBox.Show($"Đã thêm món '{tenMon}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearInputs();
        LoadDanhSachMon();
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaMon <= 0)
        {
            MessageBox.Show("Vui lòng chọn món cần sửa từ bảng danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string tenMon = txtTenMon.Text.Trim();
        if (string.IsNullOrEmpty(tenMon))
        {
            MessageBox.Show("Vui lòng nhập tên món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenMon.Focus();
            return;
        }

        using var context = new QL_TraSuaContext();
        var mon = context.MonUongs.Find(_selectedMaMon);
        if (mon == null)
        {
            MessageBox.Show("Không tìm thấy món cần sửa trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        mon.TenMon = tenMon;
        if (cboDanhMuc.SelectedValue is int maDm)
        {
            mon.MaDm = maDm;
        }
        mon.GiaBan = nudGiaBan.Value;
        mon.DangBan = chkDangBan.Checked;

        context.SaveChanges();

        MessageBox.Show($"Đã cập nhật món '{tenMon}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearInputs();
        LoadDanhSachMon();
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaMon <= 0)
        {
            MessageBox.Show("Vui lòng chọn món cần xóa từ bảng danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa món '{txtTenMon.Text}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        using var context = new QL_TraSuaContext();
        var mon = context.MonUongs.Find(_selectedMaMon);
        if (mon == null)
        {
            MessageBox.Show("Không tìm thấy món trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Kiểm tra xem món đã có trong chi tiết hóa đơn chưa
        bool coHoaDon = context.ChiTietHoaDons.Any(ct => ct.MaMon == _selectedMaMon);
        if (coHoaDon)
        {
            var hoiNgungBan = MessageBox.Show(
                $"Món '{mon.TenMon}' đã phát sinh trong các đơn hàng đã bán nên không thể xóa hoàn toàn.\nBạn có muốn chuyển trạng thái món sang 'Ngừng bán' không?",
                "Món đã có lịch sử đơn hàng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (hoiNgungBan == DialogResult.Yes)
            {
                mon.DangBan = false;
                context.SaveChanges();
                MessageBox.Show("Đã chuyển trạng thái món sang 'Ngừng bán'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            context.MonUongs.Remove(mon);
            context.SaveChanges();
            MessageBox.Show("Đã xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        ClearInputs();
        LoadDanhSachMon();
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        ClearInputs();
    }

    private void ClearInputs()
    {
        _selectedMaMon = 0;
        txtTenMon.Clear();
        if (cboDanhMuc.Items.Count > 0) cboDanhMuc.SelectedIndex = 0;
        nudGiaBan.Value = 0;
        chkDangBan.Checked = true;
        dgvMonUong.ClearSelection();
    }

    private void txtTimKiem_TextChanged(object sender, EventArgs e)
    {
        LoadDanhSachMon();
    }

    private void cboLocDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDanhSachMon();
    }

    private void btnHienTatCa_Click(object sender, EventArgs e)
    {
        txtTimKiem.Clear();
        if (cboLocDanhMuc.Items.Count > 0) cboLocDanhMuc.SelectedIndex = 0;
        LoadDanhSachMon();
    }
}
