namespace QuanLyBanQuanAo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCTHD")]
    public partial class tblCTHD
    {
        [Key]
        [StringLength(20)]
        public string MaHoaDon { get; set; }

        [StringLength(20)]
        public string MaSanPham { get; set; }

        public double? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? GiamGia { get; set; }

        public double? ThanhTien { get; set; }

        public virtual tblHoaDon tblHoaDon { get; set; }

        public virtual tblSanPham tblSanPham { get; set; }
    }
}
