using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.EF;
using Microsoft.Ajax.Utilities;

namespace BookStore.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(int pageNum =1, int pageSize = 9)
        {
            var bookDao = new BooksDao();
            var model = bookDao.listAllBookWithPaging(pageNum,pageSize);
            ViewData["ListBookType"] = new BookTypeDao().getAllType() ;
            return View(model);
        }

        public ActionResult SingleProduct(int id)
        {
            var book = new BooksDao().getBookWithID(id);
            ViewData["book"] = book;
            //ViewData["bookType"] = new BookTypeDao().getBookTypeWithId(book.);
            return View();
        }

        [HttpPost]
        public ActionResult listBookWithType(int id)
        {
            IEnumerable<sach> listBook = new BooksDao().listBookWithType(id);
            ViewData["listBookWithType"] = listBook;
            return PartialView();
        }
    }
}