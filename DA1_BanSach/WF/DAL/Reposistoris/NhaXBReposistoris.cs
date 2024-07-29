using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;

namespace WF.DAL.Reposistoris
{
    public class NhaXBReposistoris
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public List<NhaXuatBan> GetAllSachstr()
        {
            return db.NhaXuatBans.ToList();
        }
        public bool Them(NhaXuatBan nhaXuatBan)
        {
            db.NhaXuatBans.Add(nhaXuatBan);
            db.SaveChanges();
            return true;
        }
        public bool Sua(NhaXuatBan nhaxuatban, int id)
        {
            var nxb = db.NhaXuatBans.FirstOrDefault(x => x.Id == id);
            nxb.MaNxb = nhaxuatban.MaNxb;
            nxb.TenNxb = nhaxuatban.TenNxb;
            nxb.DiaChi = nhaxuatban.DiaChi;
            nxb.NamXb = nhaxuatban.NamXb;
            nxb.TrangThai = nhaxuatban.TrangThai;
            nxb.Sđt = nhaxuatban.Sđt;
            db.NhaXuatBans.Update(nxb);
            db.SaveChanges();
            return true;
        }

        public List<NhaXuatBan> FindName(string name)
        {
            return db.NhaXuatBans.Where(x => x.TenNxb.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
