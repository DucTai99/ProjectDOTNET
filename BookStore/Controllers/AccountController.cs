using BookStore.Filter;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [AccessFilter]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult changePassWord(string currentPass, string newPass)
        {
            int idUser = Int32.Parse(Session["UserId"].ToString());
            bool changeSuccess = new UserDao().updatePassword(idUser,currentPass,newPass);
            if (changeSuccess)
            {
                return Json(new
                {
                    error = "NoError"
                });
            }
            return Json(new
            {
                error = "CurrentPassWordWrong"
            });
        }
    }
}