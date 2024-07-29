using DocumentFormat.OpenXml.Office2010.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TheArtOfDevHtmlRenderer.Adapters;
using WF.BLL.Service;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN
{
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }
        NhanVienService nhanviensv;
        int idwhenclick = new int();
        string pathimg;
        dynamic imgLoad;
        private void Nhanvien_Load(object sender, EventArgs e)
        {
            nhanviensv = new NhanVienService();
            LoadNhanVien();
        }
        public void LoadNhanVien()
        {
            int STT = 1;
            dgvDanhSach.ColumnCount = 15;
            dgvDanhSach.Rows.Clear();
            dgvDanhSach.Columns[0].Name = "ID";
            dgvDanhSach.Columns[1].Name = "STT";
            dgvDanhSach.Columns[2].Name = "Mã NV";
            dgvDanhSach.Columns[3].Name = "Tên NV";
            dgvDanhSach.Columns[4].Name = "Hình ảnh";
            dgvDanhSach.Columns[5].Name = "CCCD";
            dgvDanhSach.Columns[6].Name = "Ngày sinh";
            dgvDanhSach.Columns[7].Name = "Giới tính";
            dgvDanhSach.Columns[8].Name = "Email";
            dgvDanhSach.Columns[9].Name = "SĐT";
            dgvDanhSach.Columns[10].Name = "Tài khoản";
            dgvDanhSach.Columns[11].Name = "Mật khẩu";
            dgvDanhSach.Columns[12].Name = "Vai trò";
            dgvDanhSach.Columns[13].Name = "Địa chỉ";
            dgvDanhSach.Columns[14].Name = "Trạng thái";
            dgvDanhSach.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            dgvDanhSach.Columns[0].Visible = false;

            foreach (var item in nhanviensv.GetAllNhanViensv())
            {
                if (item.TrangThai != "Nghỉ làm") // Kiểm tra trạng thái của nhân viên
                {
                    dgvDanhSach.Rows.Add(item.Id, STT++, item.MaNv, item.HoTenNv, item.Hinh, item.Cccd, item.NgaySinh, item.GioiTinh, item.Email, item.Sđt, item.TenTk, HidePassword(item.MatKhau), item.VaiTro, item.DiaChi, item.TrangThai);
                }
            }
        }
        private string HidePassword(string password)
        {
            // Nếu mật khẩu không rỗng, che dấu mật khẩu bằng dấu hoa thị (*)
            return string.IsNullOrEmpty(password) ? string.Empty : new string('*', password.Length);
        }
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imagebytes = ms.ToArray();
                return imagebytes;
            }
        }

        public Image Base64ToImage(byte[] imagebytes)
        {
            MemoryStream ms = new MemoryStream(imagebytes, 0, imagebytes.Length);
            ms.Write(imagebytes, 0, imagebytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg; *.jpeg; *.png; *.gif";
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Image image = Image.FromFile(openFileDialog.FileName);


                    pictureNhanvien.Image = image;

                    pathimg = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                }
            }
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaNV.Text))
                    errors.Add("Vui lòng nhập mã nhân viên.");

                if (string.IsNullOrEmpty(txtTen.Text))
                    errors.Add("Vui lòng nhập tên nhân viên.");

                if (string.IsNullOrEmpty(txtcccd.Text))
                    errors.Add("Vui lòng nhập số CCCD.");

                if (string.IsNullOrEmpty(txtemail.Text))
                    errors.Add("Vui lòng nhập email.");

                if (string.IsNullOrEmpty(txtsđt.Text))
                    errors.Add("Vui lòng nhập số điện thoại.");

                if (string.IsNullOrEmpty(txttaikhoan.Text))
                    errors.Add("Vui lòng nhập tài khoản.");

                if (string.IsNullOrEmpty(txtmatkhau.Text))
                    errors.Add("Vui lòng nhập mật khẩu.");

                if (string.IsNullOrEmpty(txtdiachi.Text))
                    errors.Add("Vui lòng nhập địa chỉ.");

                // Hiển thị thông báo nếu có trường nào bị bỏ trống
                if (errors.Count > 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Kiểm tra MaNv không được lớn hơn 10 ký tự và chỉ chứa các ký tự chữ và số
                if (txtMaNV.Text.Length > 10 || !Regex.IsMatch(txtMaNV.Text, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
                {
                    errors.Add("Mã nhân viên không quá 10 ký tự và phải chứa cả chữ và số, không chứa kí tự đặc biệt.");
                }
                if (!Regex.IsMatch(txtTen.Text, @"^[\p{L}\s]*$"))
                {
                    errors.Add("Tên Nhân viên không được chứa ký tự đặc biệt hoặc số.");
                }
                // Kiểm tra Hinh không được để trống
                if (string.IsNullOrEmpty(pathimg))
                {
                    errors.Add("Vui lòng chọn hình ảnh.");
                }

                // Kiểm tra Cccd không được lớn hơn 15 ký tự và chỉ chứa các ký tự chữ và số
                if (txtcccd.Text.Length != 12 || !Regex.IsMatch(txtcccd.Text, "^[0-9]{12}$"))
                {
                    errors.Add("CCCD phải chứa đúng 12 ký tự và chỉ chứa số.");
                }
                DateTime ngaySinh;
                if (!DateTime.TryParseExact(dtpNgaySinh.Text.Trim(), "dd-MM-yyyy", null, DateTimeStyles.None, out ngaySinh))
                {
                    errors.Add("Ngày sinh không hợp lệ.");
                }
                else
                {
                    // Tính tuổi từ ngày sinh
                    int age = DateTime.Today.Year - ngaySinh.Year;
                    if (DateTime.Today < ngaySinh.AddYears(age)) age--;
                    if (age < 18)
                    {
                        errors.Add("Nhân viên phải đủ 18 tuổi trở lên.");
                    }
                }
                // Kiểm tra checkbox giới tính
                if (!rdoNam.Checked && !rdonu.Checked)
                {
                    errors.Add("Vui lòng chọn giới tính.");
                }
                // Kiểm tra định dạng email
                if (!IsValidEmail(txtemail.Text))
                {
                    errors.Add("Email không đúng định dạng.");
                }

                // Kiểm tra Sđt phải có đúng 10 ký tự và chỉ chứa các ký tự số
                if (txtsđt.Text.Length != 10 || !Regex.IsMatch(txtsđt.Text, "^(09|07|03|08)[0-9]{8}$"))
                {
                    errors.Add("Số điện thoại phải bắt đầu bằng đầu số 09, 07 ,08, 03 và có đúng 10 chữ số.");
                }
                // Kiểm tra checkbox giới tính
                if (!rdoNhanvien.Checked && !rdoquanly.Checked)
                {
                    errors.Add("Vui lòng chọn chức vụ.");
                }
                // kiểm tra mật khẩu : 
                if (!Regex.IsMatch(txtmatkhau.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtmatkhau.Text, @"[0-9]"))
                {
                    errors.Add("Mật khẩu phải chứa cả chữ và số.");
                }
                // Kiểm tra check trạng thái
                if (!rdoDangLam.Checked && !rdoNghilam.Checked)
                {
                    errors.Add("Vui lòng chọn Trạng thái");
                }
                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra Mã nhân viên đã tồn tại
                bool check = nhanviensv.GetAllNhanViensv().Any(x => string.Equals(x.MaNv, txtMaNV.Text, StringComparison.OrdinalIgnoreCase));
                if (check)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }

                byte[] imageBytes = File.ReadAllBytes(pathimg);
                NhanVien nv = new NhanVien();
                nv.MaNv = txtMaNV.Text;
                nv.HoTenNv = txtTen.Text;
                nv.Hinh = imageBytes;
                nv.Cccd = txtcccd.Text;
                nv.NgaySinh = DateTime.ParseExact(dtpNgaySinh.Text.Trim(), "dd-MM-yyyy", null);
                nv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                nv.Email = txtemail.Text;
                nv.Sđt = txtsđt.Text;
                nv.TenTk = txttaikhoan.Text;
                nv.MatKhau = txtmatkhau.Text;
                nv.VaiTro = rdoNhanvien.Checked ? "Nhân viên" : "Quản lý";
                nv.DiaChi = txtdiachi.Text;
                nv.TrangThai = rdoDangLam.Checked ? "Đang làm" : "Nghỉ làm";
                MessageBox.Show(nhanviensv.Them(nv));
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void txtSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaNV.Text))
                    errors.Add("Vui lòng nhập mã nhân viên.");

                if (string.IsNullOrEmpty(txtTen.Text))
                    errors.Add("Vui lòng nhập tên nhân viên.");

                if (string.IsNullOrEmpty(txtcccd.Text))
                    errors.Add("Vui lòng nhập số CCCD.");

                if (string.IsNullOrEmpty(txtemail.Text))
                    errors.Add("Vui lòng nhập email.");

                if (string.IsNullOrEmpty(txtsđt.Text))
                    errors.Add("Vui lòng nhập số điện thoại.");

                if (string.IsNullOrEmpty(txttaikhoan.Text))
                    errors.Add("Vui lòng nhập tài khoản.");

                if (string.IsNullOrEmpty(txtmatkhau.Text))
                    errors.Add("Vui lòng nhập mật khẩu.");

                if (string.IsNullOrEmpty(txtdiachi.Text))
                    errors.Add("Vui lòng nhập địa chỉ.");

                // Hiển thị thông báo nếu có trường nào bị bỏ trống
                if (errors.Count > 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Kiểm tra MaNv không được lớn hơn 10 ký tự và chỉ chứa các ký tự chữ và số
                if (txtMaNV.Text.Length > 10 || !Regex.IsMatch(txtMaNV.Text, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
                {
                    errors.Add("Mã nhân viên không quá 10 ký tự và phải chứa cả chữ và số.");
                }
                if (!Regex.IsMatch(txtTen.Text, @"^[\p{L}\s]*$"))
                {
                    errors.Add("Tên Nhân viên không được chứa ký tự đặc biệt hoặc số.");
                }
                // Kiểm tra Cccd không được lớn hơn 15 ký tự và chỉ chứa các ký tự chữ và số
                if (txtcccd.Text.Length != 12 || !Regex.IsMatch(txtcccd.Text, "^[0-9]{12}$"))
                {
                    errors.Add("CCCD phải chứa đúng 12 ký tự và chỉ chứa số.");
                }
                DateTime ngaySinh;
                if (!DateTime.TryParseExact(dtpNgaySinh.Text.Trim(), "dd-MM-yyyy", null, DateTimeStyles.None, out ngaySinh))
                {
                    errors.Add("Ngày sinh không hợp lệ.");
                }
                else
                {
                    // Tính tuổi từ ngày sinh
                    int age = DateTime.Today.Year - ngaySinh.Year;
                    if (DateTime.Today < ngaySinh.AddYears(age)) age--;
                    if (age < 18)
                    {
                        errors.Add("Nhân viên phải đủ 18 tuổi trở lên.");
                    }
                }
                // Kiểm tra checkbox giới tính
                if (!rdoNam.Checked && !rdonu.Checked)
                {
                    errors.Add("Vui lòng chọn giới tính.");
                }
                // Kiểm tra định dạng email
                if (!IsValidEmail(txtemail.Text))
                {
                    errors.Add("Email không đúng định dạng.");
                }

                // Kiểm tra Sđt phải có đúng 10 ký tự và chỉ chứa các ký tự số
                if (txtsđt.Text.Length != 10 || !Regex.IsMatch(txtsđt.Text, "^(09|07|03|08)[0-9]{8}$"))
                {
                    errors.Add("Số điện thoại phải bắt đầu bằng đầu số 09, 07 ,08, 03 và có đúng 10 chữ số.");
                }
                // Kiểm tra checkbox giới tính
                if (!rdoNhanvien.Checked && !rdoquanly.Checked)
                {
                    errors.Add("Vui lòng chọn chức vụ.");
                }
                // kiểm tra mật khẩu : 
                if (string.IsNullOrEmpty(txtmatkhau.Text))
                {
                    if (!Regex.IsMatch(txtmatkhau.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtmatkhau.Text, @"[0-9]"))
                    {
                        errors.Add("Mật khẩu phải chứa cả chữ và số.");
                    }
                }
                // Kiểm tra check trạng thái
                if (!rdoDangLam.Checked && !rdoNghilam.Checked)
                {
                    errors.Add("Vui lòng chọn Trạng thái");
                }
                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NhanVien nv = new NhanVien();
                if (pathimg != null)
                {
                    byte[] imageBytes = File.ReadAllBytes(pathimg);
                    nv.Hinh = imageBytes;
                }
                else
                    nv.Hinh = imgLoad;
                nv.MaNv = txtMaNV.Text;
                nv.HoTenNv = txtTen.Text;
                nv.Cccd = txtcccd.Text;
                nv.NgaySinh = DateTime.ParseExact(dtpNgaySinh.Text.Trim(), "dd-MM-yyyy", null);
                nv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                nv.Email = txtemail.Text;
                nv.Sđt = txtsđt.Text;
                nv.TenTk = txttaikhoan.Text;
                nv.MatKhau = txtmatkhau.Text;
                nv.VaiTro = rdoNhanvien.Checked ? "Nhân viên" : "Quản lý";
                nv.DiaChi = txtdiachi.Text;
                nv.TrangThai = rdoDangLam.Checked ? "Đang làm" : "Nghỉ làm";
                MessageBox.Show(nhanviensv.sua(nv, idwhenclick));
                LoadNhanVien();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtLammoi_Click_1(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTen.Text = "";
            txtcccd.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            rdoNam.Checked = false;
            rdonu.Checked = false;
            txtemail.Text = "";
            txtsđt.Text = "";
            txttaikhoan.Text = "";
            txtmatkhau.Text = "";
            rdoNhanvien.Checked = false;
            rdoquanly.Checked = false;
            txtdiachi.Text = "";
            rdoDangLam.Checked = false;
            rdoNghilam.Checked = false;
            pictureNhanvien.Image = null;
            txtMaNV.ReadOnly = false;
            txtTimKiem.Text = "";
            LoadNhanVien();
            comboBox1.Text = "";
        }

        private void dgvDanhSach_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.CurrentRow != null && dgvDanhSach.CurrentRow.Cells[0].Value != null)
            {
                txtMaNV.ReadOnly = true;
                idwhenclick = int.Parse(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
                txtMaNV.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                txtTen.Text = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                txtcccd.Text = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dgvDanhSach.CurrentRow.Cells[6].Value);
                if (dgvDanhSach.CurrentRow.Cells[7].Value.ToString().Equals("Nam", StringComparison.OrdinalIgnoreCase))
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdonu.Checked = true;
                }
                txtemail.Text = dgvDanhSach.CurrentRow.Cells[8].Value.ToString();
                txtsđt.Text = dgvDanhSach.CurrentRow.Cells[9].Value.ToString();
                txttaikhoan.Text = dgvDanhSach.CurrentRow.Cells[10].Value.ToString();
                txtmatkhau.Text = dgvDanhSach.CurrentRow.Cells[11].Value.ToString();
                if (dgvDanhSach.CurrentRow.Cells[12].Value.ToString().Equals("Nhân Viên", StringComparison.OrdinalIgnoreCase))
                {
                    rdoNhanvien.Checked = true;
                }
                else
                {
                    rdoquanly.Checked = true;
                }
                txtdiachi.Text = dgvDanhSach.CurrentRow.Cells[13].Value.ToString();
                if (dgvDanhSach.CurrentRow.Cells[14].Value.ToString().Equals("Đang làm", StringComparison.OrdinalIgnoreCase))
                {
                    rdoDangLam.Checked = true;
                }
                else
                {
                    rdoNghilam.Checked = true;
                }

                var s = nhanviensv.Findid(idwhenclick);
                if (s != null && s.Hinh != null)
                {
                    byte[] imageData = s.Hinh;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureNhanvien.Image = Image.FromStream(ms);
                        imgLoad = s.Hinh;
                    }
                }
                else
                {
                    pictureNhanvien.Image = null;
                    imgLoad = null;
                }
            }
        }
        public void LoadNhanVien(string name)
        {
            int STT = 1;
            dgvDanhSach.ColumnCount = 15;
            dgvDanhSach.Rows.Clear();
            dgvDanhSach.Columns[0].Name = "ID";
            dgvDanhSach.Columns[1].Name = "STT";
            dgvDanhSach.Columns[2].Name = "Mã NV";
            dgvDanhSach.Columns[3].Name = "Tên NV";
            dgvDanhSach.Columns[4].Name = "Hình ảnh";
            dgvDanhSach.Columns[5].Name = "CCCD";
            dgvDanhSach.Columns[6].Name = "Ngày sinh";
            dgvDanhSach.Columns[7].Name = "Giới tính";
            dgvDanhSach.Columns[8].Name = "Email";
            dgvDanhSach.Columns[9].Name = "SĐT";
            dgvDanhSach.Columns[10].Name = "Tài khoản";
            dgvDanhSach.Columns[11].Name = "Mật khẩu";
            dgvDanhSach.Columns[12].Name = "Vai trò";
            dgvDanhSach.Columns[13].Name = "Địa chỉ";
            dgvDanhSach.Columns[14].Name = "Trạng thái";
            dgvDanhSach.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            dgvDanhSach.Columns[0].Visible = false;

            var query = from nv in nhanviensv.GetAllNhanViensv()
                        where nv.HoTenNv.ToLower().Contains(name.ToLower()) || nv.MaNv.ToLower().Contains(name.ToLower())
                        select new
                        {
                            nv.Id,
                            STT = ++STT,
                            nv.MaNv,
                            nv.HoTenNv,
                            nv.Hinh,
                            nv.Cccd,
                            nv.NgaySinh,
                            nv.GioiTinh,
                            nv.Email,
                            nv.Sđt,
                            nv.TenTk,
                            nv.MatKhau,
                            nv.VaiTro,
                            nv.DiaChi,
                            nv.TrangThai
                        };

            foreach (var item in query)
            {
                dgvDanhSach.Rows.Add(item.Id, item.STT, item.MaNv, item.HoTenNv, item.Hinh, item.Cccd, item.NgaySinh, item.GioiTinh, item.Email, item.Sđt, item.TenTk, HidePassword(item.MatKhau), item.VaiTro, item.DiaChi, item.TrangThai);
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadNhanVien(txtTimKiem.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int STT = 1;
            dgvDanhSach.ColumnCount = 15;
            dgvDanhSach.Rows.Clear();
            dgvDanhSach.Columns[0].Name = "ID";
            dgvDanhSach.Columns[1].Name = "STT";
            dgvDanhSach.Columns[2].Name = "Mã NV";
            dgvDanhSach.Columns[3].Name = "Tên NV";
            dgvDanhSach.Columns[4].Name = "Hình ảnh";
            dgvDanhSach.Columns[5].Name = "CCCD";
            dgvDanhSach.Columns[6].Name = "Ngày sinh";
            dgvDanhSach.Columns[7].Name = "Giới tính";
            dgvDanhSach.Columns[8].Name = "Email";
            dgvDanhSach.Columns[9].Name = "SĐT";
            dgvDanhSach.Columns[10].Name = "Tài khoản";
            dgvDanhSach.Columns[11].Name = "Mật khẩu";
            dgvDanhSach.Columns[12].Name = "Vai trò";
            dgvDanhSach.Columns[13].Name = "Địa chỉ";
            dgvDanhSach.Columns[14].Name = "Trạng thái";
            dgvDanhSach.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            dgvDanhSach.Columns[0].Visible = false;

            // Lấy danh sách nhân viên từ khachhangsv.FindName(name)
            var nhanVienList = nhanviensv.GetAllNhanViensv();

            // Kiểm tra xem mục được chọn trong ComboBox có phải là "Quản lý" không
            if (comboBox1.SelectedItem.ToString() == "Quản Lý")
            {
                // Lọc nhân viên có vai trò là "Quản lý"
                nhanVienList = nhanVienList.Where(nv => nv.VaiTro == "Quản lý").ToList();
            }
            else
            {
                nhanVienList = nhanVienList.Where(nv => nv.VaiTro == "Nhân viên").ToList();
            }

            foreach (var nv in nhanVienList)
            {
                dgvDanhSach.Rows.Add(nv.Id, STT++, nv.MaNv, nv.HoTenNv, nv.Hinh, nv.Cccd, nv.NgaySinh, nv.GioiTinh, nv.Email, nv.Sđt, nv.TenTk, HidePassword(nv.MatKhau), nv.VaiTro, nv.DiaChi, nv.TrangThai);
            }
        }
    }
}
