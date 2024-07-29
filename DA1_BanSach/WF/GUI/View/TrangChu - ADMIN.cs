using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN;
using WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien;

namespace WF.Form_Login_TrangChu
{
    public partial class TrangChu___ADMIN : Form
    {
        public TrangChu___ADMIN()
        {
            InitializeComponent();
        }
        private void bt_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_TrangChu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void hideSubMenu()
        {
            label4.Visible = false;
            pictureBox3.Visible = false;
        }
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

        private void Close_TrangChu_Click_1(object sender, EventArgs e)
        {
            Close();
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

        private void bt_BanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BanHang());
            hideSubMenu();
        }

        private void bt_HoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DonHang());
            hideSubMenu();
        }

        private void bt_SanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SanPham());
            hideSubMenu();
        }

        private void bt_NhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Nhanvien());
            hideSubMenu();
        }

        private void bt_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHangg());
            hideSubMenu();
        }

        private void bt_MaGiamGia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhuyenMai());
            hideSubMenu();
        }

        private void bt_ThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKe());
            hideSubMenu();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }
        VideoCaptureDevice videoCaptureDevice;
        private void TrangChu___ADMIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
            }
        }
    }
}
