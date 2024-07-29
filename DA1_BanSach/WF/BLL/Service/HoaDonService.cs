using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.BLL.Service
{
    public class HoaDonService
    {
        HoaDonReposistoris HoaDonReposistoris = new HoaDonReposistoris();
        public List<HoaDon> GetAllHoaDonrv()
        {
            return HoaDonReposistoris.GetAllHoaDonstr();
        }
        public void Them(HoaDon hoadon)
        {
            HoaDonReposistoris.Them(hoadon);
        }
        public string Sua(HoaDon hoadon , int id)
        {
            HoaDonReposistoris.Sua(hoadon, id);
            return "Sửa thành công";
        }

        public string suatt(HoaDon hoadon, int id)
        {
            HoaDonReposistoris.suatt(hoadon, id);
            return "Sửa thành công";
        }
        public string Xoa(int id)
        {
            HoaDonReposistoris.Xoa( id);
            return "Xóa thành công";
        }
        public void suagiamgia(HoaDon hoadon, int id)
        {
            HoaDonReposistoris.suagiamgia(hoadon, id);
        }
    }
}
