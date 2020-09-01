using Model.EF;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Common;
using System.Net.Mail;
using System.Net;

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
            var req = this.Request.Url;
            if (ModelState.IsValid)
            {
                var userInDB = new UserDao().login(user);
                if (userInDB != null)
                {
                    Session["UserId"] = userInDB.idUser.ToString();
                    Session["UserEmail"] = userInDB.email.ToString();
                    Session["UserLevel"] = userInDB.level.ToString();
                    if (Session["redController"] != null)
                    {
                        var redController = Session["redController"].ToString();
                        var redAction = Session["redAction"].ToString();
                        Session["redController"] = null;
                        Session["redAction"] = null;
                        return RedirectToAction(redAction, redController);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
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
                bool success = userDao.signUp(email, password);
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

        public ActionResult ForgotPassword(string email)
        {
            UserDao userDao = new UserDao();
            string newPassword = userDao.randomPassword();
            if (userDao.updatePasswordRandom(email,newPassword))
            {
                //string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/sendnewpassword.html"));
                //content = content.Replace("{{Password}}", newPassword);
                //new MailHelper().sendMail(email, "Thay đổi mật khẩu", content);
                
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress("emailhoctap99@gmail.com");
                    mail.Subject = "Lấy lại mật khẩu";
                    string Body = "Mật khẩu mới của ban là : " + newPassword;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("emailhoctap99@gmail.com", "sinhvienvuotkho");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    ViewBag.message = "Đã gửi về email";
                } catch (Exception)
                {
                    ViewBag.message = "Lỗi trong viêc gửi gmail";
                }
            }
            else
            {
                ViewBag.message = "Email không tồn tại";
            }
            return PartialView();
        }
            
    }
}