using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    public class ShoppingCart
    {
        public List<Item> listItem { get; set; }
        public decimal total { get; set; }

        public int saleCode { get; set; }

        private BookStoreDbContext db;

        public ShoppingCart()
        {
            listItem = new List<Item>();
            total = 0;
            saleCode = 0;
            this.db = new BookStoreDbContext();
        }

        public void addItem(Item itemToAdd)
        {
            Item item = listItem.Where(itemInList => itemInList.book.maSach == itemToAdd.book.maSach).FirstOrDefault();
            if (item != null)
            {
                item.increaseQuantity();
                calculatorTotal();
            }
            else
            {
                listItem.Add(itemToAdd);
                calculatorTotal();
            }

        }

        public decimal calculatorTotal()
        {
            total = 0;
            foreach (var item in listItem)
            {
                total = total + item.calculateTotal();
            }
            return total;
        }

        public int getNumItems()
        {
            int numItem = 0;
            foreach (var item in listItem)
            {
                numItem = numItem + item.quantity;
            }
            return numItem;
        }

        public void removeItem(int idBook)
        {
            foreach (var product in listItem)
            {
                if (product.book.maSach == idBook)
                {
                    listItem.Remove(product);
                    calculatorTotal();
                    break;
                }
            }
        }

        public void removeAllItem()
        {
            listItem.Clear();
            calculatorTotal();
        }

        public void changeNumItem(int idBook, int number)
        {
            foreach (var product in listItem)
            {
                if (product.book.maSach == idBook)
                {
                    product.quantity = number;
                    calculatorTotal();
                    break;
                }
            }
        }

        public decimal totalWithSaleCode(String code)
        {
            calculatorTotal();
            if(saleCode == 0)
            {
                if (code.Equals(""))
                {
                    return total;
                }
                else
                {
                    salecode sc = db.salecodes.Where(codeSale => codeSale.codeSale == code).FirstOrDefault();
                    if (sc != null)
                    {
                        saleCode = (int)sc.khuyenMai;
                        return total - (total * saleCode / 100);
                    }
                    else
                    {
                        return total;
                    }
                }
            }
            else
            {
                return total - (total * saleCode / 100);
            }
        }
    }
}
