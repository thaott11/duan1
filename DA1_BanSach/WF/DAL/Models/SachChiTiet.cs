using System;
using System.Collections.Generic;

namespace WF.DAL.Models;

public partial class SachChiTiet
{
    public int Id { get; set; }

    public string MaSachCt { get; set; } = null!;

    public string Tap { get; set; } = null!;

    public int SoLuong { get; set; }

    public int SoTrang { get; set; }

    public double GiaBan { get; set; }

    public byte[] HinhAnh { get; set; } = null!;

    public int? Idsach { get; set; }

    public int? Idnxb { get; set; }

    public int? Idtheloai { get; set; }

    public string? TenTheLoai { get; set; }

    public virtual ICollection<HoaDonCt> HoaDonCts { get; } = new List<HoaDonCt>();

    public virtual NhaXuatBan? IdnxbNavigation { get; set; }

    public virtual Sach? IdsachNavigation { get; set; }

    public virtual NhaXuatBan? IdtheloaiNavigation { get; set; }
}
