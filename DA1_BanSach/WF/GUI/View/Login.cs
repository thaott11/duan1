using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF.BLL.Service;
using WF.DAL.Models;

namespace WF.Form_Login_TrangChu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        TaikhoanService tksv = new TaikhoanService();
        private void bt_Login_Click(object sender, EventArgs e)
        {
            string taikhoan = txt_username.Text;
            string matkhau = txt_password.Text;
            NhanVien user;
            if (tksv.Taikhoans(taikhoan, matkhau, out user))
            {
                if (user.VaiTro == "Quản lý")
                {
                    // Mở form dành cho quản lý
                    TrangChu___ADMIN admin = new TrangChu___ADMIN();
                    admin.Show();
                }
                else
                {
                    // Mở form dành cho nhân viên
                    TrangChu___NhanVien nhanvien = new TrangChu___NhanVien();
                    nhanvien.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
