
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
            dynamic list = new BooksDao().listBookTopSell();
            return View();
        }

        //public IEnumerable<sach> listBookWithPage
    }
}