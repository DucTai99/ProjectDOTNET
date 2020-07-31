using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BookTypeDao
    {
        private BookStoreDbContext db;
        public BookTypeDao()
        {
            db = new BookStoreDbContext();
        }

        public theloaisach getBookTypeWithId(int id){
            return db.theloaisaches.Find(id);
        }
        public IEnumerable<theloaisach> getAllType() {
            return db.theloaisaches;
        }
    }
}
