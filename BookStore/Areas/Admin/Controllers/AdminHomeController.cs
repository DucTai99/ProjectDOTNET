using BookStore.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace BookStore.Areas.Admin.Controllers
{
    [AdminFilter]
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            BooksDao bookDao = new BooksDao();
            ViewBag.listBook = bookDao.getAllBook();
            return View();
        }

        [HttpPost]
        public ActionResult bookDetail(int idBook)
        {
            sach book = new BooksDao().getBookWithID(idBook);
            ViewBag.book = book;
            return PartialView();
        }
    }

    
}