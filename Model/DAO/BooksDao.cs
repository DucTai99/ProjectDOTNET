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

        public IEnumerable<sach> listAllBookWithPaging(int pageNum, int pageSize) {
            return db.saches.OrderBy(book => book.maSach).ToPagedList(pageNum, pageSize);
        }

        public IEnumerable<sach> listBookWithType(int idType)
        {
            return db.saches.Where(book => book.loaiSach == idType);
        }
    }
}
