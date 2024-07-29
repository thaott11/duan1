namespace WF.GUI.View
{
    partial class ThemKhachHang
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvdskh = new DataGridView();
            panel2 = new Panel();
            button1 = new Button();
            panel1 = new Panel();
            pictureBox4 = new PictureBox();
            txtTimkiemkh = new TextBox();
            tabPage2 = new TabPage();
            btnLammoi = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtDiaChi = new TextBox();
            label6 = new Label();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            txtSĐT = new TextBox();
            txtTenKh = new TextBox();
            txtMaKH = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdskh).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 605);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvdskh);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 567);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Danh sách khách hàng";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvdskh
            // 
            dgvdskh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdskh.BackgroundColor = SystemColors.ButtonHighlight;
            dgvdskh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdskh.Dock = DockStyle.Fill;
            dgvdskh.Location = new Point(3, 50);
            dgvdskh.Name = "dgvdskh";
            dgvdskh.RowHeadersWidth = 62;
            dgvdskh.RowTemplate.Height = 33;
            dgvdskh.Size = new Size(786, 428);
            dgvdskh.TabIndex = 3;
            dgvdskh.CellClick += dgvdskh_CellClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(3, 478);
            panel2.Name = "panel2";
            panel2.Size = new Size(786, 86);
            panel2.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Location = new Point(335, 24);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "Chọn";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(txtTimkiemkh);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(786, 47);
            panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.tk;
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(536, 8);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(34, 29);
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // txtTimkiemkh
            // 
            txtTimkiemkh.Location = new Point(147, 5);
            txtTimkiemkh.Multiline = true;
            txtTimkiemkh.Name = "txtTimkiemkh";
            txtTimkiemkh.Size = new Size(424, 36);
            txtTimkiemkh.TabIndex = 8;
            txtTimkiemkh.TextChanged += txtTimkiemkh_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnLammoi);
            tabPage2.Controls.Add(btnSua);
            tabPage2.Controls.Add(btnThem);
            tabPage2.Controls.Add(txtDiaChi);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(rdoNu);
            tabPage2.Controls.Add(rdoNam);
            tabPage2.Controls.Add(txtSĐT);
            tabPage2.Controls.Add(txtTenKh);
            tabPage2.Controls.Add(txtMaKH);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 567);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Thêm khách hàng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLammoi
            // 
            btnLammoi.BackColor = Color.RosyBrown;
            btnLammoi.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnLammoi.Location = new Point(503, 439);
            btnLammoi.Name = "btnLammoi";
            btnLammoi.Size = new Size(139, 52);
            btnLammoi.TabIndex = 24;
            btnLammoi.Text = "Làm mới";
            btnLammoi.UseVisualStyleBackColor = false;
            btnLammoi.Click += btnLammoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.RosyBrown;
            btnSua.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnSua.Location = new Point(328, 439);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(139, 52);
            btnSua.TabIndex = 23;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.RosyBrown;
            btnThem.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.Location = new Point(144, 439);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(139, 52);
            btnThem.TabIndex = 22;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(256, 271);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(450, 83);
            txtDiaChi.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(58, 271);
            label6.Name = "label6";
            label6.Size = new Size(93, 27);
            label6.TabIndex = 20;
            label6.Text = "Địa chỉ :";
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(390, 148);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(61, 29);
            rdoNu.TabIndex = 19;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(256, 150);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(75, 29);
            rdoNam.TabIndex = 18;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // txtSĐT
            // 
            txtSĐT.Location = new Point(256, 211);
            txtSĐT.Name = "txtSĐT";
            txtSĐT.Size = new Size(445, 31);
            txtSĐT.TabIndex = 17;
            // 
            // txtTenKh
            // 
            txtTenKh.Location = new Point(256, 92);
            txtTenKh.Name = "txtTenKh";
            txtTenKh.Size = new Size(445, 31);
            txtTenKh.TabIndex = 16;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(256, 38);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(445, 31);
            txtMaKH.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(58, 211);
            label4.Name = "label4";
            label4.Size = new Size(149, 27);
            label4.TabIndex = 14;
            label4.Text = "Số điện thoại :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(58, 150);
            label3.Name = "label3";
            label3.Size = new Size(109, 27);
            label3.TabIndex = 13;
            label3.Text = "Giới tính :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(58, 92);
            label2.Name = "label2";
            label2.Size = new Size(177, 27);
            label2.TabIndex = 12;
            label2.Text = "Tên khách hàng :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(58, 38);
            label1.Name = "label1";
            label1.Size = new Size(177, 27);
            label1.TabIndex = 11;
            label1.Text = "Mã Khách hàng :";
            // 
            // ThemKhachHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 605);
            Controls.Add(tabControl1);
            Name = "ThemKhachHang";
            Text = "ThemKhachHang";
            Load += ThemKhachHang_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvdskh).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private PictureBox pictureBox4;
        private TextBox txtTimkiemkh;
        private Panel panel2;
        private DataGridView dgvdskh;
        private Button button1;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private TextBox txtSĐT;
        private TextBox txtTenKh;
        private TextBox txtMaKH;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDiaChi;
        private Label label6;
        private Button btnLammoi;
        private Button btnSua;
        private Button btnThem;
    }
}