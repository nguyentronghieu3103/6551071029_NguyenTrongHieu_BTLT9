namespace Bai1;

partial class FormChiTieu
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        
        grpThongTin = new System.Windows.Forms.GroupBox();
        lblNgayChi = new System.Windows.Forms.Label();
        dtpNgayChi = new System.Windows.Forms.DateTimePicker();
        lblLoaiChi = new System.Windows.Forms.Label();
        cboLoaiChi = new System.Windows.Forms.ComboBox();
        lblNoiDung = new System.Windows.Forms.Label();
        txtNoiDung = new System.Windows.Forms.TextBox();
        lblSoTien = new System.Windows.Forms.Label();
        numSoTien = new System.Windows.Forms.NumericUpDown();
        lblGhiChu = new System.Windows.Forms.Label();
        txtGhiChu = new System.Windows.Forms.TextBox();
        btnThem = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnLamMoi = new System.Windows.Forms.Button();

        grpTimKiem = new System.Windows.Forms.GroupBox();
        lblTimNoiDung = new System.Windows.Forms.Label();
        txtTimNoiDung = new System.Windows.Forms.TextBox();
        lblTimLoaiChi = new System.Windows.Forms.Label();
        cboTimLoaiChi = new System.Windows.Forms.ComboBox();
        lblTuNgay = new System.Windows.Forms.Label();
        dtpTuNgay = new System.Windows.Forms.DateTimePicker();
        lblDenNgay = new System.Windows.Forms.Label();
        dtpDenNgay = new System.Windows.Forms.DateTimePicker();
        btnTim = new System.Windows.Forms.Button();

        dgvChiTieu = new System.Windows.Forms.DataGridView();
        colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNgayChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colLoaiChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();

        lblTongChi = new System.Windows.Forms.Label();

        grpThongTin.SuspendLayout();
        grpTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numSoTien).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvChiTieu).BeginInit();
        SuspendLayout();

        // 
        // grpThongTin
        // 
        grpThongTin.Controls.Add(lblNgayChi);
        grpThongTin.Controls.Add(dtpNgayChi);
        grpThongTin.Controls.Add(lblLoaiChi);
        grpThongTin.Controls.Add(cboLoaiChi);
        grpThongTin.Controls.Add(lblNoiDung);
        grpThongTin.Controls.Add(txtNoiDung);
        grpThongTin.Controls.Add(lblSoTien);
        grpThongTin.Controls.Add(numSoTien);
        grpThongTin.Controls.Add(lblGhiChu);
        grpThongTin.Controls.Add(txtGhiChu);
        grpThongTin.Controls.Add(btnThem);
        grpThongTin.Controls.Add(btnSua);
        grpThongTin.Controls.Add(btnXoa);
        grpThongTin.Controls.Add(btnLamMoi);
        grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        grpThongTin.Location = new System.Drawing.Point(14, 10);
        grpThongTin.Name = "grpThongTin";
        grpThongTin.Size = new System.Drawing.Size(560, 205);
        grpThongTin.TabIndex = 0;
        grpThongTin.TabStop = false;
        grpThongTin.Text = "Thông tin khoản chi";

        // 
        // lblNgayChi
        // 
        lblNgayChi.AutoSize = true;
        lblNgayChi.Location = new System.Drawing.Point(12, 28);
        lblNgayChi.Name = "lblNgayChi";
        lblNgayChi.Size = new System.Drawing.Size(60, 17);
        lblNgayChi.TabIndex = 0;
        lblNgayChi.Text = "Ngày chi";

        // 
        // dtpNgayChi
        // 
        dtpNgayChi.CustomFormat = "dd/MM/yyyy";
        dtpNgayChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpNgayChi.Location = new System.Drawing.Point(82, 24);
        dtpNgayChi.Name = "dtpNgayChi";
        dtpNgayChi.Size = new System.Drawing.Size(140, 24);
        dtpNgayChi.TabIndex = 1;

        // 
        // lblLoaiChi
        // 
        lblLoaiChi.AutoSize = true;
        lblLoaiChi.Location = new System.Drawing.Point(240, 28);
        lblLoaiChi.Name = "lblLoaiChi";
        lblLoaiChi.Size = new System.Drawing.Size(56, 17);
        lblLoaiChi.TabIndex = 2;
        lblLoaiChi.Text = "Loại chi:";

        // 
        // cboLoaiChi
        // 
        cboLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboLoaiChi.FormattingEnabled = true;
        cboLoaiChi.Location = new System.Drawing.Point(305, 24);
        cboLoaiChi.Name = "cboLoaiChi";
        cboLoaiChi.Size = new System.Drawing.Size(235, 25);
        cboLoaiChi.TabIndex = 3;

        // 
        // lblNoiDung
        // 
        lblNoiDung.AutoSize = true;
        lblNoiDung.Location = new System.Drawing.Point(12, 60);
        lblNoiDung.Name = "lblNoiDung";
        lblNoiDung.Size = new System.Drawing.Size(64, 17);
        lblNoiDung.TabIndex = 4;
        lblNoiDung.Text = "Nội dung";

        // 
        // txtNoiDung
        // 
        txtNoiDung.Location = new System.Drawing.Point(82, 57);
        txtNoiDung.MaxLength = 100;
        txtNoiDung.Name = "txtNoiDung";
        txtNoiDung.Size = new System.Drawing.Size(140, 24);
        txtNoiDung.TabIndex = 5;

        // 
        // lblSoTien
        // 
        lblSoTien.AutoSize = true;
        lblSoTien.Location = new System.Drawing.Point(240, 60);
        lblSoTien.Name = "lblSoTien";
        lblSoTien.Size = new System.Drawing.Size(48, 17);
        lblSoTien.TabIndex = 6;
        lblSoTien.Text = "Số tiền";

        // 
        // numSoTien
        // 
        numSoTien.DecimalPlaces = 0;
        numSoTien.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        numSoTien.Location = new System.Drawing.Point(305, 57);
        numSoTien.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
        numSoTien.Name = "numSoTien";
        numSoTien.Size = new System.Drawing.Size(235, 24);
        numSoTien.TabIndex = 7;
        numSoTien.ThousandsSeparator = true;

        // 
        // lblGhiChu
        // 
        lblGhiChu.AutoSize = true;
        lblGhiChu.Location = new System.Drawing.Point(12, 92);
        lblGhiChu.Name = "lblGhiChu";
        lblGhiChu.Size = new System.Drawing.Size(51, 17);
        lblGhiChu.TabIndex = 8;
        lblGhiChu.Text = "Ghi chú";

        // 
        // txtGhiChu
        // 
        txtGhiChu.Location = new System.Drawing.Point(82, 90);
        txtGhiChu.MaxLength = 200;
        txtGhiChu.Multiline = true;
        txtGhiChu.Name = "txtGhiChu";
        txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtGhiChu.Size = new System.Drawing.Size(458, 62);
        txtGhiChu.TabIndex = 9;

        // 
        // btnThem
        // 
        btnThem.BackColor = System.Drawing.Color.White;
        btnThem.Location = new System.Drawing.Point(82, 160);
        btnThem.Name = "btnThem";
        btnThem.Size = new System.Drawing.Size(85, 33);
        btnThem.TabIndex = 10;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = false;
        btnThem.Click += btnThem_Click;

        // 
        // btnSua
        // 
        btnSua.BackColor = System.Drawing.Color.White;
        btnSua.Location = new System.Drawing.Point(182, 160);
        btnSua.Name = "btnSua";
        btnSua.Size = new System.Drawing.Size(85, 33);
        btnSua.TabIndex = 11;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = false;
        btnSua.Click += btnSua_Click;

        // 
        // btnXoa
        // 
        btnXoa.BackColor = System.Drawing.Color.White;
        btnXoa.Location = new System.Drawing.Point(282, 160);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new System.Drawing.Size(85, 33);
        btnXoa.TabIndex = 12;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = false;
        btnXoa.Click += btnXoa_Click;

        // 
        // btnLamMoi
        // 
        btnLamMoi.BackColor = System.Drawing.Color.White;
        btnLamMoi.Location = new System.Drawing.Point(382, 160);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(85, 33);
        btnLamMoi.TabIndex = 13;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = false;
        btnLamMoi.Click += btnLamMoi_Click;

        // 
        // grpTimKiem
        // 
        grpTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        grpTimKiem.Controls.Add(lblTimNoiDung);
        grpTimKiem.Controls.Add(txtTimNoiDung);
        grpTimKiem.Controls.Add(lblTimLoaiChi);
        grpTimKiem.Controls.Add(cboTimLoaiChi);
        grpTimKiem.Controls.Add(lblTuNgay);
        grpTimKiem.Controls.Add(dtpTuNgay);
        grpTimKiem.Controls.Add(lblDenNgay);
        grpTimKiem.Controls.Add(dtpDenNgay);
        grpTimKiem.Controls.Add(btnTim);
        grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        grpTimKiem.Location = new System.Drawing.Point(588, 10);
        grpTimKiem.Name = "grpTimKiem";
        grpTimKiem.Size = new System.Drawing.Size(364, 205);
        grpTimKiem.TabIndex = 1;
        grpTimKiem.TabStop = false;
        grpTimKiem.Text = "Tìm kiếm";

        // 
        // lblTimNoiDung
        // 
        lblTimNoiDung.AutoSize = true;
        lblTimNoiDung.Location = new System.Drawing.Point(12, 28);
        lblTimNoiDung.Name = "lblTimNoiDung";
        lblTimNoiDung.Size = new System.Drawing.Size(56, 17);
        lblTimNoiDung.TabIndex = 0;
        lblTimNoiDung.Text = "TextBox";

        // 
        // txtTimNoiDung
        // 
        txtTimNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtTimNoiDung.Location = new System.Drawing.Point(80, 24);
        txtTimNoiDung.Name = "txtTimNoiDung";
        txtTimNoiDung.PlaceholderText = "Nhập nội dung...";
        txtTimNoiDung.Size = new System.Drawing.Size(268, 24);
        txtTimNoiDung.TabIndex = 1;
        txtTimNoiDung.TextChanged += txtTimNoiDung_TextChanged;

        // 
        // lblTimLoaiChi
        // 
        lblTimLoaiChi.AutoSize = true;
        lblTimLoaiChi.Location = new System.Drawing.Point(12, 60);
        lblTimLoaiChi.Name = "lblTimLoaiChi";
        lblTimLoaiChi.Size = new System.Drawing.Size(56, 17);
        lblTimLoaiChi.TabIndex = 2;
        lblTimLoaiChi.Text = "Loại chi";

        // 
        // cboTimLoaiChi
        // 
        cboTimLoaiChi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        cboTimLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboTimLoaiChi.FormattingEnabled = true;
        cboTimLoaiChi.Location = new System.Drawing.Point(80, 57);
        cboTimLoaiChi.Name = "cboTimLoaiChi";
        cboTimLoaiChi.Size = new System.Drawing.Size(268, 25);
        cboTimLoaiChi.TabIndex = 3;
        cboTimLoaiChi.SelectedIndexChanged += cboTimLoaiChi_SelectedIndexChanged;

        // 
        // lblTuNgay
        // 
        lblTuNgay.AutoSize = true;
        lblTuNgay.Location = new System.Drawing.Point(12, 96);
        lblTuNgay.Name = "lblTuNgay";
        lblTuNgay.Size = new System.Drawing.Size(55, 17);
        lblTuNgay.TabIndex = 4;
        lblTuNgay.Text = "Từ ngày";

        // 
        // dtpTuNgay
        // 
        dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpTuNgay.Location = new System.Drawing.Point(80, 92);
        dtpTuNgay.Name = "dtpTuNgay";
        dtpTuNgay.Size = new System.Drawing.Size(145, 24);
        dtpTuNgay.TabIndex = 5;

        // 
        // lblDenNgay
        // 
        lblDenNgay.AutoSize = true;
        lblDenNgay.Location = new System.Drawing.Point(12, 131);
        lblDenNgay.Name = "lblDenNgay";
        lblDenNgay.Size = new System.Drawing.Size(63, 17);
        lblDenNgay.TabIndex = 6;
        lblDenNgay.Text = "Đến ngày";

        // 
        // dtpDenNgay
        // 
        dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpDenNgay.Location = new System.Drawing.Point(80, 127);
        dtpDenNgay.Name = "dtpDenNgay";
        dtpDenNgay.Size = new System.Drawing.Size(145, 24);
        dtpDenNgay.TabIndex = 7;

        // 
        // btnTim
        // 
        btnTim.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnTim.BackColor = System.Drawing.Color.White;
        btnTim.Location = new System.Drawing.Point(245, 123);
        btnTim.Name = "btnTim";
        btnTim.Size = new System.Drawing.Size(103, 30);
        btnTim.TabIndex = 8;
        btnTim.Text = "Tìm";
        btnTim.UseVisualStyleBackColor = false;
        btnTim.Click += btnTim_Click;

        // 
        // dgvChiTieu
        // 
        dgvChiTieu.AllowUserToAddRows = false;
        dgvChiTieu.AllowUserToDeleteRows = false;
        dgvChiTieu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvChiTieu.BackgroundColor = System.Drawing.Color.White;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvChiTieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvChiTieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvChiTieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colMa,
            colNgayChi,
            colNoiDung,
            colLoaiChi,
            colSoTien,
            colGhiChu
        });
        dgvChiTieu.Location = new System.Drawing.Point(14, 226);
        dgvChiTieu.MultiSelect = false;
        dgvChiTieu.Name = "dgvChiTieu";
        dgvChiTieu.ReadOnly = true;
        dgvChiTieu.RowHeadersVisible = true;
        dgvChiTieu.RowHeadersWidth = 35;
        dgvChiTieu.RowTemplate.Height = 26;
        dgvChiTieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvChiTieu.Size = new System.Drawing.Size(938, 275);
        dgvChiTieu.TabIndex = 2;
        dgvChiTieu.CellClick += dgvChiTieu_CellClick;
        dgvChiTieu.CellFormatting += dgvChiTieu_CellFormatting;

        // 
        // colMa
        // 
        colMa.DataPropertyName = "MaCt";
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        colMa.DefaultCellStyle = dataGridViewCellStyle2;
        colMa.HeaderText = "Mã";
        colMa.MinimumWidth = 60;
        colMa.Name = "colMa";
        colMa.ReadOnly = true;
        colMa.Width = 80;

        // 
        // colNgayChi
        // 
        colNgayChi.DataPropertyName = "NgayChi";
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        colNgayChi.DefaultCellStyle = dataGridViewCellStyle3;
        colNgayChi.HeaderText = "Ngày chi";
        colNgayChi.MinimumWidth = 100;
        colNgayChi.Name = "colNgayChi";
        colNgayChi.ReadOnly = true;
        colNgayChi.Width = 120;

        // 
        // colNoiDung
        // 
        colNoiDung.DataPropertyName = "NoiDung";
        colNoiDung.HeaderText = "Nội dung";
        colNoiDung.MinimumWidth = 150;
        colNoiDung.Name = "colNoiDung";
        colNoiDung.ReadOnly = true;
        colNoiDung.Width = 190;

        // 
        // colLoaiChi
        // 
        colLoaiChi.DataPropertyName = "LoaiChi";
        colLoaiChi.HeaderText = "Loại chi";
        colLoaiChi.MinimumWidth = 100;
        colLoaiChi.Name = "colLoaiChi";
        colLoaiChi.ReadOnly = true;
        colLoaiChi.Width = 130;

        // 
        // colSoTien
        // 
        colSoTien.DataPropertyName = "SoTien";
        colSoTien.HeaderText = "Số tiền";
        colSoTien.MinimumWidth = 100;
        colSoTien.Name = "colSoTien";
        colSoTien.ReadOnly = true;
        colSoTien.Width = 120;

        // 
        // colGhiChu
        // 
        colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        colGhiChu.DataPropertyName = "GhiChu";
        colGhiChu.HeaderText = "Ghi chú";
        colGhiChu.MinimumWidth = 120;
        colGhiChu.Name = "colGhiChu";
        colGhiChu.ReadOnly = true;

        // 
        // lblTongChi
        // 
        lblTongChi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        lblTongChi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        lblTongChi.ForeColor = System.Drawing.Color.Red;
        lblTongChi.Location = new System.Drawing.Point(540, 508);
        lblTongChi.Name = "lblTongChi";
        lblTongChi.Size = new System.Drawing.Size(412, 35);
        lblTongChi.TabIndex = 3;
        lblTongChi.Text = "Tổng chi: 0 đ";
        lblTongChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // 
        // FormChiTieu
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(966, 549);
        Controls.Add(lblTongChi);
        Controls.Add(dgvChiTieu);
        Controls.Add(grpTimKiem);
        Controls.Add(grpThongTin);
        MinimumSize = new System.Drawing.Size(900, 500);
        Name = "FormChiTieu";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Sổ chi tiêu cá nhân";
        Load += FormChiTieu_Load;

        grpThongTin.ResumeLayout(false);
        grpThongTin.PerformLayout();
        grpTimKiem.ResumeLayout(false);
        grpTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numSoTien).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvChiTieu).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox grpThongTin;
    private System.Windows.Forms.Label lblNgayChi;
    private System.Windows.Forms.DateTimePicker dtpNgayChi;
    private System.Windows.Forms.Label lblLoaiChi;
    private System.Windows.Forms.ComboBox cboLoaiChi;
    private System.Windows.Forms.Label lblNoiDung;
    private System.Windows.Forms.TextBox txtNoiDung;
    private System.Windows.Forms.Label lblSoTien;
    private System.Windows.Forms.NumericUpDown numSoTien;
    private System.Windows.Forms.Label lblGhiChu;
    private System.Windows.Forms.TextBox txtGhiChu;
    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;

    private System.Windows.Forms.GroupBox grpTimKiem;
    private System.Windows.Forms.Label lblTimNoiDung;
    private System.Windows.Forms.TextBox txtTimNoiDung;
    private System.Windows.Forms.Label lblTimLoaiChi;
    private System.Windows.Forms.ComboBox cboTimLoaiChi;
    private System.Windows.Forms.Label lblTuNgay;
    private System.Windows.Forms.DateTimePicker dtpTuNgay;
    private System.Windows.Forms.Label lblDenNgay;
    private System.Windows.Forms.DateTimePicker dtpDenNgay;
    private System.Windows.Forms.Button btnTim;

    private System.Windows.Forms.DataGridView dgvChiTieu;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNgayChi;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNoiDung;
    private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiChi;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
    private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;

    private System.Windows.Forms.Label lblTongChi;
}
