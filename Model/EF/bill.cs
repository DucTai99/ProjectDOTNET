namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookstore.bill")]
    public partial class bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            billcontainsaches = new HashSet<billcontainsach>();
        }

        [Key]
        public int idBill { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string detail { get; set; }

        public int? idUserEmail { get; set; }

        public int? total { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string address { get; set; }

        public int? payment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string phoneNumber { get; set; }

        public int? tinhTrangDonHang { get; set; }

        public virtual payment payment1 { get; set; }

        public virtual user user { get; set; }

        public virtual tinhtrangbill tinhtrangbill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<billcontainsach> billcontainsaches { get; set; }
    }
}
