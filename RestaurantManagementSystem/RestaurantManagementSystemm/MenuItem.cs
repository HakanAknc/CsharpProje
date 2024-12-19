
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystemm
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<MenuItem> SubMenu { get; set; }

        public MenuItem(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
            SubMenu = new List<MenuItem>();
        }
    }
}
