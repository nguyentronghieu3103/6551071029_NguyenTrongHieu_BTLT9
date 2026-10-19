using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Bai1.Models;

namespace Bai1;

public partial class FormChiTieu : Form
{
    private List<ChiTieu> _allChiTieu = new();
    private int _selectedMaCt = 0;
    private readonly CultureInfo _vnCulture = CultureInfo.GetCultureInfo("vi-VN");

    public FormChiTieu()
    {
        InitializeComponent();
    }

    private void FormChiTieu_Load(object sender, EventArgs e)
    {
        InitializeCategories();
        InitializeDateFilters();
        LoadData();
    }

    private void InitializeCategories()
    {
        var standardCategories = new List<string>
        {
            "Ăn uống",
            "Đi lại",
            "Học tập",
            "Giải trí",
            "Khác"
        };

        // Try to query distinct categories from database if available
        try
        {
            using var db = DbContextFactory.CreateContext();
            var dbCategories = db.ChiTieus
                .Select(c => c.LoaiChi)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .ToList();

            foreach (var cat in dbCategories)
            {
                if (!standardCategories.Contains(cat))
                {
                    standardCategories.Add(cat);
                }
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi lấy danh mục chi tiêu ban đầu: {Message}", ex.Message);
        }

        // Setup input ComboBox
        cboLoaiChi.Items.Clear();
        foreach (var cat in standardCategories)
        {
            cboLoaiChi.Items.Add(cat);
        }
        if (cboLoaiChi.Items.Count > 0)
        {
            cboLoaiChi.SelectedIndex = 0;
        }

        // Setup search ComboBox
        cboTimLoaiChi.Items.Clear();
        cboTimLoaiChi.Items.Add("Tất cả");
        foreach (var cat in standardCategories)
        {
            cboTimLoaiChi.Items.Add(cat);
        }
        cboTimLoaiChi.SelectedIndex = 0;
    }

    private void InitializeDateFilters()
    {
        dtpNgayChi.Value = DateTime.Today;

        // Default "Từ ngày" to start of current month, "Đến ngày" to today
        DateTime now = DateTime.Today;
        dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
        dtpDenNgay.Value = now;
    }

    private void LoadData()
    {
        try
        {
            using var db = DbContextFactory.CreateContext();
            _allChiTieu = db.ChiTieus
                .AsNoTracking()
                .OrderBy(c => c.NgayChi)
                .ThenBy(c => c.MaCt)
                .ToList();

            ApplyFilter();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp dữ liệu chi tiêu từ cơ sở dữ liệu: {Message}", ex.Message);
            MessageBox.Show(
                "Có lỗi xảy ra khi truy cập cơ sở dữ liệu. Vui lòng kiểm tra lại cấu hình kết nối trong appsettings.json!\n\nChi tiết: " + ex.Message,
                "Lỗi kết nối CSDL",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private void ApplyFilter()
    {
        string keyword = txtTimNoiDung.Text.Trim().ToLower();
        string selectedLoaiChi = cboTimLoaiChi.SelectedItem?.ToString() ?? "Tất cả";
        DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value);
        DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value);

        var query = _allChiTieu.AsEnumerable();

        // 1. Filter by keyword in NoiDung
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(c => c.NoiDung != null && c.NoiDung.ToLower().Contains(keyword));
        }

        // 2. Filter by LoaiChi
        if (!string.IsNullOrEmpty(selectedLoaiChi) && selectedLoaiChi != "Tất cả")
        {
            query = query.Where(c => string.Equals(c.LoaiChi, selectedLoaiChi, StringComparison.OrdinalIgnoreCase));
        }

        // 3. Filter by Date range
        query = query.Where(c => c.NgayChi >= tuNgay && c.NgayChi <= denNgay);

        var filteredList = query.ToList();

        // Bind to DataGridView
        dgvChiTieu.DataSource = null;
        dgvChiTieu.DataSource = filteredList;

        // Update total money label
        decimal tongChi = filteredList.Sum(c => c.SoTien);
        lblTongChi.Text = $"Tổng chi: {tongChi.ToString("#,##0", _vnCulture)} đ";
    }

    private void dgvChiTieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value == null) return;

        string colName = dgvChiTieu.Columns[e.ColumnIndex].Name;

