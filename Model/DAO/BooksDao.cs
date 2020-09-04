using Model.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Org.BouncyCastle.Asn1.Cmp;

namespace Model.DAO
{
    public class BooksDao
    {
        private BookStoreDbContext db;
        public BooksDao()
        {
            this.db = new BookStoreDbContext();
        }

        public List<sach> getAllBook()
        {
            List<sach> listBook = new List<sach>();
            listBook = db.saches.ToList();

            return listBook;
        }

        public sach getBookWithID(int id)
        {
            return db.saches.Where(book => book.maSach == id).FirstOrDefault();
        }
        public IEnumerable<sach> getAllBookSale()
        {
            return db.saches.Where(book => book.khuyenMai > 0).OrderByDescending(book => book.khuyenMai);
        }
        public IEnumerable<sach> getAllBookSaleWithPaging(int pageNum, int pageSize)
        {
            return db.saches.Where(book => book.khuyenMai > 0).OrderByDescending(book => book.khuyenMai).ToPagedList(pageNum, pageSize);
        }

        public IEnumerable<sach> listAllBookWithPaging(int pageNum, int pageSize)
        {
            return db.saches.OrderBy(book => book.maSach).ToPagedList(pageNum, pageSize);
        }

        public IEnumerable<sach> getAllOfBooks()
        {
            return db.saches;
        }

        public IEnumerable<sach> getAllBooksBetweenPrice(int firstPrice, int secondPrice)
        {
            return db.saches.Where(book => (book.gia - (book.gia * book.khuyenMai / 100)) > firstPrice && (book.gia - (book.gia * book.khuyenMai / 100)) < secondPrice).OrderBy(book => book.gia - (book.gia * book.khuyenMai / 100));
        }

        public IEnumerable<sach> listBookWithType(int idType)
        {
            return db.saches.Where(book => book.loaiSach == idType);
        }

        public IEnumerable<sach> listBookSearch(String name)
        {
            return db.saches.Where(book => book.tenSach.Contains(name) || book.tenTacGia.Contains(name)).ToList();
        }

        public List<sach> listBookTopSell()
        {
            List<sach> listBookTopSell = new List<sach>();
            var query = (from b in db.billcontainsaches
                         group b by b.idSach into g
                         select new
                         {
                             Id = g.Key,
                             Sum = g.Sum(b => b.quantity),
                         }).OrderByDescending(a => a.Sum).Take(12).ToList();
            List<int> listIdBook = query.Select(i => i.Id).ToList();
            foreach (int id in listIdBook)
            {
                listBookTopSell.Add(getBookWithID(id));
            }
            return listBookTopSell;
        }

        public List<sach> listBookNewest()
        {
            return db.saches.OrderByDescending(book => book.ngayXuatBan).Take(12).ToList();
        }

        public List<sach> updateBook(int id, string hinhAnh, string moTa, string tenSach, string tenTacGia, int soLuong, DateTime ngayXuatBan, int khuyenMai, decimal gia)
        {
            sach book = getBookWithID(id);
            book.hinhAnh = hinhAnh;
            book.moTa = moTa;
            book.gia = gia;
            book.khuyenMai = khuyenMai;

            book.ngayXuatBan = ngayXuatBan;
            book.soLuong = soLuong;
            book.tenTacGia = tenTacGia;
            book.tenSach = tenSach;
            db.SaveChanges();
            return db.saches.ToList()
             ;
        }

    }
}