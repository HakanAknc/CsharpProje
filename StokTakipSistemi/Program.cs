using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi
{
    class Program
    {
        static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                // Ana Menü
                Console.Clear();
                Console.WriteLine("=== Stok Takip Sistemi ===");
                Console.WriteLine("1. Ürün Ekle");
                Console.WriteLine("2. Ürün Sil");
                Console.WriteLine("3. Ürün Güncelle");
                Console.WriteLine("4. Stok Durumunu Görüntüle");
                Console.WriteLine("5. Satış Yap");
                Console.WriteLine("6. Çıkış");
                Console.Write("Bir seçenek girin: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        DeleteProduct();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":
                        DisplayStock();
                        break;
                    case "5":
                        MakeSale();
                        break;
                    case "6":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("=== Ürün Ekleme ===");

            Console.Write("Ürün Adı: ");
            string name = Console.ReadLine();

            Console.Write("Ürün Fiyatı: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Ürün Stoku: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Product newProduct = new Product(name, price, stock);
            products.Add(newProduct);

            Console.WriteLine("Ürün başarıyla eklendi");
            Console.ReadLine();

        }

        static void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("=== Ürün Silme ===");

            Console.Write("Silmek istediğiniz ürünün adın girin: ");
            string name = Console.ReadLine();

            Product productToRemove = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine("Ürün başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Ürün bulunamaddı.");
            }
            Console.ReadLine();
        }

        static void UpdateProduct()
        {
            Console.Clear();
            Console.WriteLine("=== Ürün Güncelleme ===");

            Console.Write("Güncellemek istediğiniz ürünün adını girin: ");
            string name = Console.ReadLine();

            Product productToUpdate = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (productToUpdate != null)
            {
                Console.Write("Yeni Fiyat: ");
                productToUpdate.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Yeni Stok: ");
                productToUpdate.Stock = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ürün başarıyla eklendi");
            }
            else
            {
                Console.WriteLine("Ürün bulunamadı");
            }
            Console.ReadLine();
        }

        static void DisplayStock()
        {
            Console.Clear();
            Console.WriteLine("Stok Durumu");

            foreach (var product in products)
            {
                product.DisplayInfo();
            }
            Console.ReadLine();
        }

        static void MakeSale()
        {
            Console.Clear();
            Console.WriteLine("=== Satış Yapma ===");

            Console.Write("Satış yapmak istedeiğiniz ürünün adını girin: ");
            string name = Console.ReadLine();

            Product productToSell = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (productToSell != null)
            {
                Console.Write("Satılan Miktar: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                if (productToSell.Stock >= quantity)
                {
                    productToSell.Stock -= quantity;
                    Console.WriteLine($"Satış başarıyla gerçekleştirildi. Satılan miktar: {quantity}");
                }
                else
                {
                    Console.WriteLine("Yetersiz stok.");
                }
            }
            else
            {
                Console.WriteLine("Ürün bulunamadı.");
            }
            Console.ReadLine();
        }
    }
}
