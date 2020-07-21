namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookstore.tinhtrangbill")]
    public partial class tinhtrangbill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tinhtrangbill()
        {
            bills = new HashSet<bill>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTinhTrang { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string kieuTinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }
    }
}
