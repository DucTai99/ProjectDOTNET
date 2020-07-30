using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    class UserDao
    {
        private BookStoreDbContext db;
        public UserDao() {
            this.db = new BookStoreDbContext();
        }

        public bool updatePassword(int idUser, string oldPassWordUser, string newPassWordUser) {
            bool changeSuccess = false;
            user userFromDB = db.users.First(user => user.idUser == idUser && user.password.Equals(oldPassWordUser));
            userFromDB.password = newPassWordUser;
            db.SaveChanges();

            return changeSuccess;
        }

        public bool Login(string emailUser,string passWordUser) {
            bool loginSuccess = false;
            int count = db.users.Count(user => user.email.Equals(emailUser) && user.password.Equals(passWordUser));
            if (count == 1) {
                loginSuccess = true;
            }

            return loginSuccess;
        }
    }
}
