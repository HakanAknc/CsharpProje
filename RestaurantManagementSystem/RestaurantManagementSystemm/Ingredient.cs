﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystemm
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; } // Erzak miktarı

        public Ingredient(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
