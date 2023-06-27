namespace QuanLyBanQuanAo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDangNhap")]
    public partial class tblDangNhap
    {
        [Key]
        [StringLength(20)]
        public string TenTaiKhoan { get; set; }

        [StringLength(15)]
        public string MatKhau { get; set; }
    }
}
