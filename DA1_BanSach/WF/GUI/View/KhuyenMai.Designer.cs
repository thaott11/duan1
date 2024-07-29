namespace WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN
{
    partial class KhuyenMai
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
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            dgvDanhSachMaGiamGia = new DataGridView();
            panel8 = new Panel();
            pictureBox1 = new PictureBox();
            txtTimKiem = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            label2 = new Label();
            dtpNgayBatDau = new DateTimePicker();
            txtSoLuong = new TextBox();
            label9 = new Label();
            txtGiamToiDa = new TextBox();
            txtMaGiamGia = new TextBox();
            dtpNgayKetThuc = new DateTimePicker();
            txtTiLeGiam = new TextBox();
            txtDonToiThieu = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            panel5 = new Panel();
            btnLamMoi = new Button();
            panel7 = new Panel();
            btnSua = new Button();
            panel6 = new Panel();
            btnThem = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachMaGiamGia).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1301, 83);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(437, 14);
            label5.Name = "label5";
            label5.Size = new Size(280, 55);
            label5.TabIndex = 1;
            label5.Text = "Mã giảm giá";
            // 
            // panel2
            // 
            panel2.BackColor = Color.GhostWhite;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 83);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(1301, 753);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            panel3.Location = new Point(10, 381);
            panel3.Margin = new Padding(10);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(1281, 362);
            panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvDanhSachMaGiamGia);
            groupBox1.Controls.Add(panel8);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1261, 342);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách mã giảm giá ";
            // 
            // dgvDanhSachMaGiamGia
            // 
            dgvDanhSachMaGiamGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachMaGiamGia.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDanhSachMaGiamGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachMaGiamGia.Dock = DockStyle.Fill;
            dgvDanhSachMaGiamGia.Location = new Point(3, 96);
            dgvDanhSachMaGiamGia.Name = "dgvDanhSachMaGiamGia";
            dgvDanhSachMaGiamGia.RowHeadersWidth = 62;
            dgvDanhSachMaGiamGia.RowTemplate.Height = 33;
            dgvDanhSachMaGiamGia.Size = new Size(1255, 243);
            dgvDanhSachMaGiamGia.TabIndex = 1;
            dgvDanhSachMaGiamGia.CellClick += dgvDanhSachMaGiamGia_CellClick_1;
            // 
            // panel8
            // 
            panel8.Controls.Add(pictureBox1);
            panel8.Controls.Add(txtTimKiem);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(3, 36);
            panel8.Name = "panel8";
            panel8.Size = new Size(1255, 60);
            panel8.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.tk;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(736, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 39);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(224, 8);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(555, 46);
            txtTimKiem.TabIndex = 4;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.4356F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.5644035F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Controls.Add(panel5, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1281, 371);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Controls.Add(dtpNgayBatDau);
            panel4.Controls.Add(txtSoLuong);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(txtGiamToiDa);
            panel4.Controls.Add(txtMaGiamGia);
            panel4.Controls.Add(dtpNgayKetThuc);
            panel4.Controls.Add(txtTiLeGiam);
            panel4.Controls.Add(txtDonToiThieu);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1050, 365);
            panel4.TabIndex = 0;
            panel4.Paint += panel4_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(40, 98);
            label2.Name = "label2";
            label2.Size = new Size(176, 33);
            label2.TabIndex = 17;
            label2.Text = "Ngày bắt đầu :";
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.CustomFormat = "dd-MM-yyyy";
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.Location = new Point(285, 100);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(258, 31);
            dtpNgayBatDau.TabIndex = 18;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(749, 102);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(298, 31);
            txtSoLuong.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(575, 98);
            label9.Name = "label9";
            label9.Size = new Size(171, 33);
            label9.TabIndex = 15;
            label9.Text = "Số lượng mã :";
            // 
            // txtGiamToiDa
            // 
            txtGiamToiDa.Location = new Point(740, 29);
            txtGiamToiDa.Name = "txtGiamToiDa";
            txtGiamToiDa.Size = new Size(307, 31);
            txtGiamToiDa.TabIndex = 12;
            // 
            // txtMaGiamGia
            // 
            txtMaGiamGia.Location = new Point(286, 30);
            txtMaGiamGia.Name = "txtMaGiamGia";
            txtMaGiamGia.Size = new Size(258, 31);
            txtMaGiamGia.TabIndex = 11;
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.CustomFormat = "dd-MM-yyyy";
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.Location = new Point(286, 172);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(258, 31);
            dtpNgayKetThuc.TabIndex = 10;
            // 
            // txtTiLeGiam
            // 
            txtTiLeGiam.Location = new Point(286, 244);
            txtTiLeGiam.Name = "txtTiLeGiam";
            txtTiLeGiam.Size = new Size(258, 31);
            txtTiLeGiam.TabIndex = 8;
            // 
            // txtDonToiThieu
            // 
            txtDonToiThieu.Location = new Point(285, 313);
            txtDonToiThieu.Name = "txtDonToiThieu";
            txtDonToiThieu.Size = new Size(258, 31);
            txtDonToiThieu.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(575, 27);
            label7.Name = "label7";
            label7.Size = new Size(159, 33);
            label7.TabIndex = 5;
            label7.Text = "Giảm tối đa :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(40, 310);
            label6.Name = "label6";
            label6.Size = new Size(239, 33);
            label6.TabIndex = 4;
            label6.Text = "Đơn hàng tối thiếu :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(40, 241);
            label4.Name = "label4";
            label4.Size = new Size(141, 33);
            label4.TabIndex = 3;
            label4.Text = "Tỉ lệ giảm :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(40, 170);
            label3.Name = "label3";
            label3.Size = new Size(184, 33);
            label3.TabIndex = 2;
            label3.Text = "Ngày kết thúc :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(40, 27);
            label1.Name = "label1";
            label1.Size = new Size(167, 33);
            label1.TabIndex = 0;
            label1.Text = "Mã giảm giá :";
            // 
            // panel5
            // 
            panel5.Controls.Add(btnLamMoi);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(btnSua);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(btnThem);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(1059, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(219, 365);
            panel5.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.DarkCyan;
            btnLamMoi.Dock = DockStyle.Top;
            btnLamMoi.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnLamMoi.Location = new Point(0, 276);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(219, 89);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 227);
            panel7.Name = "panel7";
            panel7.Size = new Size(219, 49);
            panel7.TabIndex = 3;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.DarkCyan;
            btnSua.Dock = DockStyle.Top;
            btnSua.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnSua.Location = new Point(0, 138);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(219, 89);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 89);
            panel6.Name = "panel6";
            panel6.Size = new Size(219, 49);
            panel6.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DarkCyan;
            btnThem.Dock = DockStyle.Top;
            btnThem.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.Location = new Point(0, 0);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(219, 89);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // KhuyenMai
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1301, 836);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "KhuyenMai";
            Text = "KhuyenMai";
            Load += KhuyenMai_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachMaGiamGia).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private GroupBox groupBox1;
        private Panel panel4;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label1;
        private Panel panel5;
        private DateTimePicker dtpNgayKetThuc;
        private TextBox txtTiLeGiam;
        private TextBox txtDonToiThieu;
        private TextBox txtGiamToiDa;
        private TextBox txtMaGiamGia;
        private Button button2;
        private Panel panel6;
        private Button btnThem;
        private Button btnLamMoi;
        private Panel panel7;
        private Button btnSua;
        private TextBox txtSoLuong;
        private Label label9;
        private DateTimePicker dtpNgayBatDau;
        private Label label2;
        private DataGridView dgvDanhSachMaGiamGia;
        private Panel panel8;
        private PictureBox pictureBox1;
        private TextBox txtTimKiem;
    }
}