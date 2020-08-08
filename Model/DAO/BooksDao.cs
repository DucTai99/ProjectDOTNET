using Model.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class BooksDao
    {
        private BookStoreDbContext db;
        public BooksDao() {
            this.db = new BookStoreDbContext();
        }

        public List<sach> getAllBook() {
            List<sach> listBook = new List<sach>();
            listBook = db.saches.ToList();

            return listBook;
        }

        public sach getBookWithID(int id) {
            return db.saches.Find(id);
        }

        public IEnumerable<sach> getAllBookSale()
        {
            return db.saches.Where(book => book.khuyenMai > 0).OrderByDescending(book => book.khuyenMai);
        }

        public IEnumerable<sach> listAllBookWithPaging(int pageNum, int pageSize) {
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

        //Sách bán chạy
        public List<billcontainsach> topSelling()
        {
            var books = db.billcontainsaches.OrderByDescending(bill => bill.quantity);
            return books.ToList();
        }
        //SÁCH MỚI : 

        public List<sach> newBook()
        {
            var newBooks = db.saches.OrderByDescending(book => book.ngayXuatBan);
            return newBooks.ToList();
        }

    }
}
