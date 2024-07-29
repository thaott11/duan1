namespace WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien
{
    partial class KhachHangg
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
            btnLammoi = new Button();
            btnSua = new Button();
            btnThem = new Button();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            txtDiaChi = new TextBox();
            txtSĐT = new TextBox();
            txtTenKh = new TextBox();
            txtMaKH = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            dgvDanhSachkh = new DataGridView();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            txtTimKiemkh = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachkh).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Times New Roman", 26F, FontStyle.Bold, GraphicsUnit.Point);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5, 6, 5, 6);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(1301, 83);
            panel1.TabIndex = 41;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(422, 12);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(476, 55);
            label5.TabIndex = 3;
            label5.Text = "Quản Lý Khách Hàng";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(btnLammoi);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(rdoNu);
            panel2.Controls.Add(rdoNam);
            panel2.Controls.Add(txtDiaChi);
            panel2.Controls.Add(txtSĐT);
            panel2.Controls.Add(txtTenKh);
            panel2.Controls.Add(txtMaKH);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(1301, 279);
            panel2.TabIndex = 42;
            // 
            // btnLammoi
            // 
            btnLammoi.BackColor = Color.RosyBrown;
            btnLammoi.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnLammoi.Location = new Point(1118, 172);
            btnLammoi.Name = "btnLammoi";
            btnLammoi.Size = new Size(139, 52);
            btnLammoi.TabIndex = 13;
            btnLammoi.Text = "Làm mới";
            btnLammoi.UseVisualStyleBackColor = false;
            btnLammoi.Click += btnLammoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.RosyBrown;
            btnSua.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnSua.Location = new Point(943, 172);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(139, 52);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.RosyBrown;
            btnThem.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.Location = new Point(759, 172);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(139, 52);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(385, 143);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(61, 29);
            rdoNu.TabIndex = 10;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(251, 145);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(75, 29);
            rdoNam.TabIndex = 9;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(839, 31);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(450, 83);
            txtDiaChi.TabIndex = 8;
            // 
            // txtSĐT
            // 
            txtSĐT.Location = new Point(251, 206);
            txtSĐT.Name = "txtSĐT";
            txtSĐT.Size = new Size(445, 31);
            txtSĐT.TabIndex = 7;
            // 
            // txtTenKh
            // 
            txtTenKh.Location = new Point(251, 87);
            txtTenKh.Name = "txtTenKh";
            txtTenKh.Size = new Size(445, 31);
            txtTenKh.TabIndex = 6;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(251, 33);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(445, 31);
            txtMaKH.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(740, 31);
            label6.Name = "label6";
            label6.Size = new Size(93, 27);
            label6.TabIndex = 4;
            label6.Text = "Địa chỉ :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(53, 206);
            label4.Name = "label4";
            label4.Size = new Size(149, 27);
            label4.TabIndex = 3;
            label4.Text = "Số điện thoại :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(53, 145);
            label3.Name = "label3";
            label3.Size = new Size(109, 27);
            label3.TabIndex = 2;
            label3.Text = "Giới tính :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(53, 87);
            label2.Name = "label2";
            label2.Size = new Size(177, 27);
            label2.TabIndex = 1;
            label2.Text = "Tên khách hàng :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 33);
            label1.Name = "label1";
            label1.Size = new Size(177, 27);
            label1.TabIndex = 0;
            label1.Text = "Mã Khách hàng :";
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 362);
            panel3.Name = "panel3";
            panel3.Size = new Size(1301, 474);
            panel3.TabIndex = 43;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(dgvDanhSachkh);
            groupBox1.Controls.Add(panel4);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1301, 474);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách khách hàng";
            // 
            // dgvDanhSachkh
            // 
            dgvDanhSachkh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachkh.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDanhSachkh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachkh.Dock = DockStyle.Fill;
            dgvDanhSachkh.Location = new Point(3, 94);
            dgvDanhSachkh.Name = "dgvDanhSachkh";
            dgvDanhSachkh.RowHeadersWidth = 62;
            dgvDanhSachkh.RowTemplate.Height = 33;
            dgvDanhSachkh.Size = new Size(1295, 377);
            dgvDanhSachkh.TabIndex = 1;
            dgvDanhSachkh.CellClick += dgvDanhSachkh_CellClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(txtTimKiemkh);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 36);
            panel4.Name = "panel4";
            panel4.Size = new Size(1295, 58);
            panel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.tk;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(888, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 39);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // txtTimKiemkh
            // 
            txtTimKiemkh.Location = new Point(363, 6);
            txtTimKiemkh.Multiline = true;
            txtTimKiemkh.Name = "txtTimKiemkh";
            txtTimKiemkh.Size = new Size(568, 46);
            txtTimKiemkh.TabIndex = 2;
            txtTimKiemkh.TextChanged += txtTimKiemkh_TextChanged;
            // 
            // KhachHangg
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1301, 836);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "KhachHangg";
            Text = "KhachHang";
            Load += KhachHang_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachkh).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label5;
        private Panel panel2;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private TextBox txtDiaChi;
        private TextBox txtSĐT;
        private TextBox txtTenKh;
        private TextBox txtMaKH;
        private Button btnLammoi;
        private Button btnSua;
        private Button btnThem;
        private Panel panel3;
        private GroupBox groupBox1;
        private DataGridView dgvDanhSachkh;
        private Panel panel4;
        private PictureBox pictureBox1;
        private TextBox txtTimKiemkh;
    }
}