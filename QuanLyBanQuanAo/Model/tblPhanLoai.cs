namespace QuanLyBanQuanAo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPhanLoai")]
    public partial class tblPhanLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPhanLoai()
        {
            tblSanPhams = new HashSet<tblSanPham>();
        }

        [Key]
        [StringLength(20)]
        public string MaPhanLoai { get; set; }

        [Required]
        [StringLength(20)]
        public string TenPhanLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSanPham> tblSanPhams { get; set; }
    }
}
