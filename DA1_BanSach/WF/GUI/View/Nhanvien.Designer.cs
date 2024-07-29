namespace WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN
{
    partial class Nhanvien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            rdoquanly = new RadioButton();
            rdoNhanvien = new RadioButton();
            label10 = new Label();
            groupBox3 = new GroupBox();
            rdonu = new RadioButton();
            rdoNam = new RadioButton();
            label9 = new Label();
            rdoNghilam = new RadioButton();
            rdoDangLam = new RadioButton();
            label3 = new Label();
            label2 = new Label();
            txtsđt = new TextBox();
            label1 = new Label();
            txtMaNV = new TextBox();
            txtdiachi = new TextBox();
            txtmatkhau = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            dtpNgaySinh = new DateTimePicker();
            label8 = new Label();
            txttaikhoan = new TextBox();
            label7 = new Label();
            txtcccd = new TextBox();
            label6 = new Label();
            txtTen = new TextBox();
            label4 = new Label();
            txtemail = new TextBox();
            panel4 = new Panel();
            txtLammoi = new Button();
            panel10 = new Panel();
            txtSua = new Button();
            panel7 = new Panel();
            btnThem = new Button();
            panel6 = new Panel();
            label14 = new Label();
            groupBox1 = new GroupBox();
            dgvDanhSach = new DataGridView();
            panel9 = new Panel();
            label15 = new Label();
            comboBox1 = new ComboBox();
            pictureBox2 = new PictureBox();
            txtTimKiem = new TextBox();
            panel5 = new Panel();
            panel8 = new Panel();
            btnChonAnh = new Button();
            pictureNhanvien = new PictureBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            panel4.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureNhanvien).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1301, 54);
            panel1.TabIndex = 1;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(495, 9);
            label5.Name = "label5";
            label5.Size = new Size(315, 37);
            label5.TabIndex = 1;
            label5.Text = "Quản Lý Nhân Viên";
            // 
            // panel2
            // 
            panel2.BackColor = Color.GhostWhite;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 54);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(1301, 792);
            panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.GhostWhite;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.03044F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.9695549F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel4, 1, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1281, 772);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Lavender;
            panel3.Controls.Add(groupBox2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1031, 380);
            panel3.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(rdoNghilam);
            groupBox2.Controls.Add(rdoDangLam);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtsđt);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtMaNV);
            groupBox2.Controls.Add(txtdiachi);
            groupBox2.Controls.Add(txtmatkhau);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(dtpNgaySinh);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txttaikhoan);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtcccd);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtTen);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtemail);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1031, 380);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Tin Nhân Viên";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rdoquanly);
            groupBox4.Controls.Add(rdoNhanvien);
            groupBox4.Controls.Add(label10);
            groupBox4.Location = new Point(464, 15);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(484, 69);
            groupBox4.TabIndex = 33;
            groupBox4.TabStop = false;
            // 
            // rdoquanly
            // 
            rdoquanly.AutoSize = true;
            rdoquanly.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoquanly.Location = new Point(259, 26);
            rdoquanly.Name = "rdoquanly";
            rdoquanly.Size = new Size(122, 31);
            rdoquanly.TabIndex = 23;
            rdoquanly.TabStop = true;
            rdoquanly.Text = "Quản Lý";
            rdoquanly.UseVisualStyleBackColor = true;
            // 
            // rdoNhanvien
            // 
            rdoNhanvien.AutoSize = true;
            rdoNhanvien.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoNhanvien.Location = new Point(115, 26);
            rdoNhanvien.Name = "rdoNhanvien";
            rdoNhanvien.Size = new Size(139, 31);
            rdoNhanvien.TabIndex = 22;
            rdoNhanvien.TabStop = true;
            rdoNhanvien.Text = "Nhân Viên";
            rdoNhanvien.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(6, 29);
            label10.Name = "label10";
            label10.Size = new Size(93, 27);
            label10.TabIndex = 21;
            label10.Text = "Vai Trò :";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rdonu);
            groupBox3.Controls.Add(rdoNam);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(32, 223);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(426, 51);
            groupBox3.TabIndex = 32;
            groupBox3.TabStop = false;
            // 
            // rdonu
            // 
            rdonu.AutoSize = true;
            rdonu.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdonu.Location = new Point(282, 19);
            rdonu.Name = "rdonu";
            rdonu.Size = new Size(67, 31);
            rdonu.TabIndex = 20;
            rdonu.TabStop = true;
            rdonu.Text = "Nữ";
            rdonu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoNam.Location = new Point(160, 17);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(83, 31);
            rdoNam.TabIndex = 19;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(1, 17);
            label9.Name = "label9";
            label9.Size = new Size(116, 27);
            label9.TabIndex = 18;
            label9.Text = "Giới Tính :";
            // 
            // rdoNghilam
            // 
            rdoNghilam.AutoSize = true;
            rdoNghilam.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoNghilam.Location = new Point(743, 287);
            rdoNghilam.Name = "rdoNghilam";
            rdoNghilam.Size = new Size(124, 31);
            rdoNghilam.TabIndex = 31;
            rdoNghilam.TabStop = true;
            rdoNghilam.Text = "Nghỉ làm";
            rdoNghilam.UseVisualStyleBackColor = true;
            // 
            // rdoDangLam
            // 
            rdoDangLam.AutoSize = true;
            rdoDangLam.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoDangLam.Location = new Point(593, 286);
            rdoDangLam.Name = "rdoDangLam";
            rdoDangLam.Size = new Size(135, 31);
            rdoDangLam.TabIndex = 30;
            rdoDangLam.TabStop = true;
            rdoDangLam.Text = "Đang làm ";
            rdoDangLam.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(464, 286);
            label3.Name = "label3";
            label3.Size = new Size(121, 27);
            label3.TabIndex = 29;
            label3.Text = "Trạng thái :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 332);
            label2.Name = "label2";
            label2.Size = new Size(67, 27);
            label2.TabIndex = 28;
            label2.Text = "SDT :";
            // 
            // txtsđt
            // 
            txtsđt.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtsđt.Location = new Point(192, 329);
            txtsđt.Name = "txtsđt";
            txtsđt.Size = new Size(260, 35);
            txtsđt.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(26, 90);
            label1.Name = "label1";
            label1.Size = new Size(166, 27);
            label1.TabIndex = 26;
            label1.Text = "Tên Nhân viên :";
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtMaNV.Location = new Point(192, 41);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(260, 35);
            txtMaNV.TabIndex = 25;
            // 
            // txtdiachi
            // 
            txtdiachi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtdiachi.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtdiachi.Location = new Point(592, 195);
            txtdiachi.Multiline = true;
            txtdiachi.Name = "txtdiachi";
            txtdiachi.Size = new Size(369, 71);
            txtdiachi.TabIndex = 24;
            // 
            // txtmatkhau
            // 
            txtmatkhau.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtmatkhau.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtmatkhau.Location = new Point(593, 141);
            txtmatkhau.Name = "txtmatkhau";
            txtmatkhau.Size = new Size(369, 35);
            txtmatkhau.TabIndex = 23;
            txtmatkhau.UseSystemPasswordChar = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(464, 141);
            label13.Name = "label13";
            label13.Size = new Size(116, 27);
            label13.TabIndex = 22;
            label13.Text = "Mật khẩu :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(464, 87);
            label12.Name = "label12";
            label12.Size = new Size(120, 27);
            label12.TabIndex = 21;
            label12.Text = "Tài khoản :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(464, 195);
            label11.Name = "label11";
            label11.Size = new Size(98, 27);
            label11.TabIndex = 21;
            label11.Text = "Địa Chỉ :";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd-MM-yyyy";
            dtpNgaySinh.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(192, 183);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(260, 35);
            dtpNgaySinh.TabIndex = 15;
            dtpNgaySinh.Value = new DateTime(2024, 3, 17, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(26, 185);
            label8.Name = "label8";
            label8.Size = new Size(123, 27);
            label8.TabIndex = 13;
            label8.Text = "Ngày Sinh :";
            // 
            // txttaikhoan
            // 
            txttaikhoan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txttaikhoan.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txttaikhoan.Location = new Point(592, 90);
            txttaikhoan.Name = "txttaikhoan";
            txttaikhoan.Size = new Size(369, 35);
            txttaikhoan.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(26, 137);
            label7.Name = "label7";
            label7.Size = new Size(125, 27);
            label7.TabIndex = 11;
            label7.Text = "Số CMND :";
            // 
            // txtcccd
            // 
            txtcccd.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtcccd.Location = new Point(192, 133);
            txtcccd.Name = "txtcccd";
            txtcccd.Size = new Size(260, 35);
            txtcccd.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(26, 283);
            label6.Name = "label6";
            label6.Size = new Size(80, 27);
            label6.TabIndex = 9;
            label6.Text = "Email :";
            // 
            // txtTen
            // 
            txtTen.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTen.Location = new Point(192, 87);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(260, 35);
            txtTen.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(26, 39);
            label4.Name = "label4";
            label4.Size = new Size(161, 27);
            label4.TabIndex = 7;
            label4.Text = "Mã Nhân viên :";
            // 
            // txtemail
            // 
            txtemail.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtemail.Location = new Point(192, 280);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(260, 35);
            txtemail.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Lavender;
            panel4.Controls.Add(txtLammoi);
            panel4.Controls.Add(panel10);
            panel4.Controls.Add(txtSua);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(btnThem);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(label14);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(1040, 389);
            panel4.Name = "panel4";
            panel4.Size = new Size(238, 380);
            panel4.TabIndex = 1;
            // 
            // txtLammoi
            // 
            txtLammoi.BackColor = Color.DarkCyan;
            txtLammoi.Dock = DockStyle.Top;
            txtLammoi.FlatStyle = FlatStyle.Flat;
            txtLammoi.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            txtLammoi.Location = new Point(0, 270);
            txtLammoi.Name = "txtLammoi";
            txtLammoi.Size = new Size(238, 70);
            txtLammoi.TabIndex = 32;
            txtLammoi.Text = "làm mới";
            txtLammoi.UseVisualStyleBackColor = false;
            txtLammoi.Click += txtLammoi_Click_1;
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 230);
            panel10.Name = "panel10";
            panel10.Size = new Size(238, 40);
            panel10.TabIndex = 31;
            // 
            // txtSua
            // 
            txtSua.BackColor = Color.DarkCyan;
            txtSua.Dock = DockStyle.Top;
            txtSua.FlatStyle = FlatStyle.Flat;
            txtSua.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            txtSua.Location = new Point(0, 160);
            txtSua.Name = "txtSua";
            txtSua.Size = new Size(238, 70);
            txtSua.TabIndex = 30;
            txtSua.Text = "Cập Nhập Thông Tin";
            txtSua.UseVisualStyleBackColor = false;
            txtSua.Click += txtSua_Click_1;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 120);
            panel7.Name = "panel7";
            panel7.Size = new Size(238, 40);
            panel7.TabIndex = 30;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DarkCyan;
            btnThem.Dock = DockStyle.Top;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.Location = new Point(0, 50);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(238, 70);
            btnThem.TabIndex = 29;
            btnThem.Text = "Thêm Nhân Viên";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click_1;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(238, 50);
            panel6.TabIndex = 27;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(27, 30);
            label14.Name = "label14";
            label14.Size = new Size(0, 22);
            label14.TabIndex = 26;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvDanhSach);
            groupBox1.Controls.Add(panel9);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(10, 396);
            groupBox1.Margin = new Padding(10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1017, 366);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh Sách Nhân Viên";
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSach.Dock = DockStyle.Fill;
            dgvDanhSach.Location = new Point(3, 102);
            dgvDanhSach.Name = "dgvDanhSach";
            dgvDanhSach.RowHeadersWidth = 62;
            dgvDanhSach.RowTemplate.Height = 33;
            dgvDanhSach.Size = new Size(1011, 261);
            dgvDanhSach.TabIndex = 2;
            dgvDanhSach.CellClick += dgvDanhSach_CellClick_1;
            // 
            // panel9
            // 
            panel9.Controls.Add(label15);
            panel9.Controls.Add(comboBox1);
            panel9.Controls.Add(pictureBox2);
            panel9.Controls.Add(txtTimKiem);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(3, 31);
            panel9.Name = "panel9";
            panel9.Size = new Size(1011, 71);
            panel9.TabIndex = 1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(362, 4);
            label15.Name = "label15";
            label15.Size = new Size(139, 27);
            label15.TabIndex = 7;
            label15.Text = "Lọc chức vụ:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Quản Lý", "Nhân Viên" });
            comboBox1.Location = new Point(362, 31);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(213, 35);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.tk;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(277, 18);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 31);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(34, 15);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(280, 38);
            txtTimKiem.TabIndex = 4;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel8);
            panel5.Controls.Add(pictureNhanvien);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(1040, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(238, 380);
            panel5.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnChonAnh);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 337);
            panel8.Name = "panel8";
            panel8.Size = new Size(238, 43);
            panel8.TabIndex = 2;
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.DarkCyan;
            btnChonAnh.Dock = DockStyle.Fill;
            btnChonAnh.Location = new Point(0, 0);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(238, 43);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // pictureNhanvien
            // 
            pictureNhanvien.BackColor = Color.Black;
            pictureNhanvien.Dock = DockStyle.Fill;
            pictureNhanvien.Location = new Point(0, 0);
            pictureNhanvien.Name = "pictureNhanvien";
            pictureNhanvien.Size = new Size(238, 380);
            pictureNhanvien.SizeMode = PictureBoxSizeMode.Zoom;
            pictureNhanvien.TabIndex = 0;
            pictureNhanvien.TabStop = false;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.Connection = null;
            sqlCommand1.Notification = null;
            sqlCommand1.Transaction = null;
            // 
            // Nhanvien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1301, 846);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "Nhanvien";
            Text = "Nhanvien";
            Load += Nhanvien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureNhanvien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Panel panel2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private RadioButton rdoquanly;
        private RadioButton rdoNhanvien;
        private Label label10;
        private PictureBox pictureNhanvien;
        private GroupBox groupBox3;
        private RadioButton rdonu;
        private RadioButton rdoNam;
        private Label label9;
        private RadioButton rdoNghilam;
        private RadioButton rdoDangLam;
        private Label label3;
        private Label label2;
        private TextBox txtsđt;
        private Label label1;
        private TextBox txtMaNV;
        private TextBox txtdiachi;
        private TextBox txtmatkhau;
        private Label label13;
        private Label label12;
        private Label label11;
        private DateTimePicker dtpNgaySinh;
        private Label label8;
        private TextBox txttaikhoan;
        private Label label7;
        private TextBox txtcccd;
        private Label label6;
        private TextBox txtTen;
        private Label label4;
        private TextBox txtemail;
        private PictureBox pictureBox2;
        private TextBox txtTimKiem;
        private GroupBox groupBox1;
        private Button btnChonAnh;
        private Panel panel5;
        private Panel panel8;
        private Panel panel9;
        private Panel panel4;
        private Panel panel10;
        private Button txtSua;
        private Panel panel7;
        private Button btnThem;
        private Panel panel6;
        private Label label14;
        private Button txtLammoi;
        private DataGridView dgvDanhSach;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ComboBox comboBox1;
        private Label label15;
    }
}