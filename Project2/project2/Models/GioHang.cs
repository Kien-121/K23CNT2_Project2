using System;
using System.Collections.Generic;

namespace Project2.Models;

public partial class GioHang
{
    public int MaGh { get; set; }

    public int? MaKh { get; set; }

    public int? MaSp { get; set; }

    public int? SoLuong { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}
