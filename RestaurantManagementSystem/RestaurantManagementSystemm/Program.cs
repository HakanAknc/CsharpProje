using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystemm
{
    public class Program
    {

        static List<MenuItem> menuList = new List<MenuItem>();              // Menu Listesi
        static List<Ingredient> ingredientList = new List<Ingredient>();   // Erzak Listesi
        static List<Order> orderList = new List<Order>();                  // Sipariş Listesi
        static int orderCounter = 1;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Restorant Yönetim Sistemi ===");
                Console.WriteLine("1. Menü Yönetim");
                Console.WriteLine("2. Erzak Yönetim");
                Console.WriteLine("3. Sipariş Yönetim");
                Console.WriteLine("4. Çıkış");
                Console.Write("Seçiminizi yapın: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageMenu();
                        break;
                    case "2":
                        ManageIngredients();
                        break;
                    case "3":
                        ManageOrders();
                        break;
                    case "4":
                        Console.WriteLine("Çıkış yapılıyor.");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim lütfen tekrar deniyin.");
                        break;
                }
                Console.WriteLine("Devam etmek için bir tuşa basın.");
                Console.ReadKey();
            }
        }

        static void ManageOrders()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sipariş Yönetimi ===");
                Console.WriteLine("1. Sipariş Listele");
                Console.WriteLine("2. Sipariş Ekle");
                Console.WriteLine("3. Sipariş Sil");
                Console.WriteLine("4. Geri Dön");
                Console.Write("Seçiminizi yapın: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListOrders();
                        break;
                    case "2":
                        AddOrder();
                        break;
                    case "3":
                        DeleteOrder();
                        break;
                    case "4":
                        return; // Ana menüye geri dön
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                        break;
                }

                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        // Sipariş Listeleme
        static void ListOrders()
        {
            Console.Clear();
            Console.WriteLine("=== Sipariş Listesi ===");
            if (orderList.Count == 0)
            {
                Console.WriteLine("Hiç sipariş bulunmamaktadır.");
            }
            else
            {
                foreach (var order in orderList)
                {
                    Console.WriteLine($"Sipariş ID: {order.OrderId}, Müşteri: {order.CustomerName}, Ürün: {order.MenuItem}, Miktar: {order.Quantity}, Toplam Fiyat: {order.TotalPrice} TL");
                }
            }
        }

        // Yeni Sipariş Ekleme
        static void AddOrder()
        {
            Console.Write("Müşteri adı: ");
            string customerName = Console.ReadLine();

            Console.Write("Sipariş edilen ürün: ");
            string menuItem = Console.ReadLine();

            Console.Write("Sipariş miktarı: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Ürün birim fiyatı: ");
            double pricePerItem = double.Parse(Console.ReadLine());

            double totalPrice = quantity * pricePerItem;

            orderList.Add(new Order(orderCounter, customerName, menuItem, quantity, totalPrice));
            Console.WriteLine($"Sipariş başarıyla eklendi! Sipariş ID: {orderCounter}");
            orderCounter++; // Sipariş ID'sini artır
        }

        // Sipariş Silme
        static void DeleteOrder()
        {
            ListOrders();
            Console.Write("Silmek istediğiniz sipariş ID'sini girin: ");
            int orderId = int.Parse(Console.ReadLine());

            var orderToRemove = orderList.Find(o => o.OrderId == orderId);
            if (orderToRemove != null)
            {
                orderList.Remove(orderToRemove);
                Console.WriteLine("Sipariş başarıyla silindi!");
            }
            else
            {
                Console.WriteLine("Geçersiz sipariş ID'si!");
            }
        }

        static void ManageIngredients()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("=== Erzak Yönetimi ===");
                Console.WriteLine("1. Erzak Listele");
                Console.WriteLine("2. Yeni Erzak Ekle");
                Console.WriteLine("3. Erzak Güncelle");
                Console.WriteLine("4. Erzak Sil");
                Console.WriteLine("5. Geri Dön");
                Console.Write("Seçiminizi yapın: ");

                string coice = Console.ReadLine();

                switch (coice)
                {
                    case "1":
                        ListIngredients();
                        break;
                    case "2":
                        AddIngredient();
                        break;
                    case "3":
                        UpdateIngredient();
                        break;
                    case "4":
                        DeleteIngredient();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar denyin.");
                        break;
                }
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        // Erzak Listeleme
        static void ListIngredients()
        {
            Console.Clear();
            Console.WriteLine("=== Erzak Listesi ===");
            if (ingredientList.Count == 0)
            {
                Console.WriteLine("Hiç erzak bulunmamaktadır..");
            }
            else
            {
                for (int i = 0; i < ingredientList.Count; i++)
                {
                    var ingredient = ingredientList[i];
                    Console.WriteLine($"{i + 1}. {ingredient.Name} - {ingredient.Quantity} adet");
                }
            }
        }

        // Yeni Erzak Ekleme
        static void AddIngredient()
        {
            Console.Write("Erzak adı: ");
            string name = Console.ReadLine();

            Console.WriteLine("Erzak miktarı: ");
            int quantity = int.Parse(Console.ReadLine());

            ingredientList.Add(new Ingredient(name, quantity));
            Console.WriteLine("Erzak başarıyla eklendi.");
        }

        // Erzak Güncelleme
        static void UpdateIngredient()
        {
            ListIngredients();
            Console.WriteLine("Güncellemek istediğiniz erzak numarasını seçin: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < ingredientList.Count)
            {
                Console.Write("Yeni miktarı girin: ");
                int newQuantity = int.Parse(Console.ReadLine());

                ingredientList[index].Quantity = newQuantity;
                Console.WriteLine("Erzak başarıyla güncellendi!");
            }
            else
            {
                Console.WriteLine("Geçeersiz bir işlem!");
            }
        }

        // Erzak Silme
        static void DeleteIngredient()
        {
            ListIngredients();
            Console.Write("Silmek istediğiniz erzak numarasını seçin: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < ingredientList.Count)
            {
                ingredientList.RemoveAt(index);
                Console.WriteLine("Erzak başarıyla silindi!");
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }

        static void ManageMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menü Yönetim ===");
                Console.WriteLine("1. Menü Listele");
                Console.WriteLine("2. Yeni Menü Ekle");
                Console.WriteLine("3. Alt Menü Ekle");
                Console.WriteLine("4. Geri Dön");
                Console.Write("Seçiminizi yapın: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListMenu(menuList, 0);
                        break;
                    case "2":
                        AddMenu();
                        break;
                    case "3":
                        AddSubMenu();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                        break;
                }
                Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                Console.ReadKey();
            }
        }

        // Menü Listeleme
        static void ListMenu(List<MenuItem> menu, int level)
        {
            foreach (var item in menu)
            {
                Console.WriteLine(new string('-', level * 2) + $" {item.Name} - {item.Price:C} - {item.Description}");
                if (item.SubMenu.Count > 0)
                {
                    ListMenu(item.SubMenu, level + 1); // Alt menüleri listele
                }
            }
        }

        // Yeni Menü Ekleme
        static void AddMenu()
        {
            Console.WriteLine("Menü Adı: ");
            string name = Console.ReadLine();

            Console.WriteLine("Fiyat: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Açıklama: ");
            string description = Console.ReadLine();
            
            menuList.Add(new MenuItem(name, price, description));
            Console.WriteLine("Menü başarıyla eklendi.");
        }

        // Alt Menü Ekleme
        static void AddSubMenu()
        {
            Console.Write("Alt menü eklemek istediğiniz ana menüyü seçin: ");
            ListMenu(menuList, 0);
            Console.Write("Ana menü numarasını girin (0'dan başlayarak): ");
            int index = int.Parse(Console.ReadLine());

            if(index >= 0 && index < menuList.Count)
            {
                Console.Write("Alt menü adı: ");
                string name = Console.ReadLine();

                Console.Write("Fiyat: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Açıklama: ");
                string description = Console.ReadLine();

                menuList[index].SubMenu.Add(new MenuItem(name, price, description));
                Console.WriteLine("Alt menü başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Geçersiz ana menü seçimi");
            }
        }
    }
}
