using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using WF.BLL.Service;
using WF.DAL.Models;
using WF.DAL.Reposistoris;
using WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien
{
    public partial class KhachHangg : Form
    {
        public KhachHangg()
        {
            InitializeComponent();
        }
        KhachHangService khachhangsv;
        int idwhenclick = new int();
        private void KhachHang_Load(object sender, EventArgs e)
        {
            khachhangsv = new KhachHangService();
            LoadKhachHang();
        }
        public void LoadKhachHang()
        {
            int STT = 1;
            dgvDanhSachkh.ColumnCount = 7;
            dgvDanhSachkh.Rows.Clear();
            dgvDanhSachkh.Columns[0].Name = "ID";
            dgvDanhSachkh.Columns[1].Name = "STT";
            dgvDanhSachkh.Columns[2].Name = "Mã khách hàng";
            dgvDanhSachkh.Columns[3].Name = "Tên khách hàng";
            dgvDanhSachkh.Columns[4].Name = "Giới tính";
            dgvDanhSachkh.Columns[5].Name = "Số điện thoại";
            dgvDanhSachkh.Columns[6].Name = "Địa Chỉ";

            dgvDanhSachkh.Columns[0].Visible = false;

            foreach (var item in khachhangsv.GetAllKhachHangsv())
            {
                dgvDanhSachkh.Rows.Add(item.Id, STT++, item.MaKhachHang, item.TenKhachHang, item.GioiTinh, item.Sđt, item.DiaChi);
            }
        }

        private void dgvDanhSachkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSachkh.CurrentRow != null && dgvDanhSachkh.CurrentRow.Cells[0].Value != null)
            {
                idwhenclick = int.Parse(dgvDanhSachkh.CurrentRow.Cells[0].Value.ToString());
                txtMaKH.Text = dgvDanhSachkh.CurrentRow.Cells[2].Value.ToString();
                txtTenKh.Text = dgvDanhSachkh.CurrentRow.Cells[3].Value.ToString();
                if (dgvDanhSachkh.CurrentRow.Cells[4].Value.ToString().Equals("Nam"))
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
                txtSĐT.Text = dgvDanhSachkh.CurrentRow.Cells[5].Value.ToString();
                txtDiaChi.Text = dgvDanhSachkh.CurrentRow.Cells[6].Value.ToString();
                txtMaKH.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra MaKhachHang không được để trống
                if (string.IsNullOrEmpty(txtMaKH.Text))
                {
                    errors.Add("Mã khách hàng không được trống.");
                }
                if (txtMaKH.Text.Length > 10 || !Regex.IsMatch(txtMaKH.Text, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
                {
                    errors.Add("Mã khách hàng không quá 10 ký tự và phải chứa cả chữ và số, không chứa kí tự đặc biệt.");
                }

                // Kiểm tra mã khách hàng đã tồn tại
                bool check = khachhangsv.GetAllKhachHangsv().Any(x => string.Equals(x.MaKhachHang, txtMaKH.Text, StringComparison.OrdinalIgnoreCase));
                if (check)
                {
                    errors.Add("Mã khách hàng đã tồn tại.");
                }

                // Kiểm tra TenKhachHang không được để trống
                if (string.IsNullOrEmpty(txtTenKh.Text))
                {
                    errors.Add("Tên khách hàng không được để trống.");
                }
                if (!Regex.IsMatch(txtTenKh.Text, @"^[\p{L}\s]*$"))
                {
                    errors.Add("Tên khách hàng không được chứa ký tự đặc biệt hoặc số.");
                }

                // Kiểm tra SĐT có đúng 10 chữ số không
                if (!string.IsNullOrEmpty(txtSĐT.Text) && (txtSĐT.Text.Length != 10 || !Regex.IsMatch(txtSĐT.Text, "^(09|07|03|08)[0-9]{8}$")))
                {
                    errors.Add("Số điện thoại phải bắt đầu bằng đầu số 09, 07 ,08 hoặc 03 và có đúng 10 chữ số.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu không có lỗi, thêm khách hàng mới
                KhachHang kh = new KhachHang();
                kh.MaKhachHang = txtMaKH.Text;
                kh.TenKhachHang = txtTenKh.Text;
                kh.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                kh.Sđt = txtSĐT.Text;
                kh.DiaChi = txtDiaChi.Text;
                MessageBox.Show(khachhangsv.Them(kh));
                LoadKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra MaKhachHang không được để trống
                if (string.IsNullOrEmpty(txtMaKH.Text))
                {
                    errors.Add("Mã khách hàng không được trống.");
                }
                if (txtMaKH.Text.Length > 10 || !Regex.IsMatch(txtMaKH.Text, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
                {
                    errors.Add("Mã khách hàng không quá 10 ký tự và phải chứa cả chữ và số, không chứa kí tự đặc biệt.");
                }

                // Kiểm tra TenKhachHang không được để trống
                if (string.IsNullOrEmpty(txtTenKh.Text))
                {
                    errors.Add("Tên khách hàng không được để trống.");
                }
                if (!Regex.IsMatch(txtTenKh.Text, @"^[\p{L}\s]*$"))
                {
                    errors.Add("Tên khách hàng không được chứa ký tự đặc biệt hoặc số.");
                }

                // Kiểm tra SĐT có đúng 10 chữ số không
                if (!string.IsNullOrEmpty(txtSĐT.Text) && (txtSĐT.Text.Length != 10 || !Regex.IsMatch(txtSĐT.Text, "^(09|07|03|08)[0-9]{8}$")))
                {
                    errors.Add("Số điện thoại phải bắt đầu bằng đầu số 09, 07 ,08 hoặc 03 và có đúng 10 chữ số.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
            txtMaKH.ReadOnly = false;
        }
        public void LoadTimKiem(string name)
        {
            int STT = 1;
            dgvDanhSachkh.ColumnCount = 7;
            dgvDanhSachkh.Rows.Clear();
            dgvDanhSachkh.Columns[0].Name = "ID";
            dgvDanhSachkh.Columns[1].Name = "STT";
            dgvDanhSachkh.Columns[2].Name = "Mã khách hàng";
            dgvDanhSachkh.Columns[3].Name = "Tên khách hàng";
            dgvDanhSachkh.Columns[4].Name = "Giới tính";
            dgvDanhSachkh.Columns[5].Name = "Số điện thoại";
            dgvDanhSachkh.Columns[6].Name = "Địa Chỉ";

            dgvDanhSachkh.Columns[0].Visible = false;

            var allKhachHangs = khachhangsv.GetAllKhachHangsv();

            var query = from kh in allKhachHangs
                        where kh.TenKhachHang.ToLower().Contains(name.ToLower()) || kh.MaKhachHang.ToLower().Contains(name.ToLower())
                        select new
                        {
                            kh.Id,
                            STT = ++STT,
                            kh.MaKhachHang,
                            kh.TenKhachHang,
                            kh.GioiTinh,
                            kh.Sđt,
                            kh.DiaChi
                        };
            foreach (var item in query)
            {
                dgvDanhSachkh.Rows.Add(item.Id, item.STT, item.MaKhachHang, item.TenKhachHang, item.GioiTinh, item.Sđt, item.DiaChi);
            }
        }
        private void txtTimKiemkh_TextChanged(object sender, EventArgs e)
        {
            LoadTimKiem(txtTimKiemkh.Text.Trim());
        }
    }
}
