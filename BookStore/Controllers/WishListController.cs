using Model.DAO;
using BookStore.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace BookStore.Controllers
{
    [AccessFilter]
    public class WishListController : Controller
    {
        // GET: WishList
        public ActionResult Index()
        {

            var idUser = Int32.Parse(Session["UserId"].ToString());
            //WishListDao().addBookToWishList(idUser, idBook);
            //WishListDao wlDao = new WishListDao();
            //var wishList = new  WishListDao().addBookToWishList(idUser, idBook);
            //var wl = new WishListDao().listBookWistlist(idBook);
            var wl = new WishListDao().listBookWistlist(Int32.Parse(Session["UserId"].ToString()));
            ViewData["wishListDao"] = wl;
            return PartialView();
        }
    }
}