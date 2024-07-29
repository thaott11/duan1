using AForge.Video;
using AForge.Video.DirectShow;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.Word.DrawingShape;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF.BLL.Service;
using WF.DAL.Models;
using WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN;
using WF.GUI.View;
using ZXing;
using static QRCoder.PayloadGenerator;
using static QRCoder.PayloadGenerator.SwissQrCode;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien
{
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }
        VoucherService vcsv;
        KhachHangService khachhangsv;
        NhanVienService nhanviensv;
        SachService sachsv;
        SachCtService sachctsv;
        HoaDonService hoadonsv;
        HoaDonCtService hoadonctsv;
        int idwhenClick = new int();
        private bool isDoubleClick = false;
        private void BanHang_Load(object sender, EventArgs e)
        {
            vcsv = new VoucherService();
            khachhangsv = new KhachHangService();
            nhanviensv = new NhanVienService();
            hoadonsv = new HoaDonService();
            sachsv = new SachService();
            sachctsv = new SachCtService();
            hoadonctsv = new HoaDonCtService();
            LoadSp();
            LoadGiamGia();
            LoadHD();
            camCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in camCollection)
            {
                cbocame.Items.Add(item.Name);
            }
            if (camCollection.Count > 0)
            {
                cbocame.SelectedIndex = 0;
            }
        }

        public void LoadSp()
        {
            int index = 0;
            var result = from sct in sachctsv.GetAllSachctsv()
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
                         };

            dgvDanhSachSP.DataSource = result.ToList();
            dgvDanhSachSP.Columns[0].Visible = false;
            dgvDanhSachSP.Columns[1].HeaderText = "STT";
            dgvDanhSachSP.Columns[2].HeaderText = "Mã sách";
            dgvDanhSachSP.Columns[3].HeaderText = "Tiêu đề";
            dgvDanhSachSP.Columns[4].HeaderText = "Hình ảnh";
            dgvDanhSachSP.Columns[5].HeaderText = "Số lượng";
            dgvDanhSachSP.Columns[6].HeaderText = "Tập";
            dgvDanhSachSP.Columns[7].HeaderText = "Số trang";
            dgvDanhSachSP.Columns[8].HeaderText = "Giá bán";

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvDanhSachSP.Columns[4];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        public void LoadHD()
        {
            int STT = 1;
            dgvHoaDon.Rows.Clear();
            dgvHoaDon.ColumnCount = 9;
            dgvHoaDon.Columns[0].Name = "ID";
            dgvHoaDon.Columns[1].Name = "STT";
            dgvHoaDon.Columns[2].Name = "Mã HD";
            dgvHoaDon.Columns[3].Name = "Tên NV";
            dgvHoaDon.Columns[4].Name = "Tên KH";
            dgvHoaDon.Columns[5].Name = "Ngày tạo";
            dgvHoaDon.Columns[6].Name = "Trạng thái";
            dgvHoaDon.Columns[7].Name = "Mã KH";
            dgvHoaDon.Columns[8].Name = "Giảm giá";
            dgvHoaDon.Columns[8].Visible = false;

            dgvHoaDon.Columns[7].Visible = false;
            dgvHoaDon.Columns[0].Visible = false;

            foreach (var item in hoadonsv.GetAllHoaDonrv())
            {
                var nv = nhanviensv.GetAllNhanViensv().FirstOrDefault(x => x.Id == item.Idnhanvien);
                var kh = khachhangsv.GetAllKhachHangsv().FirstOrDefault(x => x.Id == item.Idkhachhang);
                if (nv != null && kh != null && item.TrangThai == "Chưa thanh toán")
                {
                    dgvHoaDon.Rows.Add(item.Id, STT++, item.MaHd, nv.HoTenNv, kh.TenKhachHang, item.NgayMuaHang, item.TrangThai, kh.MaKhachHang, item.GiamGia);
                }
            }

            var loadkh = khachhangsv.GetAllKhachHangsv().ToList();
            cboid.DataSource = loadkh;
            cboid.ValueMember = "Id";

        }
        private int countClicks = 0;
        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (countClicks < 10)
            {
                HoaDon hd = new HoaDon();
                string maHD;
                var allHoaDon = hoadonsv.GetAllHoaDonrv();
                int count = allHoaDon.Count + 1;
                maHD = "HĐ" + count;
                while (allHoaDon.Any(x => x.MaHd == maHD))
                {
                    count++;
                    maHD = "HĐ" + count;
                }
                hd.MaHd = maHD;
                hd.Idnhanvien = 1;
                hd.Idkhachhang = 1;
                hd.NgayMuaHang = DateTime.Now;
                hd.TrangThai = "Chưa thanh toán";
                hd.GiamGia = 0;
                hoadonsv.Them(hd);
                LoadHD();
                txtMaKh.Text = "";
                txtTenKH.Text = "";

                countClicks++; // Tăng số lần click
            }
            else
            {
                // Hiển thị thông báo cho người dùng biết đã đạt giới hạn 10 lần
                MessageBox.Show("Bạn chỉ được phép tạo hóa đơn tối đa 10 lần liên tiếp.");
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null && dgvHoaDon.CurrentRow.Cells[0].Value != null)
            {
                idwhenClick = int.Parse(dgvHoaDon.CurrentRow.Cells[0].Value.ToString());
                txtMaKh.Text = dgvHoaDon.CurrentRow.Cells[7].Value.ToString();
                txtTenKH.Text = dgvHoaDon.CurrentRow.Cells[4].Value.ToString();
                txtidmax.Text = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
            }
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            ThemKhachHang frm = new ThemKhachHang();
            frm.Show();
        }
        public void CapNhatThongTinKhachHang(string maKhachHang, string tenKhachHang, int id)
        {
            cboid.Text = id.ToString();
            txtMaKh.Text = maKhachHang;
            txtTenKH.Text = tenKhachHang;
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Idkhachhang = int.Parse(cboid.SelectedValue.ToString());
            hoadonsv.Sua(hd, idwhenClick);
            LoadHD();
        }

        private void lbTienThua_TextChanged(object sender, EventArgs e)
        {
            double kt, tt;
            if (double.TryParse(txtTienKhachdua.Text, out kt) && double.TryParse(lbThanhToan.Text, out tt))
            {
                double tienthua = kt - tt;
                lbTienThua.Text = tienthua.ToString();
            }
        }
        private void TinhTongTien()
        {
            double tongTien = 0;
            foreach (DataGridViewRow row in dgvDsHoaDonChiTiet.Rows)
            {
                double thanhTien;
                if (row.Cells[7].Value != null && double.TryParse(row.Cells[7].Value.ToString(), out thanhTien))
                {
                    tongTien += thanhTien;
                }
                lbTongTien.Text = tongTien.ToString();
                lbThanhToan.Text = tongTien.ToString();
                LoadGiamGia();
            }

        }
        public void Loadhdct()
        {
            int STT = 1;
            dgvDsHoaDonChiTiet.Rows.Clear();
            dgvDsHoaDonChiTiet.ColumnCount = 9;
            dgvDsHoaDonChiTiet.Columns[0].Name = "ID";
            dgvDsHoaDonChiTiet.Columns[1].Name = "STT";
            dgvDsHoaDonChiTiet.Columns[2].Name = "MaHDCT";
            dgvDsHoaDonChiTiet.Columns[3].Name = "MaSP";
            dgvDsHoaDonChiTiet.Columns[4].Name = "Tên sách";
            dgvDsHoaDonChiTiet.Columns[5].Name = "Số Lượng";
            dgvDsHoaDonChiTiet.Columns[6].Name = "Giá ";
            dgvDsHoaDonChiTiet.Columns[7].Name = "Thành Tiền";
            dgvDsHoaDonChiTiet.Columns[8].Name = "IDHD";
            dgvDsHoaDonChiTiet.Columns[0].Visible = false;
            //dgvDsHoaDonChiTiet.Columns[8].Visible = false;

            foreach (var item in hoadonctsv.GetAllHoaDonCtsv())
            {
                dgvDsHoaDonChiTiet.Rows.Add(item.Id, STT++, item.MaHdct, item.MaSpct, item.TenSp, item.SoLuongMua, item.GiaBan, item.ThanhTien, item.IdhoaDon);
            }
            TinhTongTien();
        }

        private void txtTienKhachdua_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtTienKhachdua.Text, out double tienKhachDua))
            {
                double tongTienSauGiam = Convert.ToDouble(lbThanhToan.Text);
                double tienThua = Math.Max(tienKhachDua - tongTienSauGiam, 0);
                lbTienThua.Text = tienThua.ToString();
            }
            else
            {
                lbTienThua.Text = "0";
            }
        }
        private void dgvDsHoaDonChiTiet_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDsHoaDonChiTiet.Columns[7].Index)
            {
                TinhTongTien();
            }
            else if (e.ColumnIndex == dgvDsHoaDonChiTiet.Columns[5].Index)
            {
                int sl = Convert.ToInt32(dgvDsHoaDonChiTiet.Rows[e.RowIndex].Cells[5].Value);
                double gia = Convert.ToDouble(dgvDsHoaDonChiTiet.Rows[e.RowIndex].Cells[6].Value);
                dgvDsHoaDonChiTiet.Rows[e.RowIndex].Cells[7].Value = sl * gia;
                TinhTongTien();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            int mahd = int.Parse(txtmahd.Text);
            var removedItem = hoadonctsv.GetAllHoaDonCtsv().FirstOrDefault(x => x.Id == mahd);
            int removedQuantity = removedItem != null ? removedItem.SoLuongMua : 0;
            var sachct = sachctsv.GetAllSachctsv().Find(x => x.MaSachCt == txtMas.Text);
            int slcon = sachct.SoLuong;
            int newSL = slcon + removedQuantity;
            string mess = hoadonctsv.Xoa(mahd);
            MessageBox.Show(mess, "Thông báo");
            sachctsv.updateSL(txtMas.Text, newSL);
            LoadSp();
            // Kiểm tra xem Idhoadon có bằng với txtidmax.Text hay không
            int selectedHoaDonId = Convert.ToInt32(txtidmax.Text);
            if (selectedHoaDonId == int.Parse(txtidmax.Text))
            {
                Loadhdct(selectedHoaDonId);
            }
            if (newSL > 0)
            {
                sachsv.CapNhatTrangThaiSachConHang();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDsHoaDonChiTiet.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                double tienKhachDua;
                if (!double.TryParse(txtTienKhachdua.Text, out tienKhachDua) || tienKhachDua < 0)
                {
                    MessageBox.Show("Tiền khách đưa không được số âm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Lấy giá trị số tiền thanh toán từ lbThanhToan
                if (!double.TryParse(lbThanhToan.Text, out double thanhToan))
                {
                    MessageBox.Show("Lỗi khi lấy thông tin thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem tiền khách đưa có nhỏ hơn giá trị thanh toán hay không
                if (tienKhachDua < thanhToan)
                {
                    MessageBox.Show("Tiền khách đưa không được nhỏ hơn số tiền cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var tt = MessageBox.Show("Bạn có chắc chắn muốn thanh toán không", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tt == DialogResult.Yes)
                {
                    var inhd = MessageBox.Show("Bạn có muốn in hóa đơn không ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (inhd == DialogResult.Yes)
                    {
                        InHoaDon();
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán thành công");
                    }
                    if (cboGiamGia.SelectedItem != null)
                    {
                        KeyValuePair<string, string> selectedItem = (KeyValuePair<string, string>)cboGiamGia.SelectedItem;

                        // Lấy giá trị key và value của mục đã chọn
                        string maGiamGia = selectedItem.Key;
                        var voucher = vcsv.GetAllVouchersv().FirstOrDefault(x => x.MaVoucher == maGiamGia);
                        if (voucher != null)
                        {
                            // Trừ số lượng của mã giảm giá đó đi 1
                            if (voucher.SoLuong > 0)
                            {
                                voucher.SoLuong--;
                                vcsv.UpdateMaGiamGia(voucher);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã giảm giá không tồn tại.");
                        }
                    }

                    HoaDon hd = new HoaDon();
                    hd.TrangThai = "Đã thanh toán";
                    hoadonsv.suatt(hd, int.Parse(txtidmax.Text));
                    hoaDonCts.Clear();
                    dgvDsHoaDonChiTiet.Rows.Clear();
                    LoadHD();

                    lbTienThua.Text = "";
                    txtTienKhachdua.Text = "";
                    lbTongTien.Text = "";
                    cboGiamGia.Text = "";
                    lblTienGiam.Text = "";
                    lbThanhToan.Text = "";
                    txtGhiChu.Text = "";
                    txtMaKh.Text = "";
                    txtTenKH.Text = "";
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        private void cboGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGiamGia.SelectedItem != null && cboGiamGia.SelectedItem is KeyValuePair<string, string> selectedItem)
            {
                string maGiamGia = selectedItem.Key;
                double tongTien;
                if (double.TryParse(lbTongTien.Text, out tongTien))
                {
                    double tiLeGiamGia = vcsv.GetTiLeGiamGia(maGiamGia);
                    double giamToiDa = vcsv.GetGiamToiDa(maGiamGia); // Lấy giá trị GiamToiDa từ mã giảm giá

                    if (tiLeGiamGia > 0)
                    {
                        double tienGiam = tongTien * (tiLeGiamGia / 100.0);

                        // Nếu số tiền giảm vượt quá số tiền giảm tối đa, chỉ sử dụng số tiền giảm tối đa
                        if (tienGiam > giamToiDa)
                        {
                            tienGiam = giamToiDa;
                        }

                        double tongTienSauGiam = tongTien - tienGiam;

                        // Cập nhật giảm giá trong hóa đơn
                        HoaDon hd = new HoaDon();
                        hd.GiamGia = tienGiam;
                        hoadonsv.suagiamgia(hd, int.Parse(txtidmax.Text));

                        // Hiển thị giá trị tiền giảm trên label thay vì textbox
                        lblTienGiam.Text = tienGiam.ToString();
                        lbThanhToan.Text = tongTienSauGiam.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể chuyển đổi tổng tiền thành số.");
                }
            }
        }
        public void LoadGiamGia()
        {
            cboGiamGia.Items.Clear();
            DateTime today = DateTime.Now;
            foreach (var magiamgia in vcsv.GetAllVouchersv())
            {
                if (magiamgia.NgayKetThuc >= today && magiamgia.DonHangToiThieu <= GetTongTien())
                {
                    string displayText = $"{magiamgia.TiLeGiam}% - {magiamgia.GiamToiDa}đ";
                    cboGiamGia.Items.Add(new KeyValuePair<string, string>(magiamgia.MaVoucher, displayText));
                }
            }
        }

        private double GetTongTien()
        {
            double tongTien;
            if (double.TryParse(lbTongTien.Text, out tongTien))
            {
                return tongTien;
            }
            return 0;
        }

        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDanhSachSP.Rows[e.RowIndex];
                string mahdct;
                var allHoaDonct = hoadonctsv.GetAllHoaDonCtsv();
                int count = allHoaDonct.Count + 1;
                mahdct = "HDCT" + count;
                while (allHoaDonct.Any(x => x.MaHdct == mahdct))
                {
                    count++;
                    mahdct = "HDCT" + count;
                }
                string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng:", "Nhập số lượng");
                if (string.IsNullOrEmpty(input))
                {
                    return; // Kết thúc hàm
                }
                int soLuong;
                if (!int.TryParse(input, out soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0");
                    return;
                }
                int soluongkho = int.Parse(selectedRow.Cells[5].Value.ToString());

                if (soLuong > soluongkho)
                {
                    MessageBox.Show("Số lượng không đủ trong kho");
                    return;
                }
                int IdSp = int.Parse(selectedRow.Cells[0].Value.ToString());
                int tong = soluongkho - soLuong;
                SachChiTiet sachct = new SachChiTiet();
                sachct.SoLuong = tong;
                var success = sachctsv.UpdateSP(IdSp, sachct);
                if (success != null)
                {
                    selectedRow.Cells[5].Value = tong;
                }

                string maSpct = selectedRow.Cells[2].Value.ToString();
                HoaDonCt hdct = new HoaDonCt();
                hdct.MaHdct = mahdct;
                hdct.MaSpct = maSpct;
                hdct.TenSp = selectedRow.Cells[3].Value.ToString();
                hdct.SoLuongMua = soLuong;
                hdct.GiaBan = double.Parse(selectedRow.Cells[8].Value.ToString());
                hdct.ThanhTien = hdct.GiaBan * hdct.SoLuongMua;
                hdct.IdhoaDon = int.Parse(txtidmax.Text);

                hoadonctsv.Update(hdct);

                // Kiểm tra xem Idhoadon có bằng với txtidmax.Text hay không
                int selectedHoaDonId = Convert.ToInt32(txtidmax.Text);
                if (selectedHoaDonId == int.Parse(txtidmax.Text))
                {
                    Loadhdct(selectedHoaDonId);
                }
                LoadSp();
                if (tong == 0)
                {
                    sachsv.CapNhatTrangThaiSach();
                }

                if (tong == 0)
                {
                    MessageBox.Show("Sản phẩm đã hết hàng!");
                    return;
                }
                if (tong < 5)
                {
                    MessageBox.Show("Sản phẩm sắp hết hàng!");
                }

            }
        }

        private void dgvDsHoaDonChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDsHoaDonChiTiet.CurrentRow != null && dgvDsHoaDonChiTiet.CurrentRow.Cells[0].Value != null)
            {
                txtmahd.Text = dgvDsHoaDonChiTiet.CurrentRow.Cells[0].Value.ToString();
                txtMas.Text = dgvDsHoaDonChiTiet.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu hóa đơn thành cônng");
            hoaDonCts.Clear();
            dgvDsHoaDonChiTiet.Rows.Clear();
            LoadHD();
            lbTongTien.Text = "";
            cboGiamGia.Text = "";
            lblTienGiam.Text = "";
            lbThanhToan.Text = "";
            txtTienKhachdua.Text = "";
            lbTienThua.Text = "";
            txtGhiChu.Text = "";
            txtMaKh.Text = "";
            txtTenKH.Text = "";
            //InHoaDon();
        }
        public void LoadSp(string name)
        {
            int index = 0;
            var result = from sct in sachctsv.GetAllSachctsv()
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
                         };

            dgvDanhSachSP.DataSource = result.ToList();
            dgvDanhSachSP.Columns[0].Visible = false;
            dgvDanhSachSP.Columns[1].HeaderText = "STT";
            dgvDanhSachSP.Columns[2].HeaderText = "Mã sách";
            dgvDanhSachSP.Columns[3].HeaderText = "Tiêu đề";
            dgvDanhSachSP.Columns[4].HeaderText = "Hình ảnh";
            dgvDanhSachSP.Columns[5].HeaderText = "Số lượng";
            dgvDanhSachSP.Columns[6].HeaderText = "Tập";
            dgvDanhSachSP.Columns[7].HeaderText = "Số trang";
            dgvDanhSachSP.Columns[8].HeaderText = "Giá bán";

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvDanhSachSP.Columns[4];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadSp(txtTimKiem.Text);
        }
        List<HoaDonCt> hoaDonCts = new List<HoaDonCt>();
        public void Loadhdct(int selectedHoaDonId)
        {
            int STT = 1;
            dgvDsHoaDonChiTiet.Rows.Clear();
            dgvDsHoaDonChiTiet.ColumnCount = 9;
            dgvDsHoaDonChiTiet.Columns[0].Name = "ID";
            dgvDsHoaDonChiTiet.Columns[1].Name = "STT";
            dgvDsHoaDonChiTiet.Columns[2].Name = "MaHDCT";
            dgvDsHoaDonChiTiet.Columns[3].Name = "MaSP";
            dgvDsHoaDonChiTiet.Columns[4].Name = "Tên sách";
            dgvDsHoaDonChiTiet.Columns[5].Name = "Số Lượng";
            dgvDsHoaDonChiTiet.Columns[6].Name = "Giá ";
            dgvDsHoaDonChiTiet.Columns[7].Name = "Thành Tiền";
            dgvDsHoaDonChiTiet.Columns[8].Name = "IDHD";
            dgvDsHoaDonChiTiet.Columns[0].Visible = false;
            dgvDsHoaDonChiTiet.Columns[8].Visible = false;

            var result = from hdct in hoadonctsv.GetAllHoaDonCtsv()
                         join hd in hoadonsv.GetAllHoaDonrv() on hdct.IdhoaDon equals hd.Id
                         where hdct.IdhoaDon == selectedHoaDonId
                         select new
                         {
                             hdct.Id,
                             STT = ++STT,
                             hdct.MaHdct,
                             hdct.MaSpct,
                             hdct.TenSp,
                             hdct.SoLuongMua,
                             hdct.GiaBan,
                             hdct.ThanhTien,
                             hdct.IdhoaDon
                         };

            foreach (var item in result)
            {
                dgvDsHoaDonChiTiet.Rows.Add(item.Id, item.STT, item.MaHdct, item.MaSpct, item.TenSp, item.SoLuongMua, item.GiaBan, item.ThanhTien, item.IdhoaDon);
            }
            TinhTongTien();
        }
        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null && dgvHoaDon.CurrentRow.Cells[0].Value != null)
            {
                if (e.RowIndex >= 0)
                {
                    string idhd = dgvHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtidmax.Text = idhd;

                    // Kiểm tra xem Idhoadon có bằng với txtidmax.Text hay không
                    int selectedHoaDonId = Convert.ToInt32(idhd);
                    if (selectedHoaDonId == int.Parse(txtidmax.Text))
                    {
                        Loadhdct(selectedHoaDonId);
                    }
                }
            }
        }
        FilterInfoCollection camCollection;
        VideoCaptureDevice videoCaptureDevice;
        bool scanning = false;
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (scanning)
            {
                pictureQR.Image = (Bitmap)eventArgs.Frame.Clone();
            }
        }

        private void BanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (scanning && pictureQR.Image != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)pictureQR.Image);
                if (result != null)
                {
                    string decoded = result.Text.Trim();
                    // Tìm kiếm sản phẩm trong database
                    var sanPham = (from sachct in sachctsv.GetAllSachctsv()
                                   join sach in sachsv.GetAllSachsv() on sachct.Idsach equals sach.Id
                                   where string.Equals(sachct.MaSachCt, decoded, StringComparison.OrdinalIgnoreCase)
                                   select new
                                   {
                                       maSachCt = sachct.MaSachCt,
                                       TenSach = sach.TieuDe,
                                       giaban = sachct.GiaBan,
                                       sl = sachct.SoLuong,
                                       idsct = sachct.Id,
                                   }).FirstOrDefault();
                    if (sanPham != null)
                    {
                        string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng:", "Nhập số lượng", "1");
                        if (string.IsNullOrEmpty(input))
                        {
                            return;
                        }

                        int soLuong;
                        if (!int.TryParse(input, out soLuong) || soLuong <= 0)
                        {
                            MessageBox.Show("Số lượng không hợp lệ");
                            return;
                        }

                        int soluongkho = sanPham.sl;
                        if (soLuong > soluongkho)
                        {
                            MessageBox.Show("Số lượng không đủ trong kho");
                            return;
                        }

                        int IdSp = sanPham.idsct;
                        int tong = soluongkho - soLuong;
                        SachChiTiet sachct = new SachChiTiet();
                        sachct.SoLuong = tong;

                        // Cập nhật số lượng mới cho sản phẩm
                        var success = sachctsv.UpdateSP(IdSp, sachct);
                        if (success != null)
                        {
                            // Nếu cập nhật thành công, cập nhật giá trị mới của số lượng
                            soluongkho = tong;
                        }

                        HoaDonCt hdct = new HoaDonCt();
                        hdct.MaHdct = GenerateHoaDonCtId();
                        hdct.MaSpct = sanPham.maSachCt;
                        hdct.TenSp = sanPham.TenSach;
                        hdct.SoLuongMua = soLuong;
                        hdct.GiaBan = sanPham.giaban;
                        hdct.ThanhTien = hdct.GiaBan * hdct.SoLuongMua;
                        hdct.IdhoaDon = int.Parse(txtidmax.Text);
                        hoadonctsv.Update(hdct);

                        // Kiểm tra xem Idhoadon có bằng với txtidmax.Text hay không
                        int selectedHoaDonId = Convert.ToInt32(txtidmax.Text);
                        if (selectedHoaDonId == int.Parse(txtidmax.Text))
                        {
                            Loadhdct(selectedHoaDonId);
                        }
                        LoadSp();
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không tồn tại");
                    }

                    timer1.Stop();
                    scanning = false; // Đặt biến scanning về false để ngăn quét tiếp
                }
            }
        }
        public string GenerateHoaDonCtId()
        {
            string mahdct;
            var allHoaDonct = hoadonctsv.GetAllHoaDonCtsv();
            int count = allHoaDonct.Count + 1;
            mahdct = "HDCT" + count;
            while (allHoaDonct.Any(x => x.MaHdct == mahdct))
            {
                count++;
                mahdct = "HDCT" + count;
            }
            return mahdct; // Trả về mã hóa đơn chi tiết đã được tạo
        }
        private void btnstart_Click_1(object sender, EventArgs e)
        {
            if (!scanning)
            {
                videoCaptureDevice = new VideoCaptureDevice(camCollection[cbocame.SelectedIndex].MonikerString);
                videoCaptureDevice.NewFrame += new AForge.Video.NewFrameEventHandler(VideoCaptureDevice_NewFrame);
                videoCaptureDevice.Start();
                scanning = true;
                timer1.Start();
            }
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoCaptureDevice != null)
                {
                    if (videoCaptureDevice.IsRunning)
                    {
                        videoCaptureDevice.SignalToStop();
                        videoCaptureDevice.WaitForStop();
                        pictureQR.Image = null;
                        videoCaptureDevice = null;
                        scanning = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi dừng camera: " + ex.Message);
            }
        }

        private void txttiengiam_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idh = int.Parse(txtmahd.Text);
            var xoa = MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xoa == DialogResult.Yes)
            {
                string thongbao = hoadonsv.Xoa(idh);
                MessageBox.Show(thongbao);
                LoadHD();
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.TrangThai = "Đã Hủy";
            hoadonsv.suatt(hd, int.Parse(txtidmax.Text));
            LoadHD();
            countClicks++;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
        private void InHoaDon()
        {
            ppdhd.Document = pdhd;
            ppdhd.ShowDialog();
        }
        private void pdhd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var hoadon = hoadonsv.GetAllHoaDonrv().FirstOrDefault(x => x.Id == idwhenClick);
            var kh = khachhangsv.GetAllKhachHangsv().FirstOrDefault(k => k.Id == hoadon.Idkhachhang);
            var nv = nhanviensv.GetAllNhanViensv().FirstOrDefault(n => n.Id == hoadon.Idnhanvien);
            var w = pdhd.DefaultPageSettings.PaperSize.Width;
            //Tên cửa hàng
            string text = "Cửa Hàng bán sách onlybooks";
            Font font = new Font("Times New Roman", 30, FontStyle.Bold);
            Brush brush = Brushes.Black;
            SizeF textSize = e.Graphics.MeasureString(text, font);

            int x = (int)((e.PageBounds.Width - textSize.Width) / 2);
            int y = 20; // Điểm y không thay đổi

            e.Graphics.DrawString(text, font, brush, new PointF(x, y));
            // địa chỉ 
            string address = "Địa chỉ: Số 36 ngõ 322/90 Mỹ Đình, Hà Nội";
            Font addressFont = new Font("Times New Roman", 18, FontStyle.Italic);
            Brush addressBrush = Brushes.Black;
            SizeF addressSize = e.Graphics.MeasureString(address, addressFont);

            int addressX = (int)((e.PageBounds.Width - addressSize.Width) / 2);
            int addressY = 80;
            e.Graphics.DrawString(address, addressFont, addressBrush, new PointF(addressX, addressY));

            // Số điện thoại 
            string phoneNumber = "SĐT: 0779238876";
            Font phoneNumberFont = new Font("Times New Roman", 18);
            Brush phoneNumberBrush = Brushes.Black;
            SizeF phoneNumberSize = e.Graphics.MeasureString(phoneNumber, phoneNumberFont);

            int phoneNumberX = (int)((e.PageBounds.Width - phoneNumberSize.Width) / 2);
            int phoneNumberY = 110;
            e.Graphics.DrawString(phoneNumber, phoneNumberFont, phoneNumberBrush, new PointF(phoneNumberX, phoneNumberY));
            // Tiều đề 
            string tieude = "Hóa Đơn Bán Sách";
            Font tieudeFont = new Font("Times New Roman", 30, FontStyle.Bold);
            Brush tieudeBrush = Brushes.Black;
            SizeF tieudeSize = e.Graphics.MeasureString(tieude, tieudeFont);

            int tieudeX = (int)((e.PageBounds.Width - tieudeSize.Width) / 2);
            int tieudeY = 170;

            e.Graphics.DrawString(tieude, tieudeFont, tieudeBrush, new PointF(tieudeX, tieudeY));
            // Mã Hóa Đơn
            string hdon = "Mã Hóa Đơn: " + (hoadon?.MaHd ?? "");
            Font hdFont = new Font("Times New Roman", 15, FontStyle.Bold);
            Brush hdBrush = Brushes.Black;
            SizeF hdSize = e.Graphics.MeasureString(hdon, hdFont);

            int hdX = (int)((e.PageBounds.Width - hdSize.Width) / 2);
            int hdY = 230; // Điểm y giống với dòng tiêu đề

            e.Graphics.DrawString(hdon, hdFont, hdBrush, new PointF(hdX, hdY));

            // Thời gian
            string currentTime = DateTime.Now.ToString();
            Font timeFont = new Font("Times New Roman", 15, FontStyle.Bold);
            Brush timeBrush = Brushes.Black;
            SizeF timeSize = e.Graphics.MeasureString(currentTime, timeFont);

            int timeX = (int)((e.PageBounds.Width - timeSize.Width) / 2);
            int timeY = hdY + (int)hdSize.Height + 15; // Thêm khoảng cách 20 pixel giữa dòng mã hóa đơn và dòng thời gian

            e.Graphics.DrawString(currentTime, timeFont, timeBrush, new PointF(timeX, timeY));

            // Ngày Mua
            y += 20;
            e.Graphics.DrawString(string.Format("Ngày Mua : {0}", ((DateTime)hoadon.NgayMuaHang).ToString("dd/MM/yyyy HH:mm")),
                new System.Drawing.Font("Times New Roman", 15),
                System.Drawing.Brushes.Black,
                new System.Drawing.Point(40, y + 280));
            e.Graphics.DrawString(string.Format("Tên Khách Hàng : {0}", kh.TenKhachHang),
                new System.Drawing.Font("Times New Roman", 15),
                System.Drawing.Brushes.Black,
                new System.Drawing.Point(40, y + 320));
            e.Graphics.DrawString(string.Format("Tên Nhân Viên : {0}", nv.HoTenNv),
                new System.Drawing.Font("Times New Roman", 15),
                System.Drawing.Brushes.Black,
                new System.Drawing.Point(40, y + 360));
            e.Graphics.DrawString(string.Format("SĐT : {0}", kh.Sđt),
               new System.Drawing.Font("Times New Roman", 15),
               System.Drawing.Brushes.Black,
               new System.Drawing.Point(40, y + 400));
            y += 50;
            // Tính toán kích thước của cột "Tên Sản Phẩm"
            int tenSanPhamWidth = (w / 2) - 50; // Chiều rộng bằng nửa chiều rộng của khổ giấy trừ đi 100 (khoảng cách từ vị trí bắt đầu của cột đến cột "Số Lượng")

            // Vẽ header của bảng và border
            int cellHeight = 40;
            int startX = 40;
            int startY = y + 400;

            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, 60, cellHeight)); // Border STT
            e.Graphics.DrawString("STT", new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(startX, startY));

            startX += 60;
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, tenSanPhamWidth, cellHeight)); // Border Tên Sản Phẩm
            e.Graphics.DrawString("Tên Sản Phẩm", new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(startX, startY));

            startX += tenSanPhamWidth;
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, 100, cellHeight)); // Border Số Lượng
            e.Graphics.DrawString("Số Lượng", new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(startX, startY));

            startX += 100;
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, 100, cellHeight)); // Border Đơn Giá
            e.Graphics.DrawString("Đơn Giá", new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(startX, startY));

            startX += 100;
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, 110, cellHeight)); // Border Thành Tiền
            e.Graphics.DrawString("Thành Tiền", new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(startX, startY));

            int stt = 1;
            y += 20;
            double tongTien = 0;

            // Vẽ các dòng dữ liệu của bảng và border
            foreach (var hct in hoadonctsv.GetAllHoaDonCtsv().Where(c => c.IdhoaDon == idwhenClick))
            {
                var thanhtien = hct.SoLuongMua * hct.GiaBan;
                tongTien += thanhtien;

                // Cập nhật tọa độ y cho dòng tiếp theo
                startY += cellHeight;

                // Vẽ border và in nội dung cho dòng dữ liệu
                startX = 40;
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, 60, cellHeight)); // Border STT
                e.Graphics.DrawString(stt.ToString(), new Font("Times New Roman", 15), Brushes.Black, new Point(startX, startY));

                startX += 60;
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, tenSanPhamWidth, cellHeight)); // Border Tên Sản Phẩm
                e.Graphics.DrawString(hct.TenSp, new Font("Times New Roman", 15), Brushes.Black, new Point(startX, startY));

                startX += tenSanPhamWidth;
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, 100, cellHeight)); // Border Số Lượng
                e.Graphics.DrawString(hct.SoLuongMua.ToString(), new Font("Times New Roman", 15), Brushes.Black, new Point(startX, startY));

                startX += 100;
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, 100, cellHeight)); // Border Đơn Giá
                e.Graphics.DrawString(hct.GiaBan.ToString(), new Font("Times New Roman", 15), Brushes.Black, new Point(startX, startY));

                startX += 100;
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, 110, cellHeight)); // Border Thành Tiền
                e.Graphics.DrawString(thanhtien.ToString(), new Font("Times New Roman", 15), Brushes.Black, new Point(startX, startY));

                stt++;
                y += cellHeight;
            }

            y += 60;
            e.Graphics.DrawString(string.Format("Tổng tiền: {0} VNĐ", tongTien), new System.Drawing.Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(40, y + 400));
            y += 30;
            e.Graphics.DrawString(string.Format("Giảm giá: {0} VNĐ", hoadon.GiamGia), new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(40, y + 400));
            y += 30;
            double thanhToan = tongTien - hoadon.GiamGia.GetValueOrDefault();
            e.Graphics.DrawString(string.Format("Thanh toán: {0} VNĐ", thanhToan), new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(40, y + 400));
            y += 30;
            string inputText = txtTienKhachdua.Text.Trim();
            double tienKhachDua;
            if (string.IsNullOrWhiteSpace(inputText))
            {
                tienKhachDua = 0;
            }
            else
            {
                if (!double.TryParse(inputText, out tienKhachDua))
                {
                    return;
                }
            }
            e.Graphics.DrawString(string.Format("Tiền mặt: {0} VNĐ", tienKhachDua), new Font("Times New Roman", 15), Brushes.Black, new Point(40, y + 400));

            y += 30;
            double tienThua;
            if (double.TryParse(lbTienThua.Text, out tienThua))
            {
                e.Graphics.DrawString(string.Format("Tiền thừa: {0} VNĐ", tienThua), new Font("Times New Roman", 15), Brushes.Black, new Point(40, y + 400));
            }
            y += 50;
            int xThankYou = e.PageBounds.Width - 500;
            int yThankYou = y + 400;

            // Vẽ lời cảm ơn
            e.Graphics.DrawString("Xin chân thành cảm ơn sự ủng hộ của quý khách!", new Font("Times New Roman", 15, FontStyle.Italic | FontStyle.Bold), Brushes.Black, new Point(xThankYou, yThankYou));
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
                    LoadSp();
                    break;
                default:
                    break;
            }
        }
        private void FilterProductsByPrice(int minPrice, int maxPrice)
        {
            int index = 0;
            var result = from sct in sachctsv.GetAllSachctsv()
                         join s in sachsv.GetAllSachsv() on sct.Idsach equals s.Id
                         where sct.SoLuong != 0 && sct.GiaBan >= minPrice && sct.GiaBan <= maxPrice
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
                         };

            dgvDanhSachSP.DataSource = result.ToList();
            dgvDanhSachSP.Columns[0].Visible = false;
            dgvDanhSachSP.Columns[1].HeaderText = "STT";
            dgvDanhSachSP.Columns[2].HeaderText = "Mã sách";
            dgvDanhSachSP.Columns[3].HeaderText = "Tiêu đề";
            dgvDanhSachSP.Columns[4].HeaderText = "Hình ảnh";
            dgvDanhSachSP.Columns[5].HeaderText = "Số lượng";
            dgvDanhSachSP.Columns[6].HeaderText = "Tập";
            dgvDanhSachSP.Columns[7].HeaderText = "Số trang";
            dgvDanhSachSP.Columns[8].HeaderText = "Giá bán";

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvDanhSachSP.Columns[4];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
    }
}
