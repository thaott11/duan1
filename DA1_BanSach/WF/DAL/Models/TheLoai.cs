using System;
using System.Collections.Generic;

namespace WF.DAL.Models;

public partial class TheLoai
{
    public int Id { get; set; }

    public string MaTl { get; set; } = null!;

    public string TenTl { get; set; } = null!;
}
