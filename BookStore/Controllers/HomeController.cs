using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            BookStoreDbContext db = new BookStoreDbContext();
            user user1 = db.users.First(user => user.idUser == 19);
            //UserDao userDao = new UserDao();
            //user user = userDao.getUserById(19);
            int a = user1.idUser;
            db.SaveChanges();
            //Console.WriteLine("Here");
            return View();
        }
    }
}