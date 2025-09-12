using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project2.Models;

public partial class QlbanDoAnContext : DbContext
{
    public QlbanDoAnContext()
    {
    }

    public QlbanDoAnContext(DbContextOptions<QlbanDoAnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=QLBanDoAn;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => new { e.MaDh, e.MaSp }).HasName("PK__ChiTietD__F557D6E0D3E6A4F3");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.MaDh).HasColumnName("MaDH");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.DonGia).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.MaDhNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaDh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDon__MaDH__4D94879B");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDon__MaSP__4E88ABD4");
        });

        modelBuilder.Entity<ChiTietGioHang>(entity =>
        {
            entity.HasKey(e => new { e.MaGh, e.MaSp }).HasName("PK__ChiTietG__F557FE042CB6178A");

            entity.ToTable("ChiTietGioHang");

            entity.Property(e => e.MaGh).HasColumnName("MaGH");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaGhNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.MaGh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietGio__MaGH__4316F928");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietGio__MaSP__440B1D61");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.MaDm).HasName("PK__DanhMuc__2725866E9F433D31");

            entity.ToTable("DanhMuc");

            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.TenDm)
                .HasMaxLength(100)
                .HasColumnName("TenDM");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDh).HasName("PK__DonHang__272586617E479237");

            entity.ToTable("DonHang");

            entity.Property(e => e.MaDh).HasColumnName("MaDH");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.NgayDat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhuongThucTt)
                .HasMaxLength(20)
                .HasColumnName("PhuongThucTT");
            entity.Property(e => e.TongTien).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(20);

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__DonHang__MaKH__49C3F6B7");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.MaGh).HasName("PK__GioHang__2725AE857BA8338B");

            entity.ToTable("GioHang");

            entity.Property(e => e.MaGh).HasColumnName("MaGH");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__GioHang__MaKH__3F466844");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1EABFA229A");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Email, "UQ__KhachHan__A9D1053414A5FB19").IsUnique();

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.DiaChiMacDinh).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A3EF71788");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.Email, "UQ__NhanVien__A9D1053484B4658E").IsUnique();

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");
            entity.Property(e => e.VaiTro).HasMaxLength(20);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C09DF35FC");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Anh).HasMaxLength(255);
            entity.Property(e => e.Gia).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.TenSp)
                .HasMaxLength(100)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaDm)
                .HasConstraintName("FK__SanPham__MaDM__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
