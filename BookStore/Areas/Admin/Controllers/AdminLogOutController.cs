using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class AdminLogOutController : Controller
    {
        // GET: Admin/LogOut
        public ActionResult Index()
        {
            Session["UserId"] = null;
            Session["UserEmail"] = null;
            Session["UserLevel"] = null;
            Session["shoppingCart"] = null;
            return RedirectToAction("SignIn", "Login", new { area =""});
        }
    }
}