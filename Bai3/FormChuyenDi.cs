using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai3.Models;
using Bai3.Services;

namespace Bai3
{
    public partial class FormChuyenDi : Form
    {
        private int? _selectedId = null;
        private List<ChuyenDi> _allTrips = new();
        private WeatherForecastResult? _lastWeatherResult = null;
        private bool _isInitializing = true;

        public FormChuyenDi()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {
            Load += FormChuyenDi_Load;
            cboLanguage.SelectedIndexChanged += CboLanguage_SelectedIndexChanged;

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;

            btnXemThoiTiet.Click += BtnXemThoiTiet_Click;

            txtTimKiem.TextChanged += (s, e) => ApplyFilter();
            chkChuaHoanThanh.CheckedChanged += (s, e) => ApplyFilter();
            chkLocTheoNgay.CheckedChanged += ChkLocTheoNgay_CheckedChanged;
            dtpTuNgay.ValueChanged += (s, e) => ApplyFilter();
            dtpDenNgay.ValueChanged += (s, e) => ApplyFilter();
            btnTim.Click += (s, e) => ApplyFilter();
            btnBoLoc.Click += BtnBoLoc_Click;

            dgvChuyenDi.SelectionChanged += DgvChuyenDi_SelectionChanged;
            dgvChuyenDi.CellFormatting += DgvChuyenDi_CellFormatting;
            dgvChuyenDi.CellDoubleClick += (s, e) => BtnXemThoiTiet_Click(s, e);
        }

        private void FormChuyenDi_Load(object? sender, EventArgs e)
        {
            _isInitializing = true;

            // Load language preference
            LocalizationService.LoadSettings();

            // Setup language combo
            cboLanguage.Items.Clear();
            cboLanguage.Items.Add("Tiếng Việt");
            cboLanguage.Items.Add("English");
            cboLanguage.SelectedIndex = LocalizationService.IsVietnamese ? 0 : 1;

            // Setup grid
            SetupDataGridView();

            // Populate vehicle combo
            PopulateVehicles();

            // Default dates
            dtpNgayDi.Value = DateTime.Today;
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today.AddDays(30);

            // Apply localization
            ApplyLocalization();

            // Load data from DB
            LoadDataFromDatabase();

            // Set initial weather placeholder
            ShowInitialWeatherState();

            _isInitializing = false;

            // Select first row if available
            if (dgvChuyenDi.Rows.Count > 0)
            {
                dgvChuyenDi.Rows[0].Selected = true;
                PopulateInputsFromSelectedRow();
            }
        }

        private void SetupDataGridView()
        {
            dgvChuyenDi.AutoGenerateColumns = false;
            dgvChuyenDi.Columns.Clear();
            dgvChuyenDi.EnableHeadersVisualStyles = false;
            dgvChuyenDi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(238, 238, 238);
            dgvChuyenDi.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvChuyenDi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvChuyenDi.ColumnHeadersHeight = 35;
            dgvChuyenDi.RowTemplate.Height = 28;
            dgvChuyenDi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvChuyenDi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(25, 118, 210);
            dgvChuyenDi.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaChuyen",
                DataPropertyName = nameof(ChuyenDi.MaChuyen),
                HeaderText = LocalizationService.Get("ColId"),
                Width = 60,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenChuyen",
                DataPropertyName = nameof(ChuyenDi.TenChuyen),
                HeaderText = LocalizationService.Get("ColTripName"),
                Width = 190
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDiaDiem",
                DataPropertyName = nameof(ChuyenDi.DiaDiem),
                HeaderText = LocalizationService.Get("ColDestination"),
                Width = 130
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayDi",
                DataPropertyName = nameof(ChuyenDi.NgayDi),
                HeaderText = LocalizationService.Get("ColDate"),
                Width = 110,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoNguoi",
                DataPropertyName = nameof(ChuyenDi.SoNguoi),
                HeaderText = LocalizationService.Get("ColPeople"),
                Width = 80,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNganSach",
                DataPropertyName = nameof(ChuyenDi.NganSach),
                HeaderText = LocalizationService.Get("ColBudget"),
                Width = 120,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhuongTien",
                DataPropertyName = nameof(ChuyenDi.PhuongTien),
                HeaderText = LocalizationService.Get("ColTransport"),
                Width = 110
            });

