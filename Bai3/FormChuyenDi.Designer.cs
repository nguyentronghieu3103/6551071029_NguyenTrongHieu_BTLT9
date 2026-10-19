namespace Bai3
{
    partial class FormChuyenDi
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitle = new Label();
            lblLanguage = new Label();
            cboLanguage = new ComboBox();

            grpTripInfo = new GroupBox();
            lblTenChuyen = new Label();
            txtTenChuyen = new TextBox();
            lblDiaDiem = new Label();
            txtDiaDiem = new TextBox();
            lblNgayDi = new Label();
            dtpNgayDi = new DateTimePicker();
            lblSoNguoi = new Label();
            numSoNguoi = new NumericUpDown();
            lblNganSach = new Label();
            numNganSach = new NumericUpDown();
            lblPhuongTien = new Label();
            cboPhuongTien = new ComboBox();
            chkDaHoanThanh = new CheckBox();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            btnXemThoiTiet = new Button();
            progressBarWeather = new ProgressBar();
            grpWeather = new GroupBox();
            lblWeatherHeader = new Label();
            picWeatherIcon = new PictureBox();
            lblWeatherDesc = new Label();
            lblWeatherTemp = new Label();
            lblWeatherRainProb = new Label();
            pnlWarning = new Panel();
            lblWarningIcon = new Label();
            lblWarningText = new Label();

            pnlFilter = new Panel();
            txtTimKiem = new TextBox();
            chkChuaHoanThanh = new CheckBox();
            chkLocTheoNgay = new CheckBox();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnTim = new Button();
            btnBoLoc = new Button();

            dgvChuyenDi = new DataGridView();

            grpTripInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoNguoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNganSach).BeginInit();
            grpWeather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picWeatherIcon).BeginInit();
            pnlWarning.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).BeginInit();
            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(320, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kế hoạch dã ngoại cuối tuần";

            // 
            // lblLanguage
            // 
            lblLanguage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLanguage.AutoSize = true;
            lblLanguage.Font = new Font("Segoe UI", 9.5F);
            lblLanguage.Location = new Point(810, 22);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(69, 17);
            lblLanguage.TabIndex = 1;
            lblLanguage.Text = "Ngôn ngữ:";

            // 
            // cboLanguage
            // 
            cboLanguage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLanguage.Font = new Font("Segoe UI", 9.5F);
            cboLanguage.FormattingEnabled = true;
            cboLanguage.Location = new Point(885, 18);
            cboLanguage.Name = "cboLanguage";
            cboLanguage.Size = new Size(145, 25);
            cboLanguage.TabIndex = 2;

            // 
            // grpTripInfo
            // 
            grpTripInfo.Controls.Add(lblTenChuyen);
            grpTripInfo.Controls.Add(txtTenChuyen);
            grpTripInfo.Controls.Add(lblDiaDiem);
            grpTripInfo.Controls.Add(txtDiaDiem);
            grpTripInfo.Controls.Add(lblNgayDi);
            grpTripInfo.Controls.Add(dtpNgayDi);
            grpTripInfo.Controls.Add(lblSoNguoi);
            grpTripInfo.Controls.Add(numSoNguoi);
            grpTripInfo.Controls.Add(lblNganSach);
            grpTripInfo.Controls.Add(numNganSach);
            grpTripInfo.Controls.Add(lblPhuongTien);
            grpTripInfo.Controls.Add(cboPhuongTien);
            grpTripInfo.Controls.Add(chkDaHoanThanh);
            grpTripInfo.Controls.Add(lblGhiChu);
            grpTripInfo.Controls.Add(txtGhiChu);
            grpTripInfo.Controls.Add(btnThem);
            grpTripInfo.Controls.Add(btnSua);
            grpTripInfo.Controls.Add(btnXoa);
            grpTripInfo.Controls.Add(btnLamMoi);
            grpTripInfo.Font = new Font("Segoe UI", 9.5F);
            grpTripInfo.Location = new Point(20, 52);
            grpTripInfo.Name = "grpTripInfo";
            grpTripInfo.Size = new Size(540, 310);
            grpTripInfo.TabIndex = 3;
            grpTripInfo.TabStop = false;
            grpTripInfo.Text = "Thông tin chuyến đi";

            // 
            // lblTenChuyen
            // 
            lblTenChuyen.AutoSize = true;
            lblTenChuyen.Location = new Point(15, 28);
            lblTenChuyen.Name = "lblTenChuyen";
            lblTenChuyen.Size = new Size(76, 17);
            lblTenChuyen.TabIndex = 0;
            lblTenChuyen.Text = "Tên chuyến:";

            // 
            // txtTenChuyen
            // 
            txtTenChuyen.Location = new Point(110, 25);
            txtTenChuyen.Name = "txtTenChuyen";
            txtTenChuyen.Size = new Size(410, 24);
            txtTenChuyen.TabIndex = 1;

            // 
            // lblDiaDiem
            // 
            lblDiaDiem.AutoSize = true;
            lblDiaDiem.Location = new Point(15, 59);
            lblDiaDiem.Name = "lblDiaDiem";
            lblDiaDiem.Size = new Size(62, 17);
            lblDiaDiem.TabIndex = 2;
            lblDiaDiem.Text = "Địa điểm:";

            // 
            // txtDiaDiem
            // 
            txtDiaDiem.Location = new Point(110, 56);
            txtDiaDiem.Name = "txtDiaDiem";
            txtDiaDiem.Size = new Size(410, 24);
            txtDiaDiem.TabIndex = 3;

            // 
            // lblNgayDi
            // 
            lblNgayDi.AutoSize = true;
            lblNgayDi.Location = new Point(15, 90);
            lblNgayDi.Name = "lblNgayDi";
            lblNgayDi.Size = new Size(56, 17);
            lblNgayDi.TabIndex = 4;
            lblNgayDi.Text = "Ngày đi:";

            // 
            // dtpNgayDi
            // 
            dtpNgayDi.Format = DateTimePickerFormat.Custom;
            dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            dtpNgayDi.Location = new Point(110, 87);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(150, 24);
            dtpNgayDi.TabIndex = 5;

            // 
            // lblSoNguoi
            // 
            lblSoNguoi.AutoSize = true;
            lblSoNguoi.Location = new Point(15, 122);
            lblSoNguoi.Name = "lblSoNguoi";
            lblSoNguoi.Size = new Size(63, 17);
            lblSoNguoi.TabIndex = 6;
            lblSoNguoi.Text = "Số người:";

            // 
            // numSoNguoi
            // 
            numSoNguoi.Location = new Point(110, 119);
            numSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoNguoi.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoNguoi.Name = "numSoNguoi";
            numSoNguoi.Size = new Size(150, 24);
            numSoNguoi.TabIndex = 7;
            numSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // lblNganSach
            // 
            lblNganSach.AutoSize = true;
            lblNganSach.Location = new Point(15, 153);
            lblNganSach.Name = "lblNganSach";
            lblNganSach.Size = new Size(71, 17);
            lblNganSach.TabIndex = 8;
            lblNganSach.Text = "Ngân sách:";

            // 
            // numNganSach
            // 
            numNganSach.ThousandsSeparator = true;
            numNganSach.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numNganSach.Location = new Point(110, 150);
            numNganSach.Name = "numNganSach";
            numNganSach.Size = new Size(150, 24);
            numNganSach.TabIndex = 9;

            // 
            // lblPhuongTien
            // 
            lblPhuongTien.AutoSize = true;
            lblPhuongTien.Location = new Point(15, 184);
            lblPhuongTien.Name = "lblPhuongTien";
            lblPhuongTien.Size = new Size(82, 17);
            lblPhuongTien.TabIndex = 10;
            lblPhuongTien.Text = "Phương tiện:";

            // 
            // cboPhuongTien
            // 
            cboPhuongTien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongTien.FormattingEnabled = true;
            cboPhuongTien.Location = new Point(110, 181);
            cboPhuongTien.Name = "cboPhuongTien";
            cboPhuongTien.Size = new Size(150, 25);
            cboPhuongTien.TabIndex = 11;

            // 
            // chkDaHoanThanh
            // 
            chkDaHoanThanh.AutoSize = true;
            chkDaHoanThanh.Location = new Point(15, 214);
            chkDaHoanThanh.Name = "chkDaHoanThanh";
            chkDaHoanThanh.Size = new Size(111, 21);
            chkDaHoanThanh.TabIndex = 12;
            chkDaHoanThanh.Text = "Đã hoàn thành";
            chkDaHoanThanh.UseVisualStyleBackColor = true;

            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(275, 90);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(54, 17);
            lblGhiChu.TabIndex = 13;
            lblGhiChu.Text = "Ghi chú:";

            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(275, 115);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Size = new Size(245, 90);
            txtGhiChu.TabIndex = 14;

            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(240, 240, 240);
            btnThem.FlatStyle = FlatStyle.System;
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            btnThem.Location = new Point(15, 255);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(115, 36);
            btnThem.TabIndex = 15;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;

            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(240, 240, 240);
            btnSua.FlatStyle = FlatStyle.System;
            btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            btnSua.Location = new Point(145, 255);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(115, 36);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;

            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(240, 240, 240);
            btnXoa.FlatStyle = FlatStyle.System;
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            btnXoa.Location = new Point(275, 255);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(115, 36);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;

            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(240, 240, 240);
            btnLamMoi.FlatStyle = FlatStyle.System;
            btnLamMoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            btnLamMoi.Location = new Point(405, 255);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(115, 36);
            btnLamMoi.TabIndex = 18;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;

            // 
            // btnXemThoiTiet
            // 
            btnXemThoiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXemThoiTiet.BackColor = Color.FromArgb(240, 240, 240);
            btnXemThoiTiet.FlatStyle = FlatStyle.System;
            btnXemThoiTiet.Font = new Font("Segoe UI", 9.5F);
            btnXemThoiTiet.Location = new Point(580, 58);
            btnXemThoiTiet.Name = "btnXemThoiTiet";
            btnXemThoiTiet.Size = new Size(150, 32);
            btnXemThoiTiet.TabIndex = 4;
            btnXemThoiTiet.Text = "Xem thời tiết";
            btnXemThoiTiet.UseVisualStyleBackColor = false;

            // 
            // progressBarWeather
            // 
            progressBarWeather.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarWeather.Location = new Point(740, 64);
            progressBarWeather.Name = "progressBarWeather";
            progressBarWeather.Size = new Size(290, 20);
            progressBarWeather.Style = ProgressBarStyle.Marquee;
            progressBarWeather.MarqueeAnimationSpeed = 30;
            progressBarWeather.Visible = false;
            progressBarWeather.TabIndex = 5;

            // 
            // grpWeather
            // 
            grpWeather.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpWeather.Controls.Add(lblWeatherHeader);
            grpWeather.Controls.Add(picWeatherIcon);
            grpWeather.Controls.Add(lblWeatherDesc);
            grpWeather.Controls.Add(lblWeatherTemp);
            grpWeather.Controls.Add(lblWeatherRainProb);
            grpWeather.Controls.Add(pnlWarning);
            grpWeather.Font = new Font("Segoe UI", 9.5F);
            grpWeather.Location = new Point(580, 96);
            grpWeather.Name = "grpWeather";
            grpWeather.Size = new Size(450, 266);
            grpWeather.TabIndex = 6;
            grpWeather.TabStop = false;

            // 
            // lblWeatherHeader
            // 
            lblWeatherHeader.AutoSize = true;
            lblWeatherHeader.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblWeatherHeader.ForeColor = Color.FromArgb(33, 33, 33);
            lblWeatherHeader.Location = new Point(15, 18);
            lblWeatherHeader.Name = "lblWeatherHeader";
            lblWeatherHeader.Size = new Size(260, 19);
            lblWeatherHeader.TabIndex = 0;
            lblWeatherHeader.Text = "Dự báo thời tiết ngày ...";

            // 
            // picWeatherIcon
            // 
            picWeatherIcon.Location = new Point(25, 55);
            picWeatherIcon.Name = "picWeatherIcon";
            picWeatherIcon.Size = new Size(110, 85);
            picWeatherIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            picWeatherIcon.TabIndex = 1;
            picWeatherIcon.TabStop = false;

            // 
            // lblWeatherDesc
            // 
            lblWeatherDesc.AutoSize = true;
            lblWeatherDesc.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblWeatherDesc.ForeColor = Color.FromArgb(33, 33, 33);
            lblWeatherDesc.Location = new Point(148, 52);
            lblWeatherDesc.Name = "lblWeatherDesc";
            lblWeatherDesc.Size = new Size(130, 28);
            lblWeatherDesc.TabIndex = 2;
            lblWeatherDesc.Text = "Trời quang";

            // 
            // lblWeatherTemp
            // 
            lblWeatherTemp.AutoSize = true;
            lblWeatherTemp.Font = new Font("Segoe UI", 10.5F);
            lblWeatherTemp.ForeColor = Color.FromArgb(66, 66, 66);
            lblWeatherTemp.Location = new Point(150, 88);
            lblWeatherTemp.Name = "lblWeatherTemp";
            lblWeatherTemp.Size = new Size(140, 19);
            lblWeatherTemp.TabIndex = 3;
            lblWeatherTemp.Text = "Nhiệt độ: --°C - --°C";

            // 
            // lblWeatherRainProb
            // 
            lblWeatherRainProb.AutoSize = true;
            lblWeatherRainProb.Font = new Font("Segoe UI", 10.5F);
            lblWeatherRainProb.ForeColor = Color.FromArgb(66, 66, 66);
            lblWeatherRainProb.Location = new Point(150, 115);
            lblWeatherRainProb.Name = "lblWeatherRainProb";
            lblWeatherRainProb.Size = new Size(125, 19);
            lblWeatherRainProb.TabIndex = 4;
            lblWeatherRainProb.Text = "Khả năng mưa: --%";

            // 
            // pnlWarning
            // 
            pnlWarning.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlWarning.BackColor = Color.FromArgb(255, 224, 178);
            pnlWarning.Controls.Add(lblWarningIcon);
            pnlWarning.Controls.Add(lblWarningText);
            pnlWarning.Location = new Point(15, 170);
            pnlWarning.Name = "pnlWarning";
            pnlWarning.Size = new Size(420, 65);
            pnlWarning.TabIndex = 5;
            pnlWarning.Visible = false;

            // 
            // lblWarningIcon
            // 
            lblWarningIcon.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWarningIcon.ForeColor = Color.FromArgb(230, 81, 0);
            lblWarningIcon.Location = new Point(8, 12);
            lblWarningIcon.Name = "lblWarningIcon";
            lblWarningIcon.Size = new Size(35, 40);
            lblWarningIcon.TabIndex = 0;
            lblWarningIcon.Text = "!";
            lblWarningIcon.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblWarningText
            // 
            lblWarningText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWarningText.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblWarningText.ForeColor = Color.FromArgb(191, 54, 12);
            lblWarningText.Location = new Point(45, 12);
            lblWarningText.Name = "lblWarningText";
            lblWarningText.Size = new Size(365, 40);
            lblWarningText.TabIndex = 1;
            lblWarningText.Text = "Nên mang áo mưa hoặc cân nhắc dời lịch";
            lblWarningText.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // pnlFilter
            // 
            pnlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilter.Controls.Add(txtTimKiem);
            pnlFilter.Controls.Add(chkChuaHoanThanh);
            pnlFilter.Controls.Add(chkLocTheoNgay);
            pnlFilter.Controls.Add(lblTuNgay);
            pnlFilter.Controls.Add(dtpTuNgay);
            pnlFilter.Controls.Add(lblDenNgay);
            pnlFilter.Controls.Add(dtpDenNgay);
            pnlFilter.Controls.Add(btnTim);
            pnlFilter.Controls.Add(btnBoLoc);
            pnlFilter.Font = new Font("Segoe UI", 9.5F);
            pnlFilter.Location = new Point(20, 375);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1010, 40);
            pnlFilter.TabIndex = 7;

            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(0, 7);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(230, 24);
            txtTimKiem.TabIndex = 0;

            // 
            // chkChuaHoanThanh
            // 
            chkChuaHoanThanh.AutoSize = true;
            chkChuaHoanThanh.Location = new Point(240, 9);
            chkChuaHoanThanh.Name = "chkChuaHoanThanh";
            chkChuaHoanThanh.Size = new Size(215, 21);
            chkChuaHoanThanh.TabIndex = 1;
            chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";
            chkChuaHoanThanh.UseVisualStyleBackColor = true;

            // 
            // chkLocTheoNgay
            // 
            chkLocTheoNgay.AutoSize = true;
            chkLocTheoNgay.Location = new Point(465, 9);
            chkLocTheoNgay.Name = "chkLocTheoNgay";
            chkLocTheoNgay.Size = new Size(116, 21);
            chkLocTheoNgay.TabIndex = 2;
            chkLocTheoNgay.Text = "Lọc theo ngày";
            chkLocTheoNgay.UseVisualStyleBackColor = true;

            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(585, 10);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(26, 17);
            lblTuNgay.TabIndex = 3;
            lblTuNgay.Text = "Từ:";

            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Enabled = false;
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Location = new Point(615, 7);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(110, 24);
            dtpTuNgay.TabIndex = 4;

            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(730, 10);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(34, 17);
            lblDenNgay.TabIndex = 5;
            lblDenNgay.Text = "Đến:";

            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Enabled = false;
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Location = new Point(770, 7);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(110, 24);
            dtpDenNgay.TabIndex = 6;

            // 
            // btnTim
            // 
            btnTim.BackColor = Color.FromArgb(240, 240, 240);
            btnTim.FlatStyle = FlatStyle.System;
            btnTim.Location = new Point(890, 5);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(55, 28);
            btnTim.TabIndex = 7;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;

            // 
            // btnBoLoc
            // 
            btnBoLoc.BackColor = Color.FromArgb(240, 240, 240);
            btnBoLoc.FlatStyle = FlatStyle.System;
            btnBoLoc.Location = new Point(950, 5);
            btnBoLoc.Name = "btnBoLoc";
            btnBoLoc.Size = new Size(60, 28);
            btnBoLoc.TabIndex = 8;
            btnBoLoc.Text = "Tất cả";
            btnBoLoc.UseVisualStyleBackColor = false;

            // 
            // dgvChuyenDi
            // 
            dgvChuyenDi.AllowUserToAddRows = false;
            dgvChuyenDi.AllowUserToDeleteRows = false;
            dgvChuyenDi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChuyenDi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenDi.BackgroundColor = Color.White;
            dgvChuyenDi.BorderStyle = BorderStyle.Fixed3D;
            dgvChuyenDi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenDi.Location = new Point(20, 425);
            dgvChuyenDi.MultiSelect = false;
            dgvChuyenDi.Name = "dgvChuyenDi";
            dgvChuyenDi.ReadOnly = true;
            dgvChuyenDi.RowHeadersVisible = true;
            dgvChuyenDi.RowHeadersWidth = 30;
            dgvChuyenDi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenDi.Size = new Size(1010, 240);
            dgvChuyenDi.TabIndex = 8;

            // 
            // FormChuyenDi
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1050, 680);
            Controls.Add(dgvChuyenDi);
            Controls.Add(pnlFilter);
            Controls.Add(grpWeather);
            Controls.Add(progressBarWeather);
            Controls.Add(btnXemThoiTiet);
            Controls.Add(grpTripInfo);
            Controls.Add(cboLanguage);
            Controls.Add(lblLanguage);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1000, 650);
            Name = "FormChuyenDi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kế hoạch dã ngoại";

            grpTripInfo.ResumeLayout(false);
            grpTripInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoNguoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNganSach).EndInit();
            grpWeather.ResumeLayout(false);
            grpWeather.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picWeatherIcon).EndInit();
            pnlWarning.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblLanguage;
        private ComboBox cboLanguage;

        private GroupBox grpTripInfo;
        private Label lblTenChuyen;
        private TextBox txtTenChuyen;
        private Label lblDiaDiem;
        private TextBox txtDiaDiem;
        private Label lblNgayDi;
        private DateTimePicker dtpNgayDi;
        private Label lblSoNguoi;
        private NumericUpDown numSoNguoi;
        private Label lblNganSach;
        private NumericUpDown numNganSach;
        private Label lblPhuongTien;
        private ComboBox cboPhuongTien;
        private CheckBox chkDaHoanThanh;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private Button btnXemThoiTiet;
        private ProgressBar progressBarWeather;
        private GroupBox grpWeather;
        private Label lblWeatherHeader;
        private PictureBox picWeatherIcon;
        private Label lblWeatherDesc;
        private Label lblWeatherTemp;
        private Label lblWeatherRainProb;
        private Panel pnlWarning;
        private Label lblWarningIcon;
        private Label lblWarningText;

        private Panel pnlFilter;
        private TextBox txtTimKiem;
        private CheckBox chkChuaHoanThanh;
        private CheckBox chkLocTheoNgay;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTim;
        private Button btnBoLoc;

        private DataGridView dgvChuyenDi;
    }
}
