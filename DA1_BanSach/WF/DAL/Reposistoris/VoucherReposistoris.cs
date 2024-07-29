using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WF.DAL.Models;

namespace WF.DAL.Reposistoris
{
    public class VoucherReposistoris
    {
        QuanLyBanSachContext db = new QuanLyBanSachContext();
        public List<Voucher> GetAllVoucherstr()
        {
            return db.Vouchers.ToList();
        }

        public bool Them(Voucher vc)
        {
            try
            {
                db.Vouchers.Add(vc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Sua(Voucher vc , int id)
        {
            var sua = db.Vouchers.SingleOrDefault(x => x.Id == id);
            sua.MaVoucher = vc.MaVoucher;
            sua.NgayBatDau = vc.NgayBatDau;
            sua.NgayKetThuc = vc.NgayKetThuc;
            sua.TiLeGiam = vc.TiLeGiam;
            sua.DonHangToiThieu = vc.DonHangToiThieu;
            sua.GiamToiDa = vc.GiamToiDa;
            sua.SoLuong = vc .SoLuong;
            db.Vouchers.Update(sua);
            db.SaveChanges();
            return true;
        }
        public double GetTiLeGiamGia(string maGiamGia)
        {
            // Thực hiện truy vấn từ cơ sở dữ liệu để lấy tỉ lệ giảm giá
            Voucher voucher = db.Vouchers.FirstOrDefault(x => x.MaVoucher == maGiamGia);
            if (voucher != null)
            {
                return voucher.TiLeGiam;
            }
            return 0;
        }
        public double GetGiamToiDa(string maGiamGia)
        {
            using (var context = new QuanLyBanSachContext())
            {
                var voucher = context.Vouchers.FirstOrDefault(v => v.MaVoucher == maGiamGia);
                if (voucher != null)
                {
                    return voucher.GiamToiDa;
                }
            }
            return 0; 
        }
        public List<Voucher> FindMa(string ma)
        {
            return db.Vouchers.Where(x => x.MaVoucher.ToLower().Contains(ma.ToLower())).ToList();
        }
        public void UpdateMaGiamGia(Voucher voucher)
        {
            db.Vouchers.Update(voucher);
            db.SaveChanges();
        }
    }
}
