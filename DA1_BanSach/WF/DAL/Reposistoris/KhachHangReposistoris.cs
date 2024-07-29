using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;

namespace WF.DAL.Reposistoris
{
    public class KhachHangReposistoris
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public List<KhachHang> GetAllKhachHangstr()
        {
            return db.KhachHangs.ToList();
        }

        public bool Them(KhachHang kh)
        {
            db.KhachHangs.Add(kh);
            db.SaveChanges();
            return true;
        }

        public bool Sua(KhachHang kh , int id)
        {
            var sua = db.KhachHangs.FirstOrDefault(x => x.Id == id);
            sua.MaKhachHang = kh.MaKhachHang;
            sua.TenKhachHang = kh.TenKhachHang;
            sua.GioiTinh = kh.GioiTinh;
            sua.Sđt = kh.Sđt;
            sua.DiaChi = kh.DiaChi;
            db.KhachHangs.Update(sua);
            db.SaveChanges();
            return true;
        }

        public List<KhachHang> FindName(string name)
        {
            return db.KhachHangs.Where(x => x.TenKhachHang.ToLower().Contains(name.ToLower())).ToList();
        }
        public List<KhachHang> FindMa(string name)
        {
            return db.KhachHangs.Where(x => x.MaKhachHang.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
