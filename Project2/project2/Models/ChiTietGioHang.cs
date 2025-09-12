using System;
using System.Collections.Generic;

namespace project2.Models;

public partial class ChiTietGioHang
{
    public int MaGh { get; set; }

    public int MaSp { get; set; }

    public int? SoLuong { get; set; }

    public virtual GioHang MaGhNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
