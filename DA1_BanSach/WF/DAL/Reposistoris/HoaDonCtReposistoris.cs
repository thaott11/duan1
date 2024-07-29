using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;

namespace WF.DAL.Reposistoris
{
    public class HoaDonCtReposistoris
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public List<HoaDonCt> GetAllHoaDonct()
        {
            return db.HoaDonCts.ToList();
        }
        public bool Them(HoaDonCt hoadonct)
        {
            db.HoaDonCts.Add(hoadonct);
            db.SaveChanges();
            return true;
        }
        public bool Xoa(int id)
        {
            var XemayDelete = db.HoaDonCts.FirstOrDefault(x => x.Id == id);
            if (XemayDelete == null)
            {
                return false;
            }
            db.HoaDonCts.Remove(XemayDelete);
            db.SaveChanges();
            return true;
        }
        public void Update(HoaDonCt hoadonct)
        {
            var existingHdct = db.HoaDonCts.FirstOrDefault(x => x.MaSpct == hoadonct.MaSpct && x.IdhoaDon == hoadonct.IdhoaDon);

            if (existingHdct != null)
            {
                existingHdct.SoLuongMua += hoadonct.SoLuongMua;
                existingHdct.ThanhTien += hoadonct.ThanhTien;
            }
            else
            {
                db.HoaDonCts.Add(hoadonct);
            }
            db.SaveChanges();
        }

        public HoaDonCt GetHoaDonCtByMaSpctAndIdHoaDon(string maSpct, int idHoaDon)
        {
            // Truy vấn từ database để lấy chi tiết hóa đơn với mã sản phẩm và Id hóa đơn tương ứng
            return db.HoaDonCts.FirstOrDefault(x => x.MaSpct == maSpct && x.IdhoaDon == idHoaDon);
        }
    }
}
