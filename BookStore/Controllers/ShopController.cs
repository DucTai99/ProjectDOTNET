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

        public ActionResult addItemToCart(int idBook)
        {
            var book = new BooksDao().getBookWithID(idBook);
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            Item item = new Item(book);
            shoppingCart.addItem(item);
            ViewBag.shoppingCart = shoppingCart;
            return PartialView();
        }

        [HttpPost]
        public ActionResult addComment(int idBook, String content)
        {
            comment comment = new comment();
            comment.idUser = Int32.Parse(Session["UserId"].ToString());
            comment.maSach = idBook;
            comment.commentText = content;
            CommentDao commentDao = new CommentDao();
            commentDao.addComment(comment);
            var book = new BooksDao().getBookWithID(idBook);
            ViewData["book"] = book;
            return PartialView();
        }
    }
}