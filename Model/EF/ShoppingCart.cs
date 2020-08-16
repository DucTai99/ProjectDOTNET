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

        public ShoppingCart()
        {
            listItem = new List<Item>();
            total = 0;
        }

        public void addItem(Item itemToAdd)
        {
            Item item = listItem.Where(itemInList => itemInList.book.maSach == itemToAdd.book.maSach).FirstOrDefault();
            if (item!=null)
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
                total = total + item.total;
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
                if(product.book.maSach == idBook)
                {
                    listItem.Remove(product);
                    calculatorTotal();
                    break;
                }
            }
        }
    }
}
