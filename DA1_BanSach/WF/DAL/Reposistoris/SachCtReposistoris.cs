using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN;

namespace WF.DAL.Reposistoris
{
    public class SachCtReposistoris
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public List<SachChiTiet> GetAllSachctstr()
        {
            return db.SachChiTiets.ToList();
        }
        public bool Them(SachChiTiet sachct)
        {
            db.SachChiTiets.Add(sachct);
            db.SaveChanges();
            return true;
        }
        public bool Sua(SachChiTiet sachct, int id)
        {
            var sct = db.SachChiTiets.FirstOrDefault(s => s.Id == id);
            sct.Idsach = sachct.Idsach;
            sct.SoLuong = sachct.SoLuong;
            sct.Tap = sachct.Tap;
            sct.SoTrang = sachct.SoTrang;
            sct.GiaBan = sachct.GiaBan;
            sct.MaSachCt = sachct.MaSachCt;
            sct.Idnxb = sachct.Idnxb;
            sct.TenTheLoai = sachct.TenTheLoai;
            sct.HinhAnh = sachct.HinhAnh;
            db.SachChiTiets.Update(sct);
            db.SaveChanges();
            return true;
        }
        public bool UpdateSanPham(int id, SachChiTiet sachct)
        {
            var update = db.SachChiTiets.FirstOrDefault(x => x.Id == id);
            update.SoLuong = sachct.SoLuong;
            db.SachChiTiets.Update(update);
            db.SaveChanges();
            return true;
        }
        public List<Sach> FindName(string name)
        {
            return db.Saches.Where(x => x.TieuDe.ToLower().Contains(name.ToLower())).ToList();
        }
        public SachChiTiet Findid(int id)
        {
            return db.SachChiTiets.FirstOrDefault(x => x.Id == id);
        }
        public bool UpdateSPCTRes(SachChiTiet sct)
        {
            if (sct != null)
            {
                db.SachChiTiets.Update(sct);
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
        public SachChiTiet findbyID(string masct)
        {
            return db.SachChiTiets.FirstOrDefault(x => x.MaSachCt == masct);
        }
        public void ThemTheLoai(string tenTheLoai)
        {
            // Kiểm tra xem tên thể loại đã tồn tại trong cơ sở dữ liệu chưa
            if (!db.SachChiTiets.Any(t => t.TenTheLoai == tenTheLoai))
            {
                SachChiTiet theLoai = new SachChiTiet();
                theLoai.TenTheLoai = tenTheLoai;

                // Thêm thể loại mới vào DbSet và lưu thay đổi vào cơ sở dữ liệu
                db.SachChiTiets.Add(theLoai);
                db.SaveChanges();
            }
        }
    } 
}
