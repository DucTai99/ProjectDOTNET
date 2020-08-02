using Model.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.ViewModel;

namespace Model.DAO
{
    public class BooksDao
    {
        private BookStoreDbContext db;
        private BookViewModel mv;
        public BooksDao()
        {
            this.db = new BookStoreDbContext();
            this.mv = new BookViewModel();
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
      

      //hiện thể loại sách  
        public BookViewModel listByCateId(int id)
        {
            var b = from s in db.saches
                    join tls in db.theloaisaches on s.loaiSach equals tls.maTheLoai
                    where s.maSach == id
                    select new BookViewModel()
                    {
                        
                        tenSach = s.tenSach,
                        tenTheLoai = tls.tenTheLoai,
                        tenTacGia = s.tenTacGia
                    };
                return b.First();
        }

        }
}
