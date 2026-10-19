namespace bai4;

partial class FormHoaDon
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
        pnlTop = new Panel();
        btnXemTatCa = new Button();
        btnHomNay = new Button();
        lblTongSoDon = new Label();
        lblDoanhThuNgay = new Label();
        dtpNgay = new DateTimePicker();
        lblChonNgay = new Label();
        splitContainer1 = new SplitContainer();
        gbHoaDon = new GroupBox();
        dgvHoaDon = new DataGridView();
        gbChiTiet = new GroupBox();
        dgvChiTietHoaDon = new DataGridView();
        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        gbHoaDon.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
        gbChiTiet.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).BeginInit();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.BackColor = Color.WhiteSmoke;
        pnlTop.Controls.Add(btnXemTatCa);
        pnlTop.Controls.Add(btnHomNay);
        pnlTop.Controls.Add(lblTongSoDon);
        pnlTop.Controls.Add(lblDoanhThuNgay);
        pnlTop.Controls.Add(dtpNgay);
        pnlTop.Controls.Add(lblChonNgay);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(984, 60);
        pnlTop.TabIndex = 0;
        // 
        // btnXemTatCa
        // 
        btnXemTatCa.Location = new Point(350, 15);
        btnXemTatCa.Name = "btnXemTatCa";
        btnXemTatCa.Size = new Size(110, 30);
        btnXemTatCa.TabIndex = 5;
        btnXemTatCa.Text = "Xem tất cả";
        btnXemTatCa.UseVisualStyleBackColor = true;
        btnXemTatCa.Click += btnXemTatCa_Click;
        // 
        // btnHomNay
        // 
        btnHomNay.Location = new Point(255, 15);
        btnHomNay.Name = "btnHomNay";
        btnHomNay.Size = new Size(85, 30);
        btnHomNay.TabIndex = 4;
        btnHomNay.Text = "Hôm nay";
        btnHomNay.UseVisualStyleBackColor = true;
        btnHomNay.Click += btnHomNay_Click;
        // 
        // lblTongSoDon
        // 
        lblTongSoDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTongSoDon.AutoSize = true;
        lblTongSoDon.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
        lblTongSoDon.Location = new Point(500, 21);
        lblTongSoDon.Name = "lblTongSoDon";
        lblTongSoDon.Size = new Size(106, 19);
        lblTongSoDon.TabIndex = 3;
        lblTongSoDon.Text = "Tổng số đơn: 0";
        // 
        // lblDoanhThuNgay
        // 
        lblDoanhThuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblDoanhThuNgay.AutoSize = true;
        lblDoanhThuNgay.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblDoanhThuNgay.ForeColor = Color.ForestGreen;
        lblDoanhThuNgay.Location = new Point(690, 19);
        lblDoanhThuNgay.Name = "lblDoanhThuNgay";
        lblDoanhThuNgay.Size = new Size(168, 21);
        lblDoanhThuNgay.TabIndex = 2;
        lblDoanhThuNgay.Text = "Doanh thu ngày: 0 đ";
        // 
        // dtpNgay
        // 
        dtpNgay.CustomFormat = "dd/MM/yyyy";
        dtpNgay.Format = DateTimePickerFormat.Custom;
        dtpNgay.Location = new Point(105, 17);
        dtpNgay.Name = "dtpNgay";
        dtpNgay.Size = new Size(140, 25);
        dtpNgay.TabIndex = 1;
        dtpNgay.ValueChanged += dtpNgay_ValueChanged;
        // 
        // lblChonNgay
        // 
        lblChonNgay.AutoSize = true;
        lblChonNgay.Location = new Point(16, 21);
        lblChonNgay.Name = "lblChonNgay";
        lblChonNgay.Size = new Size(79, 19);
        lblChonNgay.TabIndex = 0;
        lblChonNgay.Text = "Chọn ngày:";
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 60);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(gbHoaDon);
        splitContainer1.Panel1.Padding = new Padding(10);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(gbChiTiet);
        splitContainer1.Panel2.Padding = new Padding(10);
        splitContainer1.Size = new Size(984, 501);
        splitContainer1.SplitterDistance = 530;
        splitContainer1.TabIndex = 1;
        // 
        // gbHoaDon
        // 
        gbHoaDon.Controls.Add(dgvHoaDon);
        gbHoaDon.Dock = DockStyle.Fill;
        gbHoaDon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        gbHoaDon.Location = new Point(10, 10);
        gbHoaDon.Name = "gbHoaDon";
        gbHoaDon.Size = new Size(510, 481);
        gbHoaDon.TabIndex = 0;
        gbHoaDon.TabStop = false;
        gbHoaDon.Text = "Danh sách hóa đơn";
        // 
        // dgvHoaDon
        // 
        dgvHoaDon.AllowUserToAddRows = false;
        dgvHoaDon.AllowUserToDeleteRows = false;
        dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHoaDon.BackgroundColor = Color.White;
        dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvHoaDon.Dock = DockStyle.Fill;
        dgvHoaDon.Location = new Point(3, 21);
        dgvHoaDon.MultiSelect = false;
        dgvHoaDon.Name = "dgvHoaDon";
        dgvHoaDon.ReadOnly = true;
        dgvHoaDon.RowHeadersWidth = 35;
        dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHoaDon.Size = new Size(504, 457);
        dgvHoaDon.TabIndex = 0;
        dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
        // 
        // gbChiTiet
        // 
        gbChiTiet.Controls.Add(dgvChiTietHoaDon);
        gbChiTiet.Dock = DockStyle.Fill;
        gbChiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        gbChiTiet.Location = new Point(10, 10);
        gbChiTiet.Name = "gbChiTiet";
        gbChiTiet.Size = new Size(430, 481);
        gbChiTiet.TabIndex = 0;
        gbChiTiet.TabStop = false;
        gbChiTiet.Text = "Chi tiết hóa đơn";
        // 
        // dgvChiTietHoaDon
        // 
        dgvChiTietHoaDon.AllowUserToAddRows = false;
        dgvChiTietHoaDon.AllowUserToDeleteRows = false;
        dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvChiTietHoaDon.BackgroundColor = Color.White;
        dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvChiTietHoaDon.Dock = DockStyle.Fill;
        dgvChiTietHoaDon.Location = new Point(3, 21);
        dgvChiTietHoaDon.MultiSelect = false;
        dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
        dgvChiTietHoaDon.ReadOnly = true;
        dgvChiTietHoaDon.RowHeadersWidth = 35;
        dgvChiTietHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvChiTietHoaDon.Size = new Size(424, 457);
        dgvChiTietHoaDon.TabIndex = 0;
        // 
        // FormHoaDon
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 561);
        Controls.Add(splitContainer1);
        Controls.Add(pnlTop);
        MinimumSize = new Size(850, 450);
        Name = "FormHoaDon";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Danh sách hóa đơn & Doanh thu";
        Load += FormHoaDon_Load;
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        gbHoaDon.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
        gbChiTiet.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).EndInit();
        ResumeLayout(false);
    }

    private Panel pnlTop;
    private Label lblChonNgay;
    private DateTimePicker dtpNgay;
    private Label lblDoanhThuNgay;
    private Label lblTongSoDon;
    private Button btnHomNay;
    private Button btnXemTatCa;
    private SplitContainer splitContainer1;
    private GroupBox gbHoaDon;
    private DataGridView dgvHoaDon;
    private GroupBox gbChiTiet;
    private DataGridView dgvChiTietHoaDon;
}
