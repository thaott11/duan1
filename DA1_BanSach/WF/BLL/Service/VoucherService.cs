using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace WF.BLL.Service
{
    public class VoucherService
    {
        VoucherReposistoris vcstr = new VoucherReposistoris();
        public List<Voucher> GetAllVouchersv()
        {
            return vcstr.GetAllVoucherstr();
        }

        public string Them(Voucher vc)
        {
            if (vcstr.Them(vc))
            {
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }
        public string sua(Voucher vc, int id)
        {
            if (vcstr.Sua(vc, id))
            {
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public double GetTiLeGiamGia(string maGiamGia)
        {
            // Gọi phương thức từ repository để lấy tỉ lệ giảm giá từ cơ sở dữ liệu
            return vcstr.GetTiLeGiamGia(maGiamGia);
        }
        public double GetGiamToiDa(string maGiamGia)
        {
            return vcstr.GetGiamToiDa(maGiamGia);
        }
        public List<Voucher> TimkiemMa(string ma)
        {
            return vcstr.FindMa(ma);
        }
        public void UpdateMaGiamGia(Voucher voucher)
        {
            vcstr.UpdateMaGiamGia(voucher);
        }
    }
}
