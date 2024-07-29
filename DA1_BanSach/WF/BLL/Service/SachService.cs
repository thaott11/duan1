using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.BLL.Service
{
    public class SachService
    {
        SachReposistoris SachReposistoris = new SachReposistoris();
        public List<Sach> GetAllSachsv()
        {
            return SachReposistoris.GetAllSachstr();
        }

        public string Them(Sach sach)
        {
            if (SachReposistoris.Them(sach))
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }

        public string sua(Sach sach, int id)
        {
            if (SachReposistoris.Sua(sach ,id))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public List<Sach> FindName(string name)
        {
            return SachReposistoris.FindName(name);
        }
        public void CapNhatTrangThaiSach()
        {
            SachReposistoris.CapNhatTrangThaiSach();
        }
        public void CapNhatTrangThaiSachConHang()
        {
            SachReposistoris.CapNhatTrangThaiSachConHang();
        }
    }
}
