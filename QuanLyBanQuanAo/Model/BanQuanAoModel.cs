using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyBanQuanAo.Model
{
    public partial class BanQuanAoModel : DbContext
    {
        public BanQuanAoModel()
            : base("name=BanQuanAoModel")
        {
        }

        public virtual DbSet<tblChatLieu> tblChatLieux { get; set; }
        public virtual DbSet<tblCTHD> tblCTHDs { get; set; }
        public virtual DbSet<tblDangNhap> tblDangNhaps { get; set; }
        public virtual DbSet<tblHoaDon> tblHoaDons { get; set; }
        public virtual DbSet<tblKhachHang> tblKhachHangs { get; set; }
        public virtual DbSet<tblNhanVien> tblNhanViens { get; set; }
        public virtual DbSet<tblPhanLoai> tblPhanLoais { get; set; }
        public virtual DbSet<tblSanPham> tblSanPhams { get; set; }
        public virtual DbSet<tblThuongHieu> tblThuongHieux { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblHoaDon>()
                .HasOptional(e => e.tblCTHD)
                .WithRequired(e => e.tblHoaDon);
            
        }
    }
}
