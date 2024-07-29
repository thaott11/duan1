using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;

namespace WF.DAL.Reposistoris
{
    public class HoaDonReposistoris
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public List<HoaDon> GetAllHoaDonstr()
        {
            return db.HoaDons.ToList();
        }

        public bool Them(HoaDon hoaDon)
        {
            db.HoaDons.Add(hoaDon);
            db.SaveChanges();
            return true;
        }
        public bool Sua(HoaDon hoaDon, int id)
        {
            var sua = db.HoaDons.FirstOrDefault(x  => x.Id == id);
            sua.Idkhachhang = hoaDon.Idkhachhang;
            db.HoaDons.Update(sua);
            db.SaveChanges();
            return true;
        }
        public bool suatt(HoaDon hoaDon, int id)
        {
            var sua = db.HoaDons.FirstOrDefault(x => x.Id == id);
            sua.TrangThai = hoaDon.TrangThai;
            db.HoaDons.Update(sua);
            db.SaveChanges();
            return true;
        }
        public bool Xoa(int id)
        {
            var xoa = db.HoaDons.FirstOrDefault(x => x.Id == id);
            db.HoaDons.Remove(xoa);
            db.SaveChanges();
            return true;
        }
        public bool suagiamgia(HoaDon hoaDon, int id)
        {
            var sua = db.HoaDons.FirstOrDefault(x => x.Id == id);
            sua.GiamGia = hoaDon.GiamGia;
            db.HoaDons.Update(sua);
            db.SaveChanges();
            return true;
        }
    }
}
