using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        
        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Ürün Adı: {Name}, Fiyat: {Price} TL, Stok: {Stock}");
        }
    }
}
