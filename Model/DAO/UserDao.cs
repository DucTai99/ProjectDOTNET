using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Security.Cryptography;

namespace Model.DAO
{
    public class UserDao
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

        public user login(user user) {
            var md5Pass = encMd5PassWord(user.password);
            user.password = md5Pass;
            return db.users.Where(userInDB => userInDB.email.Equals(user.email) && userInDB.password.Equals(user.password)).FirstOrDefault();
        }

        public bool isExistEmail(string email)
        {
            int count = db.users.Count(user => user.email.Equals(email));
            if(count == 0)
            {
                return false;
            }
            return true;
        }

        public bool signUp(string email,string password)
        {
            if (isExistEmail(email))
            {
                return false;
            }
            else
            {
                user user = new user();
                user.email = email;
                user.password = encMd5PassWord(password);
                user.level = 1;
                user.active = 1;
                db.users.Add(user);
                db.SaveChanges();
                return true;
            }
        }
        public string encMd5PassWord(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password.ToLower();
            return result;
        }
    }
}
