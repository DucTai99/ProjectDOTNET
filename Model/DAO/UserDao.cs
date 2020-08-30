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
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case   
            passwordBuilder.Append(RandomString(4, true));

            // 4-Digits between 1000 and 9999  
            passwordBuilder.Append(RandomNumber(1000, 9999));

            // 2-Letters upper case  
            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();

            // string ran = "a b c d e f g h i j k l m n o p q r s t u v w x y z 1 2 3 4 5 6 7 8 9 0 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
            //string[] a = ran.Split(' ');
            //string newPassword = "";
            //for(var i = 0; i < 8; i ++)
            //{
            //    int len = new Random().Next(a.Length);
            //    newPassword = newPassword + a[len];
            //}
            //return newPassword;
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            Random random = new Random();
            var builder = new StringBuilder(size);

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
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
