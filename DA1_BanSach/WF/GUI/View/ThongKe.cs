using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml;
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

namespace WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();

        }
        HoaDonCtService hoadonctsv;
        SachCtService sachctsv;
        HoaDonService hdsv;
        SachService sachsv;
        private void ThongKe_Load(object sender, EventArgs e)
        {
            hoadonctsv = new HoaDonCtService();
            hdsv = new HoaDonService();
            sachctsv = new SachCtService();
            sachsv = new SachService();

        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtptungay.Value.Date; // Lấy chỉ ngày, loại bỏ thông tin về giờ, phút và giây
            DateTime ngayKetThuc = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Lấy ngày kết thúc và đặt giờ, phút và giây về 23:59:59

            //Tổng doanh thu
            var tongDoanhThu = (from hct in hoadonctsv.GetAllHoaDonCtsv()
                                join hd in hdsv.GetAllHoaDonrv() on hct.IdhoaDon equals hd.Id
                                where hd.NgayMuaHang >= ngayBatDau && hd.NgayMuaHang <= ngayKetThuc
                                select hct.ThanhTien).Sum();

            //Tổng sản phẩm
            var tongsanpham = (from hct in hoadonctsv.GetAllHoaDonCtsv()
                               join hd in hdsv.GetAllHoaDonrv() on hct.IdhoaDon equals hd.Id
                               where hd.NgayMuaHang >= ngayBatDau && hd.NgayMuaHang <= ngayKetThuc
                               select hct.SoLuongMua).Sum();
            //Tổng số đơn hàng 
            var tongSoDonh = (from hd in hdsv.GetAllHoaDonrv()
                              where hd.NgayMuaHang >= ngayBatDau && hd.NgayMuaHang <= ngayKetThuc
                              select hd).Count();

            //Hiển thị lên lable
            lbdoanhthu.Text = tongDoanhThu.ToString();
            lbspban.Text = tongsanpham.ToString();
            lbtongdonhang.Text = tongSoDonh.ToString();
            ThongKeSanPhamBanChay(ngayBatDau, ngayKetThuc);
            ThongKeSanPhamSapHetHang(ngayBatDau, ngayKetThuc);
        }
        public void ThongKeSanPhamBanChay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            int index = 0;
            var thongKeSanPham = (from hct in hoadonctsv.GetAllHoaDonCtsv()
                                  join hd in hdsv.GetAllHoaDonrv() on hct.IdhoaDon equals hd.Id
                                  where hd.NgayMuaHang >= ngayBatDau && hd.NgayMuaHang <= ngayKetThuc
                                  group hct by hct.MaSpct into g
                                  select new
                                  {
                                      MaSanPham = g.Key,
                                      TenSP = g.Select(x => x.TenSp).FirstOrDefault(),
                                      GiaBan = g.Select(x => x.GiaBan).FirstOrDefault(),
                                      SoLuotMua = g.Sum(x => x.SoLuongMua),
                                      TongTien = g.Sum(x => x.SoLuongMua * x.GiaBan),
                                  }).OrderByDescending(x => x.SoLuotMua).ToList();

            dgvBanChay.DataSource = thongKeSanPham;
            dgvBanChay.Columns[0].HeaderText = "Mã sách";
            dgvBanChay.Columns[1].HeaderText = "Tên SP";
            dgvBanChay.Columns[2].HeaderText = "Giá bán";
            dgvBanChay.Columns[3].HeaderText = "Số lượt mua";
            dgvBanChay.Columns[4].HeaderText = "Tổng tiền";
        }
        public void ThongKeSanPhamSapHetHang(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            try
            {
                int index = 0;
                var result = from sct in sachctsv.GetAllSachctsv()
                             join s in sachsv.GetAllSachsv() on sct.Idsach equals s.Id
                             where sct.SoLuong < 10
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
                                 sct.GiaBan
                             };

                dgvsaphethang.DataSource = result.ToList();
                dgvsaphethang.Columns[0].Visible = false;
                dgvsaphethang.Columns[1].HeaderText = "STT";
                dgvsaphethang.Columns[2].HeaderText = "Mã sách";
                dgvsaphethang.Columns[3].HeaderText = "Tiêu đề";
                dgvsaphethang.Columns[4].HeaderText = "Hình ảnh";
                dgvsaphethang.Columns[5].HeaderText = "Số lượng";
                dgvsaphethang.Columns[6].HeaderText = "Tập";
                dgvsaphethang.Columns[7].HeaderText = "Số trang";
                dgvsaphethang.Columns[8].HeaderText = "Giá bán";

                DataGridViewImageColumn pic = new DataGridViewImageColumn();
                pic = (DataGridViewImageColumn)dgvsaphethang.Columns[4];
                pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void export_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                try
                {
                    senderexcel(filePath);
                    MessageBox.Show("Xuất File Excel Thành công");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Xuất File Excel không  Thành công" + ex.Message);
                }
            }
        }
        private void senderexcel(string path)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                // đặt tên người tạo file
                p.Workbook.Properties.Author = "";

                // đặt tiêu đề cho file
                p.Workbook.Properties.Title = "Báo cáo thống kê";

                //Tạo một sheet để làm việc trên đó
                ExcelWorksheet ws = p.Workbook.Worksheets.Add("Sheet1");

                // fontsize mặc định cho cả sheet
                ws.Cells.Style.Font.Size = 11;
                // font family mặc định cho cả sheet
                ws.Cells.Style.Font.Name = "Calibri";

                // Ghi tiêu đề cho từng cột
                for (int i = 0; i < dgvBanChay.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1].Value = dgvBanChay.Columns[i].HeaderText;
                }

                // Ghi dữ liệu từ DataGridView vào file Excel
                for (int i = 0; i < dgvBanChay.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvBanChay.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = dgvBanChay.Rows[i].Cells[j].Value;
                    }
                }

                //Lưu file lại
                FileInfo excelFile = new FileInfo(path);
                p.SaveAs(excelFile);
            }
        }

    }
}
