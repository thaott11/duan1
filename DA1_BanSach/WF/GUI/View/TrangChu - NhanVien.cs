using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien;

namespace WF.Form_Login_TrangChu
{
    public partial class TrangChu___NhanVien : Form
    {
        public TrangChu___NhanVien()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Close_TrangChu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bt_Logout_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
        private void hideSubMenu()
        {
            label4.Visible = false;
            pictureBox3.Visible = false;
        }

        //public void loadform(object Form)
        //{
        //    if (this.pn_chucnang.Controls.Count > 0)
        //        this.pn_chucnang.Controls.RemoveAt(0);
        //    Form f = Form as Form;
        //    f.TopLevel = false;
        //    f.Dock = DockStyle.Fill;
        //    this.pn_chucnang.Controls.Add(f);
        //    this.pn_chucnang.Tag = f;
        //    f.Show();
        //}
        private Form currentFormChild;
        public void OpenChildForm(Form ChildForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            pn_chucnang.Controls.Add(ChildForm);
            pn_chucnang.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        private void bt_HoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DonHang());
            hideSubMenu();
        }

        private void bt_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHangg());
            hideSubMenu();
        }

        private void bt_BanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BanHang());
            hideSubMenu();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bt_ChangeForm_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
