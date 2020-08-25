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

        [HttpPost]
        public ActionResult removeItem(int idBook)
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            shoppingCart.removeItem(idBook);
            return PartialView();
        }

        public ActionResult removeAllItem()
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            shoppingCart.removeAllItem();
            return PartialView();
        }

        public ActionResult changeNumItem(int idBook, int number)
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            shoppingCart.changeNumItem(idBook, number);
            return PartialView();
        }

        public ActionResult useCodeSale(String codeSale)
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            shoppingCart.totalWithSaleCode(codeSale);
            return PartialView();
        }
    }
}