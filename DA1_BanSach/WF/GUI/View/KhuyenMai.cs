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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN
{
    public partial class KhuyenMai : Form
    {
        public KhuyenMai()
        {
            InitializeComponent();
        }
        VoucherService vouchersv;
        int idwhenclick = new int();
        private void KhuyenMai_Load(object sender, EventArgs e)
        {
            vouchersv = new VoucherService();
            LoadVoucher();
        }
        public void LoadVoucher()
        {
            int STT = 1;
            dgvDanhSachMaGiamGia.ColumnCount = 9;
            dgvDanhSachMaGiamGia.Rows.Clear();
            dgvDanhSachMaGiamGia.Columns[0].Name = "ID";
            dgvDanhSachMaGiamGia.Columns[1].Name = "STT";
            dgvDanhSachMaGiamGia.Columns[2].Name = "Mã giảm giá";
            dgvDanhSachMaGiamGia.Columns[3].Name = "Ngày bắt đầu";
            dgvDanhSachMaGiamGia.Columns[4].Name = "Ngày kết thúc";
            dgvDanhSachMaGiamGia.Columns[5].Name = "Tỉ lệ giảm(%)";
            dgvDanhSachMaGiamGia.Columns[6].Name = "Đơn hàng tối thiểu";
            dgvDanhSachMaGiamGia.Columns[7].Name = "Giảm tối đa";
            dgvDanhSachMaGiamGia.Columns[8].Name = "Số Lượng";
            dgvDanhSachMaGiamGia.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgvDanhSachMaGiamGia.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";

            dgvDanhSachMaGiamGia.Columns[0].Visible = false;

            foreach (var item in vouchersv.GetAllVouchersv())
            {
                if (item.NgayKetThuc >= DateTime.Now)
                {
                    dgvDanhSachMaGiamGia.Rows.Add(item.Id, STT++, item.MaVoucher, item.NgayBatDau, item.NgayKetThuc, item.TiLeGiam, item.DonHangToiThieu, item.GiamToiDa, item.SoLuong);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                if (string.IsNullOrEmpty(txtMaGiamGia.Text) ||
                    string.IsNullOrEmpty(dtpNgayBatDau.Text) ||
                    string.IsNullOrEmpty(dtpNgayKetThuc.Text) ||
                    string.IsNullOrEmpty(txtDonToiThieu.Text) ||
                    string.IsNullOrEmpty(txtSoLuong.Text) ||
                    string.IsNullOrEmpty(txtGiamToiDa.Text) ||
                    string.IsNullOrEmpty(txtTiLeGiam.Text))
                {
                    errors.Add("Vui lòng điền đầy đủ thông tin.");
                }

                double tigiam;
                if (!double.TryParse(txtTiLeGiam.Text, out tigiam) || tigiam > 100 || tigiam <= 0)
                {
                    errors.Add("Tỉ lệ giảm không hợp lệ (phải là số dương và nhỏ hơn 100).");
                }

                double donToiThieu, giamToiDa;
                int soLuong;
                if (!double.TryParse(txtDonToiThieu.Text, out donToiThieu) || donToiThieu < 0)
                {
                    errors.Add("Đơn hàng tối thiểu không hợp lệ (phải là số dương).");
                }

                if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
                {
                    errors.Add("Số lượng không hợp lệ (phải là số nguyên dương).");
                }

                if (DateTime.ParseExact(dtpNgayBatDau.Text.Trim(), "dd-MM-yyyy", null) > DateTime.ParseExact(dtpNgayKetThuc.Text.Trim(), "dd-MM-yyyy", null))
                {
                    errors.Add("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                }

                if (!double.TryParse(txtGiamToiDa.Text, out giamToiDa) || giamToiDa <= 0)
                {
                    errors.Add("Giảm tối đa không hợp lệ (phải là số dương).");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mã voucher đã tồn tại
                bool check = vouchersv.GetAllVouchersv().Any(x => string.Equals(x.MaVoucher, txtMaGiamGia.Text, StringComparison.OrdinalIgnoreCase));
                if (check)
                {
                    errors.Add("Mã đã tồn tại.");
                }

                // Nếu không có lỗi, thêm voucher mới
                if (errors.Count == 0)
                {
                    Voucher vc = new Voucher();
                    vc.MaVoucher = txtMaGiamGia.Text;
                    vc.NgayBatDau = DateTime.ParseExact(dtpNgayBatDau.Text.Trim(), "dd-MM-yyyy", null);
                    vc.TiLeGiam = tigiam;
                    vc.NgayKetThuc = DateTime.ParseExact(dtpNgayKetThuc.Text.Trim() + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null);
                    vc.SoLuong = soLuong;
                    vc.GiamToiDa = giamToiDa;
                    MessageBox.Show(vouchersv.Them(vc));
                    LoadVoucher();
                }
                else
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaGiamGia.Text = "";
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
            txtTiLeGiam.Text = "";
            txtDonToiThieu.Text = "";
            txtGiamToiDa.Text = "";
            txtSoLuong.Text = "";
            LoadVoucher();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>();
                if (string.IsNullOrEmpty(txtMaGiamGia.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã giảm giá và nhập thông tin cần sửa ");
                    return;
                }
                double tigiam;
                if (!double.TryParse(txtTiLeGiam.Text, out tigiam) || tigiam > 100 || tigiam <= 0)
                {
                    errors.Add("Tỉ lệ giảm không hợp lệ (phải là số dương và nhỏ hơn 100).");
                }

                double donToiThieu, giamToiDa;
                int soLuong;
                if (!double.TryParse(txtDonToiThieu.Text, out donToiThieu) || donToiThieu < 0)
                {
                    errors.Add("Đơn hàng tối thiểu không hợp lệ (phải là số dương).");
                }

                if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
                {
                    errors.Add("Số lượng không hợp lệ (phải là số nguyên dương).");
                }

                if (DateTime.ParseExact(dtpNgayBatDau.Text.Trim(), "dd-MM-yyyy", null) > DateTime.ParseExact(dtpNgayKetThuc.Text.Trim(), "dd-MM-yyyy", null))
                {
                    errors.Add("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                }

                if (!double.TryParse(txtGiamToiDa.Text, out giamToiDa) || giamToiDa <= 0)
                {
                    errors.Add("Giảm tối đa không hợp lệ (phải là số dương).");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Voucher vc = new Voucher();
                vc.MaVoucher = txtMaGiamGia.Text;
                vc.NgayBatDau = DateTime.ParseExact(dtpNgayBatDau.Text.Trim(), "dd-MM-yyyy", null);
                vc.NgayKetThuc = DateTime.ParseExact(dtpNgayKetThuc.Text.Trim() + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null);
                vc.TiLeGiam = int.Parse(txtTiLeGiam.Text);
                vc.DonHangToiThieu = int.Parse(txtDonToiThieu.Text);
                vc.GiamToiDa = int.Parse(txtGiamToiDa.Text);
                vc.SoLuong = int.Parse(txtSoLuong.Text);
                MessageBox.Show(vouchersv.sua(vc, idwhenclick));
                LoadVoucher();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvDanhSachMaGiamGia_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSachMaGiamGia.CurrentRow != null && dgvDanhSachMaGiamGia.CurrentRow.Cells[0].Value != null)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvDanhSachMaGiamGia.Rows[e.RowIndex];

                    // Set textbox values based on the selected row
                    idwhenclick = int.Parse(dgvDanhSachMaGiamGia.CurrentRow.Cells[0].Value.ToString());
                    txtMaGiamGia.Text = selectedRow.Cells[2].Value.ToString();
                    dtpNgayBatDau.Value = Convert.ToDateTime(selectedRow.Cells[3].Value);
                    dtpNgayKetThuc.Value = Convert.ToDateTime(selectedRow.Cells[4].Value);
                    txtTiLeGiam.Text = selectedRow.Cells[5].Value.ToString();
                    txtDonToiThieu.Text = selectedRow.Cells[6].Value.ToString();
                    txtGiamToiDa.Text = selectedRow.Cells[7].Value.ToString();
                    txtSoLuong.Text = selectedRow.Cells[8].Value.ToString();
                }
            }
        }
        public void LoadVoucher(string name)
        {
            int STT = 1;
            dgvDanhSachMaGiamGia.ColumnCount = 9;
            dgvDanhSachMaGiamGia.Rows.Clear();
            dgvDanhSachMaGiamGia.Columns[0].Name = "ID";
            dgvDanhSachMaGiamGia.Columns[1].Name = "STT";
            dgvDanhSachMaGiamGia.Columns[2].Name = "Mã giảm giá";
            dgvDanhSachMaGiamGia.Columns[3].Name = "Ngày bắt đầu";
            dgvDanhSachMaGiamGia.Columns[4].Name = "Ngày kết thúc";
            dgvDanhSachMaGiamGia.Columns[5].Name = "Tỉ lệ giảm(%)";
            dgvDanhSachMaGiamGia.Columns[6].Name = "Đơn hàng tối thiểu";
            dgvDanhSachMaGiamGia.Columns[7].Name = "Giảm tối đa";
            dgvDanhSachMaGiamGia.Columns[8].Name = "Số Lượng";
            dgvDanhSachMaGiamGia.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgvDanhSachMaGiamGia.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";

            dgvDanhSachMaGiamGia.Columns[0].Visible = false;

            foreach (var item in vouchersv.TimkiemMa(name))
            {
                dgvDanhSachMaGiamGia.Rows.Add(item.Id, STT++, item.MaVoucher, item.NgayBatDau, item.NgayKetThuc, item.TiLeGiam, item.DonHangToiThieu, item.GiamToiDa, item.SoLuong);
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadVoucher(txtTimKiem.Text);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
