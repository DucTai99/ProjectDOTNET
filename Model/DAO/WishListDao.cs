using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class WishListDao
    {
        private BookStoreDbContext db;
        public WishListDao()
        {
            this.db = new BookStoreDbContext();
        }
        public bool addBookToWishList(int idUser, int idBook)
        {
            wishlist wl = new wishlist();
            wl.idUser = idUser;
            wl.idSach = idBook;
            db.wishlists.Add(wl);
            db.SaveChanges();
            return true;
        }

        public List<wishlist> getWishListByIdUser(int idUser)
        {
            List<wishlist> list = db.wishlists.Where(wishlist => wishlist.idUser == idUser).ToList();

            return list;
        }
    }
}
