namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookstore.sach")]
    public partial class sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sach()
        {
            billcontainsaches = new HashSet<billcontainsach>();
            comments = new HashSet<comment>();
            wishlists = new HashSet<wishlist>();
        }

        [Key]
        public int maSach { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string tenSach { get; set; }

        public int? loaiSach { get; set; }

        public decimal gia { get; set; }

        public int? soLuong { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string tenTacGia { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string hinhAnh { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string moTa { get; set; }

        public int khuyenMai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<billcontainsach> billcontainsaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }

        public virtual theloaisach theloaisach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wishlist> wishlists { get; set; }
    }
}
