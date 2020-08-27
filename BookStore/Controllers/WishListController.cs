using BookStore.Filter;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [AccessFilter]
    public class WishListController : Controller
    {
        // GET: WishList
        public ActionResult Index()
        {
            int idUser = Int32.Parse(Session["UserId"].ToString());
            List<wishlist> list = new WishListDao().getWishListByIdUser(idUser);
            ViewBag.wishList = list;
            return View();
        }
    }
}