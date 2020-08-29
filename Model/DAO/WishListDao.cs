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
            List<wishlist> list = getWishListByIdUser(idUser);
            foreach (var wishlist in list)
            {
                if (wishlist.idSach == idBook)
                {
                    return true;
                }
            }
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

        public void removeBookFromWishList(int idUser, int idBook)
        {
            List<wishlist> list = getWishListByIdUser(idUser);
            foreach (var wishlist in list)
            {
                if (wishlist.idSach == idBook)
                {
                    db.wishlists.Remove(wishlist);
                    db.SaveChanges();
                    break;
                }
            }
        }

        public List<wishlist> removeAllBookFromWishList(int idUser)
        {
            List<wishlist> list = getWishListByIdUser(idUser);
            db.wishlists.RemoveRange(list);
            db.SaveChanges();
            list.Clear();
            return list;
        }
    }
}
