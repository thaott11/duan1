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
using WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien;

namespace WF.GUI.View
{
    public partial class ThemKhachHang : Form
    {
        public ThemKhachHang()
        {
            InitializeComponent();
        }
        KhachHangService khachhangsv;
        int idwhenclick = new int();
        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["BanHang"] != null)
            {
                BanHang banHangForm = (BanHang)Application.OpenForms["BanHang"];
                int id = int.Parse(dgvdskh.CurrentRow.Cells[0].Value.ToString());
                string maKhachHang = dgvdskh.CurrentRow.Cells[2].Value.ToString();
                string tenKhachHang = dgvdskh.CurrentRow.Cells[3].Value.ToString();

                banHangForm.CapNhatThongTinKhachHang(maKhachHang, tenKhachHang, id);
            }
            else
            {
                BanHang banHangForm = new BanHang();

                string maKhachHang = dgvdskh.CurrentRow.Cells[2].Value.ToString();
                string tenKhachHang = dgvdskh.CurrentRow.Cells[3].Value.ToString();
                int id = int.Parse(dgvdskh.CurrentRow.Cells[0].Value.ToString());


                banHangForm.CapNhatThongTinKhachHang(maKhachHang, tenKhachHang, id);
            }
            this.Close();
        }

        private void ThemKhachHang_Load(object sender, EventArgs e)
        {
            khachhangsv = new KhachHangService();
            LoadKhachHang();
        }
        public void LoadKhachHang()
        {
            int STT = 1;
            dgvdskh.ColumnCount = 7;
            dgvdskh.Rows.Clear();
            dgvdskh.Columns[0].Name = "ID";
            dgvdskh.Columns[1].Name = "STT";
            dgvdskh.Columns[2].Name = "Mã khách hàng";
            dgvdskh.Columns[3].Name = "Tên khách hàng";
            dgvdskh.Columns[4].Name = "Giới tính";
            dgvdskh.Columns[5].Name = "Số điện thoại";
            dgvdskh.Columns[6].Name = "Địa Chỉ";

            dgvdskh.Columns[0].Visible = false;

            foreach (var item in khachhangsv.GetAllKhachHangsv())
            {
                dgvdskh.Rows.Add(item.Id, STT++, item.MaKhachHang, item.TenKhachHang, item.GioiTinh, item.Sđt, item.DiaChi);
            }
        }

        public void LoadKhachHang(string name)
        {
            int STT = 1;
            dgvdskh.ColumnCount = 7;
            dgvdskh.Rows.Clear();
            dgvdskh.Columns[0].Name = "ID";
            dgvdskh.Columns[1].Name = "STT";
            dgvdskh.Columns[2].Name = "Mã khách hàng";
            dgvdskh.Columns[3].Name = "Tên khách hàng";
            dgvdskh.Columns[4].Name = "Giới tính";
            dgvdskh.Columns[5].Name = "Số điện thoại";
            dgvdskh.Columns[6].Name = "Địa Chỉ";

            dgvdskh.Columns[0].Visible = false;

            foreach (var item in khachhangsv.FindName(name))
            {
                dgvdskh.Rows.Add(item.Id, STT++, item.MaKhachHang, item.TenKhachHang, item.GioiTinh, item.Sđt, item.DiaChi);
            }
        }
        private void txtTimkiemkh_TextChanged(object sender, EventArgs e)
        {
            LoadKhachHang(txtTimkiemkh.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check = khachhangsv.GetAllKhachHangsv().Any(x => x.MaKhachHang == txtMaKH.Text);
            if (check)
            {
                MessageBox.Show("Mã đã tồn tại");
            }
            else
            {
                KhachHang kh = new KhachHang();
                kh.MaKhachHang = txtMaKH.Text;
                kh.TenKhachHang = txtTenKh.Text;
                kh.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                kh.Sđt = txtSĐT.Text;
                kh.DiaChi = txtDiaChi.Text;
                MessageBox.Show(khachhangsv.Them(kh));
                LoadKhachHang();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.MaKhachHang = txtMaKH.Text;
                kh.TenKhachHang = txtTenKh.Text;
                kh.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                kh.Sđt = txtSĐT.Text;
                kh.DiaChi = txtDiaChi.Text;
                MessageBox.Show(khachhangsv.sua(kh, idwhenclick));
                LoadKhachHang();
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi rồi");
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKh.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtSĐT.Text = "";
            txtDiaChi.Text = "";
        }

        private void dgvdskh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idwhenclick = int.Parse(dgvdskh.CurrentRow.Cells[0].Value.ToString());
            txtMaKH.Text = dgvdskh.CurrentRow.Cells[2].Value.ToString();
            txtTenKh.Text = dgvdskh.CurrentRow.Cells[3].Value.ToString();
            if (dgvdskh.CurrentRow.Cells[4].Value.ToString().Equals("Nam"))
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNu.Checked = true;
            }
            txtSĐT.Text = dgvdskh.CurrentRow.Cells[5].Value.ToString();
            txtDiaChi.Text = dgvdskh.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
