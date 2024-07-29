using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.BLL.Service
{
    public class NhaXBService
    {
        NhaXBReposistoris NhaXBReposistoris = new NhaXBReposistoris();
        public List<NhaXuatBan> GetAllNXBsv()
        {
            return NhaXBReposistoris.GetAllSachstr();
        }
        public string Them(NhaXuatBan nhaXuatBan)
        {
            if (NhaXBReposistoris.Them(nhaXuatBan))
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }

        public string sua(NhaXuatBan nhaxuatban, int id)
        {
            if (NhaXBReposistoris.Sua(nhaxuatban, id))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public List<NhaXuatBan> FindName(string name)
        {
            return NhaXBReposistoris.FindName(name);
        }
    }
}
