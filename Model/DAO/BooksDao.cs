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

        public IEnumerable<sach> listAllBookWithPaging(int pageNum, int pageSize)
        {
            return db.saches.OrderBy(sach => sach.tenSach).ToPagedList(pageNum, pageSize);
        }
        ///

        public sach bookWithID(int id)
        {
            return db.saches.Find(id);
        }

        public List<sach> sameCate (int id)
        {
            var cate = db.saches.Find(id);
            List<sach> listBook = new List<sach>();
            //khác id sách , nhưng cùng mã thể loại
            listBook = db.saches.Where(book => book.maSach != id && book.loaiSach == cate.loaiSach).ToList();
            return listBook;
        }

        }
}
