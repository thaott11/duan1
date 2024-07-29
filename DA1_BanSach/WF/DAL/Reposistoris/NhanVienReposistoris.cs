using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;

namespace WF.DAL.Reposistoris
{
    public class NhanVienReposistoris
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public List<NhanVien> GetAllNhanVienstr()
        {
            return db.NhanViens.ToList();
        }

        public bool Them(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
            return true;
        }
        public bool Sua(NhanVien nv, int id)
        {
            var sua = db.NhanViens.FirstOrDefault(x => x.Id == id);
            sua.MaNv = nv.MaNv;
            sua.HoTenNv = nv.HoTenNv;
            sua.Cccd = nv.Cccd;
            sua.NgaySinh = nv.NgaySinh;
            sua.GioiTinh = nv.GioiTinh;
            sua.Email = nv.Email;
            sua.Sđt = nv.Sđt;
            sua.VaiTro = nv.VaiTro;
            sua.TenTk = nv.TenTk;
            sua.MatKhau = nv.MatKhau;
            sua.DiaChi = nv.DiaChi;
            sua.TrangThai = nv.TrangThai;
            sua.Hinh = nv .Hinh;
            db.NhanViens.Update(sua);
            db.SaveChanges();
            return true;
        }
        public List<NhanVien> FindName(string name)
        {
            return db.NhanViens.Where(x => x.HoTenNv.ToLower().Contains(name.ToLower())).ToList();
        }

        public NhanVien Findid(int id)
        {
            return db.NhanViens.FirstOrDefault(x => x.Id == id);
        }
    }
}
