using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    public class Item
    {
        public sach book { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal total { get; set; }

        public Item(sach book)
        {
            this.book = book;
            this.quantity = 1;
            this.price = this.book.gia;
            this.total = this.quantity * this.price;

        }
        public decimal calculateTotal()
        {
            total = quantity * price;
            return total;
        }

        public int increaseQuantity()
        {
            quantity = quantity + 1;
            calculateTotal();
            return quantity;
        }
    }
}
