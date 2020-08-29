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
            var currentPass = encMd5PassWord(oldPassWordUser);
            var newPass = encMd5PassWord(newPassWordUser);
            user userFromDB = db.users.Where(user => user.idUser == idUser && user.password.Equals(currentPass)).FirstOrDefault();
            if (userFromDB != null)
            {
                userFromDB.password = newPass;
                db.SaveChanges();
                changeSuccess = true;
            }
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

        public user getUserByEmail(string email)
        {
            return db.users.Where(user => user.email == email).FirstOrDefault();
        }

        public string randomPassword()
        {
            string ran = "a b c d e f g h i j k l m n o p q r s t u v w x y z 1 2 3 4 5 6 7 8 9 0 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            string[] a = ran.Split(' ');
            string newPassword = "";
            for(var i = 0; i < 8; i ++)
            {
                int len = new Random().Next(a.Length);
                newPassword = newPassword + a[len];
            }
            return newPassword;
        }

        public bool updatePasswordRandom(string email, string newPassword)
        {
            bool changeSuccess = false;
            var newPass = encMd5PassWord(newPassword);
            user userFromDB = getUserByEmail(email);
            if (userFromDB != null)
            {
                userFromDB.password = newPass;
                db.SaveChanges();
                changeSuccess = true;
            }
            return changeSuccess;
        }
    }
}
