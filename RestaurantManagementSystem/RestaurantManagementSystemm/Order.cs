using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystemm
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string MenuItem { get; set; } // Sipariş edilen menü öğesi
        public int Quantity { get; set; } // Sipariş miktarı
        public double TotalPrice { get; set; } // Toplam fiyat

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
