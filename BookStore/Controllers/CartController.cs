using BookStore.Filter;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [AccessFilter]
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            ViewBag.shoppingCart = shoppingCart;
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult removeItem(int idBook)
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            shoppingCart.removeItem(idBook);
            ViewBag.shoppingCart = shoppingCart;
            return PartialView();
        }

        public ActionResult removeAllItem()
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            shoppingCart.removeAllItem();
            ViewBag.shoppingCart = shoppingCart;
            return PartialView();
        }

        public ActionResult changeNumItem(int idBook, int number)
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            shoppingCart.changeNumItem(idBook, number);
            ViewBag.shoppingCart = shoppingCart;
            return PartialView();
        }
    }
}