        if (colName == "colMa" && e.Value is int ma)
        {
            e.Value = ma.ToString("D3");
            e.FormattingApplied = true;
        }
        else if (colName == "colNgayChi" && e.Value is DateOnly d)
        {
            e.Value = d.ToString("dd/MM/yyyy");
            e.FormattingApplied = true;
        }
        else if (colName == "colSoTien" && (e.Value is decimal || e.Value is double || e.Value is int))
        {
            decimal val = Convert.ToDecimal(e.Value);
            e.Value = val.ToString("#,##0", _vnCulture);
            e.FormattingApplied = true;
        }
    }

    private void dgvChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvChiTieu.Rows.Count) return;

        if (dgvChiTieu.Rows[e.RowIndex].DataBoundItem is ChiTieu item)
        {
            _selectedMaCt = item.MaCt;
            dtpNgayChi.Value = item.NgayChi.ToDateTime(TimeOnly.MinValue);
            txtNoiDung.Text = item.NoiDung ?? string.Empty;

            if (!string.IsNullOrEmpty(item.LoaiChi))
            {
                if (!cboLoaiChi.Items.Contains(item.LoaiChi))
                {
                    cboLoaiChi.Items.Add(item.LoaiChi);
                }
                cboLoaiChi.SelectedItem = item.LoaiChi;
            }

            numSoTien.Value = item.SoTien >= 0 && item.SoTien <= numSoTien.Maximum ? item.SoTien : 0;
            txtGhiChu.Text = item.GhiChu ?? string.Empty;
        }
    }

    private bool ValidateInputs()
    {
        // 1. Nội dung không rỗng
        if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
        {
            MessageBox.Show("Nội dung chi tiêu không được để trống!", "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNoiDung.Focus();
            return false;
        }

        // 2. Số tiền > 0
        if (numSoTien.Value <= 0)
        {
            MessageBox.Show("Số tiền chi tiêu phải lớn hơn 0 đ!", "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numSoTien.Focus();
            return false;
        }

        // 3. Ngày chi không lớn hơn hôm nay
        DateOnly ngayChi = DateOnly.FromDateTime(dtpNgayChi.Value);
        DateOnly homNay = DateOnly.FromDateTime(DateTime.Today);
        if (ngayChi > homNay)
        {
            MessageBox.Show("Ngày chi không được lớn hơn ngày hôm nay!", "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpNgayChi.Focus();
            return false;
        }

        // 4. Loại chi không rỗng
        if (string.IsNullOrWhiteSpace(cboLoaiChi.Text))
        {
            MessageBox.Show("Vui lòng chọn loại chi tiêu!", "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboLoaiChi.Focus();
            return false;
        }

        return true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        try
        {
            using var db = DbContextFactory.CreateContext();
            var newItem = new ChiTieu
            {
                NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value),
                NoiDung = txtNoiDung.Text.Trim(),
                LoaiChi = cboLoaiChi.Text.Trim(),
                SoTien = numSoTien.Value,
                GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
            };

            db.ChiTieus.Add(newItem);
            db.SaveChanges();

            // Log Information
            Log.Information("Thêm khoản chi thành công: MaCT = {MaCT}, NoiDung = {NoiDung}, SoTien = {SoTien}, LoaiChi = {LoaiChi}",
                newItem.MaCt, newItem.NoiDung, newItem.SoTien, newItem.LoaiChi);

            MessageBox.Show("Thêm khoản chi tiêu mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
            ClearInputControls();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thêm khoản chi mới: {Message}", ex.Message);
            MessageBox.Show("Có lỗi xảy ra khi thêm khoản chi. Vui lòng thử lại!\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaCt <= 0)
        {
            MessageBox.Show("Vui lòng chọn một dòng khoản chi từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (!ValidateInputs()) return;

        try
        {
            using var db = DbContextFactory.CreateContext();
            var existing = db.ChiTieus.Find(_selectedMaCt);

            if (existing == null)
            {
                MessageBox.Show("Khoản chi được chọn không còn tồn tại trong CSDL!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            existing.NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value);
            existing.NoiDung = txtNoiDung.Text.Trim();
            existing.LoaiChi = cboLoaiChi.Text.Trim();
            existing.SoTien = numSoTien.Value;
            existing.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

            db.SaveChanges();

            // Log Information
            Log.Information("Sửa khoản chi thành công: MaCT = {MaCT}, NoiDung = {NoiDung}, SoTien = {SoTien}, LoaiChi = {LoaiChi}",
                existing.MaCt, existing.NoiDung, existing.SoTien, existing.LoaiChi);

            MessageBox.Show("Cập nhật khoản chi tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
            ClearInputControls();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi sửa khoản chi MaCT = {MaCT}: {Message}", _selectedMaCt, ex.Message);
            MessageBox.Show("Có lỗi xảy ra khi cập nhật khoản chi. Vui lòng thử lại!\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaCt <= 0)
        {
            MessageBox.Show("Vui lòng chọn một dòng khoản chi từ danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var dr = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa khoản chi '{txtNoiDung.Text}' (Mã: {_selectedMaCt:D3}) không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (dr != DialogResult.Yes) return;

        try
        {
            using var db = DbContextFactory.CreateContext();
            var existing = db.ChiTieus.Find(_selectedMaCt);

            if (existing != null)
            {
                db.ChiTieus.Remove(existing);
                db.SaveChanges();

                // Log Information
                Log.Information("Xóa khoản chi thành công: MaCT = {MaCT}", _selectedMaCt);

                MessageBox.Show("Xóa khoản chi tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadData();
            ClearInputControls();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi xóa khoản chi MaCT = {MaCT}: {Message}", _selectedMaCt, ex.Message);
            MessageBox.Show("Có lỗi xảy ra khi xóa khoản chi. Vui lòng thử lại!\nChi tiết: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        ClearInputControls();

        // Reset search controls
        txtTimNoiDung.Clear();
        cboTimLoaiChi.SelectedIndex = 0;
        InitializeDateFilters();

        LoadData();
    }

    private void ClearInputControls()
    {
        _selectedMaCt = 0;
        dtpNgayChi.Value = DateTime.Today;
        txtNoiDung.Clear();
        if (cboLoaiChi.Items.Count > 0)
        {
            cboLoaiChi.SelectedIndex = 0;
        }
        numSoTien.Value = 0;
        txtGhiChu.Clear();
        dgvChiTieu.ClearSelection();
    }

    private void btnTim_Click(object sender, EventArgs e)
    {
        if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
        {
            MessageBox.Show("'Từ ngày' không được lớn hơn 'Đến ngày'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        ApplyFilter();
    }

    private void txtTimNoiDung_TextChanged(object sender, EventArgs e)
    {
        ApplyFilter();
    }

    private void cboTimLoaiChi_SelectedIndexChanged(object sender, EventArgs e)
    {
        ApplyFilter();
    }
}
