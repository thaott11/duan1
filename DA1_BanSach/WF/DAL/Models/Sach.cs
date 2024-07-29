using System;
using System.Collections.Generic;

namespace WF.DAL.Models;

public partial class Sach
{
    public int Id { get; set; }

    public string MaSach { get; set; } = null!;

    public string TieuDe { get; set; } = null!;

    public string? MoTa { get; set; }

    public string NgonNgu { get; set; } = null!;

    public string TacGia { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<SachChiTiet> SachChiTiets { get; } = new List<SachChiTiet>();
}
