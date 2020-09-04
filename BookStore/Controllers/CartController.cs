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

        public ActionResult checkOutDone(String payment, String detail = "Detail", String address = "", String name = "", String phoneNumber = "")
        {
            ShoppingCart shoppingCart = (ShoppingCart)Session["shoppingCart"];
            int idUser = Int32.Parse(Session["UserId"].ToString());
            bill bill = new bill();
            bill.detail = detail;
            bill.idUserEmail = idUser;
            bill.total = (int)shoppingCart.totalWithSaleCode();
            bill.address = address;
            bill.payment = Int32.Parse(payment);
            bill.date = DateTime.Today;
            bill.name = name;
            bill.phoneNumber = phoneNumber;
            bill.tinhTrangDonHang = 1;
            BillDao billDao = new BillDao();
            billDao.addBill(bill);
            bill billInDB = billDao.getLastRecord();
            if(billDao.addBillContainSach(billInDB.idBill, shoppingCart))
            {
                ShoppingCart newShoppingCart = new ShoppingCart();
                Session["shoppingCart"] = newShoppingCart;
            }
            return PartialView();
        }
    }
}