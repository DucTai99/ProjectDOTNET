﻿using Model.EF;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(user user)
        {
            if (ModelState.IsValid)
            {
                var userInDB = new UserDao().login(user); 
                if (userInDB != null)
                {
                    Session["UserId"] = userInDB.idUser.ToString();
                    Session["UserEmail"] = userInDB.email.ToString();
                    Session["UserLevel"] = userInDB.level.ToString();
                    return RedirectToAction("Index","Home");
                }
            }
            ViewBag.message = "Sai tên đăng nhập hoặc mật khẩu";
            return View(user);
        }


        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(string email, string password, string cfpassword)
        {
            var userDao = new UserDao();
            if (!password.Equals(cfpassword))
            {
                ViewBag.errorPassWord = "Mật khẩu nhập lại không đúng";
            }
            else
            {
                bool success = userDao.signUp(email,password);
                if (!success)
                {
                    ViewBag.existEmail = "Email này đã tồn tại";
                }
                else
                {
                    ViewBag.success = "Đăng ký thành công";
                }
            }
            ViewBag.email = email;
            return View();
        }

    }
}