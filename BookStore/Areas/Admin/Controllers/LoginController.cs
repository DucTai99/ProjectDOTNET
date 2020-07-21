using BookStore.Areas.Admin.Models;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login(LoginModel user)
        {
            if (ModelState.IsValid) {
                var dao = new UserDao();
                var result = dao.login(user.userEmail,user.userPassword);
                if (result)
                {
                    return RedirectToAction("Index","Home");
                }
                else {
                    ModelState.AddModelError("","Dang nhap khong dung");
                }
            }
            return View("Index");
        }
    }
}