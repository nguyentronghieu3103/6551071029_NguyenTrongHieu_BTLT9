namespace bai5;

partial class FormMain
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tabMain = new TabControl();
        tabTour = new TabPage();
        dgvTour = new DataGridView();
        gbTourFilter = new GroupBox();
        btnHienTatCaTour = new Button();
        btnTimTour = new Button();
        txtTimTour = new TextBox();
        lblTimTour = new Label();
        gbTourInput = new GroupBox();
        btnLamMoiTour = new Button();
        btnXoaTour = new Button();
        btnSuaTour = new Button();
        btnThemTour = new Button();
        nudSoChoToiDa = new NumericUpDown();
        lblSoChoToiDa = new Label();
        dtpNgayKhoiHanh = new DateTimePicker();
        lblNgayKhoiHanh = new Label();
        nudGiaNgoaiTe = new NumericUpDown();
        lblGiaNgoaiTe = new Label();
        cboNgoaiTe = new ComboBox();
        lblNgoaiTe = new Label();
        txtDiemDen = new TextBox();
        lblDiemDen = new Label();
        txtTenTour = new TextBox();
        lblTenTour = new Label();
        tabKhachHang = new TabPage();
        dgvKhachHang = new DataGridView();
        gbKHFilter = new GroupBox();
        btnHienTatCaKH = new Button();
        btnTimKH = new Button();
        txtTimKH = new TextBox();
        lblTimKH = new Label();
        gbKHInput = new GroupBox();
        btnLamMoiKH = new Button();
        btnXoaKH = new Button();
        btnSuaKH = new Button();
        btnThemKH = new Button();
        txtEmail = new TextBox();
        lblEmail = new Label();
        txtSoDienThoai = new TextBox();
        lblSoDienThoai = new Label();
        txtHoTen = new TextBox();
        lblHoTen = new Label();
        tabDatTour = new TabPage();
        pnlDatTourBottom = new Panel();
        lblTongDoanhThu = new Label();
        dgvDatTour = new DataGridView();
        pnlDatTourFilter = new Panel();
        btnTatCaDatTour = new Button();
        btnTimDatTour = new Button();
        cboThangKhoiHanh = new ComboBox();
        lblThangKhoiHanh = new Label();
        txtTimDatTour = new TextBox();
        gbThongTinDat = new GroupBox();
        lblSoChoConLai = new Label();
        btnDatTour = new Button();
        lblTongTienVND = new Label();
        lblTongTienHeader = new Label();
        lblNguonTyGia = new Label();
        lblTyGia = new Label();
        lblTyGiaHeader = new Label();
        lblGiaNguoi = new Label();
        lblGiaNguoiHeader = new Label();
        nudSoNguoi = new NumericUpDown();
        lblSoNguoi = new Label();
        cboTour = new ComboBox();
        lblTour = new Label();
        cboKhachHang = new ComboBox();
        lblKhachHang = new Label();
        tabMain.SuspendLayout();
        tabTour.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTour).BeginInit();
        gbTourFilter.SuspendLayout();
        gbTourInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoChoToiDa).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudGiaNgoaiTe).BeginInit();
        tabKhachHang.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
        gbKHFilter.SuspendLayout();
        gbKHInput.SuspendLayout();
        tabDatTour.SuspendLayout();
        pnlDatTourBottom.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDatTour).BeginInit();
        pnlDatTourFilter.SuspendLayout();
        gbThongTinDat.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
        SuspendLayout();
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabTour);
        tabMain.Controls.Add(tabKhachHang);
        tabMain.Controls.Add(tabDatTour);
        tabMain.Dock = DockStyle.Fill;
        tabMain.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        tabMain.Location = new Point(0, 0);
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 2;
        tabMain.Size = new Size(1064, 621);
        tabMain.TabIndex = 0;
        tabMain.SelectedIndexChanged += tabMain_SelectedIndexChanged;
        // 
        // tabTour
        // 
        tabTour.Controls.Add(dgvTour);
        tabTour.Controls.Add(gbTourFilter);
        tabTour.Controls.Add(gbTourInput);
        tabTour.Location = new Point(4, 26);
        tabTour.Name = "tabTour";
        tabTour.Padding = new Padding(10);
        tabTour.Size = new Size(1056, 591);
        tabTour.TabIndex = 0;
        tabTour.Text = "Tour";
        tabTour.UseVisualStyleBackColor = true;
        // 
        // dgvTour
        // 
        dgvTour.AllowUserToAddRows = false;
        dgvTour.AllowUserToDeleteRows = false;
        dgvTour.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvTour.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvTour.BackgroundColor = Color.White;
        dgvTour.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTour.Location = new Point(10, 235);
        dgvTour.MultiSelect = false;
        dgvTour.Name = "dgvTour";
        dgvTour.ReadOnly = true;
        dgvTour.RowHeadersWidth = 35;
        dgvTour.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTour.Size = new Size(1036, 346);
        dgvTour.TabIndex = 2;
        dgvTour.CellClick += dgvTour_CellClick;
        // 
        // gbTourFilter
        // 
        gbTourFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gbTourFilter.Controls.Add(btnHienTatCaTour);
        gbTourFilter.Controls.Add(btnTimTour);
        gbTourFilter.Controls.Add(txtTimTour);
        gbTourFilter.Controls.Add(lblTimTour);
        gbTourFilter.Location = new Point(10, 168);
        gbTourFilter.Name = "gbTourFilter";
        gbTourFilter.Size = new Size(1036, 60);
        gbTourFilter.TabIndex = 1;
        gbTourFilter.TabStop = false;
        gbTourFilter.Text = "Tìm kiếm tour";
        // 
        // btnHienTatCaTour
        // 
        btnHienTatCaTour.Location = new Point(560, 22);
        btnHienTatCaTour.Name = "btnHienTatCaTour";
        btnHienTatCaTour.Size = new Size(95, 30);
        btnHienTatCaTour.TabIndex = 3;
        btnHienTatCaTour.Text = "Tất cả";
        btnHienTatCaTour.UseVisualStyleBackColor = true;
        btnHienTatCaTour.Click += btnHienTatCaTour_Click;
        // 
        // btnTimTour
        // 
        btnTimTour.Location = new Point(450, 22);
        btnTimTour.Name = "btnTimTour";
        btnTimTour.Size = new Size(95, 30);
        btnTimTour.TabIndex = 2;
        btnTimTour.Text = "Tìm";
        btnTimTour.UseVisualStyleBackColor = true;
        btnTimTour.Click += btnTimTour_Click;
        // 
        // txtTimTour
        // 
        txtTimTour.Location = new Point(180, 24);
        txtTimTour.Name = "txtTimTour";
        txtTimTour.PlaceholderText = "Nhập tên tour hoặc điểm đến...";
        txtTimTour.Size = new Size(250, 25);
        txtTimTour.TabIndex = 1;
        txtTimTour.TextChanged += txtTimTour_TextChanged;
        // 
        // lblTimTour
        // 
        lblTimTour.AutoSize = true;
        lblTimTour.Location = new Point(15, 27);
        lblTimTour.Name = "lblTimTour";
        lblTimTour.Size = new Size(157, 19);
        lblTimTour.TabIndex = 0;
        lblTimTour.Text = "Tìm theo tên / điểm đến:";
        // 
        // gbTourInput
        // 
        gbTourInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gbTourInput.Controls.Add(btnLamMoiTour);
        gbTourInput.Controls.Add(btnXoaTour);
        gbTourInput.Controls.Add(btnSuaTour);
        gbTourInput.Controls.Add(btnThemTour);
        gbTourInput.Controls.Add(nudSoChoToiDa);
        gbTourInput.Controls.Add(lblSoChoToiDa);
        gbTourInput.Controls.Add(dtpNgayKhoiHanh);
        gbTourInput.Controls.Add(lblNgayKhoiHanh);
        gbTourInput.Controls.Add(nudGiaNgoaiTe);
        gbTourInput.Controls.Add(lblGiaNgoaiTe);
        gbTourInput.Controls.Add(cboNgoaiTe);
        gbTourInput.Controls.Add(lblNgoaiTe);
        gbTourInput.Controls.Add(txtDiemDen);
        gbTourInput.Controls.Add(lblDiemDen);
        gbTourInput.Controls.Add(txtTenTour);
        gbTourInput.Controls.Add(lblTenTour);
        gbTourInput.Location = new Point(10, 10);
        gbTourInput.Name = "gbTourInput";
        gbTourInput.Size = new Size(1036, 150);
        gbTourInput.TabIndex = 0;
        gbTourInput.TabStop = false;
        gbTourInput.Text = "Thông tin Tour";
        // 
        // btnLamMoiTour
        // 
        btnLamMoiTour.Location = new Point(410, 105);
        btnLamMoiTour.Name = "btnLamMoiTour";
        btnLamMoiTour.Size = new Size(90, 32);
        btnLamMoiTour.TabIndex = 15;
        btnLamMoiTour.Text = "Làm mới";
        btnLamMoiTour.UseVisualStyleBackColor = true;
        btnLamMoiTour.Click += btnLamMoiTour_Click;
        // 
        // btnXoaTour
        // 
        btnXoaTour.BackColor = Color.FromArgb(220, 53, 69);
        btnXoaTour.ForeColor = Color.White;
        btnXoaTour.Location = new Point(305, 105);
        btnXoaTour.Name = "btnXoaTour";
        btnXoaTour.Size = new Size(90, 32);
        btnXoaTour.TabIndex = 14;
        btnXoaTour.Text = "Xóa";
        btnXoaTour.UseVisualStyleBackColor = false;
        btnXoaTour.Click += btnXoaTour_Click;
        // 
        // btnSuaTour
        // 
        btnSuaTour.BackColor = Color.FromArgb(0, 123, 255);
        btnSuaTour.ForeColor = Color.White;
        btnSuaTour.Location = new Point(200, 105);
        btnSuaTour.Name = "btnSuaTour";
        btnSuaTour.Size = new Size(90, 32);
        btnSuaTour.TabIndex = 13;
        btnSuaTour.Text = "Sửa";
        btnSuaTour.UseVisualStyleBackColor = false;
        btnSuaTour.Click += btnSuaTour_Click;
        // 
        // btnThemTour
        // 
        btnThemTour.BackColor = Color.FromArgb(40, 167, 69);
        btnThemTour.ForeColor = Color.White;
        btnThemTour.Location = new Point(95, 105);
        btnThemTour.Name = "btnThemTour";
        btnThemTour.Size = new Size(90, 32);
        btnThemTour.TabIndex = 12;
        btnThemTour.Text = "Thêm";
        btnThemTour.UseVisualStyleBackColor = false;
        btnThemTour.Click += btnThemTour_Click;
        // 
        // nudSoChoToiDa
        // 
        nudSoChoToiDa.Location = new Point(810, 65);
        nudSoChoToiDa.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudSoChoToiDa.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudSoChoToiDa.Name = "nudSoChoToiDa";
        nudSoChoToiDa.Size = new Size(110, 25);
        nudSoChoToiDa.TabIndex = 11;
        nudSoChoToiDa.TextAlign = HorizontalAlignment.Center;
        nudSoChoToiDa.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // lblSoChoToiDa
        // 
        lblSoChoToiDa.AutoSize = true;
        lblSoChoToiDa.Location = new Point(710, 68);
        lblSoChoToiDa.Name = "lblSoChoToiDa";
        lblSoChoToiDa.Size = new Size(95, 19);
        lblSoChoToiDa.TabIndex = 10;
        lblSoChoToiDa.Text = "Số chỗ tối đa:";
        // 
        // dtpNgayKhoiHanh
        // 
        dtpNgayKhoiHanh.CustomFormat = "dd/MM/yyyy";
        dtpNgayKhoiHanh.Format = DateTimePickerFormat.Custom;
        dtpNgayKhoiHanh.Location = new Point(810, 26);
        dtpNgayKhoiHanh.Name = "dtpNgayKhoiHanh";
        dtpNgayKhoiHanh.Size = new Size(140, 25);
        dtpNgayKhoiHanh.TabIndex = 9;
        // 
        // lblNgayKhoiHanh
        // 
        lblNgayKhoiHanh.AutoSize = true;
        lblNgayKhoiHanh.Location = new Point(710, 30);
        lblNgayKhoiHanh.Name = "lblNgayKhoiHanh";
        lblNgayKhoiHanh.Size = new Size(74, 19);
        lblNgayKhoiHanh.TabIndex = 8;
        lblNgayKhoiHanh.Text = "Khởi hành:";
        // 
        // nudGiaNgoaiTe
        // 
        nudGiaNgoaiTe.DecimalPlaces = 2;
        nudGiaNgoaiTe.Location = new Point(490, 65);
        nudGiaNgoaiTe.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
        nudGiaNgoaiTe.Name = "nudGiaNgoaiTe";
        nudGiaNgoaiTe.Size = new Size(180, 25);
        nudGiaNgoaiTe.TabIndex = 7;
        nudGiaNgoaiTe.TextAlign = HorizontalAlignment.Right;
        nudGiaNgoaiTe.ThousandsSeparator = true;
        // 
        // lblGiaNgoaiTe
        // 
        lblGiaNgoaiTe.AutoSize = true;
        lblGiaNgoaiTe.Location = new Point(400, 68);
        lblGiaNgoaiTe.Name = "lblGiaNgoaiTe";
        lblGiaNgoaiTe.Size = new Size(86, 19);
        lblGiaNgoaiTe.TabIndex = 6;
        lblGiaNgoaiTe.Text = "Giá ngoại tệ:";
        // 
        // cboNgoaiTe
        // 
        cboNgoaiTe.DropDownStyle = ComboBoxStyle.DropDownList;
        cboNgoaiTe.FormattingEnabled = true;
        cboNgoaiTe.Items.AddRange(new object[] { "THB", "KRW", "JPY", "USD", "VND" });
        cboNgoaiTe.Location = new Point(490, 26);
        cboNgoaiTe.Name = "cboNgoaiTe";
        cboNgoaiTe.Size = new Size(100, 25);
        cboNgoaiTe.TabIndex = 5;
        // 
        // lblNgoaiTe
        // 
        lblNgoaiTe.AutoSize = true;
        lblNgoaiTe.Location = new Point(400, 30);
        lblNgoaiTe.Name = "lblNgoaiTe";
        lblNgoaiTe.Size = new Size(66, 19);
        lblNgoaiTe.TabIndex = 4;
        lblNgoaiTe.Text = "Ngoại tệ:";
        // 
        // txtDiemDen
        // 
        txtDiemDen.Location = new Point(95, 65);
        txtDiemDen.Name = "txtDiemDen";
        txtDiemDen.Size = new Size(270, 25);
        txtDiemDen.TabIndex = 3;
        // 
        // lblDiemDen
        // 
        lblDiemDen.AutoSize = true;
        lblDiemDen.Location = new Point(15, 68);
        lblDiemDen.Name = "lblDiemDen";
        lblDiemDen.Size = new Size(71, 19);
        lblDiemDen.TabIndex = 2;
        lblDiemDen.Text = "Điểm đến:";
        // 
        // txtTenTour
        // 
        txtTenTour.Location = new Point(95, 26);
        txtTenTour.Name = "txtTenTour";
        txtTenTour.Size = new Size(270, 25);
        txtTenTour.TabIndex = 1;
        // 
        // lblTenTour
        // 
        lblTenTour.AutoSize = true;
        lblTenTour.Location = new Point(15, 30);
        lblTenTour.Name = "lblTenTour";
        lblTenTour.Size = new Size(64, 19);
        lblTenTour.TabIndex = 0;
        lblTenTour.Text = "Tên tour:";
        // 
        // tabKhachHang
        // 
        tabKhachHang.Controls.Add(dgvKhachHang);
        tabKhachHang.Controls.Add(gbKHFilter);
        tabKhachHang.Controls.Add(gbKHInput);
        tabKhachHang.Location = new Point(4, 26);
        tabKhachHang.Name = "tabKhachHang";
        tabKhachHang.Padding = new Padding(10);
        tabKhachHang.Size = new Size(1056, 591);
        tabKhachHang.TabIndex = 1;
        tabKhachHang.Text = "Khách hàng";
        tabKhachHang.UseVisualStyleBackColor = true;
        // 
        // dgvKhachHang
        // 
        dgvKhachHang.AllowUserToAddRows = false;
        dgvKhachHang.AllowUserToDeleteRows = false;
        dgvKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvKhachHang.BackgroundColor = Color.White;
        dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvKhachHang.Location = new Point(10, 215);
        dgvKhachHang.MultiSelect = false;
        dgvKhachHang.Name = "dgvKhachHang";
        dgvKhachHang.ReadOnly = true;
        dgvKhachHang.RowHeadersWidth = 35;
        dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvKhachHang.Size = new Size(1036, 366);
        dgvKhachHang.TabIndex = 2;
        dgvKhachHang.CellClick += dgvKhachHang_CellClick;
        // 
        // gbKHFilter
        // 
        gbKHFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gbKHFilter.Controls.Add(btnHienTatCaKH);
        gbKHFilter.Controls.Add(btnTimKH);
        gbKHFilter.Controls.Add(txtTimKH);
        gbKHFilter.Controls.Add(lblTimKH);
        gbKHFilter.Location = new Point(10, 148);
        gbKHFilter.Name = "gbKHFilter";
        gbKHFilter.Size = new Size(1036, 60);
        gbKHFilter.TabIndex = 1;
        gbKHFilter.TabStop = false;
        gbKHFilter.Text = "Tìm kiếm khách hàng";
        // 
        // btnHienTatCaKH
        // 
        btnHienTatCaKH.Location = new Point(540, 22);
        btnHienTatCaKH.Name = "btnHienTatCaKH";
        btnHienTatCaKH.Size = new Size(95, 30);
        btnHienTatCaKH.TabIndex = 3;
        btnHienTatCaKH.Text = "Tất cả";
        btnHienTatCaKH.UseVisualStyleBackColor = true;
        btnHienTatCaKH.Click += btnHienTatCaKH_Click;
        // 
        // btnTimKH
        // 
        btnTimKH.Location = new Point(430, 22);
        btnTimKH.Name = "btnTimKH";
        btnTimKH.Size = new Size(95, 30);
        btnTimKH.TabIndex = 2;
        btnTimKH.Text = "Tìm";
        btnTimKH.UseVisualStyleBackColor = true;
        btnTimKH.Click += btnTimKH_Click;
        // 
        // txtTimKH
        // 
        txtTimKH.Location = new Point(160, 24);
        txtTimKH.Name = "txtTimKH";
        txtTimKH.PlaceholderText = "Nhập tên hoặc số điện thoại...";
        txtTimKH.Size = new Size(250, 25);
        txtTimKH.TabIndex = 1;
        txtTimKH.TextChanged += txtTimKH_TextChanged;
        // 
        // lblTimKH
        // 
        lblTimKH.AutoSize = true;
        lblTimKH.Location = new Point(15, 27);
        lblTimKH.Name = "lblTimKH";
        lblTimKH.Size = new Size(137, 19);
        lblTimKH.TabIndex = 0;
        lblTimKH.Text = "Tìm theo tên / SĐT:";
        // 
        // gbKHInput
        // 
        gbKHInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gbKHInput.Controls.Add(btnLamMoiKH);
        gbKHInput.Controls.Add(btnXoaKH);
        gbKHInput.Controls.Add(btnSuaKH);
        gbKHInput.Controls.Add(btnThemKH);
        gbKHInput.Controls.Add(txtEmail);
        gbKHInput.Controls.Add(lblEmail);
        gbKHInput.Controls.Add(txtSoDienThoai);
        gbKHInput.Controls.Add(lblSoDienThoai);
        gbKHInput.Controls.Add(txtHoTen);
        gbKHInput.Controls.Add(lblHoTen);
        gbKHInput.Location = new Point(10, 10);
        gbKHInput.Name = "gbKHInput";
        gbKHInput.Size = new Size(1036, 130);
        gbKHInput.TabIndex = 0;
        gbKHInput.TabStop = false;
        gbKHInput.Text = "Thông tin Khách hàng";
        // 
        // btnLamMoiKH
        // 
        btnLamMoiKH.Location = new Point(430, 75);
        btnLamMoiKH.Name = "btnLamMoiKH";
        btnLamMoiKH.Size = new Size(95, 32);
        btnLamMoiKH.TabIndex = 9;
        btnLamMoiKH.Text = "Làm mới";
        btnLamMoiKH.UseVisualStyleBackColor = true;
        btnLamMoiKH.Click += btnLamMoiKH_Click;
        // 
        // btnXoaKH
        // 
        btnXoaKH.BackColor = Color.FromArgb(220, 53, 69);
        btnXoaKH.ForeColor = Color.White;
        btnXoaKH.Location = new Point(320, 75);
        btnXoaKH.Name = "btnXoaKH";
        btnXoaKH.Size = new Size(95, 32);
        btnXoaKH.TabIndex = 8;
        btnXoaKH.Text = "Xóa";
        btnXoaKH.UseVisualStyleBackColor = false;
        btnXoaKH.Click += btnXoaKH_Click;
        // 
        // btnSuaKH
        // 
        btnSuaKH.BackColor = Color.FromArgb(0, 123, 255);
        btnSuaKH.ForeColor = Color.White;
        btnSuaKH.Location = new Point(210, 75);
        btnSuaKH.Name = "btnSuaKH";
        btnSuaKH.Size = new Size(95, 32);
        btnSuaKH.TabIndex = 7;
        btnSuaKH.Text = "Sửa";
        btnSuaKH.UseVisualStyleBackColor = false;
        btnSuaKH.Click += btnSuaKH_Click;
        // 
        // btnThemKH
        // 
        btnThemKH.BackColor = Color.FromArgb(40, 167, 69);
        btnThemKH.ForeColor = Color.White;
        btnThemKH.Location = new Point(100, 75);
        btnThemKH.Name = "btnThemKH";
        btnThemKH.Size = new Size(95, 32);
        btnThemKH.TabIndex = 6;
        btnThemKH.Text = "Thêm";
        btnThemKH.UseVisualStyleBackColor = false;
        btnThemKH.Click += btnThemKH_Click;
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(740, 26);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(260, 25);
        txtEmail.TabIndex = 5;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(685, 30);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(44, 19);
        lblEmail.TabIndex = 4;
        lblEmail.Text = "Email:";
        // 
        // txtSoDienThoai
        // 
        txtSoDienThoai.Location = new Point(470, 26);
        txtSoDienThoai.Name = "txtSoDienThoai";
        txtSoDienThoai.Size = new Size(180, 25);
        txtSoDienThoai.TabIndex = 3;
        // 
        // lblSoDienThoai
        // 
        lblSoDienThoai.AutoSize = true;
        lblSoDienThoai.Location = new Point(415, 30);
        lblSoDienThoai.Name = "lblSoDienThoai";
        lblSoDienThoai.Size = new Size(39, 19);
        lblSoDienThoai.TabIndex = 2;
        lblSoDienThoai.Text = "SĐT:";
        // 
        // txtHoTen
        // 
        txtHoTen.Location = new Point(100, 26);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.Size = new Size(280, 25);
        txtHoTen.TabIndex = 1;
        // 
        // lblHoTen
        // 
        lblHoTen.AutoSize = true;
        lblHoTen.Location = new Point(15, 30);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(54, 19);
        lblHoTen.TabIndex = 0;
        lblHoTen.Text = "Họ tên:";
        // 
        // tabDatTour
        // 
        tabDatTour.Controls.Add(pnlDatTourBottom);
        tabDatTour.Controls.Add(dgvDatTour);
        tabDatTour.Controls.Add(pnlDatTourFilter);
        tabDatTour.Controls.Add(gbThongTinDat);
        tabDatTour.Location = new Point(4, 26);
        tabDatTour.Name = "tabDatTour";
        tabDatTour.Padding = new Padding(10);
        tabDatTour.Size = new Size(1056, 591);
        tabDatTour.TabIndex = 2;
        tabDatTour.Text = "Đặt tour";
        tabDatTour.UseVisualStyleBackColor = true;
        // 
        // pnlDatTourBottom
        // 
        pnlDatTourBottom.Controls.Add(lblTongDoanhThu);
        pnlDatTourBottom.Dock = DockStyle.Bottom;
        pnlDatTourBottom.Location = new Point(10, 546);
        pnlDatTourBottom.Name = "pnlDatTourBottom";
        pnlDatTourBottom.Size = new Size(1036, 35);
        pnlDatTourBottom.TabIndex = 3;
        // 
        // lblTongDoanhThu
        // 
        lblTongDoanhThu.Dock = DockStyle.Right;
        lblTongDoanhThu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblTongDoanhThu.Location = new Point(536, 0);
        lblTongDoanhThu.Name = "lblTongDoanhThu";
        lblTongDoanhThu.Size = new Size(500, 35);
        lblTongDoanhThu.TabIndex = 0;
        lblTongDoanhThu.Text = "Tổng doanh thu: 0 đ";
        lblTongDoanhThu.TextAlign = ContentAlignment.MiddleRight;
        // 
        // dgvDatTour
        // 
        dgvDatTour.AllowUserToAddRows = false;
        dgvDatTour.AllowUserToDeleteRows = false;
        dgvDatTour.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvDatTour.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvDatTour.BackgroundColor = Color.White;
        dgvDatTour.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDatTour.Location = new Point(10, 275);
        dgvDatTour.MultiSelect = false;
        dgvDatTour.Name = "dgvDatTour";
        dgvDatTour.ReadOnly = true;
        dgvDatTour.RowHeadersWidth = 35;
        dgvDatTour.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDatTour.Size = new Size(1036, 265);
        dgvDatTour.TabIndex = 2;
        // 
        // pnlDatTourFilter
        // 
        pnlDatTourFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlDatTourFilter.Controls.Add(btnTatCaDatTour);
        pnlDatTourFilter.Controls.Add(btnTimDatTour);
        pnlDatTourFilter.Controls.Add(cboThangKhoiHanh);
        pnlDatTourFilter.Controls.Add(lblThangKhoiHanh);
        pnlDatTourFilter.Controls.Add(txtTimDatTour);
        pnlDatTourFilter.Location = new Point(10, 230);
        pnlDatTourFilter.Name = "pnlDatTourFilter";
        pnlDatTourFilter.Size = new Size(1036, 38);
        pnlDatTourFilter.TabIndex = 1;
        // 
        // btnTatCaDatTour
        // 
        btnTatCaDatTour.Location = new Point(680, 4);
        btnTatCaDatTour.Name = "btnTatCaDatTour";
        btnTatCaDatTour.Size = new Size(80, 30);
        btnTatCaDatTour.TabIndex = 4;
        btnTatCaDatTour.Text = "Tất cả";
        btnTatCaDatTour.UseVisualStyleBackColor = true;
        btnTatCaDatTour.Click += btnTatCaDatTour_Click;
        // 
        // btnTimDatTour
        // 
        btnTimDatTour.Location = new Point(600, 4);
        btnTimDatTour.Name = "btnTimDatTour";
        btnTimDatTour.Size = new Size(70, 30);
        btnTimDatTour.TabIndex = 3;
        btnTimDatTour.Text = "Tìm";
        btnTimDatTour.UseVisualStyleBackColor = true;
        btnTimDatTour.Click += btnTimDatTour_Click;
        // 
        // cboThangKhoiHanh
        // 
        cboThangKhoiHanh.DropDownStyle = ComboBoxStyle.DropDownList;
        cboThangKhoiHanh.FormattingEnabled = true;
        cboThangKhoiHanh.Location = new Point(460, 6);
        cboThangKhoiHanh.Name = "cboThangKhoiHanh";
        cboThangKhoiHanh.Size = new Size(125, 25);
        cboThangKhoiHanh.TabIndex = 2;
        cboThangKhoiHanh.SelectedIndexChanged += cboThangKhoiHanh_SelectedIndexChanged;
        // 
        // lblThangKhoiHanh
        // 
        lblThangKhoiHanh.AutoSize = true;
        lblThangKhoiHanh.Location = new Point(340, 9);
        lblThangKhoiHanh.Name = "lblThangKhoiHanh";
        lblThangKhoiHanh.Size = new Size(114, 19);
        lblThangKhoiHanh.TabIndex = 1;
        lblThangKhoiHanh.Text = "Tháng khởi hành:";
        // 
        // txtTimDatTour
        // 
        txtTimDatTour.Location = new Point(0, 6);
        txtTimDatTour.Name = "txtTimDatTour";
        txtTimDatTour.PlaceholderText = "Tìm theo tên khách hoặc tên tour";
        txtTimDatTour.Size = new Size(320, 25);
        txtTimDatTour.TabIndex = 0;
        txtTimDatTour.TextChanged += txtTimDatTour_TextChanged;
        // 
        // gbThongTinDat
        // 
        gbThongTinDat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gbThongTinDat.Controls.Add(lblSoChoConLai);
        gbThongTinDat.Controls.Add(btnDatTour);
        gbThongTinDat.Controls.Add(lblTongTienVND);
        gbThongTinDat.Controls.Add(lblTongTienHeader);
        gbThongTinDat.Controls.Add(lblNguonTyGia);
        gbThongTinDat.Controls.Add(lblTyGia);
        gbThongTinDat.Controls.Add(lblTyGiaHeader);
        gbThongTinDat.Controls.Add(lblGiaNguoi);
        gbThongTinDat.Controls.Add(lblGiaNguoiHeader);
        gbThongTinDat.Controls.Add(nudSoNguoi);
        gbThongTinDat.Controls.Add(lblSoNguoi);
        gbThongTinDat.Controls.Add(cboTour);
        gbThongTinDat.Controls.Add(lblTour);
        gbThongTinDat.Controls.Add(cboKhachHang);
        gbThongTinDat.Controls.Add(lblKhachHang);
        gbThongTinDat.Location = new Point(10, 10);
        gbThongTinDat.Name = "gbThongTinDat";
        gbThongTinDat.Size = new Size(1036, 215);
        gbThongTinDat.TabIndex = 0;
        gbThongTinDat.TabStop = false;
        gbThongTinDat.Text = "Thông tin đặt tour";
        // 
        // lblSoChoConLai
        // 
        lblSoChoConLai.AutoSize = true;
        lblSoChoConLai.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point);
        lblSoChoConLai.ForeColor = Color.DimGray;
        lblSoChoConLai.Location = new Point(200, 93);
        lblSoChoConLai.Name = "lblSoChoConLai";
        lblSoChoConLai.Size = new Size(111, 17);
        lblSoChoConLai.TabIndex = 14;
        lblSoChoConLai.Text = "(Số chỗ còn lại: ...)";
        // 
        // btnDatTour
        // 
        btnDatTour.BackColor = Color.FromArgb(40, 167, 69);
        btnDatTour.FlatStyle = FlatStyle.Flat;
        btnDatTour.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnDatTour.ForeColor = Color.White;
        btnDatTour.Location = new Point(105, 172);
        btnDatTour.Name = "btnDatTour";
        btnDatTour.Size = new Size(130, 36);
        btnDatTour.TabIndex = 13;
        btnDatTour.Text = "Đặt tour";
        btnDatTour.UseVisualStyleBackColor = false;
        btnDatTour.Click += btnDatTour_Click;
        // 
        // lblTongTienVND
        // 
        lblTongTienVND.AutoSize = true;
        lblTongTienVND.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
        lblTongTienVND.ForeColor = Color.DarkRed;
        lblTongTienVND.Location = new Point(100, 140);
        lblTongTienVND.Name = "lblTongTienVND";
        lblTongTienVND.Size = new Size(45, 28);
        lblTongTienVND.TabIndex = 12;
        lblTongTienVND.Text = "0 đ";
        // 
        // lblTongTienHeader
        // 
        lblTongTienHeader.AutoSize = true;
        lblTongTienHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        lblTongTienHeader.ForeColor = Color.DarkRed;
        lblTongTienHeader.Location = new Point(15, 144);
        lblTongTienHeader.Name = "lblTongTienHeader";
        lblTongTienHeader.Size = new Size(80, 20);
        lblTongTienHeader.TabIndex = 11;
        lblTongTienHeader.Text = "Tổng tiền:";
        // 
        // lblNguonTyGia
        // 
        lblNguonTyGia.AutoSize = true;
        lblNguonTyGia.BackColor = Color.FromArgb(240, 240, 240);
        lblNguonTyGia.BorderStyle = BorderStyle.FixedSingle;
        lblNguonTyGia.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
        lblNguonTyGia.ForeColor = Color.FromArgb(64, 64, 64);
        lblNguonTyGia.Location = new Point(275, 120);
        lblNguonTyGia.Name = "lblNguonTyGia";
        lblNguonTyGia.Padding = new Padding(2);
        lblNguonTyGia.Size = new Size(135, 21);
        lblNguonTyGia.TabIndex = 10;
        lblNguonTyGia.Text = "Tỷ giá lấy từ: cdn.jsdelivr.net";
        // 
        // lblTyGia
        // 
        lblTyGia.AutoSize = true;
        lblTyGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblTyGia.Location = new Point(125, 120);
        lblTyGia.Name = "lblTyGia";
        lblTyGia.Size = new Size(136, 19);
        lblTyGia.TabIndex = 9;
        lblTyGia.Text = "1 THB = 778 VND";
        // 
        // lblTyGiaHeader
        // 
        lblTyGiaHeader.AutoSize = true;
        lblTyGiaHeader.Location = new Point(15, 120);
        lblTyGiaHeader.Name = "lblTyGiaHeader";
        lblTyGiaHeader.Size = new Size(111, 19);
        lblTyGiaHeader.TabIndex = 8;
        lblTyGiaHeader.Text = "Tỷ giá hôm nay:";
        // 
        // lblGiaNguoi
        // 
        lblGiaNguoi.AutoSize = true;
        lblGiaNguoi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblGiaNguoi.Location = new Point(105, 93);
        lblGiaNguoi.Name = "lblGiaNguoi";
        lblGiaNguoi.Size = new Size(74, 19);
        lblGiaNguoi.TabIndex = 7;
        lblGiaNguoi.Text = "9.500 THB";
        // 
        // lblGiaNguoiHeader
        // 
        lblGiaNguoiHeader.AutoSize = true;
        lblGiaNguoiHeader.Location = new Point(15, 93);
        lblGiaNguoiHeader.Name = "lblGiaNguoiHeader";
        lblGiaNguoiHeader.Size = new Size(77, 19);
        lblGiaNguoiHeader.TabIndex = 6;
        lblGiaNguoiHeader.Text = "Giá/người:";
        // 
        // nudSoNguoi
        // 
        nudSoNguoi.Location = new Point(105, 63);
        nudSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudSoNguoi.Name = "nudSoNguoi";
        nudSoNguoi.Size = new Size(75, 25);
        nudSoNguoi.TabIndex = 5;
        nudSoNguoi.TextAlign = HorizontalAlignment.Center;
        nudSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
        nudSoNguoi.ValueChanged += nudSoNguoi_ValueChanged;
        // 
        // lblSoNguoi
        // 
        lblSoNguoi.AutoSize = true;
        lblSoNguoi.Location = new Point(15, 65);
        lblSoNguoi.Name = "lblSoNguoi";
        lblSoNguoi.Size = new Size(67, 19);
        lblSoNguoi.TabIndex = 4;
        lblSoNguoi.Text = "Số người:";
        // 
        // cboTour
        // 
        cboTour.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTour.FormattingEnabled = true;
        cboTour.Location = new Point(105, 33);
        cboTour.Name = "cboTour";
        cboTour.Size = new Size(300, 25);
        cboTour.TabIndex = 3;
        cboTour.SelectedIndexChanged += cboTour_SelectedIndexChanged;
        // 
        // lblTour
        // 
        lblTour.AutoSize = true;
        lblTour.Location = new Point(15, 36);
        lblTour.Name = "lblTour";
        lblTour.Size = new Size(40, 19);
        lblTour.TabIndex = 2;
        lblTour.Text = "Tour:";
        // 
        // cboKhachHang
        // 
        cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
        cboKhachHang.FormattingEnabled = true;
        cboKhachHang.Location = new Point(105, 5);
        cboKhachHang.Name = "cboKhachHang";
        cboKhachHang.Size = new Size(300, 25);
        cboKhachHang.TabIndex = 1;
        // 
        // lblKhachHang
        // 
        lblKhachHang.AutoSize = true;
        lblKhachHang.Location = new Point(15, 8);
        lblKhachHang.Name = "lblKhachHang";
        lblKhachHang.Size = new Size(84, 19);
        lblKhachHang.TabIndex = 0;
        lblKhachHang.Text = "Khách hàng:";
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1064, 621);
        Controls.Add(tabMain);
        Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        MinimumSize = new Size(950, 580);
        Name = "FormMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý đặt tour - Binh An v1.0.0";
        Load += FormMain_Load;
        tabMain.ResumeLayout(false);
        tabTour.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvTour).EndInit();
        gbTourFilter.ResumeLayout(false);
        gbTourFilter.PerformLayout();
        gbTourInput.ResumeLayout(false);
        gbTourInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoChoToiDa).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudGiaNgoaiTe).EndInit();
        tabKhachHang.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
        gbKHFilter.ResumeLayout(false);
        gbKHFilter.PerformLayout();
        gbKHInput.ResumeLayout(false);
        gbKHInput.PerformLayout();
        tabDatTour.ResumeLayout(false);
        pnlDatTourBottom.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDatTour).EndInit();
        pnlDatTourFilter.ResumeLayout(false);
        pnlDatTourFilter.PerformLayout();
        gbThongTinDat.ResumeLayout(false);
        gbThongTinDat.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
        ResumeLayout(false);
    }

    private TabControl tabMain;
    private TabPage tabTour;
    private TabPage tabKhachHang;
    private TabPage tabDatTour;

    // Tour Tab Controls
    private GroupBox gbTourInput;
    private Label lblTenTour;
    private TextBox txtTenTour;
    private Label lblDiemDen;
    private TextBox txtDiemDen;
    private Label lblNgoaiTe;
    private ComboBox cboNgoaiTe;
    private Label lblGiaNgoaiTe;
    private NumericUpDown nudGiaNgoaiTe;
    private Label lblNgayKhoiHanh;
    private DateTimePicker dtpNgayKhoiHanh;
    private Label lblSoChoToiDa;
    private NumericUpDown nudSoChoToiDa;
    private Button btnThemTour;
    private Button btnSuaTour;
    private Button btnXoaTour;
    private Button btnLamMoiTour;
    private GroupBox gbTourFilter;
    private Label lblTimTour;
    private TextBox txtTimTour;
    private Button btnTimTour;
    private Button btnHienTatCaTour;
    private DataGridView dgvTour;

    // Khách hàng Tab Controls
    private GroupBox gbKHInput;
    private Label lblHoTen;
    private TextBox txtHoTen;
    private Label lblSoDienThoai;
    private TextBox txtSoDienThoai;
    private Label lblEmail;
    private TextBox txtEmail;
    private Button btnThemKH;
    private Button btnSuaKH;
    private Button btnXoaKH;
    private Button btnLamMoiKH;
    private GroupBox gbKHFilter;
    private Label lblTimKH;
    private TextBox txtTimKH;
    private Button btnTimKH;
    private Button btnHienTatCaKH;
    private DataGridView dgvKhachHang;

    // Đặt tour Tab Controls
    private GroupBox gbThongTinDat;
    private Label lblKhachHang;
    private ComboBox cboKhachHang;
    private Label lblTour;
    private ComboBox cboTour;
    private Label lblSoNguoi;
    private NumericUpDown nudSoNguoi;
    private Label lblGiaNguoiHeader;
    private Label lblGiaNguoi;
    private Label lblTyGiaHeader;
    private Label lblTyGia;
    private Label lblNguonTyGia;
    private Label lblTongTienHeader;
    private Label lblTongTienVND;
    private Button btnDatTour;
    private Label lblSoChoConLai;
    private Panel pnlDatTourFilter;
    private TextBox txtTimDatTour;
    private Label lblThangKhoiHanh;
    private ComboBox cboThangKhoiHanh;
    private Button btnTimDatTour;
    private Button btnTatCaDatTour;
    private DataGridView dgvDatTour;
    private Panel pnlDatTourBottom;
    private Label lblTongDoanhThu;
}
