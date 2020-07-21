namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookstore.logo")]
    public partial class logo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idLogo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string img { get; set; }
    }
}
