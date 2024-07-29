using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;
using WF.Form_Chức_Năng.Form_Chức_Năng___ADMIN;

namespace WF.BLL.Service
{
    public class SachCtService
    { 
        SachCtReposistoris SachCtReposistoris = new SachCtReposistoris();
        public List<SachChiTiet> GetAllSachctsv()
        {
            return SachCtReposistoris.GetAllSachctstr();
        }
        public string Them(SachChiTiet sachct)
        {
            if (SachCtReposistoris.Them(sachct))
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }
        public string Sua(SachChiTiet sachct , int id)
        {
            if (SachCtReposistoris.Sua(sachct , id))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public SachChiTiet Findid(int id)
        {
            return SachCtReposistoris.Findid(id);
        }
        public string UpdateSP(int id, SachChiTiet sachct)
        {
            SachCtReposistoris.UpdateSanPham(id, sachct);
            return "Thêm thành công";
        }
        public string updateSL(string masct, int sl)
        {
            SachChiTiet upSPCT = SachCtReposistoris.findbyID(masct);
            upSPCT.SoLuong = sl;
            if (SachCtReposistoris.UpdateSPCTRes(upSPCT))
            {
                return "Cap nhat so luong thanh cong";
            }
            else
            {
                return "Cap nhat so luong that bai";
            }
        }
        public void ThemTheLoai(string tenTheLoai)
        {
            SachCtReposistoris.ThemTheLoai(tenTheLoai);
        }
    }
}
