using System;
using System.Collections.Generic;

namespace WF.DAL.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public string TrangThai { get; set; } = null!;

    public DateTime NgayMuaHang { get; set; }

    public int? Idnhanvien { get; set; }

    public int? Idkhachhang { get; set; }

    public int? Idvoucher { get; set; }

    public string? MaHd { get; set; }

    public double? GiamGia { get; set; }

    public virtual ICollection<HoaDonCt> HoaDonCts { get; } = new List<HoaDonCt>();

    public virtual KhachHang? IdkhachhangNavigation { get; set; }

    public virtual NhanVien? IdnhanvienNavigation { get; set; }

    public virtual Voucher? IdvoucherNavigation { get; set; }
}
