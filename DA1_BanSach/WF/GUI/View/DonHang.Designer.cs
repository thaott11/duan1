namespace WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien
{
    partial class DonHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonHang));
            panel1 = new Panel();
            label10 = new Label();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            dgvHoaDon = new DataGridView();
            panel4 = new Panel();
            button3 = new Button();
            button1 = new Button();
            dtpdenngay = new DateTimePicker();
            label2 = new Label();
            button2 = new Button();
            dtptungay = new DateTimePicker();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvHoaDonChiTiet = new DataGridView();
            pdhd = new System.Drawing.Printing.PrintDocument();
            ppdhd = new PrintPreviewDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            panel4.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonChiTiet).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(label10);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5, 6, 5, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1301, 78);
            panel1.TabIndex = 40;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(461, 9);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(384, 55);
            label10.TabIndex = 3;
            label10.Text = "Quản lý Hóa Đơn";
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 78);
            panel2.Name = "panel2";
            panel2.Size = new Size(1301, 758);
            panel2.TabIndex = 47;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ButtonFace;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 68.33773F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 31.66227F));
            tableLayoutPanel1.Size = new Size(1301, 758);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonFace;
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0, 0, 0, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1301, 513);
            panel3.TabIndex = 40;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvHoaDon);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1301, 435);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách hóa đơn";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.BackgroundColor = SystemColors.ButtonHighlight;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(3, 36);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 62;
            dgvHoaDon.RowTemplate.Height = 33;
            dgvHoaDon.Size = new Size(1295, 396);
            dgvHoaDon.TabIndex = 0;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            dgvHoaDon.CellDoubleClick += dgvHoaDon_CellDoubleClick;
            // 
            // panel4
            // 
            panel4.Controls.Add(button3);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(dtpdenngay);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(dtptungay);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1301, 78);
            panel4.TabIndex = 0;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackgroundImage = Properties.Resources._in;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Location = new Point(1175, 16);
            button3.Name = "button3";
            button3.Size = new Size(50, 50);
            button3.TabIndex = 53;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = SystemColors.ActiveBorder;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(805, 15);
            button1.Margin = new Padding(5, 4, 5, 4);
            button1.Name = "button1";
            button1.Size = new Size(213, 46);
            button1.TabIndex = 47;
            button1.Text = "Lọc Hóa Đơn";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dtpdenngay
            // 
            dtpdenngay.CalendarFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpdenngay.CustomFormat = "dd/MM/yyyy";
            dtpdenngay.Format = DateTimePickerFormat.Custom;
            dtpdenngay.Location = new Point(585, 23);
            dtpdenngay.Margin = new Padding(5, 6, 5, 6);
            dtpdenngay.Name = "dtpdenngay";
            dtpdenngay.Size = new Size(184, 31);
            dtpdenngay.TabIndex = 52;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(445, 21);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(141, 33);
            label2.TabIndex = 51;
            label2.Text = "Đến Ngày :";
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(33, 15);
            button2.Margin = new Padding(5, 6, 5, 6);
            button2.Name = "button2";
            button2.Size = new Size(92, 48);
            button2.TabIndex = 50;
            button2.Text = "ALL";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dtptungay
            // 
            dtptungay.CalendarFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtptungay.CustomFormat = "dd/MM/yyyy";
            dtptungay.Format = DateTimePickerFormat.Custom;
            dtptungay.Location = new Point(254, 23);
            dtptungay.Margin = new Padding(5, 6, 5, 6);
            dtptungay.Name = "dtptungay";
            dtptungay.Size = new Size(181, 31);
            dtptungay.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(135, 23);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(126, 33);
            label1.TabIndex = 49;
            label1.Text = "Từ Ngày :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvHoaDonChiTiet);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(3, 521);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1295, 234);
            groupBox2.TabIndex = 41;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hóa đơn chi tiết";
            // 
            // dgvHoaDonChiTiet
            // 
            dgvHoaDonChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDonChiTiet.BackgroundColor = SystemColors.ButtonHighlight;
            dgvHoaDonChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDonChiTiet.Dock = DockStyle.Fill;
            dgvHoaDonChiTiet.Location = new Point(3, 36);
            dgvHoaDonChiTiet.Name = "dgvHoaDonChiTiet";
            dgvHoaDonChiTiet.RowHeadersWidth = 62;
            dgvHoaDonChiTiet.RowTemplate.Height = 33;
            dgvHoaDonChiTiet.Size = new Size(1289, 195);
            dgvHoaDonChiTiet.TabIndex = 0;
            // 
            // pdhd
            // 
            pdhd.PrintPage += pdhd_PrintPage;
            // 
            // ppdhd
            // 
            ppdhd.AutoScrollMargin = new Size(0, 0);
            ppdhd.AutoScrollMinSize = new Size(0, 0);
            ppdhd.ClientSize = new Size(400, 300);
            ppdhd.Enabled = true;
            ppdhd.Icon = (Icon)resources.GetObject("ppdhd.Icon");
            ppdhd.Name = "ppdhd";
            ppdhd.Visible = false;
            // 
            // DonHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1301, 836);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "DonHang";
            Text = "DonHang";
            Load += DonHang_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonChiTiet).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label10;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private GroupBox groupBox1;
        private Panel panel4;
        private Button button1;
        private DateTimePicker dtpdenngay;
        private Label label2;
        private Button button2;
        private DateTimePicker dtptungay;
        private Label label1;
        private GroupBox groupBox2;
        private Button button3;
        private DataGridView dgvHoaDon;
        private DataGridView dgvHoaDonChiTiet;
        private System.Drawing.Printing.PrintDocument pdhd;
        private PrintPreviewDialog ppdhd;
    }
}