            dgvChuyenDi.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colDaHoanThanh",
                DataPropertyName = nameof(ChuyenDi.DaHoanThanh),
                HeaderText = LocalizationService.Get("ColCompleted"),
                Width = 95,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvChuyenDi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGhiChu",
                DataPropertyName = nameof(ChuyenDi.GhiChu),
                HeaderText = LocalizationService.Get("ColNotes"),
                Width = 150
            });
        }

        private void PopulateVehicles()
        {
            string selected = cboPhuongTien.SelectedItem?.ToString() ?? string.Empty;
            cboPhuongTien.Items.Clear();
            var list = LocalizationService.GetVehicleList();
            foreach (var item in list)
            {
                cboPhuongTien.Items.Add(item);
            }

            // Restore selection or default to 0
            int index = 0;
            if (!string.IsNullOrEmpty(selected))
            {
                string translated = LocalizationService.TranslateVehicleFromDatabase(
                    LocalizationService.TranslateVehicleToDatabase(selected));
                int found = cboPhuongTien.Items.IndexOf(translated);
                if (found >= 0) index = found;
            }
            cboPhuongTien.SelectedIndex = index;
        }

        private void CboLanguage_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isInitializing) return;

            string targetLang = cboLanguage.SelectedIndex == 1 ? LocalizationService.English : LocalizationService.Vietnamese;
            if (targetLang != LocalizationService.CurrentLanguage)
            {
                LocalizationService.SetLanguage(targetLang);
                ApplyLocalization();
            }
        }

        private void ApplyLocalization()
        {
            Text = LocalizationService.Get("AppTitle");
            lblTitle.Text = LocalizationService.Get("AppTitle");
            lblLanguage.Text = LocalizationService.Get("Language") + ":";

            // Trip info
            grpTripInfo.Text = LocalizationService.Get("TripInfo");
            lblTenChuyen.Text = LocalizationService.Get("TripName") + ":";
            lblDiaDiem.Text = LocalizationService.Get("Destination") + ":";
            lblNgayDi.Text = LocalizationService.Get("DepartureDate") + ":";
            lblSoNguoi.Text = LocalizationService.Get("PeopleCount") + ":";
            lblNganSach.Text = LocalizationService.Get("Budget") + ":";
            lblPhuongTien.Text = LocalizationService.Get("Transport") + ":";
            chkDaHoanThanh.Text = LocalizationService.Get("IsCompleted");
            lblGhiChu.Text = LocalizationService.Get("Notes") + ":";

            btnThem.Text = LocalizationService.Get("BtnAdd");
            btnSua.Text = LocalizationService.Get("BtnEdit");
            btnXoa.Text = LocalizationService.Get("BtnDelete");
            btnLamMoi.Text = LocalizationService.Get("BtnReset");

            // Weather
            btnXemThoiTiet.Text = LocalizationService.Get("BtnCheckWeather");

            // Date formats
            string dateFormat = LocalizationService.IsVietnamese ? "dd/MM/yyyy" : "MM/dd/yyyy";
            dtpNgayDi.CustomFormat = dateFormat;
            dtpTuNgay.CustomFormat = dateFormat;
            dtpDenNgay.CustomFormat = dateFormat;

            // Search & filter
            txtTimKiem.PlaceholderText = LocalizationService.Get("SearchPlaceholder");
            chkChuaHoanThanh.Text = LocalizationService.Get("FilterUncompleted");
            chkLocTheoNgay.Text = LocalizationService.Get("FilterByDate");
            lblTuNgay.Text = LocalizationService.Get("FromDate") + ":";
            lblDenNgay.Text = LocalizationService.Get("ToDate") + ":";
            btnTim.Text = LocalizationService.Get("BtnSearch");
            btnBoLoc.Text = LocalizationService.Get("BtnShowAll");

            // Update column headers
            if (dgvChuyenDi.Columns["colMaChuyen"] is { } colId)
                colId.HeaderText = LocalizationService.Get("ColId");
            if (dgvChuyenDi.Columns["colTenChuyen"] is { } colName)
                colName.HeaderText = LocalizationService.Get("ColTripName");
            if (dgvChuyenDi.Columns["colDiaDiem"] is { } colDest)
                colDest.HeaderText = LocalizationService.Get("ColDestination");
            if (dgvChuyenDi.Columns["colNgayDi"] is { } colDate)
                colDate.HeaderText = LocalizationService.Get("ColDate");
            if (dgvChuyenDi.Columns["colSoNguoi"] is { } colPeople)
                colPeople.HeaderText = LocalizationService.Get("ColPeople");
            if (dgvChuyenDi.Columns["colNganSach"] is { } colBudget)
                colBudget.HeaderText = LocalizationService.Get("ColBudget");
            if (dgvChuyenDi.Columns["colPhuongTien"] is { } colTrans)
                colTrans.HeaderText = LocalizationService.Get("ColTransport");
            if (dgvChuyenDi.Columns["colDaHoanThanh"] is { } colDone)
                colDone.HeaderText = LocalizationService.Get("ColCompleted");
            if (dgvChuyenDi.Columns["colGhiChu"] is { } colNote)
                colNote.HeaderText = LocalizationService.Get("ColNotes");

            // Update vehicles dropdown
            PopulateVehicles();

            // Refresh weather panel display if current result exists
            if (_lastWeatherResult != null)
            {
                DisplayWeatherResult(_lastWeatherResult);
            }
            else
            {
                ShowInitialWeatherState();
            }

            // Invalidate grid for reformatting
            dgvChuyenDi.Invalidate();
        }

        private void ShowInitialWeatherState()
        {
            lblWeatherHeader.Text = LocalizationService.Get("WeatherEmpty");
            lblWeatherDesc.Text = "--";
            lblWeatherTemp.Text = LocalizationService.Get("Temperature", 0, 0).Replace("0°C - 0°C", "--°C - --°C");
            lblWeatherRainProb.Text = LocalizationService.Get("RainProbability", 0).Replace("0%", "--%");
            picWeatherIcon.Image = WeatherIconRenderer.CreateWeatherIcon(WeatherCategory.Clear);
            pnlWarning.Visible = false;
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                using var db = new QL_DaNgoaiContext();
                _allTrips = db.ChuyenDis.OrderBy(c => c.NgayDi).ToList();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    LocalizationService.Get("MsgErrorTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            string keyword = txtTimKiem.Text.Trim().ToLowerInvariant();
            bool onlyUncompleted = chkChuaHoanThanh.Checked;
            bool filterByDate = chkLocTheoNgay.Checked;
            DateOnly fromDate = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
            DateOnly toDate = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

            var query = _allTrips.AsEnumerable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(t =>
                    (t.TenChuyen != null && t.TenChuyen.ToLowerInvariant().Contains(keyword)) ||
                    (t.DiaDiem != null && t.DiaDiem.ToLowerInvariant().Contains(keyword)));
            }

            if (onlyUncompleted)
            {
                query = query.Where(t => t.DaHoanThanh != true);
            }

            if (filterByDate)
            {
                query = query.Where(t => t.NgayDi >= fromDate && t.NgayDi <= toDate);
            }

            var filteredList = query.ToList();
            dgvChuyenDi.DataSource = null;
            dgvChuyenDi.DataSource = filteredList;

            // Re-select previously selected or first
            if (_selectedId.HasValue)
            {
                foreach (DataGridViewRow row in dgvChuyenDi.Rows)
                {
                    if (row.DataBoundItem is ChuyenDi c && c.MaChuyen == _selectedId.Value)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void ChkLocTheoNgay_CheckedChanged(object? sender, EventArgs e)
        {
            dtpTuNgay.Enabled = chkLocTheoNgay.Checked;
            dtpDenNgay.Enabled = chkLocTheoNgay.Checked;
            ApplyFilter();
        }

        private void BtnBoLoc_Click(object? sender, EventArgs e)
        {
            txtTimKiem.Clear();
            chkChuaHoanThanh.Checked = false;
            chkLocTheoNgay.Checked = false;
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today.AddDays(30);
            ApplyFilter();
        }

        private void DgvChuyenDi_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.RowIndex < 0) return;

            string colName = dgvChuyenDi.Columns[e.ColumnIndex].Name;

            if (colName == "colNgayDi" && e.Value is DateOnly d)
            {
                e.Value = LocalizationService.FormatDate(d);
                e.FormattingApplied = true;
            }
            else if (colName == "colNganSach" && e.Value is decimal amount)
            {
                e.Value = LocalizationService.FormatCurrency(amount);
                e.FormattingApplied = true;
            }
            else if (colName == "colPhuongTien" && e.Value is string pt)
            {
                e.Value = LocalizationService.TranslateVehicleFromDatabase(pt);
                e.FormattingApplied = true;
            }
        }

        private void DgvChuyenDi_SelectionChanged(object? sender, EventArgs e)
        {
            PopulateInputsFromSelectedRow();
        }

        private void PopulateInputsFromSelectedRow()
        {
            if (dgvChuyenDi.SelectedRows.Count == 0) return;

            if (dgvChuyenDi.SelectedRows[0].DataBoundItem is ChuyenDi trip)
            {
                _selectedId = trip.MaChuyen;
                txtTenChuyen.Text = trip.TenChuyen ?? string.Empty;
                txtDiaDiem.Text = trip.DiaDiem ?? string.Empty;

                try
                {
                    dtpNgayDi.Value = trip.NgayDi.ToDateTime(TimeOnly.MinValue);
                }
                catch
                {
                    dtpNgayDi.Value = DateTime.Today;
                }

                numSoNguoi.Value = Math.Max(1, Math.Min(1000, trip.SoNguoi));
                numNganSach.Value = Math.Max(0, Math.Min(1000000000m, trip.NganSach));

                string displayVehicle = LocalizationService.TranslateVehicleFromDatabase(trip.PhuongTien ?? string.Empty);
                int vIndex = cboPhuongTien.Items.IndexOf(displayVehicle);
                if (vIndex >= 0)
                {
                    cboPhuongTien.SelectedIndex = vIndex;
                }
                else if (cboPhuongTien.Items.Count > 0)
                {
                    cboPhuongTien.SelectedIndex = 0;
                }

                chkDaHoanThanh.Checked = trip.DaHoanThanh ?? false;
                txtGhiChu.Text = trip.GhiChu ?? string.Empty;
            }
        }

        #region CRUD Operations

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            // Validation
            string tenChuyen = txtTenChuyen.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenChuyen))
            {
                MessageBox.Show(LocalizationService.Get("MsgNameRequired"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChuyen.Focus();
                return;
            }

            string diaDiem = txtDiaDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                MessageBox.Show(LocalizationService.Get("MsgDestinationRequired"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return;
            }

            // Kiểm tra: ngày đi không nhỏ hơn hôm nay khi thêm mới
            if (dtpNgayDi.Value.Date < DateTime.Today)
            {
                MessageBox.Show(LocalizationService.Get("MsgDateInvalid"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayDi.Focus();
                return;
            }

            // Số người >= 1
            if (numSoNguoi.Value < 1)
            {
                MessageBox.Show(LocalizationService.Get("MsgPeopleInvalid"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoNguoi.Focus();
                return;
            }

            // Ngân sách >= 0
            if (numNganSach.Value < 0)
            {
                MessageBox.Show(LocalizationService.Get("MsgBudgetInvalid"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numNganSach.Focus();
                return;
            }

            string vehicleDisplay = cboPhuongTien.SelectedItem?.ToString() ?? "Ô tô";
            string dbVehicle = LocalizationService.TranslateVehicleToDatabase(vehicleDisplay);

            var newTrip = new ChuyenDi
            {
                TenChuyen = tenChuyen,
                DiaDiem = diaDiem,
                NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date),
                SoNguoi = (int)numSoNguoi.Value,
                NganSach = numNganSach.Value,
                PhuongTien = dbVehicle,
                DaHoanThanh = chkDaHoanThanh.Checked,
                GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
            };

            try
            {
                using var db = new QL_DaNgoaiContext();
                db.ChuyenDis.Add(newTrip);
                db.SaveChanges();

                _selectedId = newTrip.MaChuyen;
                LoadDataFromDatabase();

                MessageBox.Show(LocalizationService.Get("MsgAddSuccess"), LocalizationService.Get("MsgSuccessTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chuyến đi: " + ex.Message, LocalizationService.Get("MsgErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show(LocalizationService.Get("MsgSelectTripToEdit"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenChuyen = txtTenChuyen.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenChuyen))
            {
                MessageBox.Show(LocalizationService.Get("MsgNameRequired"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChuyen.Focus();
                return;
            }

            string diaDiem = txtDiaDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                MessageBox.Show(LocalizationService.Get("MsgDestinationRequired"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return;
            }

            if (numSoNguoi.Value < 1)
            {
                MessageBox.Show(LocalizationService.Get("MsgPeopleInvalid"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numNganSach.Value < 0)
            {
                MessageBox.Show(LocalizationService.Get("MsgBudgetInvalid"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vehicleDisplay = cboPhuongTien.SelectedItem?.ToString() ?? "Ô tô";
            string dbVehicle = LocalizationService.TranslateVehicleToDatabase(vehicleDisplay);

            try
            {
                using var db = new QL_DaNgoaiContext();
                var trip = db.ChuyenDis.Find(_selectedId.Value);
                if (trip == null)
                {
                    MessageBox.Show("Chuyến đi không tồn tại trong cơ sở dữ liệu!", LocalizationService.Get("MsgErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                trip.TenChuyen = tenChuyen;
                trip.DiaDiem = diaDiem;
                trip.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);
                trip.SoNguoi = (int)numSoNguoi.Value;
                trip.NganSach = numNganSach.Value;
                trip.PhuongTien = dbVehicle;
                trip.DaHoanThanh = chkDaHoanThanh.Checked;
                trip.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                db.SaveChanges();
                LoadDataFromDatabase();

                MessageBox.Show(LocalizationService.Get("MsgEditSuccess"), LocalizationService.Get("MsgSuccessTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chuyến đi: " + ex.Message, LocalizationService.Get("MsgErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageBox.Show(LocalizationService.Get("MsgSelectTripToDelete"), LocalizationService.Get("MsgWarningTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                LocalizationService.Get("MsgConfirmDelete", txtTenChuyen.Text),
                LocalizationService.Get("MsgConfirmTitle"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using var db = new QL_DaNgoaiContext();
                    var trip = db.ChuyenDis.Find(_selectedId.Value);
                    if (trip != null)
                    {
                        db.ChuyenDis.Remove(trip);
                        db.SaveChanges();
                    }

                    _selectedId = null;
                    LoadDataFromDatabase();
                    BtnLamMoi_Click(sender, e);

                    MessageBox.Show(LocalizationService.Get("MsgDeleteSuccess"), LocalizationService.Get("MsgSuccessTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa chuyến đi: " + ex.Message, LocalizationService.Get("MsgErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            _selectedId = null;
            txtTenChuyen.Clear();
            txtDiaDiem.Clear();
            dtpNgayDi.Value = DateTime.Today;
            numSoNguoi.Value = 1;
            numNganSach.Value = 0;
            if (cboPhuongTien.Items.Count > 0) cboPhuongTien.SelectedIndex = 0;
            chkDaHoanThanh.Checked = false;
            txtGhiChu.Clear();

            dgvChuyenDi.ClearSelection();
            txtTenChuyen.Focus();
        }

        #endregion

        #region Weather Forecast API

        private async void BtnXemThoiTiet_Click(object? sender, EventArgs e)
        {
            string diaDiem = txtDiaDiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                MessageBox.Show(
                    LocalizationService.IsVietnamese ? "Vui lòng nhập hoặc chọn địa điểm trước khi tra cứu thời tiết!" : "Please enter or select a destination before checking weather!",
                    LocalizationService.Get("MsgWarningTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return;
            }

            DateOnly ngayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);

            // Bắt đầu gọi API: Khóa nút & bật ProgressBar Marquee
            btnXemThoiTiet.Enabled = false;
            progressBarWeather.Visible = true;
            lblWeatherHeader.Text = LocalizationService.Get("WeatherLoading");

            try
            {
                var result = await WeatherService.GetForecastAsync(diaDiem, ngayDi);
                _lastWeatherResult = result;
                DisplayWeatherResult(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    LocalizationService.Get("MsgNetworkError") + $"\n({ex.Message})",
                    LocalizationService.Get("MsgErrorTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                progressBarWeather.Visible = false;
                btnXemThoiTiet.Enabled = true;
            }
        }

        private void DisplayWeatherResult(WeatherForecastResult result)
        {
            string dateStr = LocalizationService.FormatDate(result.Date);

            if (result.LocationNotFound)
            {
                lblWeatherHeader.Text = LocalizationService.Get("WeatherTitle", dateStr, result.DestinationName);
                lblWeatherDesc.Text = LocalizationService.IsVietnamese ? "Không tìm thấy địa điểm" : "Location not found";
                lblWeatherTemp.Text = string.Empty;
                lblWeatherRainProb.Text = string.Empty;
                picWeatherIcon.Image = WeatherIconRenderer.CreateWeatherIcon(WeatherCategory.Fog);

                pnlWarning.Visible = true;
                pnlWarning.BackColor = Color.FromArgb(255, 236, 179);
                lblWarningText.Text = LocalizationService.Get("MsgLocationNotFound", result.DestinationName, result.LocationSuggestedName ?? "");
                return;
            }

            if (result.IsBeyondForecastRange)
            {
                lblWeatherHeader.Text = LocalizationService.Get("WeatherTitle", dateStr, result.DestinationName);
                lblWeatherDesc.Text = LocalizationService.Get("WeatherBeyond");
                lblWeatherTemp.Text = string.Empty;
                lblWeatherRainProb.Text = string.Empty;
                picWeatherIcon.Image = WeatherIconRenderer.CreateWeatherIcon(WeatherCategory.Cloudy);
                pnlWarning.Visible = false;
                return;
            }

            if (!result.Success)
            {
                lblWeatherHeader.Text = LocalizationService.Get("WeatherTitle", dateStr, result.DestinationName);
                lblWeatherDesc.Text = result.ErrorMessage ?? "Lỗi tra cứu";
                lblWeatherTemp.Text = string.Empty;
                lblWeatherRainProb.Text = string.Empty;
                pnlWarning.Visible = false;
                return;
            }

            // Hiển thị thời tiết hợp lệ
            lblWeatherHeader.Text = LocalizationService.Get("WeatherTitle", dateStr, result.DestinationName);
            lblWeatherDesc.Text = result.GetDescription(LocalizationService.IsVietnamese);
            lblWeatherTemp.Text = LocalizationService.Get("Temperature", result.MinTemperature, result.MaxTemperature);
            lblWeatherRainProb.Text = LocalizationService.Get("RainProbability", result.PrecipitationProbability);
            picWeatherIcon.Image = WeatherIconRenderer.CreateWeatherIcon(result.Category);

            // Kiểm tra cảnh báo mưa >= 60%
            if (result.PrecipitationProbability >= 60)
            {
                pnlWarning.Visible = true;
                pnlWarning.BackColor = Color.FromArgb(255, 224, 178); // Màu cam nhạt
                lblWarningIcon.Text = "!";
                lblWarningText.Text = LocalizationService.Get("RainWarning");
            }
            else
            {
                pnlWarning.Visible = false;
            }
        }

        #endregion
    }
}
