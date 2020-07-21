namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
            : base("name=BookStore")
        {
        }

        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<billcontainsach> billcontainsaches { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<logo> logoes { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<sach> saches { get; set; }
        public virtual DbSet<salecode> salecodes { get; set; }
        public virtual DbSet<theloaisach> theloaisaches { get; set; }
        public virtual DbSet<tinhtrangbill> tinhtrangbills { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<wishlist> wishlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bill>()
                .Property(e => e.detail)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<comment>()
                .Property(e => e.commentText)
                .IsUnicode(false);

            modelBuilder.Entity<logo>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.payment1)
                .HasForeignKey(e => e.payment)
                .WillCascadeOnDelete();

            modelBuilder.Entity<sach>()
                .Property(e => e.tenSach)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.tenTacGia)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.hinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.moTa)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .HasMany(e => e.billcontainsaches)
                .WithRequired(e => e.sach)
                .HasForeignKey(e => e.idSach);

            modelBuilder.Entity<sach>()
                .HasMany(e => e.wishlists)
                .WithOptional(e => e.sach)
                .HasForeignKey(e => e.idSach)
                .WillCascadeOnDelete();

            modelBuilder.Entity<salecode>()
                .Property(e => e.codeSale)
                .IsUnicode(false);

            modelBuilder.Entity<theloaisach>()
                .Property(e => e.tenTheLoai)
                .IsUnicode(false);

            modelBuilder.Entity<theloaisach>()
                .HasMany(e => e.saches)
                .WithOptional(e => e.theloaisach)
                .HasForeignKey(e => e.loaiSach)
                .WillCascadeOnDelete();

            modelBuilder.Entity<tinhtrangbill>()
                .Property(e => e.kieuTinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<tinhtrangbill>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.tinhtrangbill)
                .HasForeignKey(e => e.tinhTrangDonHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.idUserEmail)
                .WillCascadeOnDelete();

            modelBuilder.Entity<user>()
                .HasMany(e => e.wishlists)
                .WithOptional(e => e.user)
                .WillCascadeOnDelete();
        }
    }
}
