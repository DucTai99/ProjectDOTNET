using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            Session["UserId"] = null;
            Session["UserEmail"] = null;
            Session["UserLevel"] = null;
            Session["shoppingCart"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}