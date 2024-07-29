using System;
using System.Collections.Generic;

namespace WF.DAL.Models;

public partial class KhachHang
{
    public int Id { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public string? TenKhachHang { get; set; }

    public string? Sđt { get; set; }

    public string? DiaChi { get; set; }

    public string? GioiTinh { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();
}
