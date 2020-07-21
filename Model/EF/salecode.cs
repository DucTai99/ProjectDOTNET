namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookstore.salecode")]
    public partial class salecode
    {
        [Key]
        public int idSale { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string codeSale { get; set; }

        public int? khuyenMai { get; set; }
    }
}
