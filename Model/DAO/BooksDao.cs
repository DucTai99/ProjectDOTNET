using Model.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    class BooksDao
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
    }
}
