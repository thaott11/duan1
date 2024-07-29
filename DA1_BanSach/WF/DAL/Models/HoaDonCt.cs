using System;
using System.Collections.Generic;

namespace WF.DAL.Models;

public partial class HoaDonCt
{
    public int Id { get; set; }

    public int SoLuongMua { get; set; }

    public double GiaBan { get; set; }

    public int? IdsachCt { get; set; }

    public int? IdhoaDon { get; set; }

    public string? MaHdct { get; set; }

    public double? ThanhTien { get; set; }

    public string? MaSpct { get; set; }

    public string? TenSp { get; set; }

    public virtual HoaDon? IdhoaDonNavigation { get; set; }

    public virtual SachChiTiet? IdsachCtNavigation { get; set; }
}
