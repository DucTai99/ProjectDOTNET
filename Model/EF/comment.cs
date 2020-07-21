namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookstore.comment")]
    public partial class comment
    {
        [Key]
        public int idComment { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string commentText { get; set; }

        public int idUser { get; set; }

        public int maSach { get; set; }

        public virtual user user { get; set; }

        public virtual sach sach { get; set; }
    }
}
