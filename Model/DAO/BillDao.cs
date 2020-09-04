using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BillDao
    {
        private BookStoreDbContext db;
        public BillDao()
        {
            this.db = new BookStoreDbContext();
        }

        public void addBill(bill bill)
        {
            db.bills.Add(bill);
            db.SaveChanges();
        }

        public bill getLastRecord()
        {
            return db.bills.OrderByDescending(bill => bill.idBill).FirstOrDefault();
        }

        public bool addBillContainSach(int idBill, ShoppingCart shoppingCart)
        {
            foreach (Item item in shoppingCart.listItem)
            {
                billcontainsach billcontainsach = new billcontainsach();
                billcontainsach.idBill = idBill;
                billcontainsach.idSach = item.book.maSach;
                billcontainsach.quantity = item.quantity;
                db.billcontainsaches.Add(billcontainsach);
                db.SaveChanges();
            }
            return true;
        }

        public List<bill> getListBillByIdUser(int idUser)
        {
            return db.bills.Where(bill => bill.idUserEmail == idUser).ToList();
        }

        public List<tinhtrangbill> getAllTypeBill()
        {
            return db.tinhtrangbills.ToList();
        }

        public List<bill> updateTinhTrangBill(int idUser, int idBill, int tinhTrang)
        {
            List<bill> listBill = getListBillByIdUser(idUser);
            foreach(var bill in listBill)
            {
                if(bill.idBill == idBill)
                {
                    bill.tinhTrangDonHang = tinhTrang;
                    db.SaveChanges();
                    break;
                }
            }
            return db.bills.Where(bill => bill.idUserEmail == idUser).ToList();
        }
    }
}
