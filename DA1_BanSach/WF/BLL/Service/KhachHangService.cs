using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.BLL.Service
{
    public class KhachHangService
    {
        KhachHangReposistoris KhachHangReposistoris = new KhachHangReposistoris();
        public List<KhachHang> GetAllKhachHangsv()
        {
            return KhachHangReposistoris.GetAllKhachHangstr();
        }

        public string Them(KhachHang kh)
        {
            if (KhachHangReposistoris.Them(kh))
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }
        public string sua(KhachHang kh, int id)
        {
            if (KhachHangReposistoris.Sua(kh, id))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }

        public List<KhachHang> FindName(string name)
        {
            return KhachHangReposistoris.FindName(name);
        }
        public List<KhachHang> FindMa(string name)
        {
            return KhachHangReposistoris.FindMa(name);
        }
    }
}
