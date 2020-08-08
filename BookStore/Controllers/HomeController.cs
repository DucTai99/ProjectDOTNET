
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            var bookDao = new BooksDao();
            ViewData["top3Selling"] = new BooksDao().topSelling().Take(3);
            //list sách mới
            ViewData["newBook"] = new BooksDao().newBook().Take(8);

            return View();
        }

        //public IEnumerable<sach> listBookWithPage
    }
}