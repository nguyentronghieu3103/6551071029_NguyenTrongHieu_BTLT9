namespace bai4;

partial class FormThucDon
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
        gbThongTin = new GroupBox();
        chkDangBan = new CheckBox();
        nudGiaBan = new NumericUpDown();
        cboDanhMuc = new ComboBox();
        txtTenMon = new TextBox();
        lblDangBan = new Label();
        lblGiaBan = new Label();
        lblDanhMuc = new Label();
        lblTenMon = new Label();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        gbTimKiem = new GroupBox();
        btnHienTatCa = new Button();
        cboLocDanhMuc = new ComboBox();
        lblLocDanhMuc = new Label();
        txtTimKiem = new TextBox();
        lblTimTen = new Label();
        dgvMonUong = new DataGridView();
        gbDanhSach = new GroupBox();
        gbThongTin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudGiaBan).BeginInit();
        gbTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMonUong).BeginInit();
        gbDanhSach.SuspendLayout();
        SuspendLayout();
        // 
        // gbThongTin
        // 
        gbThongTin.Controls.Add(chkDangBan);
        gbThongTin.Controls.Add(nudGiaBan);
        gbThongTin.Controls.Add(cboDanhMuc);
        gbThongTin.Controls.Add(txtTenMon);
        gbThongTin.Controls.Add(lblDangBan);
        gbThongTin.Controls.Add(lblGiaBan);
        gbThongTin.Controls.Add(lblDanhMuc);
        gbThongTin.Controls.Add(lblTenMon);
        gbThongTin.Controls.Add(btnThem);
        gbThongTin.Controls.Add(btnSua);
        gbThongTin.Controls.Add(btnXoa);
        gbThongTin.Controls.Add(btnLamMoi);
        gbThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        gbThongTin.Location = new Point(12, 12);
        gbThongTin.Name = "gbThongTin";
        gbThongTin.Size = new Size(860, 150);
        gbThongTin.TabIndex = 0;
        gbThongTin.TabStop = false;
        gbThongTin.Text = "Thông tin món";
        // 
        // chkDangBan
        // 
        chkDangBan.AutoSize = true;
        chkDangBan.Checked = true;
        chkDangBan.CheckState = CheckState.Checked;
        chkDangBan.Location = new Point(510, 68);
        chkDangBan.Name = "chkDangBan";
        chkDangBan.Size = new Size(90, 23);
        chkDangBan.TabIndex = 7;
        chkDangBan.Text = "Đang bán";
        chkDangBan.UseVisualStyleBackColor = true;
        // 
        // nudGiaBan
        // 
        nudGiaBan.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        nudGiaBan.Location = new Point(510, 29);
        nudGiaBan.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        nudGiaBan.Name = "nudGiaBan";
        nudGiaBan.Size = new Size(180, 25);
        nudGiaBan.TabIndex = 5;
        nudGiaBan.TextAlign = HorizontalAlignment.Right;
        nudGiaBan.ThousandsSeparator = true;
        // 
        // cboDanhMuc
        // 
        cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDanhMuc.FormattingEnabled = true;
        cboDanhMuc.Location = new Point(95, 66);
        cboDanhMuc.Name = "cboDanhMuc";
        cboDanhMuc.Size = new Size(290, 25);
        cboDanhMuc.TabIndex = 3;
        // 
        // txtTenMon
        // 
        txtTenMon.Location = new Point(95, 29);
        txtTenMon.Name = "txtTenMon";
        txtTenMon.Size = new Size(290, 25);
        txtTenMon.TabIndex = 1;
        // 
        // lblDangBan
        // 
        lblDangBan.AutoSize = true;
        lblDangBan.Location = new Point(420, 70);
        lblDangBan.Name = "lblDangBan";
        lblDangBan.Size = new Size(73, 19);
        lblDangBan.TabIndex = 6;
        lblDangBan.Text = "Trạng thái:";
        // 
        // lblGiaBan
        // 
        lblGiaBan.AutoSize = true;
        lblGiaBan.Location = new Point(420, 32);
        lblGiaBan.Name = "lblGiaBan";
        lblGiaBan.Size = new Size(59, 19);
        lblGiaBan.TabIndex = 4;
        lblGiaBan.Text = "Giá bán:";
        // 
        // lblDanhMuc
        // 
        lblDanhMuc.AutoSize = true;
        lblDanhMuc.Location = new Point(15, 70);
        lblDanhMuc.Name = "lblDanhMuc";
        lblDanhMuc.Size = new Size(74, 19);
        lblDanhMuc.TabIndex = 2;
        lblDanhMuc.Text = "Danh mục:";
        // 
        // lblTenMon
        // 
        lblTenMon.AutoSize = true;
        lblTenMon.Location = new Point(15, 32);
        lblTenMon.Name = "lblTenMon";
        lblTenMon.Size = new Size(65, 19);
        lblTenMon.TabIndex = 0;
        lblTenMon.Text = "Tên món:";
        // 
        // btnThem
        // 
        btnThem.BackColor = Color.FromArgb(40, 167, 69);
        btnThem.ForeColor = Color.White;
        btnThem.Location = new Point(95, 105);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(95, 32);
        btnThem.TabIndex = 8;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = false;
        btnThem.Click += btnThem_Click;
        // 
        // btnSua
        // 
        btnSua.BackColor = Color.FromArgb(0, 123, 255);
        btnSua.ForeColor = Color.White;
        btnSua.Location = new Point(205, 105);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(95, 32);
        btnSua.TabIndex = 9;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = false;
        btnSua.Click += btnSua_Click;
        // 
        // btnXoa
        // 
        btnXoa.BackColor = Color.FromArgb(220, 53, 69);
        btnXoa.ForeColor = Color.White;
        btnXoa.Location = new Point(315, 105);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(95, 32);
        btnXoa.TabIndex = 10;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = false;
        btnXoa.Click += btnXoa_Click;
        // 
        // btnLamMoi
        // 
        btnLamMoi.Location = new Point(425, 105);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(95, 32);
        btnLamMoi.TabIndex = 11;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;
        // 
        // gbTimKiem
        // 
        gbTimKiem.Controls.Add(btnHienTatCa);
        gbTimKiem.Controls.Add(cboLocDanhMuc);
        gbTimKiem.Controls.Add(lblLocDanhMuc);
        gbTimKiem.Controls.Add(txtTimKiem);
        gbTimKiem.Controls.Add(lblTimTen);
        gbTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        gbTimKiem.Location = new Point(12, 168);
        gbTimKiem.Name = "gbTimKiem";
        gbTimKiem.Size = new Size(860, 68);
        gbTimKiem.TabIndex = 1;
        gbTimKiem.TabStop = false;
        gbTimKiem.Text = "Tìm kiếm & Lọc";
        // 
        // btnHienTatCa
        // 
        btnHienTatCa.Location = new Point(740, 25);
        btnHienTatCa.Name = "btnHienTatCa";
        btnHienTatCa.Size = new Size(100, 30);
        btnHienTatCa.TabIndex = 4;
        btnHienTatCa.Text = "Tất cả món";
        btnHienTatCa.UseVisualStyleBackColor = true;
        btnHienTatCa.Click += btnHienTatCa_Click;
        // 
        // cboLocDanhMuc
        // 
        cboLocDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocDanhMuc.FormattingEnabled = true;
        cboLocDanhMuc.Location = new Point(510, 27);
        cboLocDanhMuc.Name = "cboLocDanhMuc";
        cboLocDanhMuc.Size = new Size(210, 25);
        cboLocDanhMuc.TabIndex = 3;
        cboLocDanhMuc.SelectedIndexChanged += cboLocDanhMuc_SelectedIndexChanged;
        // 
        // lblLocDanhMuc
        // 
        lblLocDanhMuc.AutoSize = true;
        lblLocDanhMuc.Location = new Point(400, 30);
        lblLocDanhMuc.Name = "lblLocDanhMuc";
        lblLocDanhMuc.Size = new Size(104, 19);
        lblLocDanhMuc.TabIndex = 2;
        lblLocDanhMuc.Text = "Theo danh mục:";
        // 
        // txtTimKiem
        // 
        txtTimKiem.Location = new Point(135, 27);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Nhập tên món cần tìm...";
        txtTimKiem.Size = new Size(250, 25);
        txtTimKiem.TabIndex = 1;
        txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        // 
        // lblTimTen
        // 
        lblTimTen.AutoSize = true;
        lblTimTen.Location = new Point(15, 30);
        lblTimTen.Name = "lblTimTen";
        lblTimTen.Size = new Size(114, 19);
        lblTimTen.TabIndex = 0;
        lblTimTen.Text = "Tìm theo tên món:";
        // 
        // dgvMonUong
        // 
        dgvMonUong.AllowUserToAddRows = false;
        dgvMonUong.AllowUserToDeleteRows = false;
        dgvMonUong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvMonUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvMonUong.BackgroundColor = Color.White;
        dgvMonUong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvMonUong.Location = new Point(6, 24);
        dgvMonUong.MultiSelect = false;
        dgvMonUong.Name = "dgvMonUong";
        dgvMonUong.ReadOnly = true;
        dgvMonUong.RowHeadersWidth = 35;
        dgvMonUong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMonUong.Size = new Size(848, 250);
        dgvMonUong.TabIndex = 0;
        dgvMonUong.CellClick += dgvMonUong_CellClick;
        // 
        // gbDanhSach
        // 
        gbDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        gbDanhSach.Controls.Add(dgvMonUong);
        gbDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        gbDanhSach.Location = new Point(12, 242);
        gbDanhSach.Name = "gbDanhSach";
        gbDanhSach.Size = new Size(860, 280);
        gbDanhSach.TabIndex = 2;
        gbDanhSach.TabStop = false;
        gbDanhSach.Text = "Danh sách món uống";
        // 
        // FormThucDon
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 534);
        Controls.Add(gbDanhSach);
        Controls.Add(gbTimKiem);
        Controls.Add(gbThongTin);
        MinimumSize = new Size(800, 500);
        Name = "FormThucDon";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Quản lý thực đơn";
        Load += FormThucDon_Load;
        gbThongTin.ResumeLayout(false);
        gbThongTin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudGiaBan).EndInit();
        gbTimKiem.ResumeLayout(false);
        gbTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMonUong).EndInit();
        gbDanhSach.ResumeLayout(false);
        ResumeLayout(false);
    }

    private GroupBox gbThongTin;
    private Label lblTenMon;
    private TextBox txtTenMon;
    private Label lblDanhMuc;
    private ComboBox cboDanhMuc;
    private Label lblGiaBan;
    private NumericUpDown nudGiaBan;
    private Label lblDangBan;
    private CheckBox chkDangBan;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private GroupBox gbTimKiem;
    private Label lblTimTen;
    private TextBox txtTimKiem;
    private Label lblLocDanhMuc;
    private ComboBox cboLocDanhMuc;
    private Button btnHienTatCa;
    private GroupBox gbDanhSach;
    private DataGridView dgvMonUong;
}
