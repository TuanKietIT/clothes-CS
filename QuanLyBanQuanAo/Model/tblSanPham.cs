namespace QuanLyBanQuanAo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSanPham")]
    public partial class tblSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSanPham()
        {
            tblCTHDs = new HashSet<tblCTHD>();
        }

        [Key]
        [StringLength(20)]
        public string MaSanPham { get; set; }

        [Required]
        [StringLength(20)]
        public string TenSanPham { get; set; }

        [StringLength(20)]
        public string MaThuongHieu { get; set; }

        [StringLength(20)]
        public string MaChatLieu { get; set; }

        [StringLength(20)]
        public string MaPhanLoai { get; set; }

        public int KichCo { get; set; }

        public double SoLuong { get; set; }

        public double DonGiaNhap { get; set; }

        public double DonGiaBan { get; set; }

        public DateTime? NgayNhap { get; set; }

        [Required]
        [StringLength(100)]
        public string GhiChu { get; set; }

        public string Anh { get; set; }

        public virtual tblChatLieu tblChatLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCTHD> tblCTHDs { get; set; }

        public virtual tblPhanLoai tblPhanLoai { get; set; }

        public virtual tblThuongHieu tblThuongHieu { get; set; }
    }
}
