using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai2.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Bai2
{
    public partial class FormKhachThue : Form
    {
        // 3. HttpClient dùng chung, Timeout 10s
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        private List<ProvinceItem> _provinces = new List<ProvinceItem>();
        private List<KhachThueViewModel> _allKhachList = new List<KhachThueViewModel>();
        private int _selectedKhachId = 0;
        private bool _isBinding = false;

        public FormKhachThue()
        {
            InitializeComponent();
            SetupDataGridView();
            RegisterEvents();
        }

        private void SetupDataGridView()
        {
            dgvKhachThue.AutoGenerateColumns = false;
            dgvKhachThue.Columns.Clear();

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaKhach",
                DataPropertyName = "MaKhach",
                Visible = false
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Họ tên",
                DataPropertyName = "HoTen",
                FillWeight = 130
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoDienThoai",
                HeaderText = "SĐT",
                DataPropertyName = "SoDienThoai",
                FillWeight = 95
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenPhong",
                HeaderText = "Phòng",
                DataPropertyName = "TenPhong",
                FillWeight = 65
            });

            var colGiaThue = new DataGridViewTextBoxColumn
            {
                Name = "GiaThue",
                HeaderText = "Giá thuê",
                DataPropertyName = "GiaThue",
                FillWeight = 100
            };
            colGiaThue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvKhachThue.Columns.Add(colGiaThue);

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QueQuan",
                HeaderText = "Quê quán",
                DataPropertyName = "QueQuan",
                FillWeight = 140
            });

            dgvKhachThue.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "DaDangKyTamTru",
                HeaderText = "Tạm trú",
                DataPropertyName = "DaDangKyTamTru",
                FillWeight = 65
            });
        }

        private void RegisterEvents()
        {
            this.Load += FormKhachThue_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTim.Click += BtnTim_Click;
            btnBoLoc.Click += BtnBoLoc_Click;
            btnGayLoiThu.Click += BtnGayLoiThu_Click;
            cboTinhThanh.SelectedIndexChanged += CboTinhThanh_SelectedIndexChanged;
            dgvKhachThue.CellClick += DgvKhachThue_CellClick;
            txtTimKiem.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnTim_Click(s, e); };
        }

        private async void FormKhachThue_Load(object? sender, EventArgs e)
        {
            try
            {
                LoadRooms();
                LoadKhachThueData();
                await LoadProvincesAsync();
                PopulateFilterProvinces();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi khởi tạo FormKhachThue");
                MessageBox.Show("Đã xảy ra lỗi khi khởi tạo dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 3. Tích hợp API Tỉnh / Phường-Xã (async/await, Timeout 10s, chịu lỗi mạng)

        private async Task LoadProvincesAsync()
        {
            try
            {
                lblStatus.Text = "Đang tải danh sách tỉnh/thành...";
                cboTinhThanh.DataSource = null;
                cboTinhThanh.Items.Clear();
                cboTinhThanh.Items.Add("Đang tải...");
                cboTinhThanh.SelectedIndex = 0;
                cboTinhThanh.Enabled = false;

                var list = await _httpClient.GetFromJsonAsync<List<ProvinceItem>>("https://provinces.open-api.vn/api/v2/");
                if (list != null && list.Count > 0)
                {
                    _provinces = list;
                    cboTinhThanh.Items.Clear();
                    cboTinhThanh.DisplayMember = "name";
                    cboTinhThanh.ValueMember = "code";
                    cboTinhThanh.DataSource = _provinces;
                    cboTinhThanh.SelectedIndex = -1;
                    cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDownList;
                    lblStatus.Text = $"Đã tải {_provinces.Count} tỉnh/thành từ provinces.open-api.vn";
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is OperationCanceledException || ex is TimeoutException)
            {
                // 8. Chịu lỗi mạng: Bắt lỗi mạng, ghi log, thông báo thân thiện và cho phép gõ tay
                Log.Warning(ex, "Không tải được danh sách tỉnh/thành từ API hành chính Việt Nam");
                lblStatus.Text = "Không tải được dữ liệu trực tuyến. Cho phép nhập tay tỉnh/phường xã.";
                MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cboTinhThanh.DataSource = null;
                cboTinhThanh.Items.Clear();
                cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDown;
                cboPhuongXa.DataSource = null;
                cboPhuongXa.Items.Clear();
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
            }
            finally
            {
                cboTinhThanh.Enabled = true;
            }
        }

        private async void CboTinhThanh_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isBinding) return;

            if (cboTinhThanh.SelectedItem is ProvinceItem prov)
            {
                await LoadWardsAsync(prov.code);
            }
            else if (cboTinhThanh.SelectedValue is int codeVal)
            {
                await LoadWardsAsync(codeVal);
            }
            else
            {
                cboPhuongXa.DataSource = null;
                cboPhuongXa.Items.Clear();
            }
        }

        private async Task LoadWardsAsync(int provinceCode, int? selectWardCode = null, string? selectWardName = null)
        {
            try
            {
                cboPhuongXa.DataSource = null;
                cboPhuongXa.Items.Clear();
                cboPhuongXa.Items.Add("Đang tải...");
                cboPhuongXa.SelectedIndex = 0;
                cboPhuongXa.Enabled = false;

                var provDetail = await _httpClient.GetFromJsonAsync<ProvinceItem>($"https://provinces.open-api.vn/api/v2/p/{provinceCode}?depth=2");
                var wards = provDetail?.wards ?? new List<WardItem>();

                cboPhuongXa.Items.Clear();
                cboPhuongXa.DisplayMember = "name";
                cboPhuongXa.ValueMember = "code";
                cboPhuongXa.DataSource = wards;
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDownList;

                if (selectWardCode.HasValue && selectWardCode.Value > 0)
                {
                    var matchByCode = wards.FirstOrDefault(w => w.code == selectWardCode.Value);
                    if (matchByCode != null)
                    {
                        cboPhuongXa.SelectedItem = matchByCode;
                    }
                    else if (!string.IsNullOrEmpty(selectWardName))
                    {
                        var matchByName = wards.FirstOrDefault(w => w.name.Equals(selectWardName, StringComparison.OrdinalIgnoreCase));
                        if (matchByName != null)
                        {
                            cboPhuongXa.SelectedItem = matchByName;
                        }
                        else
                        {
                            cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                            cboPhuongXa.Text = selectWardName;
                        }
                    }
                    else
                    {
                        cboPhuongXa.SelectedIndex = -1;
                    }
                }
                else if (!string.IsNullOrEmpty(selectWardName))
                {
                    var match = wards.FirstOrDefault(w => w.name.Equals(selectWardName, StringComparison.OrdinalIgnoreCase));
                    if (match != null)
                    {
                        cboPhuongXa.SelectedItem = match;
                    }
                    else
                    {
                        cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                        cboPhuongXa.Text = selectWardName;
                    }
                }
                else
                {
                    cboPhuongXa.SelectedIndex = -1;
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is OperationCanceledException || ex is TimeoutException)
            {
                Log.Warning(ex, "Không tải được danh sách phường/xã cho tỉnh mã {ProvinceCode}", provinceCode);
                MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cboPhuongXa.DataSource = null;
                cboPhuongXa.Items.Clear();
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                if (!string.IsNullOrEmpty(selectWardName))
                    cboPhuongXa.Text = selectWardName;
            }
            finally
            {
                cboPhuongXa.Enabled = true;
            }
        }

        #endregion

        #region Database & Data Loading

        private void LoadRooms()
        {
            using var context = new QL_NhaTroContext();
            var rooms = context.PhongTros
                .OrderBy(p => p.TenPhong)
                .Select(p => new PhongTroDisplay
                {
                    MaPhong = p.MaPhong,
                    TenPhong = p.TenPhong,
                    GiaThue = p.GiaThue,
                    TinhTrang = p.TinhTrang
                })
                .ToList();

            // ComboBox chọn phòng khi thêm/sửa khách
            cboPhong.DisplayMember = "DisplayText";
            cboPhong.ValueMember = "MaPhong";
            cboPhong.DataSource = rooms;
            cboPhong.SelectedIndex = -1;

            // ComboBox lọc theo phòng
            var filterRooms = new List<PhongTroDisplay>
            {
                new PhongTroDisplay { MaPhong = 0, TenPhong = "Tất cả", GiaThue = 0 }
            };
            filterRooms.AddRange(rooms);

            cboLocPhong.DisplayMember = "TenPhong";
            cboLocPhong.ValueMember = "MaPhong";
            cboLocPhong.DataSource = filterRooms;
            cboLocPhong.SelectedIndex = 0;
        }

        private void LoadKhachThueData()
        {
            using var context = new QL_NhaTroContext();
            var data = context.KhachThues
                .Include(k => k.MaPhongNavigation)
                .OrderBy(k => k.MaKhach)
                .ToList();

            var viCulture = new CultureInfo("vi-VN");

            _allKhachList = data.Select(k =>
            {
                string queQuan;
                if (!string.IsNullOrWhiteSpace(k.TenPhuongXa) && !string.IsNullOrWhiteSpace(k.TenTinh))
                    queQuan = $"{k.TenPhuongXa} - {k.TenTinh}";
                else if (!string.IsNullOrWhiteSpace(k.TenTinh))
                    queQuan = k.TenTinh;
                else
                    queQuan = k.TenPhuongXa ?? "";

                decimal gia = k.MaPhongNavigation?.GiaThue ?? 0;

                return new KhachThueViewModel
                {
                    MaKhach = k.MaKhach,
                    HoTen = k.HoTen ?? "",
                    SoDienThoai = k.SoDienThoai ?? "",
                    TenPhong = k.MaPhongNavigation?.TenPhong ?? "",
                    GiaThue = gia > 0 ? $"{gia.ToString("#,##0", viCulture)} đ" : "",
                    QueQuan = queQuan,
                    DaDangKyTamTru = k.DaDangKyTamTru == true,
                    MaPhong = k.MaPhong,
                    MaTinh = k.MaTinh,
                    TenTinh = k.TenTinh,
                    MaPhuongXa = k.MaPhuongXa,
                    TenPhuongXa = k.TenPhuongXa,
                    GioiTinh = k.GioiTinh,
                    NgaySinh = k.NgaySinh,
                    RawGiaThue = gia
                };
            }).ToList();

            dgvKhachThue.DataSource = _allKhachList.ToList();
        }

        private void PopulateFilterProvinces()
        {
            var tinhList = new List<string> { "Tất cả" };
            var uniqueFromDb = _allKhachList
                .Where(k => !string.IsNullOrWhiteSpace(k.TenTinh))
                .Select(k => k.TenTinh!)
                .Distinct()
                .OrderBy(t => t);

            tinhList.AddRange(uniqueFromDb);

            cboLocTinh.DataSource = tinhList;
            cboLocTinh.SelectedIndex = 0;
        }

        #endregion

        #region DataGridView Selection Binding

        private async void DgvKhachThue_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKhachThue.Rows.Count) return;

            var row = dgvKhachThue.Rows[e.RowIndex];
            if (row.DataBoundItem is KhachThueViewModel item)
            {
                _isBinding = true;
                try
                {
                    _selectedKhachId = item.MaKhach;
                    txtHoTen.Text = item.HoTen;
                    txtSoDienThoai.Text = item.SoDienThoai;

                    // Giới tính
                    if (item.GioiTinh == 0)
                    {
                        rbNu.Checked = true;
                    }
                    else
                    {
                        rbNam.Checked = true;
                    }

                    // Ngày sinh
                    if (item.NgaySinh.HasValue)
                    {
                        dtpNgaySinh.Value = item.NgaySinh.Value.ToDateTime(TimeOnly.MinValue);
                    }
                    else
                    {
                        dtpNgaySinh.Value = DateTime.Today;
                    }

                    // Phòng
                    if (item.MaPhong.HasValue)
                    {
                        cboPhong.SelectedValue = item.MaPhong.Value;
                    }
                    else
                    {
                        cboPhong.SelectedIndex = -1;
                    }

                    // Tạm trú
                    chkTamTru.Checked = item.DaDangKyTamTru;

                    // Tỉnh/Thành & Phường/Xã
                    await BindAddressForSelection(item);
                }
                finally
                {
                    _isBinding = false;
                }
            }
        }

        private async Task BindAddressForSelection(KhachThueViewModel item)
        {
            int? provCode = null;
            if (int.TryParse(item.MaTinh, out int parsedProvCode))
            {
                provCode = parsedProvCode;
            }

            // Tìm tỉnh theo mã hoặc tên
            ProvinceItem? matchedProv = null;
            if (provCode.HasValue && _provinces.Count > 0)
            {
                matchedProv = _provinces.FirstOrDefault(p => p.code == provCode.Value);
            }
            if (matchedProv == null && !string.IsNullOrWhiteSpace(item.TenTinh) && _provinces.Count > 0)
            {
                matchedProv = _provinces.FirstOrDefault(p => p.name.Equals(item.TenTinh, StringComparison.OrdinalIgnoreCase)
                    || item.TenTinh.Contains(p.name, StringComparison.OrdinalIgnoreCase));
            }

            if (matchedProv != null)
            {
                cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDownList;
                cboTinhThanh.SelectedItem = matchedProv;
                await LoadWardsAsync(matchedProv.code, item.MaPhuongXa, item.TenPhuongXa);
            }
            else
            {
                cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDown;
                cboTinhThanh.Text = item.TenTinh ?? "";
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                cboPhuongXa.Text = item.TenPhuongXa ?? "";
            }
        }

        #endregion

        #region 4. CRUD trên nhiều bảng & Quản lý trạng thái phòng

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using var context = new QL_NhaTroContext();

                int maPhong = (int)cboPhong.SelectedValue!;
                var phong = context.PhongTros.Find(maPhong);
                if (phong == null)
                {
                    MessageBox.Show("Phòng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin Tỉnh/Thành
                string? maTinh = null;
                string tenTinh = "";
                if (cboTinhThanh.SelectedItem is ProvinceItem prov)
                {
                    maTinh = prov.code.ToString("D2");
                    tenTinh = prov.name;
                }
                else
                {
                    tenTinh = cboTinhThanh.Text.Trim();
                }

                // Lấy thông tin Phường/Xã
                int? maPhuongXa = null;
                string tenPhuongXa = "";
                if (cboPhuongXa.SelectedItem is WardItem ward)
                {
                    maPhuongXa = ward.code;
                    tenPhuongXa = ward.name;
                }
                else
                {
                    tenPhuongXa = cboPhuongXa.Text.Trim();
                }

                var khachMoi = new KhachThue
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = rbNam.Checked ? 1 : 0,
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    MaPhong = maPhong,
                    MaTinh = maTinh,
                    TenTinh = tenTinh,
                    MaPhuongXa = maPhuongXa,
                    TenPhuongXa = tenPhuongXa,
                    DaDangKyTamTru = chkTamTru.Checked
                };

                // Quy tắc: Khi thêm khách vào phòng thì phòng chuyển "Đang thuê"
                phong.TinhTrang = "Đang thuê";

                context.KhachThues.Add(khachMoi);
                context.SaveChanges();

                Log.Information("Thêm thành công khách thuê {HoTen} vào phòng {TenPhong}", khachMoi.HoTen, phong.TenPhong);
                MessageBox.Show("Thêm khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
                LoadKhachThueData();
                PopulateFilterProvinces();
                ResetInputs();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm khách thuê");
                MessageBox.Show("Đã xảy ra lỗi khi thêm khách thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (_selectedKhachId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using var context = new QL_NhaTroContext();
                var khach = context.KhachThues.Find(_selectedKhachId);
                if (khach == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách thuê trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int oldMaPhong = khach.MaPhong ?? 0;
                int newMaPhong = (int)cboPhong.SelectedValue!;

                // Cập nhật thông tin khách
                khach.HoTen = txtHoTen.Text.Trim();
                khach.GioiTinh = rbNam.Checked ? 1 : 0;
                khach.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
                khach.SoDienThoai = txtSoDienThoai.Text.Trim();
                khach.MaPhong = newMaPhong;
                khach.DaDangKyTamTru = chkTamTru.Checked;

                // Tỉnh / Phường
                if (cboTinhThanh.SelectedItem is ProvinceItem prov)
                {
                    khach.MaTinh = prov.code.ToString("D2");
                    khach.TenTinh = prov.name;
                }
                else
                {
                    khach.TenTinh = cboTinhThanh.Text.Trim();
                }

                if (cboPhuongXa.SelectedItem is WardItem ward)
                {
                    khach.MaPhuongXa = ward.code;
                    khach.TenPhuongXa = ward.name;
                }
                else
                {
                    khach.TenPhuongXa = cboPhuongXa.Text.Trim();
                }

                // Cập nhật trạng thái phòng khi đổi phòng
                if (oldMaPhong != newMaPhong)
                {
                    // Phòng mới chuyển sang "Đang thuê"
                    var newPhong = context.PhongTros.Find(newMaPhong);
                    if (newPhong != null) newPhong.TinhTrang = "Đang thuê";

                    // Phòng cũ: Nếu không còn ai khác thì trở lại "Trống"
                    if (oldMaPhong > 0)
                    {
                        bool remainingInOld = context.KhachThues.Any(k => k.MaPhong == oldMaPhong && k.MaKhach != khach.MaKhach);
                        if (!remainingInOld)
                        {
                            var oldPhong = context.PhongTros.Find(oldMaPhong);
                            if (oldPhong != null) oldPhong.TinhTrang = "Trống";
                        }
                    }
                }
                else
                {
                    // Đảm bảo phòng hiện tại là "Đang thuê"
                    var curPhong = context.PhongTros.Find(newMaPhong);
                    if (curPhong != null) curPhong.TinhTrang = "Đang thuê";
                }

                context.SaveChanges();

                Log.Information("Cập nhật thành công khách thuê mã {MaKhach} ({HoTen})", khach.MaKhach, khach.HoTen);
                MessageBox.Show("Cập nhật thông tin khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
                LoadKhachThueData();
                PopulateFilterProvinces();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi sửa khách thuê");
                MessageBox.Show("Đã xảy ra lỗi khi sửa khách thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (_selectedKhachId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách thuê '{txtHoTen.Text}' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var context = new QL_NhaTroContext();
                var khach = context.KhachThues.Find(_selectedKhachId);
                if (khach == null)
                {
                    MessageBox.Show("Không tìm thấy khách thuê cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int? maPhong = khach.MaPhong;

                context.KhachThues.Remove(khach);

                // Quy tắc: Khi xóa người cuối cùng của phòng thì phòng trở lại "Trống"
                if (maPhong.HasValue)
                {
                    bool remaining = context.KhachThues.Any(k => k.MaPhong == maPhong && k.MaKhach != khach.MaKhach);
                    if (!remaining)
                    {
                        var phong = context.PhongTros.Find(maPhong.Value);
                        if (phong != null) phong.TinhTrang = "Trống";
                    }
                }

                context.SaveChanges();

                Log.Information("Đã xóa khách thuê mã {MaKhach}", _selectedKhachId);
                MessageBox.Show("Xóa khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
                LoadKhachThueData();
                PopulateFilterProvinces();
                ResetInputs();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khách thuê");
                MessageBox.Show("Đã xảy ra lỗi khi xóa khách thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            ResetInputs();
            LoadRooms();
            LoadKhachThueData();
            PopulateFilterProvinces();
            dgvKhachThue.ClearSelection();
        }

        private void ResetInputs()
        {
            _selectedKhachId = 0;
            txtHoTen.Text = "";
            txtSoDienThoai.Text = "";
            rbNam.Checked = true;
            rbNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Today;
            chkTamTru.Checked = false;

            if (cboPhong.Items.Count > 0) cboPhong.SelectedIndex = -1;
            if (cboTinhThanh.Items.Count > 0) cboTinhThanh.SelectedIndex = -1;
            cboTinhThanh.Text = "";

            cboPhuongXa.DataSource = null;
            cboPhuongXa.Items.Clear();
            cboPhuongXa.Text = "";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách thuê!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trọ cho khách!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhong.Focus();
                return false;
            }

            string tinhText = cboTinhThanh.Text.Trim();
            if (string.IsNullOrWhiteSpace(tinhText) || tinhText == "Đang tải...")
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Tỉnh/Thành quê quán!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTinhThanh.Focus();
                return false;
            }

            string phuongText = cboPhuongXa.Text.Trim();
            if (string.IsNullOrWhiteSpace(phuongText) || phuongText == "Đang tải...")
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Phường/Xã quê quán!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhuongXa.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region 6. Tìm kiếm & Lọc dữ liệu

        private void BtnTim_Click(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void BtnBoLoc_Click(object? sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            if (cboLocPhong.Items.Count > 0) cboLocPhong.SelectedIndex = 0;
            if (cboLocTinh.Items.Count > 0) cboLocTinh.SelectedIndex = 0;
            dgvKhachThue.DataSource = _allKhachList.ToList();
        }

        private void ApplyFilter()
        {
            var query = _allKhachList.AsEnumerable();

            // Lọc theo tên hoặc số điện thoại
            string keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword) && keyword != "Tìm theo tên hoặc SĐT")
            {
                query = query.Where(k =>
                    (!string.IsNullOrEmpty(k.HoTen) && k.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrEmpty(k.SoDienThoai) && k.SoDienThoai.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
            }

            // Lọc theo phòng
            if (cboLocPhong.SelectedIndex > 0 && cboLocPhong.SelectedValue is int maPhongFilter && maPhongFilter > 0)
            {
                query = query.Where(k => k.MaPhong == maPhongFilter);
            }

            // Lọc theo tỉnh
            if (cboLocTinh.SelectedIndex > 0 && cboLocTinh.SelectedItem != null)
            {
                string selectedTinh = cboLocTinh.SelectedItem.ToString() ?? "";
                if (selectedTinh != "Tất cả")
                {
                    query = query.Where(k =>
                        (!string.IsNullOrEmpty(k.TenTinh) && k.TenTinh.Contains(selectedTinh, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(k.QueQuan) && k.QueQuan.Contains(selectedTinh, StringComparison.OrdinalIgnoreCase)));
                }
            }

            dgvKhachThue.DataSource = query.ToList();
        }

        #endregion

        #region 7. Thử nghiệm lỗi toàn cục

        private void BtnGayLoiThu_Click(object? sender, EventArgs e)
        {
            // Ném ngoại lệ chưa bắt để kích hoạt Application.ThreadException
            throw new InvalidOperationException("Đây là ngoại lệ thử nghiệm để kiểm tra tính năng ghi log Serilog và bắt lỗi toàn cục của ứng dụng!");
        }

        #endregion
    }
}
