using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.EF;

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

        public ActionResult SingleProduct()
        {
            return View();
        }
    }
}