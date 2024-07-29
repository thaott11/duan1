using DocumentFormat.OpenXml.Office2010.Drawing;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WF.BLL.Service;
using WF.DAL.Models;
using WF.GUI.View;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        dynamic imgLoad;
        string pathimg;
        NhaXBService Nxbsv;
        SachService sachsv;
        SachCtService sachctsv;
        TheLoaiService theloaisv;
        int idwhenClick = new int();
        private void SanPham_Load(object sender, EventArgs e)
        {
            Nxbsv = new NhaXBService();
            sachsv = new SachService();
            sachctsv = new SachCtService();
            LoadNhaXuatBan();
            LoadSach();
            LoadttSachct();
            theloaisv = new TheLoaiService();
            LoadTheLoai();
            LoadDataIntoCheckListBox();
        }

        public void LoadNhaXuatBan()
        {
            int STT = 1;
            dgvDsNhaXuatBan.ColumnCount = 8;
            dgvDsNhaXuatBan.Rows.Clear();
            dgvDsNhaXuatBan.Columns[0].Name = "ID";
            dgvDsNhaXuatBan.Columns[1].Name = "STT";
            dgvDsNhaXuatBan.Columns[2].Name = "Mã NXB";
            dgvDsNhaXuatBan.Columns[3].Name = "Tên NXB";
            dgvDsNhaXuatBan.Columns[4].Name = "Địa chỉ";
            dgvDsNhaXuatBan.Columns[5].Name = "Số điện thoại";
            dgvDsNhaXuatBan.Columns[6].Name = "Năm xuất bản";
            dgvDsNhaXuatBan.Columns[7].Name = "Trạng thái";
            dgvDsNhaXuatBan.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            dgvDsNhaXuatBan.Columns[0].Visible = false;

            foreach (var item in Nxbsv.GetAllNXBsv())
            {
                if (item.TrangThai != "Ngừng Hoạt Động")
                {
                    dgvDsNhaXuatBan.Rows.Add(item.Id, STT++, item.MaNxb, item.TenNxb, item.DiaChi, item.Sđt, item.NamXb, item.TrangThai);
                }
            }
        }
        private void btnThemnxb_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaNXB.Text) || string.IsNullOrEmpty(txtTenNXB.Text) || string.IsNullOrEmpty(txtDiaChi.Text) ||
                    string.IsNullOrEmpty(txtSĐT.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaNxb không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaNXB.Text.Length > 10 || !Regex.IsMatch(txtMaNXB.Text, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
                {
                    errors.Add("Mã nhà xuất bản không quá 10 ký tự và chứa cả chữ và số, không chứa kí tự đặc biệt");
                }
                if (!Regex.IsMatch(txtTenNXB.Text, @"^[\p{L}\s]*$"))
                {
                    errors.Add("Tên NXB không được chứa ký tự đặc biệt hoặc số.");
                }
                // Kiểm tra Sđt chỉ chứa 10 số
                if (txtSĐT.Text.Length != 10 || !Regex.IsMatch(txtSĐT.Text, @"^[0-9]+$"))
                {
                    errors.Add("Số điện thoại phải có đúng 10 ký tự và chỉ chứa số.");
                }
                //Trạng thái
                if (!rdoHoatDong.Checked && !rdoDungHoatDong.Checked)
                    errors.Add("Vui lòng chọn Trạng thái.");
                // Kiểm tra năm xuất bản không lớn hơn ngày hiện tại
                DateTime namXb;
                if (!DateTime.TryParseExact(dtpNanXB.Text.Trim(), "dd-MM-yyyy", null, DateTimeStyles.None, out namXb))
                {
                    errors.Add("Ngày xuất bản không hợp lệ.");
                }
                else if (namXb > DateTime.Today)
                {
                    errors.Add("Năm xuất bản không được lớn hơn ngày hiện tại.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mã nhà xuất bản đã tồn tại
                bool check = Nxbsv.GetAllNXBsv().Any(x => string.Equals(x.MaNxb, txtMaNXB.Text, StringComparison.OrdinalIgnoreCase));
                if (check)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }

                // Thêm nhà xuất bản nếu không có lỗi
                NhaXuatBan nxb = new NhaXuatBan();
                nxb.MaNxb = txtMaNXB.Text;
                nxb.TenNxb = txtTenNXB.Text;
                nxb.DiaChi = txtDiaChi.Text;
                nxb.Sđt = txtSĐT.Text;
                nxb.NamXb = DateTime.ParseExact(dtpNanXB.Text.Trim(), "dd-MM-yyyy", null);
                nxb.TrangThai = rdoHoatDong.Checked ? "Hoạt Động" : "Ngừng Hoạt Động";
                MessageBox.Show(Nxbsv.Them(nxb));
                LoadNhaXuatBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSuanxb_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaNXB.Text) || string.IsNullOrEmpty(txtTenNXB.Text) || string.IsNullOrEmpty(txtDiaChi.Text) ||
                    string.IsNullOrEmpty(txtSĐT.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaNxb không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaNXB.Text.Length > 10 || !Regex.IsMatch(txtMaNXB.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtMaNXB.Text, @"[0-9]"))
                {
                    errors.Add("Mã nhà xuất bản không quá 10 ký tự và chứa cả chữ và số.");
                }
                // Kiểm tra Sđt chỉ chứa 10 số
                if (txtSĐT.Text.Length != 10 || !Regex.IsMatch(txtSĐT.Text, @"^[0-9]+$"))
                {
                    errors.Add("Số điện thoại phải có đúng 10 ký tự và chỉ chứa số.");
                }
                //Trạng thái
                if (!rdoHoatDong.Checked && !rdoDungHoatDong.Checked)
                    errors.Add("Vui lòng chọn Trạng thái.");
                // Kiểm tra năm xuất bản không lớn hơn ngày hiện tại
                DateTime namXb;
                if (!DateTime.TryParseExact(dtpNanXB.Text.Trim(), "dd-MM-yyyy", null, DateTimeStyles.None, out namXb))
                {
                    errors.Add("Ngày xuất bản không hợp lệ.");
                }
                else if (namXb > DateTime.Today)
                {
                    errors.Add("Năm xuất bản không được lớn hơn ngày hiện tại.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NhaXuatBan nxb = new NhaXuatBan();
                nxb.MaNxb = txtMaNXB.Text;
                nxb.TenNxb = txtTenNXB.Text;
                nxb.DiaChi = txtDiaChi.Text;
                nxb.Sđt = txtSĐT.Text;
                nxb.NamXb = DateTime.ParseExact(dtpNanXB.Text.Trim(), "dd-MM-yyyy", null);
                if (rdoHoatDong.Checked)
                {
                    nxb.TrangThai = "Hoạt Động";
                }
                else
                {
                    nxb.TrangThai = "Ngừng Hoạt Động";
                }
                MessageBox.Show(Nxbsv.sua(nxb, idwhenClick));
                LoadNhaXuatBan();
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi rồi");
            }
        }

        private void dgvDsNhaXuatBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDsNhaXuatBan.CurrentRow != null && dgvDsNhaXuatBan.CurrentRow.Cells[0].Value != null)
            {
                txtMaNXB.ReadOnly = true;
                idwhenClick = int.Parse(dgvDsNhaXuatBan.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtMaNXB.Text = dgvDsNhaXuatBan.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTenNXB.Text = dgvDsNhaXuatBan.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiaChi.Text = dgvDsNhaXuatBan.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSĐT.Text = dgvDsNhaXuatBan.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtpNanXB.Text = dgvDsNhaXuatBan.Rows[e.RowIndex].Cells[6].Value.ToString();
                if (dgvDsNhaXuatBan.Rows[e.RowIndex].Cells[7].Value.ToString().Equals("Hoạt Động"))
                {
                    rdoHoatDong.Checked = true;
                }
                else
                {
                    rdoDungHoatDong.Checked = true;
                }
            }
        }

        private void btnLamMoinxb_Click(object sender, EventArgs e)
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            dtpNanXB.Text = "";
            rdoHoatDong.Checked = false;
            rdoDungHoatDong.Checked = false;
            txtSĐT.Text = "";
            txtMaNXB.ReadOnly = false;
            txtTimKiemnxb.Text = "";
            LoadNhaXuatBan();
        }
        public void LoadNhaXuatBan(string name)
        {
            int STT = 1;
            dgvDsNhaXuatBan.ColumnCount = 8;
            dgvDsNhaXuatBan.Rows.Clear();
            dgvDsNhaXuatBan.Columns[0].Name = "ID";
            dgvDsNhaXuatBan.Columns[1].Name = "STT";
            dgvDsNhaXuatBan.Columns[2].Name = "Mã NXB";
            dgvDsNhaXuatBan.Columns[3].Name = "Tên NXB";
            dgvDsNhaXuatBan.Columns[4].Name = "Địa chỉ";
            dgvDsNhaXuatBan.Columns[5].Name = "Số điện thoại";
            dgvDsNhaXuatBan.Columns[6].Name = "Năm xuất bản";
            dgvDsNhaXuatBan.Columns[7].Name = "Trạng thái";

            dgvDsNhaXuatBan.Columns[0].Visible = false;

            var query = from nxb in Nxbsv.GetAllNXBsv()
                        where nxb.TenNxb.ToLower().Contains(name.ToLower()) || nxb.MaNxb.ToLower().Contains(name.ToLower())
                        select new
                        {
                            nxb.Id,
                            STT = ++STT,
                            nxb.MaNxb,
                            nxb.TenNxb,
                            nxb.DiaChi,
                            nxb.Sđt,
                            nxb.NamXb,
                            nxb.TrangThai
                        };

            foreach (var item in query)
            {
                dgvDsNhaXuatBan.Rows.Add(item.Id, item.STT, item.MaNxb, item.TenNxb, item.DiaChi, item.Sđt, item.NamXb, item.TrangThai);
            }
        }


        private void txtTimKiemnxb_TextChanged(object sender, EventArgs e)
        {
            LoadNhaXuatBan(txtTimKiemnxb.Text);
        }
        public void LoadSach()
        {
            int STT = 1;
            dgvDanhSachSach.ColumnCount = 8;
            dgvDanhSachSach.Rows.Clear();
            dgvDanhSachSach.Columns[0].Name = "ID";
            dgvDanhSachSach.Columns[1].Name = "STT";
            dgvDanhSachSach.Columns[2].Name = "Mã Sách";
            dgvDanhSachSach.Columns[3].Name = "Tên sách";
            dgvDanhSachSach.Columns[4].Name = "Tác giả";
            dgvDanhSachSach.Columns[5].Name = "Ngôn ngữ";
            dgvDanhSachSach.Columns[6].Name = "Mô tả";
            dgvDanhSachSach.Columns[7].Name = "Trạng thái";

            dgvDanhSachSach.Columns[0].Visible = false;

            foreach (var item in sachsv.GetAllSachsv())
            {
                if (item.TrangThai != "Hết hàng")
                {
                    dgvDanhSachSach.Rows.Add(item.Id, STT++, item.MaSach, item.TieuDe, item.TacGia, item.NgonNgu, item.MoTa, item.TrangThai);
                }
            }
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

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg; *.jpeg; *.png; *.gif";
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Image image = Image.FromFile(openFileDialog.FileName);


                    pictureSach.Image = image;

                    pathimg = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                }
            }
        }
        private void btnThemsach_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaSachs.Text) || string.IsNullOrEmpty(txtTieudes.Text) || string.IsNullOrEmpty(txtNgonngus.Text) || string.IsNullOrEmpty(txttacgias.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaSach không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaSachs.Text.Length > 10 || !Regex.IsMatch(txtMaSachs.Text, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
                {
                    errors.Add("Mã sách không quá 10 ký tự và chứa cả chữ và số , không chứa kí tự đặc biệt.");
                }

                // Kiểm tra Tiêu đề không được quá 200 ký tự
                if (txtTieudes.Text.Length > 200 || !Regex.IsMatch(txtTieudes.Text, @"^[\p{L}\d\s]*$"))
                {
                    errors.Add("Tiêu đề sách không được vượt quá 200 ký tự, không chứa kí tự đặc biệt.");
                }
                if (!Regex.IsMatch(txttacgias.Text, @"^[\p{L}\s\p{P}]*$"))
                {
                    errors.Add("Tên tác giả chỉ được chứa chữ cái và ký tự đặc biệt.");
                }

                if (!Regex.IsMatch(txtNgonngus.Text, @"^[\p{L}\s]*$"))
                {
                    errors.Add("Ngôn ngữ không được chứa ký tự đặc biệt hoặc số.");
                }
                //Trạng thái
                if (!rdoConhang.Checked && !rdohethang.Checked)
                    errors.Add("Vui lòng chọn Trạng thái.");
                // Kiểm tra NgonNgu chỉ chứa chữ và không quá 50 ký tự
                if (!Regex.IsMatch(txtNgonngus.Text, @"[a-zA-Z]") || txtNgonngus.Text.Length > 50)
                {
                    errors.Add("Ngôn ngữ sách chỉ được chứa chữ và không vượt quá 50 ký tự.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mã sách đã tồn tại
                bool check = sachsv.GetAllSachsv().Any(x => string.Equals(x.MaSach, txtMaSachs.Text, StringComparison.OrdinalIgnoreCase));

                if (check)
                {
                    MessageBox.Show("Mã đã tồn tại");
                }
                else
                {
                    Sach sach = new Sach();
                    sach.MaSach = txtMaSachs.Text;
                    sach.TieuDe = txtTieudes.Text;
                    sach.TacGia = txttacgias.Text;
                    sach.NgonNgu = txtNgonngus.Text;
                    sach.MoTa = txtMoTas.Text;
                    sach.TrangThai = rdoConhang.Checked ? "Còn hàng" : "Hết hàng";
                    MessageBox.Show(sachsv.Them(sach));
                    LoadSach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btncapnhatsach_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaSachs.Text) || string.IsNullOrEmpty(txtTieudes.Text) || string.IsNullOrEmpty(txtNgonngus.Text) || string.IsNullOrEmpty(txttacgias.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaSach không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaSachs.Text.Length > 10 || !Regex.IsMatch(txtMaSachs.Text, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
                {
                    errors.Add("Mã sách không quá 10 ký tự và chứa cả chữ và số , không chứa kí tự đặc biệt.");
                }

                // Kiểm tra Tiêu đề không được quá 200 ký tự
                if (txtTieudes.Text.Length > 200 || !Regex.IsMatch(txtTieudes.Text, @"^[\p{L}\d\s]*$"))
                {
                    errors.Add("Tiêu đề sách không được vượt quá 200 ký tự, không chứa kí tự đặc biệt.");
                }
                if (!Regex.IsMatch(txttacgias.Text, @"^[\p{L}\s\p{P}]*$"))
                {
                    errors.Add("Tên tác giả chỉ được chứa chữ cái và ký tự đặc biệt.");
                }


                if (!Regex.IsMatch(txtNgonngus.Text, @"^[\p{L}\s]*$"))
                {
                    errors.Add("Ngôn ngữ không được chứa ký tự đặc biệt hoặc số.");
                }
                //Trạng thái
                if (!rdoConhang.Checked && !rdohethang.Checked)
                    errors.Add("Vui lòng chọn Trạng thái.");
                // Kiểm tra NgonNgu chỉ chứa chữ và không quá 50 ký tự
                if (!Regex.IsMatch(txtNgonngus.Text, @"[a-zA-Z]") || txtNgonngus.Text.Length > 50)
                {
                    errors.Add("Ngôn ngữ sách chỉ được chứa chữ và không vượt quá 50 ký tự.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Sach sach = new Sach();
                sach.MaSach = txtMaSachs.Text;
                sach.TieuDe = txtTieudes.Text;
                sach.TacGia = txttacgias.Text;
                sach.MoTa = txtMoTas.Text;
                sach.TrangThai = rdoConhang.Checked ? "Còn hàng" : "Hết hàng";
                sach.NgonNgu = txtNgonngus.Text;
                MessageBox.Show(sachsv.sua(sach, idwhenClick));
                LoadSach();
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi rồi");
            }
        }

        private void dgvDanhSachSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSachSach.CurrentRow != null && dgvDanhSachSach.CurrentRow.Cells[0].Value != null)
            {
                txtMaSachs.ReadOnly = true;
                idwhenClick = int.Parse(dgvDanhSachSach.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtMaSachs.Text = dgvDanhSachSach.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTieudes.Text = dgvDanhSachSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                txttacgias.Text = dgvDanhSachSach.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNgonngus.Text = dgvDanhSachSach.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtMoTas.Text = dgvDanhSachSach.Rows[e.RowIndex].Cells[6].Value.ToString();

                string trangThai = dgvDanhSachSach.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (trangThai.Equals("Còn hàng", StringComparison.OrdinalIgnoreCase))
                {
                    rdoConhang.Checked = true;
                }
                else
                {
                    rdohethang.Checked = true;
                }
            }
        }

        private void btnlammoisach_Click(object sender, EventArgs e)
        {
            txtMaSachs.Text = "";
            txtTieudes.Text = "";
            txttacgias.Text = "";
            txtNgonngus.Text = "";
            txtMoTas.Text = "";
            rdoConhang.Checked = false;
            rdohethang.Checked = false;
            txtMaSachs.ReadOnly = false;
            LoadSach();
        }
        public void LoadSach(string name)
        {
            int STT = 1;
            dgvDanhSachSach.ColumnCount = 8;
            dgvDanhSachSach.Rows.Clear();
            dgvDanhSachSach.Columns[0].Name = "ID";
            dgvDanhSachSach.Columns[1].Name = "STT";
            dgvDanhSachSach.Columns[2].Name = "Mã Sách";
            dgvDanhSachSach.Columns[3].Name = "Tên sách";
            dgvDanhSachSach.Columns[4].Name = "Tác giả";
            dgvDanhSachSach.Columns[5].Name = "Ngôn ngữ";
            dgvDanhSachSach.Columns[6].Name = "Mô tả";
            dgvDanhSachSach.Columns[7].Name = "Trạng thái";

            dgvDanhSachSach.Columns[0].Visible = false;

            var query = from sach in sachsv.GetAllSachsv()
                        where sach.TieuDe.ToLower().Contains(name.ToLower()) || sach.MaSach.ToLower().Contains(name.ToLower())
                        select new
                        {
                            sach.Id,
                            STT = ++STT,
                            sach.MaSach,
                            sach.TieuDe,
                            sach.TacGia,
                            sach.NgonNgu,
                            sach.MoTa,
                            sach.TrangThai
                        };

            foreach (var item in query)
            {
                dgvDanhSachSach.Rows.Add(item.Id, item.STT, item.MaSach, item.TieuDe, item.TacGia, item.NgonNgu, item.MoTa, item.TrangThai);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadSach(txtTimkiemS.Text);
        }

        public void LoadttSachct()
        {
            int index = 0;
            var result = from sct in sachctsv.GetAllSachctsv()
                         join nxb in Nxbsv.GetAllNXBsv() on sct.Idnxb equals nxb.Id
                         join s in sachsv.GetAllSachsv() on sct.Idsach equals s.Id
                         where sct.SoLuong != 0
                         select new
                         {
                             sct.Id,
                             STT = ++index,
                             sct.MaSachCt,
                             s.TieuDe,
                             sct.HinhAnh,
                             sct.SoLuong,
                             sct.Tap,
                             sct.SoTrang,
                             sct.GiaBan,
                             nxb.TenNxb,
                             sct.TenTheLoai,
                         };

            dgvDanhSachct.DataSource = result.ToList();
            dgvDanhSachct.Columns[0].Visible = false;
            dgvDanhSachct.Columns[1].HeaderText = "STT";
            dgvDanhSachct.Columns[2].HeaderText = "Mã sách";
            dgvDanhSachct.Columns[3].HeaderText = "Tiêu đề";
            dgvDanhSachct.Columns[4].HeaderText = "Hình ảnh";
            dgvDanhSachct.Columns[5].HeaderText = "Số lượng";
            dgvDanhSachct.Columns[6].HeaderText = "Tập";
            dgvDanhSachct.Columns[7].HeaderText = "Số trang";
            dgvDanhSachct.Columns[8].HeaderText = "Giá bán";
            dgvDanhSachct.Columns[9].HeaderText = "Tên nhà XB";
            dgvDanhSachct.Columns[10].HeaderText = "Tên thể loại";

            var loadnxb = Nxbsv.GetAllNXBsv().ToList();
            cboNxb.DataSource = loadnxb;
            cboNxb.DisplayMember = "TenNxb";
            cboNxb.ValueMember = "Id";

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvDanhSachct.Columns[4];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(pathimg) || string.IsNullOrEmpty(txtMaSach.Text) || string.IsNullOrEmpty(txtSoLuong.Text) ||
                    string.IsNullOrEmpty(txtSotrang.Text) || string.IsNullOrEmpty(txtGia.Text) ||
                    cboNxb.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaSachCt không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaSach.Text.Length > 10 || !Regex.IsMatch(txtMaSach.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtMaSach.Text, @"[0-9]"))
                {
                    errors.Add("Mã sách chi tiết không được trống, không quá 10 ký tự chứa cả chữ và số.");
                }

                // Kiểm tra SoLuong chỉ chứa số, không âm và không vượt quá 10000
                int soLuong;
                if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0 || soLuong >= 10000)
                {
                    errors.Add("Số lượng sách phải là một số không âm và không vượt quá 10000.");
                }

                // Kiểm tra SoTrang chỉ chứa số, không âm và không vượt quá 500
                int soTrang;
                if (!int.TryParse(txtSotrang.Text, out soTrang) || soTrang <= 0 || soTrang >= 500)
                {
                    errors.Add("Số trang sách phải là một số không âm và không vượt quá 500.");
                }
                // Kiểm tra GiaBan chỉ chứa số, không âm và không vượt quá 1000000
                int giaBan;
                if (!int.TryParse(txtGia.Text, out giaBan) || giaBan < 0 || giaBan >= 1000000)
                {
                    errors.Add("Giá bán sách phải là một số không âm và không vượt quá 1000000.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool check = sachctsv.GetAllSachctsv().Any(x => string.Equals(x.MaSachCt, txtMaSach.Text, StringComparison.OrdinalIgnoreCase));
                if (check)
                {
                    MessageBox.Show("Mã đã tồn tại");
                    return;
                }
                // Thêm sách chi tiết nếu không có lỗi
                SachChiTiet sachct = new SachChiTiet();
                byte[] imageBytes = File.ReadAllBytes(pathimg);
                sachct.HinhAnh = imageBytes;
                sachct.MaSachCt = txtMaSach.Text;
                sachct.SoLuong = soLuong;
                sachct.Tap = txtTap.Text;
                sachct.SoTrang = soTrang;
                sachct.GiaBan = giaBan;
                sachct.Idnxb = int.Parse(cboNxb.SelectedValue.ToString());
                sachct.Idsach = int.Parse(textBoxID.Text);
                foreach (string item in listBox1.Items)
                {
                    sachct.TenTheLoai += item + ", "; // Nếu cần, bạn có thể thay đổi cách định dạng dữ liệu
                }

                // Xóa ký tự phụ cuối cùng nếu có
                

                MessageBox.Show(sachctsv.Them(sachct));
                LoadttSachct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaSach.Text))
            {
                var sach = sachsv.GetAllSachsv().FirstOrDefault(s => s.MaSach == txtMaSach.Text);

                if (sach != null)
                {
                    txtTieude.Text = sach.TieuDe;
                    textBoxID.Text = sach.Id.ToString();
                }
                else
                {
                    txtTieude.Text = "Not found";
                    textBoxID.Text = "";
                }
            }
            else
            {
                txtTieude.Text = "";
                textBoxID.Text = "";
            }
        }

        private void dgvDanhSachct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idwhenClick = int.Parse(dgvDanhSachct.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtMaSach.Text = dgvDanhSachct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTieude.Text = dgvDanhSachct.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSoLuong.Text = dgvDanhSachct.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtTap.Text = dgvDanhSachct.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtSotrang.Text = dgvDanhSachct.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtGia.Text = dgvDanhSachct.Rows[e.RowIndex].Cells[8].Value.ToString();
            cboNxb.Text = dgvDanhSachct.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtMaSach.ReadOnly = true;

            var s = sachctsv.Findid(idwhenClick);
            if (s != null && s.HinhAnh != null)
            {
                byte[] imageData = s.HinhAnh;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureSach.Image = Image.FromStream(ms);
                    imgLoad = s.HinhAnh;
                }
            }
            else
            {
                pictureSach.Image = null;
                imgLoad = null;
            }


            // Xóa tất cả các mục hiện có trong ListBox
            listBox1.Items.Clear();

           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>(); // Danh sách lỗi

                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(txtMaSach.Text) || string.IsNullOrEmpty(txtSoLuong.Text) ||
                    string.IsNullOrEmpty(txtSotrang.Text) || string.IsNullOrEmpty(txtGia.Text) ||
                    cboNxb.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra MaSachCt không được lớn hơn 10 ký tự và chỉ chứa cả chữ và số
                if (txtMaSach.Text.Length > 10 || !Regex.IsMatch(txtMaSach.Text, @"[a-zA-Z]") || !Regex.IsMatch(txtMaSach.Text, @"[0-9]"))
                {
                    errors.Add("Mã sách chi tiết không được trống, không quá 10 ký tự chứa cả chữ và số.");
                }

                // Kiểm tra SoLuong chỉ chứa số, không âm và không vượt quá 10000
                int soLuong;
                if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0 || soLuong >= 10000)
                {
                    errors.Add("Số lượng sách phải là một số không âm và không vượt quá 10000.");
                }

                // Kiểm tra SoTrang chỉ chứa số, không âm và không vượt quá 500
                int soTrang;
                if (!int.TryParse(txtSotrang.Text, out soTrang) || soTrang <= 0 || soTrang >= 500)
                {
                    errors.Add("Số trang sách phải là một số không âm và không vượt quá 500.");
                }

                // Kiểm tra GiaBan chỉ chứa số, không âm và không vượt quá 1000000
                int giaBan;
                if (!int.TryParse(txtGia.Text, out giaBan) || giaBan < 0 || giaBan >= 1000000)
                {
                    errors.Add("Giá bán sách phải là một số không âm và không vượt quá 1000000.");
                }

                // Hiển thị lỗi nếu có
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SachChiTiet sachct = new SachChiTiet();
                if (pathimg != null)
                {
                    byte[] imageBytes = File.ReadAllBytes(pathimg);
                    sachct.HinhAnh = imageBytes;
                }
                else
                    sachct.HinhAnh = imgLoad;
                sachct.MaSachCt = txtMaSach.Text;
                sachct.SoLuong = int.Parse(txtSoLuong.Text);
                sachct.Tap = txtTap.Text;
                sachct.SoTrang = int.Parse(txtSotrang.Text);
                sachct.GiaBan = int.Parse(txtGia.Text);
                sachct.Idnxb = int.Parse(cboNxb.SelectedValue.ToString());
                sachct.Idsach = int.Parse(textBoxID.Text);
                foreach (string item in listBox1.Items)
                {
                    sachct.TenTheLoai += item + ", "; // Nếu cần, bạn có thể thay đổi cách định dạng dữ liệu
                }

                // Xóa ký tự phụ cuối cùng nếu có
                if (sachct.TenTheLoai.EndsWith(", "))
                {
                    sachct.TenTheLoai = sachct.TenTheLoai.Remove(sachct.TenTheLoai.Length - 2);
                }
                MessageBox.Show(sachctsv.Sua(sachct, idwhenClick));

                LoadttSachct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            txtTieude.Text = "";
            txtSoLuong.Text = "";
            txtTap.Text = "";
            txtSotrang.Text = "";
            txtGia.Text = "";
            cboNxb.SelectedIndex = -1;
            pictureSach.Image = null;
            txtMaSach.ReadOnly = false;
            listBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenernator = new QRCodeGenerator();
            QRCodeData qrCodedata = qrGenernator.CreateQrCode(txtMaSach.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodedata);
            Bitmap qrcodeImg = qrcode.GetGraphic(20);
            pictureSach.Image = qrcodeImg;
        }

        private void btnLuuQr_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog savefliedialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (savefliedialog.ShowDialog() == DialogResult.OK)
                {
                    pictureSach.Image.Save(savefliedialog.FileName);
                    MessageBox.Show("Tệp đã lưu");
                }
            }
        }
        public void LoadttSachct(string name)
        {
            int index = 0;
            var result = from sct in sachctsv.GetAllSachctsv()
                         join nxb in Nxbsv.GetAllNXBsv() on sct.Idnxb equals nxb.Id
                         join s in sachsv.GetAllSachsv() on sct.Idsach equals s.Id
                         where sct.MaSachCt.ToLower().Contains(name.ToLower()) || s.TieuDe.ToLower().Contains(name.ToLower()) || sct.TenTheLoai.ToLower().Contains(name.ToLower())
                         select new
                         {
                             sct.Id,
                             STT = ++index,
                             sct.MaSachCt,
                             s.TieuDe,
                             sct.HinhAnh,
                             sct.SoLuong,
                             sct.Tap,
                             sct.SoTrang,
                             sct.GiaBan,
                             nxb.TenNxb,
                             sct.TenTheLoai,
                         };

            dgvDanhSachct.DataSource = result.ToList();
            dgvDanhSachct.Columns[0].Visible = false;
            dgvDanhSachct.Columns[1].HeaderText = "STT";
            dgvDanhSachct.Columns[2].HeaderText = "Mã sách";
            dgvDanhSachct.Columns[3].HeaderText = "Tiêu đề";
            dgvDanhSachct.Columns[4].HeaderText = "Hình ảnh";
            dgvDanhSachct.Columns[5].HeaderText = "Số lượng";
            dgvDanhSachct.Columns[6].HeaderText = "Tập";
            dgvDanhSachct.Columns[7].HeaderText = "Số trang";
            dgvDanhSachct.Columns[8].HeaderText = "Giá bán";
            dgvDanhSachct.Columns[9].HeaderText = "Tên nhà XB";
            dgvDanhSachct.Columns[10].HeaderText = "Tên thể loại";




            var loadnxb = Nxbsv.GetAllNXBsv().ToList();
            cboNxb.DataSource = loadnxb;
            cboNxb.DisplayMember = "TenNxb";
            cboNxb.ValueMember = "Id";

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvDanhSachct.Columns[4];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void txtTimKiemkh_TextChanged(object sender, EventArgs e)
        {
            LoadttSachct(txtTimKiemkh.Text);
        }
        private void SanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvDanhSachSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvDanhSachSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                // Lấy giá trị của cell được double-click
                string cellValue = dgvDanhSachSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Hiển thị giá trị của cell lên TextBox trên TabControl2
                txtMaSach.Text = cellValue;

                // Chuyển sang TabControl2
                tabControl1.SelectedIndex = 1; // Giả sử TabControl2 có index là 1
            }
        }
        public void LoadTheLoai()
        {
            int STT = 1;
            dgvDanhSachTl.ColumnCount = 4;
            dgvDanhSachTl.Rows.Clear();
            dgvDanhSachTl.Columns[0].Name = "ID";
            dgvDanhSachTl.Columns[1].Name = "STT";
            dgvDanhSachTl.Columns[2].Name = "Mã Thể loại";
            dgvDanhSachTl.Columns[3].Name = "Tên Thể loại";

            dgvDanhSachTl.Columns[0].Visible = false;

            foreach (var item in theloaisv.GetAllTheLoaisv())
            {
                dgvDanhSachTl.Rows.Add(item.Id, STT++, item.MaTl, item.TenTl);
            }
        }
        private void btnThemTl_Click(object sender, EventArgs e)
        {
            string maTl = txtMaTl.Text.Trim();
            string tenTl = txtTenTl.Text.Trim();

            // Kiểm tra xem MaTl và TenTl có rỗng không
            if (string.IsNullOrEmpty(maTl) || string.IsNullOrEmpty(tenTl))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra xem MaTl có chứa chữ và số và không quá 10 ký tự không
            if (maTl.Length > 10 || !Regex.IsMatch(maTl, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
            {
                MessageBox.Show("Mã Thể loại phải chứa chữ và số, không quá 10 ký tự , không chứa kí tự đặc biệt");
                return;
            }
            if (!Regex.IsMatch(tenTl, @"^[\p{L}\s]*$"))
            {
                MessageBox.Show("Tên Thể loại không được chứa ký tự đặc biệt hoặc số.");
                return;
            }
            bool check = theloaisv.GetAllTheLoaisv().Any(x => x.MaTl == maTl);
            if (check)
            {
                MessageBox.Show("Mã đã tồn tại");
            }
            else
            {
                TheLoai tl = new TheLoai();
                tl.MaTl = maTl;
                tl.TenTl = tenTl;
                MessageBox.Show(theloaisv.Them(tl));
                LoadTheLoai();
            }
        }

        private void btnSuatl_Click(object sender, EventArgs e)
        {
            try
            {
                string maTl = txtMaTl.Text.Trim();
                string tenTl = txtTenTl.Text.Trim();

                // Kiểm tra xem MaTl và TenTl có rỗng không
                if (string.IsNullOrEmpty(maTl) || string.IsNullOrEmpty(tenTl))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Kiểm tra xem MaTl có chứa chữ và số và không quá 10 ký tự không
                if (maTl.Length > 10 || !Regex.IsMatch(maTl, @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{1,10}$"))
                {
                    MessageBox.Show("Mã Thể loại phải chứa chữ và số, không quá 10 ký tự , không chứa kí tự đặc biệt");
                    return;
                }
                if (!Regex.IsMatch(tenTl, @"^[\p{L}\s]*$"))
                {
                    MessageBox.Show("Tên Thể loại không được chứa ký tự đặc biệt hoặc số.");
                    return;
                }

                TheLoai tl = new TheLoai();
                tl.MaTl = maTl;
                tl.TenTl = tenTl;
                MessageBox.Show(theloaisv.sua(tl, idwhenClick));
                LoadTheLoai();
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi rồi");
            }
        }

        private void btnLammoitl_Click(object sender, EventArgs e)
        {
            txtMaTl.Text = "";
            txtTenTl.Text = "";
            txtMaTl.ReadOnly = false;
        }
        public void LoadTheLoai(string name)
        {
            int STT = 1;
            dgvDanhSachTl.ColumnCount = 4;
            dgvDanhSachTl.Rows.Clear();
            dgvDanhSachTl.Columns[0].Name = "ID";
            dgvDanhSachTl.Columns[1].Name = "STT";
            dgvDanhSachTl.Columns[2].Name = "Mã Thể loại";
            dgvDanhSachTl.Columns[3].Name = "Tên Thể loại";

            dgvDanhSachTl.Columns[0].Visible = false;

            var query = from tl in theloaisv.GetAllTheLoaisv()
                        where tl.TenTl.ToLower().Contains(name.ToLower()) || tl.MaTl.ToLower().Contains(name.ToLower())
                        select new
                        {
                            tl.Id,
                            STT = ++STT,
                            tl.MaTl,
                            tl.TenTl
                        };

            foreach (var item in query)
            {
                dgvDanhSachTl.Rows.Add(item.Id, item.STT, item.MaTl, item.TenTl);
            }
        }


        private void dgvDanhSachTl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSachTl.CurrentRow != null && dgvDanhSachTl.CurrentRow.Cells[0].Value != null)
            {
                idwhenClick = int.Parse(dgvDanhSachTl.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtMaTl.Text = dgvDanhSachTl.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTenTl.Text = dgvDanhSachTl.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMaTl.ReadOnly = true;
            }
        }

        private void txtTimKiemTl_TextChanged(object sender, EventArgs e)
        {
            LoadTheLoai(txtTimKiemTl.Text);
        }
        private void LoadDataIntoCheckListBox()
        {
            var items = theloaisv.getItemsFromDatabase();
            foreach (var item in items)
            {
                checkedListBox1.Items.Add(item);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string item in checkedListBox1.CheckedItems)
            {
                listBox1.Items.Add(item);
            }
        }

        private void btnThemTheloai_Click(object sender, EventArgs e)
        {
            string maTl = textBoxmaTL.Text.Trim();
            string tenTl = textBoxTenTL.Text.Trim();

            // Kiểm tra xem MaTl và TenTl có rỗng không
            if (string.IsNullOrEmpty(maTl) || string.IsNullOrEmpty(tenTl))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra xem MaTl có chứa chữ và số và không quá 10 ký tự không
            if (string.IsNullOrEmpty(maTl) || maTl.Length > 10 || !Regex.IsMatch(maTl, @"[a-zA-Z]") || !Regex.IsMatch(maTl, @"[0-9]"))
            {
                MessageBox.Show("Mã Thể loại phải chứa chữ và số, không quá 10 ký tự.");
                return;
            }

            bool check = theloaisv.GetAllTheLoaisv().Any(x => x.MaTl == maTl);
            if (check)
            {
                MessageBox.Show("Mã đã tồn tại");
            }
            else
            {
                TheLoai tl = new TheLoai();
                tl.MaTl = maTl;
                tl.TenTl = tenTl;
                MessageBox.Show(theloaisv.Them(tl));
                LoadTheLoai();
                listBox1.Items.Clear();
                LoadDataIntoCheckListBox();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

            // Lọc sản phẩm dựa trên khoảng giá
            switch (selectedItem)
            {
                case "30.000 -> 100.000":
                    FilterProductsByPrice(30000, 100000);
                    break;
                case "100.000 -> 200.000":
                    FilterProductsByPrice(100000, 200000);
                    break;
                case "200.000 -> 400.000":
                    FilterProductsByPrice(200000, 400000);
                    break;
                case "400.000 -> 600.000":
                    FilterProductsByPrice(400000, 600000);
                    break;
                case "600.000 -> 1.000.000":
                    FilterProductsByPrice(600000, 1000000);
                    break;
                case "Tất cả":
                    LoadttSachct();
                    break;
                default:
                    break;
            }
        }
        private void FilterProductsByPrice(int minPrice, int maxPrice)
        {
            int STT = 0;
            var result = from sct in sachctsv.GetAllSachctsv()
                         join nxb in Nxbsv.GetAllNXBsv() on sct.Idnxb equals nxb.Id
                         join s in sachsv.GetAllSachsv() on sct.Idsach equals s.Id
                         where sct.SoLuong != 0 && sct.GiaBan >= minPrice && sct.GiaBan <= maxPrice
                         select new
                         {
                             sct.Id,
                             STT = ++STT,
                             sct.MaSachCt,
                             s.TieuDe,
                             sct.HinhAnh,
                             sct.SoLuong,
                             sct.Tap,
                             sct.SoTrang,
                             sct.GiaBan,
                             nxb.TenNxb,
                             sct.TenTheLoai,
                         };

            // Hiển thị kết quả lọc trong DataGridView
            dgvDanhSachct.DataSource = result.ToList();
            dgvDanhSachct.Columns[0].Visible = false;
            dgvDanhSachct.Columns[1].HeaderText = "STT";
            dgvDanhSachct.Columns[2].HeaderText = "Mã sách";
            dgvDanhSachct.Columns[3].HeaderText = "Tiêu đề";
            dgvDanhSachct.Columns[4].HeaderText = "Hình ảnh";
            dgvDanhSachct.Columns[5].HeaderText = "Số lượng";
            dgvDanhSachct.Columns[6].HeaderText = "Tập";
            dgvDanhSachct.Columns[7].HeaderText = "Số trang";
            dgvDanhSachct.Columns[8].HeaderText = "Giá bán";
            dgvDanhSachct.Columns[9].HeaderText = "Tên nhà XB";
            dgvDanhSachct.Columns[10].HeaderText = "Tên thể loại";

            var loadnxb = Nxbsv.GetAllNXBsv().ToList();
            cboNxb.DataSource = loadnxb;
            cboNxb.DisplayMember = "TenNxb";
            cboNxb.ValueMember = "Id";

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvDanhSachct.Columns[4];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void textBoxTenTL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
