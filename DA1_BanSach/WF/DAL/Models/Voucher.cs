using System;
using System.Collections.Generic;

namespace WF.DAL.Models;

public partial class Voucher
{
    public int Id { get; set; }

    public string MaVoucher { get; set; } = null!;

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public double TiLeGiam { get; set; }

    public double DonHangToiThieu { get; set; }

    public double GiamToiDa { get; set; }

    public int SoLuong { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();
}
