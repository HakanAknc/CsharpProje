using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string MenuItem { get; set; } 
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public Order(int orderId, string customerName, string menuItem, int quantity, double totalPrice)
        {
            OrderId = orderId;
            CustomerName = customerName;
            MenuItem = menuItem;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
    }
}
