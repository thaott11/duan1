using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.BLL.Service
{
    public class NhanVienService
    {
        NhanVienReposistoris NhanVienReposistoris = new NhanVienReposistoris();
        public List<NhanVien> GetAllNhanViensv()
        {
            return NhanVienReposistoris.GetAllNhanVienstr();
        }
        public string Them(NhanVien nv)
        {
            if (NhanVienReposistoris.Them(nv))
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }
        public string sua(NhanVien nv, int id)
        {
            if (NhanVienReposistoris.Sua(nv, id))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }

        public List<NhanVien> FindName(string name)
        {
            return NhanVienReposistoris.FindName(name);
        }
        public NhanVien Findid(int id) 
        {
            return NhanVienReposistoris.Findid(id);
        }
    }
}
