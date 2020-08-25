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
            var user = new UserDao().getWislistWithIdUser(Int32.Parse(Session["UserId"].ToString()));
            ViewData["user"] = user;
            return View();
        }
    }
}