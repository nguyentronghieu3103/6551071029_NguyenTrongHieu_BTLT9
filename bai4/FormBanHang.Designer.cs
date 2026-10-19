namespace bai4;

partial class FormBanHang
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
        menuStrip1 = new MenuStrip();
        menuThucDon = new ToolStripMenuItem();
        menuHoaDon = new ToolStripMenuItem();
        menuCaiDat = new ToolStripMenuItem();
        pnlContainer = new TableLayoutPanel();
        gbChonMon = new GroupBox();
        btnThemVaoDon = new Button();
        nudSoLy = new NumericUpDown();
        lblSoLy = new Label();
        lstMonUong = new ListBox();
        cboDanhMuc = new ComboBox();
        lblDanhMuc = new Label();
        gbDonHienTai = new GroupBox();
        lblTongTien = new Label();
        btnXoaDong = new Button();
        dgvGioHang = new DataGridView();
        gbThanhToan = new GroupBox();
        btnDaNhanTien = new Button();
        lblNoiDung = new Label();
        lblSoTien = new Label();
        lblThongTinTK = new Label();
        picQR = new PictureBox();
        btnTienMat = new Button();
        btnChuyenKhoan = new Button();
        menuStrip1.SuspendLayout();
        pnlContainer.SuspendLayout();
        gbChonMon.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoLy).BeginInit();
        gbDonHienTai.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
        gbThanhToan.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        menuStrip1.Items.AddRange(new ToolStripItem[] { menuThucDon, menuHoaDon, menuCaiDat });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1064, 25);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // menuThucDon
        // 
        menuThucDon.Name = "menuThucDon";
        menuThucDon.Size = new Size(130, 21);
        menuThucDon.Text = "Quản lý thực đơn";
        menuThucDon.Click += menuThucDon_Click;
        // 
        // menuHoaDon
        // 
        menuHoaDon.Name = "menuHoaDon";
        menuHoaDon.Size = new Size(189, 21);
        menuHoaDon.Text = "Danh sách hóa đơn & Doanh thu";
        menuHoaDon.Click += menuHoaDon_Click;
        // 
        // menuCaiDat
        // 
        menuCaiDat.Name = "menuCaiDat";
        menuCaiDat.Size = new Size(138, 21);
        menuCaiDat.Text = "Cài đặt tài khoản QR";
        menuCaiDat.Click += menuCaiDat_Click;
        // 
        // pnlContainer
        // 
        pnlContainer.ColumnCount = 3;
        pnlContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
        pnlContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
        pnlContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
        pnlContainer.Controls.Add(gbChonMon, 0, 0);
        pnlContainer.Controls.Add(gbDonHienTai, 1, 0);
        pnlContainer.Controls.Add(gbThanhToan, 2, 0);
        pnlContainer.Dock = DockStyle.Fill;
        pnlContainer.Location = new Point(0, 25);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Padding = new Padding(10);
        pnlContainer.RowCount = 1;
        pnlContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        pnlContainer.Size = new Size(1064, 556);
        pnlContainer.TabIndex = 1;
        // 
        // gbChonMon
        // 
        gbChonMon.Controls.Add(btnThemVaoDon);
        gbChonMon.Controls.Add(nudSoLy);
        gbChonMon.Controls.Add(lblSoLy);
        gbChonMon.Controls.Add(lstMonUong);
        gbChonMon.Controls.Add(cboDanhMuc);
        gbChonMon.Controls.Add(lblDanhMuc);
        gbChonMon.Dock = DockStyle.Fill;
        gbChonMon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        gbChonMon.Location = new Point(13, 13);
        gbChonMon.Name = "gbChonMon";
        gbChonMon.Size = new Size(264, 530);
        gbChonMon.TabIndex = 0;
        gbChonMon.TabStop = false;
        gbChonMon.Text = "Chọn món";
        // 
        // btnThemVaoDon
        // 
        btnThemVaoDon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        btnThemVaoDon.BackColor = Color.White;
        btnThemVaoDon.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
        btnThemVaoDon.Location = new Point(10, 480);
        btnThemVaoDon.Name = "btnThemVaoDon";
        btnThemVaoDon.Size = new Size(244, 40);
        btnThemVaoDon.TabIndex = 5;
        btnThemVaoDon.Text = "Thêm vào đơn";
        btnThemVaoDon.UseVisualStyleBackColor = true;
        btnThemVaoDon.Click += btnThemVaoDon_Click;
        // 
        // nudSoLy
        // 
        nudSoLy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        nudSoLy.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
        nudSoLy.Location = new Point(134, 438);
        nudSoLy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudSoLy.Name = "nudSoLy";
        nudSoLy.Size = new Size(120, 26);
        nudSoLy.TabIndex = 4;
        nudSoLy.TextAlign = HorizontalAlignment.Center;
        nudSoLy.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblSoLy
        // 
        lblSoLy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblSoLy.AutoSize = true;
        lblSoLy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblSoLy.Location = new Point(10, 440);
        lblSoLy.Name = "lblSoLy";
        lblSoLy.Size = new Size(43, 19);
        lblSoLy.TabIndex = 3;
        lblSoLy.Text = "Số ly:";
        // 
        // lstMonUong
        // 
        lstMonUong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstMonUong.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lstMonUong.FormattingEnabled = true;
        lstMonUong.ItemHeight = 17;
        lstMonUong.Location = new Point(10, 85);
        lstMonUong.Name = "lstMonUong";
        lstMonUong.Size = new Size(244, 327);
        lstMonUong.TabIndex = 2;
        // 
        // cboDanhMuc
        // 
        cboDanhMuc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDanhMuc.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        cboDanhMuc.FormattingEnabled = true;
        cboDanhMuc.Location = new Point(10, 48);
        cboDanhMuc.Name = "cboDanhMuc";
        cboDanhMuc.Size = new Size(244, 25);
        cboDanhMuc.TabIndex = 1;
        cboDanhMuc.SelectedIndexChanged += cboDanhMuc_SelectedIndexChanged;
        // 
        // lblDanhMuc
        // 
        lblDanhMuc.AutoSize = true;
        lblDanhMuc.Location = new Point(10, 25);
        lblDanhMuc.Name = "lblDanhMuc";
        lblDanhMuc.Size = new Size(74, 19);
        lblDanhMuc.TabIndex = 0;
        lblDanhMuc.Text = "Danh mục:";
        // 
        // gbDonHienTai
        // 
        gbDonHienTai.Controls.Add(lblTongTien);
        gbDonHienTai.Controls.Add(btnXoaDong);
        gbDonHienTai.Controls.Add(dgvGioHang);
        gbDonHienTai.Dock = DockStyle.Fill;
        gbDonHienTai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        gbDonHienTai.Location = new Point(283, 13);
        gbDonHienTai.Name = "gbDonHienTai";
        gbDonHienTai.Size = new Size(443, 530);
        gbDonHienTai.TabIndex = 1;
        gbDonHienTai.TabStop = false;
        gbDonHienTai.Text = "Đơn hiện tại";
        // 
        // lblTongTien
        // 
        lblTongTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblTongTien.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
        lblTongTien.ForeColor = Color.Black;
        lblTongTien.Location = new Point(6, 475);
        lblTongTien.Name = "lblTongTien";
        lblTongTien.Size = new Size(431, 45);
        lblTongTien.TabIndex = 2;
        lblTongTien.Text = "Tổng tiền: 0 đ";
        lblTongTien.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnXoaDong
        // 
        btnXoaDong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        btnXoaDong.BackColor = Color.White;
        btnXoaDong.Location = new Point(6, 428);
        btnXoaDong.Name = "btnXoaDong";
        btnXoaDong.Size = new Size(431, 35);
        btnXoaDong.TabIndex = 1;
        btnXoaDong.Text = "Xóa dòng";
        btnXoaDong.UseVisualStyleBackColor = true;
        btnXoaDong.Click += btnXoaDong_Click;
        // 
        // dgvGioHang
        // 
        dgvGioHang.AllowUserToAddRows = false;
        dgvGioHang.AllowUserToDeleteRows = false;
        dgvGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvGioHang.BackgroundColor = Color.White;
        dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvGioHang.Location = new Point(6, 25);
        dgvGioHang.MultiSelect = false;
        dgvGioHang.Name = "dgvGioHang";
        dgvGioHang.ReadOnly = true;
        dgvGioHang.RowHeadersWidth = 30;
        dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvGioHang.Size = new Size(431, 395);
        dgvGioHang.TabIndex = 0;
        // 
        // gbThanhToan
        // 
        gbThanhToan.Controls.Add(btnDaNhanTien);
        gbThanhToan.Controls.Add(lblNoiDung);
        gbThanhToan.Controls.Add(lblSoTien);
        gbThanhToan.Controls.Add(lblThongTinTK);
        gbThanhToan.Controls.Add(picQR);
        gbThanhToan.Controls.Add(btnTienMat);
        gbThanhToan.Controls.Add(btnChuyenKhoan);
        gbThanhToan.Dock = DockStyle.Fill;
        gbThanhToan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        gbThanhToan.Location = new Point(732, 13);
        gbThanhToan.Name = "gbThanhToan";
        gbThanhToan.Size = new Size(319, 530);
        gbThanhToan.TabIndex = 2;
        gbThanhToan.TabStop = false;
        gbThanhToan.Text = "Thanh toán";
        // 
        // btnDaNhanTien
        // 
        btnDaNhanTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        btnDaNhanTien.BackColor = Color.FromArgb(40, 167, 69);
        btnDaNhanTien.FlatStyle = FlatStyle.Flat;
        btnDaNhanTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        btnDaNhanTien.ForeColor = Color.White;
        btnDaNhanTien.Location = new Point(10, 480);
        btnDaNhanTien.Name = "btnDaNhanTien";
        btnDaNhanTien.Size = new Size(299, 42);
        btnDaNhanTien.TabIndex = 6;
        btnDaNhanTien.Text = "Đã nhận tiền";
        btnDaNhanTien.UseVisualStyleBackColor = false;
        btnDaNhanTien.Click += btnDaNhanTien_Click;
        // 
        // lblNoiDung
        // 
        lblNoiDung.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblNoiDung.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblNoiDung.Location = new Point(10, 446);
        lblNoiDung.Name = "lblNoiDung";
        lblNoiDung.Size = new Size(299, 24);
        lblNoiDung.TabIndex = 5;
        lblNoiDung.Text = "Nội dung:";
        // 
        // lblSoTien
        // 
        lblSoTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblSoTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblSoTien.Location = new Point(10, 420);
        lblSoTien.Name = "lblSoTien";
        lblSoTien.Size = new Size(299, 24);
        lblSoTien.TabIndex = 4;
        lblSoTien.Text = "Số tiền:    0 đ";
        // 
        // lblThongTinTK
        // 
        lblThongTinTK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblThongTinTK.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
        lblThongTinTK.ForeColor = Color.DarkSlateGray;
        lblThongTinTK.Location = new Point(10, 368);
        lblThongTinTK.Name = "lblThongTinTK";
        lblThongTinTK.Size = new Size(299, 48);
        lblThongTinTK.TabIndex = 3;
        lblThongTinTK.Text = "Chủ TK: QUAN TRA SUA\nNgân hàng: VIETCOMBANK\nSTK: 1234567890";
        lblThongTinTK.TextAlign = ContentAlignment.TopCenter;
        // 
        // picQR
        // 
        picQR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        picQR.BackColor = Color.White;
        picQR.BorderStyle = BorderStyle.FixedSingle;
        picQR.Location = new Point(10, 105);
        picQR.Name = "picQR";
        picQR.Size = new Size(299, 260);
        picQR.SizeMode = PictureBoxSizeMode.Zoom;
        picQR.TabIndex = 2;
        picQR.TabStop = false;
        // 
        // btnTienMat
        // 
        btnTienMat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnTienMat.BackColor = Color.White;
        btnTienMat.Location = new Point(10, 66);
        btnTienMat.Name = "btnTienMat";
        btnTienMat.Size = new Size(299, 32);
        btnTienMat.TabIndex = 1;
        btnTienMat.Text = "Tiền mặt";
        btnTienMat.UseVisualStyleBackColor = true;
        btnTienMat.Click += btnTienMat_Click;
        // 
        // btnChuyenKhoan
        // 
        btnChuyenKhoan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnChuyenKhoan.BackColor = Color.White;
        btnChuyenKhoan.Location = new Point(10, 26);
        btnChuyenKhoan.Name = "btnChuyenKhoan";
        btnChuyenKhoan.Size = new Size(299, 34);
        btnChuyenKhoan.TabIndex = 0;
        btnChuyenKhoan.Text = "Thanh toán chuyển khoản";
        btnChuyenKhoan.UseVisualStyleBackColor = true;
        btnChuyenKhoan.Click += btnChuyenKhoan_Click;
        // 
        // FormBanHang
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1064, 581);
        Controls.Add(pnlContainer);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        MinimumSize = new Size(980, 560);
        Name = "FormBanHang";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bán hàng - Quán trà sữa";
        Load += FormBanHang_Load;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        pnlContainer.ResumeLayout(false);
        gbChonMon.ResumeLayout(false);
        gbChonMon.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoLy).EndInit();
        gbDonHienTai.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
        gbThanhToan.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem menuThucDon;
    private ToolStripMenuItem menuHoaDon;
    private ToolStripMenuItem menuCaiDat;
    private TableLayoutPanel pnlContainer;
    private GroupBox gbChonMon;
    private Label lblDanhMuc;
    private ComboBox cboDanhMuc;
    private ListBox lstMonUong;
    private Label lblSoLy;
    private NumericUpDown nudSoLy;
    private Button btnThemVaoDon;
    private GroupBox gbDonHienTai;
    private DataGridView dgvGioHang;
    private Button btnXoaDong;
    private Label lblTongTien;
    private GroupBox gbThanhToan;
    private Button btnChuyenKhoan;
    private Button btnTienMat;
    private PictureBox picQR;
    private Label lblThongTinTK;
    private Label lblSoTien;
    private Label lblNoiDung;
    private Button btnDaNhanTien;
}
