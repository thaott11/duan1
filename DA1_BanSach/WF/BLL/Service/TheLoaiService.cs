using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.BLL.Service
{
    public class TheLoaiService
    {
        TheLoaiReposistoris TheLoaiReposistoris = new TheLoaiReposistoris();
        public List<TheLoai> GetAllTheLoaisv()
        {
            return TheLoaiReposistoris.GetAllTheLoaistr();
        }
        public string Them(TheLoai tl)
        {
            if (TheLoaiReposistoris.Them(tl))
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }

        public string sua(TheLoai tl, int id)
        {
            if (TheLoaiReposistoris.Sua(tl, id))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public List<TheLoai> FindName(string name)
        {
            return TheLoaiReposistoris.FindName(name);
        }
        public List<string> getItemsFromDatabase()
        {
            return TheLoaiReposistoris.GetItemsFromDatabase();
        }
    }
}
