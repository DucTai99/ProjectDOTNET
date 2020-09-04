using BookStore.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using BookStore.Areas.Admin.Models;

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

        [HttpPost]
        public ActionResult removeBook(int idBook) 
        {
            BooksDao bookDao = new BooksDao();
            bool success = bookDao.removeBook(idBook);
            //if (!success)
            //{
            //    return 
            //}
            
            ViewBag.listBook = bookDao.getAllBook();
            return PartialView();
        }

        [HttpPost]
        public ActionResult updateBook(int idBook, string inputBookName, int inputCategory, string inputAuthor, string areaDescription, string imageBook, int inputPrice,int inputQuantity,int inputSale)
        {
            BooksDao bookDao = new BooksDao();
            bookDao.updateBook(idBook,inputBookName,inputCategory,inputAuthor,areaDescription,imageBook,inputPrice,inputQuantity,inputSale);
            ViewBag.listBook = bookDao.getAllBook();
            sach book = bookDao.getBookWithID(idBook);
            ViewBag.book = book;
            return PartialView();
        }
        public ActionResult Account()
        {
            ViewBag.listUser = new UserDao().getAllUser();

            return View();
        }

        public ActionResult accountArea(string email)
        {
            user user = new UserDao().getUserByEmail(email);
            ViewBag.user = user;
            ViewBag.listBill = new BillDao().getListBillByIdUser(user.idUser);
            ViewBag.listTypeBill = new BillDao().getAllTypeBill();
            return PartialView();
        }

        public ActionResult changeTinhTrangBill(string email, int idBill, int tinhTrang)
        {
            user user = new UserDao().getUserByEmail(email);
            ViewBag.user = user;
            ViewBag.listBill = new BillDao().updateTinhTrangBill(user.idUser,idBill,tinhTrang);
            ViewBag.listTypeBill = new BillDao().getAllTypeBill();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Account(UserEditModel model)
        {
            ViewBag.listUser = new UserDao().updateUser(model.email,model.level,model.active);
            return View();
        }

        public ActionResult deleteUser(string email)
        {
            ViewBag.listUser = new UserDao().deleteUser(email);
            return PartialView();
        }
    }
}