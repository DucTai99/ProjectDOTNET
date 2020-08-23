namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookstore.wishlist")]
    public partial class wishlist
    {
        public int id { get; set; }

        public int? idUser { get; set; }

        public int? idSach { get; set; }

        public virtual sach sach { get; set; }

        public virtual user user { get; set; }

    }
}
