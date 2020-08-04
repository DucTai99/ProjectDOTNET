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

        public ActionResult SingleProduct(int id = 1)
        {
            var book = new BooksDao().getBookWithID(id);
            if (book == null)
            {
                return RedirectToAction("Index","Shop");
            }
            ViewData["book"] = book;
            return View();
        }

        [HttpPost]
        public ActionResult listBookWithType(int id,int firstPrice = 0,int secondePrice = 0)
        {
            IEnumerable<sach> listBook;
            if (id == 0)
            {
                listBook = new BooksDao().getAllBookSale();
            }
            else if (id == -1)
            {
                listBook = new BooksDao().getAllBooksBetweenPrice(firstPrice,secondePrice);
            }
            else
            {
                listBook = new BooksDao().listBookWithType(id);
            }
            ViewData["listBookWithType"] = listBook;
            return PartialView();
        }

        [HttpGet]
        public ActionResult listBookSearch(String name)
        {
            ViewData["listBookSearch"] = new BooksDao().listBookSearch(name);
            return PartialView();
        }
    }
}