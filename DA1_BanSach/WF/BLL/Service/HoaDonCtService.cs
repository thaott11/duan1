using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.BLL.Service
{
    public class HoaDonCtService
    {
        HoaDonCtReposistoris HoaDonCtReposistoris = new HoaDonCtReposistoris();
        public List<HoaDonCt> GetAllHoaDonCtsv()
        {
            return HoaDonCtReposistoris.GetAllHoaDonct();
        }
        public void Them(HoaDonCt hoadonct)
        {
            HoaDonCtReposistoris.Them(hoadonct);
        }

       
        public string Xoa(int id)
        {
            if (HoaDonCtReposistoris.Xoa(id))
            {
                return "Xóa Thành công ";
            }
            else
            {
                return "Xóa thất bại";
            }
        }
        public void Update(HoaDonCt hdct)
        {
            HoaDonCtReposistoris.Update(hdct);
        }
        public HoaDonCt GetHoaDonCtByMaSpctAndIdHoaDon(string maSpct, int idHoaDon)
        {
            return HoaDonCtReposistoris.GetHoaDonCtByMaSpctAndIdHoaDon(maSpct, idHoaDon);
        }
    }
}
