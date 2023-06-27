namespace QuanLyBanQuanAo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHoaDon")]
    public partial class tblHoaDon
    {
        [Key]
        [StringLength(20)]
        public string MaHoaDon { get; set; }

        [StringLength(20)]
        public string MaKhachHang { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }

        public double? TongTien { get; set; }

        public DateTime? NgayBan { get; set; }

        public virtual tblCTHD tblCTHD { get; set; }

        public virtual tblKhachHang tblKhachHang { get; set; }

        public virtual tblNhanVien tblNhanVien { get; set; }
    }
}
