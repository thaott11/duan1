using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;

namespace WF.DAL.Reposistoris
{
    public class taikhoanReposistoris
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public List<NhanVien> GetTaiKhoan()
        {
            return db.NhanViens.ToList();
        }
        public NhanVien TaiKhoan(string taikhoan, string matkhau)
        {
            return db.NhanViens.FirstOrDefault(u => u.TenTk == taikhoan && u.MatKhau == matkhau);
        }
    }
}
