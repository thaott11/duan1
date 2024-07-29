namespace WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN
{
    partial class ThongKe
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
            label1 = new Label();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label6 = new Label();
            lbdoanhthu = new Label();
            label2 = new Label();
            panel4 = new Panel();
            lbspban = new Label();
            label3 = new Label();
            panel5 = new Panel();
            lbtongdonhang = new Label();
            label4 = new Label();
            panel6 = new Panel();
            export = new Button();
            btnThongKe = new Button();
            dtpDenNgay = new DateTimePicker();
            dtptungay = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            panel7 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvBanChay = new DataGridView();
            tabPage2 = new TabPage();
            dgvsaphethang = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBanChay).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvsaphethang).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1301, 106);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(534, 23);
            label1.Name = "label1";
            label1.Size = new Size(233, 60);
            label1.TabIndex = 0;
            label1.Text = "Thống kê";
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(1301, 170);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 276F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 159F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 326F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 149F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 279F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 104F));
            tableLayoutPanel1.Controls.Add(panel3, 1, 0);
            tableLayoutPanel1.Controls.Add(panel4, 3, 0);
            tableLayoutPanel1.Controls.Add(panel5, 5, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1301, 170);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.IndianRed;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(lbdoanhthu);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(11, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(270, 164);
            panel3.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(182, 75);
            label6.Name = "label6";
            label6.Size = new Size(62, 27);
            label6.TabIndex = 2;
            label6.Text = "VNĐ";
            // 
            // lbdoanhthu
            // 
            lbdoanhthu.AutoSize = true;
            lbdoanhthu.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbdoanhthu.Location = new Point(71, 65);
            lbdoanhthu.Name = "lbdoanhthu";
            lbdoanhthu.Size = new Size(32, 38);
            lbdoanhthu.TabIndex = 1;
            lbdoanhthu.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(14, 14);
            label2.Name = "label2";
            label2.Size = new Size(142, 32);
            label2.TabIndex = 0;
            label2.Text = "Doanh thu";
            // 
            // panel4
            // 
            panel4.BackColor = Color.ForestGreen;
            panel4.Controls.Add(lbspban);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(446, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(320, 164);
            panel4.TabIndex = 1;
            // 
            // lbspban
            // 
            lbspban.AutoSize = true;
            lbspban.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbspban.Location = new Point(124, 75);
            lbspban.Name = "lbspban";
            lbspban.Size = new Size(32, 38);
            lbspban.TabIndex = 3;
            lbspban.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(18, 14);
            label3.Name = "label3";
            label3.Size = new Size(289, 32);
            label3.TabIndex = 1;
            label3.Text = "Tổng sản phẩm đã bán";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Gold;
            panel5.Controls.Add(lbtongdonhang);
            panel5.Controls.Add(label4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(921, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(273, 164);
            panel5.TabIndex = 2;
            // 
            // lbtongdonhang
            // 
            lbtongdonhang.AutoSize = true;
            lbtongdonhang.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbtongdonhang.Location = new Point(124, 75);
            lbtongdonhang.Name = "lbtongdonhang";
            lbtongdonhang.Size = new Size(32, 38);
            lbtongdonhang.TabIndex = 4;
            lbtongdonhang.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(17, 14);
            label4.Name = "label4";
            label4.Size = new Size(198, 32);
            label4.TabIndex = 1;
            label4.Text = "Tổng đơn hàng";
            // 
            // panel6
            // 
            panel6.Controls.Add(export);
            panel6.Controls.Add(btnThongKe);
            panel6.Controls.Add(dtpDenNgay);
            panel6.Controls.Add(dtptungay);
            panel6.Controls.Add(label10);
            panel6.Controls.Add(label9);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 276);
            panel6.Name = "panel6";
            panel6.Size = new Size(1301, 82);
            panel6.TabIndex = 2;
            // 
            // export
            // 
            export.BackColor = Color.DarkCyan;
            export.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            export.Location = new Point(1143, 21);
            export.Name = "export";
            export.Size = new Size(158, 43);
            export.TabIndex = 5;
            export.Text = "Export Excel";
            export.UseVisualStyleBackColor = false;
            export.Click += export_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.DarkCyan;
            btnThongKe.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnThongKe.Location = new Point(955, 21);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(131, 43);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(650, 27);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(246, 31);
            dtpDenNgay.TabIndex = 3;
            // 
            // dtptungay
            // 
            dtptungay.CustomFormat = "dd/MM/yyyy";
            dtptungay.Format = DateTimePickerFormat.Custom;
            dtptungay.Location = new Point(231, 27);
            dtptungay.Name = "dtptungay";
            dtptungay.Size = new Size(246, 31);
            dtptungay.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(509, 24);
            label10.Name = "label10";
            label10.Size = new Size(135, 33);
            label10.TabIndex = 1;
            label10.Text = "Đến ngày :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(105, 25);
            label9.Name = "label9";
            label9.Size = new Size(120, 33);
            label9.TabIndex = 0;
            label9.Text = "Từ ngày :";
            // 
            // panel7
            // 
            panel7.Controls.Add(tabControl1);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 358);
            panel7.Name = "panel7";
            panel7.Size = new Size(1301, 478);
            panel7.TabIndex = 3;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1301, 478);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvBanChay);
            tabPage1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage1.Location = new Point(4, 35);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1293, 439);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Danh sách sản phẩm bán chạy";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvBanChay
            // 
            dgvBanChay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBanChay.BackgroundColor = SystemColors.ButtonHighlight;
            dgvBanChay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBanChay.Dock = DockStyle.Fill;
            dgvBanChay.Location = new Point(3, 3);
            dgvBanChay.Name = "dgvBanChay";
            dgvBanChay.RowHeadersWidth = 62;
            dgvBanChay.RowTemplate.Height = 33;
            dgvBanChay.Size = new Size(1287, 433);
            dgvBanChay.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvsaphethang);
            tabPage2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage2.Location = new Point(4, 35);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1293, 439);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Danh sách sản phẩm sắp hết hàng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvsaphethang
            // 
            dgvsaphethang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvsaphethang.BackgroundColor = SystemColors.ButtonHighlight;
            dgvsaphethang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvsaphethang.Dock = DockStyle.Fill;
            dgvsaphethang.Location = new Point(3, 3);
            dgvsaphethang.Name = "dgvsaphethang";
            dgvsaphethang.RowHeadersWidth = 62;
            dgvsaphethang.RowTemplate.Height = 150;
            dgvsaphethang.Size = new Size(1287, 433);
            dgvsaphethang.TabIndex = 0;
            // 
            // ThongKe
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1301, 836);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ThongKe";
            Text = "ThongKe";
            Load += ThongKe_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBanChay).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvsaphethang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label6;
        private Label lbdoanhthu;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbspban;
        private Label lbtongdonhang;
        private Panel panel6;
        private Button btnThongKe;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtptungay;
        private Label label10;
        private Label label9;
        private Panel panel7;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dgvBanChay;
        private TabPage tabPage2;
        private DataGridView dgvsaphethang;
        private Button export;
    }
}