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
