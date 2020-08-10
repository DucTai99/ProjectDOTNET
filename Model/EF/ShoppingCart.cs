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
                total = total + item.price;
            }
            else
            {
                listItem.Add(itemToAdd);
                total = total + itemToAdd.price;
            }

        }

        public decimal calculatorTotal()
        {
            foreach (var item in listItem)
            {
                total = total + item.total;
            }

            return total;
        }

        public int getNumItems()
        {
            return listItem.ToArray().Length;
        }
    }
}
