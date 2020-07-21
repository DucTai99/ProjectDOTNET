using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class UserDao
    {
        BookStoreDbContext db;
        public UserDao() {
            db = new BookStoreDbContext();
        }

        public int addUser(user user) {
            db.users.Add(user);
            db.SaveChanges();
            return user.idUser;
        }

        public bool login(string email, string passWord) {
            var result = db.users.Count(user => user.email == email && user.password == passWord);
            if (result > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
