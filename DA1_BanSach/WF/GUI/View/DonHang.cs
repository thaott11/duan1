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

namespace WF.Form_Chức_Năng.Form_Chức_Năng___NhanVien
{
    public partial class DonHang : Form
    {
        public DonHang()
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
        private void DonHang_Load(object sender, EventArgs e)
        {
            vcsv = new VoucherService();
            khachhangsv = new KhachHangService();
            nhanviensv = new NhanVienService();
            hoadonsv = new HoaDonService();
            sachsv = new SachService();
            sachctsv = new SachCtService();
            hoadonctsv = new HoaDonCtService();
            LoadHD();
        }
        public void LoadHD()
        {
            int STT = 1;
            dgvHoaDon.Rows.Clear();
            dgvHoaDon.ColumnCount = 8;
            dgvHoaDon.Columns[0].Name = "ID";
            dgvHoaDon.Columns[1].Name = "STT";
            dgvHoaDon.Columns[2].Name = "Mã HD";
            dgvHoaDon.Columns[3].Name = "Tên NV";
            dgvHoaDon.Columns[4].Name = "Tên KH";
            dgvHoaDon.Columns[5].Name = "Ngày tạo";
            dgvHoaDon.Columns[6].Name = "Trạng thái";
            dgvHoaDon.Columns[7].Name = "Mã KH";

            dgvHoaDon.Columns[7].Visible = false;
            dgvHoaDon.Columns[0].Visible = false;

            foreach (var item in hoadonsv.GetAllHoaDonrv())
            {
                var nv = nhanviensv.GetAllNhanViensv().FirstOrDefault(x => x.Id == item.Idnhanvien);
                var kh = khachhangsv.GetAllKhachHangsv().FirstOrDefault(x => x.Id == item.Idkhachhang);
                if (nv != null && kh != null && item.TrangThai == "Đã thanh toán")
                {
                    dgvHoaDon.Rows.Add(item.Id, STT++, item.MaHd, nv.HoTenNv, kh.TenKhachHang, item.NgayMuaHang, item.TrangThai, kh.MaKhachHang);
                }
            }
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dgvHoaDon.Rows.Count)
            {
                int index = 0;
                var selectedHoaDonId = dgvHoaDon.Rows[rowIndex].Cells[0].Value;
                if (selectedHoaDonId != null)
                {
                    var result = from hdct in hoadonctsv.GetAllHoaDonCtsv()
                                 join hd in hoadonsv.GetAllHoaDonrv() on hdct.IdhoaDon equals hd.Id
                                 where hdct.IdhoaDon == (int)selectedHoaDonId
                                 select new
                                 {
                                     hdct.Id,
                                     STT = ++index,
                                     hdct.MaHdct,
                                     hdct.MaSpct,
                                     hdct.TenSp,
                                     hdct.SoLuongMua,
                                     hdct.GiaBan,
                                     hdct.ThanhTien,
                                     hdct.IdhoaDon
                                 };

                    dgvHoaDonChiTiet.DataSource = result.ToList();
                    dgvHoaDonChiTiet.Columns[0].Visible = false;
                    dgvHoaDonChiTiet.Columns[1].HeaderText = "STT";
                    dgvHoaDonChiTiet.Columns[2].HeaderText = "MaHDCT";
                    dgvHoaDonChiTiet.Columns[3].HeaderText = "MaSP";
                    dgvHoaDonChiTiet.Columns[4].HeaderText = "Tên sách";
                    dgvHoaDonChiTiet.Columns[5].HeaderText = "Số Lượng";
                    dgvHoaDonChiTiet.Columns[6].HeaderText = "Giá ";
                    dgvHoaDonChiTiet.Columns[7].HeaderText = "Thành Tiền";
                    dgvHoaDonChiTiet.Columns[8].HeaderText = "IDHD";
                    dgvHoaDonChiTiet.Columns[8].Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtptungay.Value.Date;
            DateTime ngayKetThuc = dtpdenngay.Value.Date.AddDays(1).AddSeconds(-1);
            LoadHD(ngayBatDau, ngayKetThuc);
        }
        public void LoadHD(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            int STT = 1;
            dgvHoaDon.Rows.Clear();
            dgvHoaDon.ColumnCount = 8;
            dgvHoaDon.Columns[0].Name = "ID";
            dgvHoaDon.Columns[1].Name = "STT";
            dgvHoaDon.Columns[2].Name = "Mã HD";
            dgvHoaDon.Columns[3].Name = "Tên NV";
            dgvHoaDon.Columns[4].Name = "Tên KH";
            dgvHoaDon.Columns[5].Name = "Ngày tạo";
            dgvHoaDon.Columns[6].Name = "Trạng thái";
            dgvHoaDon.Columns[7].Name = "Mã KH";

            dgvHoaDon.Columns[7].Visible = false;
            dgvHoaDon.Columns[0].Visible = false;

            var query = from hd in hoadonsv.GetAllHoaDonrv()
                        join nv in nhanviensv.GetAllNhanViensv() on hd.Idnhanvien equals nv.Id
                        join kh in khachhangsv.GetAllKhachHangsv() on hd.Idkhachhang equals kh.Id
                        where hd.TrangThai == "Đã thanh toán" && hd.NgayMuaHang >= ngayBatDau && hd.NgayMuaHang <= ngayKetThuc
                        select new
                        {
                            hd.Id,
                            hd.MaHd,
                            nv.HoTenNv,
                            kh.TenKhachHang,
                            hd.NgayMuaHang,
                            hd.TrangThai,
                            kh.MaKhachHang
                        };

            foreach (var item in query)
            {
                dgvHoaDon.Rows.Add(item.Id, STT++, item.MaHd, item.HoTenNv, item.TenKhachHang, item.NgayMuaHang, item.TrangThai, item.MaKhachHang);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadHD();
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
            y += 50;
            int xThankYou = e.PageBounds.Width - 500;
            int yThankYou = y + 400;
            e.Graphics.DrawString("Xin chân thành cảm ơn sự ủng hộ của quý khách!", new Font("Times New Roman", 15, FontStyle.Italic | FontStyle.Bold), Brushes.Black, new Point(xThankYou, yThankYou));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InHoaDon();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null && dgvHoaDon.CurrentRow.Cells[0].Value != null)
            {
                idwhenClick = int.Parse(dgvHoaDon.CurrentRow.Cells[0].Value.ToString());
            }
        }
    }
}
