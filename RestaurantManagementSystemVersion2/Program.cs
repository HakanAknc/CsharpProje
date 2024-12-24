using System;
using System.Collections.Generic;

namespace Restorant
{
    public class Program
    {
        static List<MenuItem> menuList = new List<MenuItem>();
        static List<Ingredient> ingredientList = new List<Ingredient>();
        static List<Order> orderList = new List<Order>();
        static int orderCounter = 1;
        static void Main(string[] args)
        {

            //menuList.Add(new MenuItem { Name = "Ramazan", Price = 450, Description = "İftar", AnaYemek = "Kebap", Tatli = "Kemalpaşa", Icecek = "Ayran" });

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Resttaurant Management System ===");
                Console.WriteLine("1. Menu Management");
                Console.WriteLine("2. Ingredient Management");
                Console.WriteLine("3. Order Management");
                Console.WriteLine("4. Exit");
                Console.Write("Select the action you want to perform (1-4): ");

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
                        Console.WriteLine("Signing out...");
                        return;
                    case "5":
                        Console.WriteLine("Invalid selection please try again.");
                        break;
                }
                Console.Write("Press any key to continue.");
                Console.ReadKey();
            }
        }

        // ORDER
        static void ManageOrders()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Order Management ===");
                Console.WriteLine("1. List Order");
                Console.WriteLine("2. Add Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. Go back");
                Console.Write("Select the action you want to perform: ");

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
                        return;
                    default:
                        Console.WriteLine("Invalid selection! Please try again.");
                        break;
                }
                Console.Write("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void ListOrders()
        {
            Console.Clear();
            Console.WriteLine("=== Order List ===");
            if (orderList.Count == 0)
            {
                Console.WriteLine("There are no orders.");
            }
            else
            {
                foreach (var order in orderList)
                {
                    Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.CustomerName}, Product: {order.MenuItem}, Amount: {order.Quantity}, Total Price: {order.TotalPrice} TL");
                }
            }
        }
        static bool CheckIngredients(string menuItem, int quantity)
        {
            foreach (var ingredient in ingredientList)
            {
                if (ingredient.Name.Equals(menuItem, StringComparison.OrdinalIgnoreCase))
                {
                    if (ingredient.Quantity >= quantity)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Insufficient stock for ingredient: {ingredient.Name}");
                        return false;
                    }
                }
            }

            Console.WriteLine($"Ingredient '{menuItem}' is not available in stock.");
            return false; 
        }

        static void UpdateIngredientStock(string menuItem, int quantity)
        {
            foreach (var ingredient in ingredientList)
            {
                if (ingredient.Name.Equals(menuItem, StringComparison.OrdinalIgnoreCase))
                {
                    ingredient.Quantity -= quantity;
                    Console.WriteLine($"Stock updated: {ingredient.Name} - Remaining: {ingredient.Quantity}");
                    return;
                }
            }
        }


        static void AddOrder()
        {
            Console.Write("Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Ordered Product: ");
            string menuItem = Console.ReadLine();

            Console.Write("Order Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            bool isAvailable = CheckIngredients(menuItem, quantity);

            if (!isAvailable)
            {
                Console.WriteLine("We cannot process the order as the required ingredients are not available in stock.");
                return;
            }

            Console.Write("Product Price: ");
            double pricePerItem = double.Parse(Console.ReadLine());

            double totalPrice = quantity * pricePerItem;

            orderList.Add(new Order(orderCounter, customerName, menuItem, quantity, totalPrice));
            Console.WriteLine($"Order added successfully! Order ID: {orderCounter}");

            UpdateIngredientStock(menuItem, quantity);

            orderCounter++;
        }

        static void DeleteOrder()
        {
            ListOrders();
            Console.Write("Enter the order ID you want to delete: ");
            int orderId = int.Parse(Console.ReadLine());

            var orderToRemove = orderList.Find(o => o.OrderId == orderId);
            if (orderToRemove != null)
            {
                orderList.Remove(orderToRemove);
                Console.WriteLine("Order deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid order ID!");
            }
        }

        // INGREDİENT
        static void ManageIngredients()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Ingredient Management ===");
                Console.WriteLine("1. List Ingredient");
                Console.WriteLine("2. Add new Ingredient");
                Console.WriteLine("3. Update Ingredient");
                Console.WriteLine("4. Delete Ingredient");
                Console.WriteLine("5. Go back");
                Console.WriteLine("Select the action you want to perform: ");

                string choice = Console.ReadLine();

                switch (choice)
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
                        Console.WriteLine("Invalid selection! Please try again.");
                        break;
                }
                Console.Write("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void ListIngredients()
        {
            Console.Clear();
            Console.WriteLine("=== List Ingredient ===");
            if (ingredientList.Count == 0)
            {
                Console.WriteLine("There are no ingredients");
            }
            else
            {
                for (int i = 0; i < ingredientList.Count; i++)
                {
                    var ingredient = ingredientList[i];
                    Console.WriteLine($"{i + 1}. {ingredient.Name} - {ingredient.Quantity} piece");
                }
            }
        }

        static void AddIngredient()
        {
            Console.Write("Ingredients Name: ");
            string name = Console.ReadLine();

            Console.Write("Ingredient quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            ingredientList.Add(new Ingredient(name, quantity));
            Console.WriteLine("Ingredients added successfully.");
        }

        static void UpdateIngredient()
        {
            ListIngredients();
            Console.WriteLine("Select the ingredient number you want to update: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < ingredientList.Count)
            {
                Console.Write("Enter the new ingredient amount: ");
                int newQuantity = int.Parse(Console.ReadLine());

                ingredientList[index].Quantity = newQuantity;
                Console.WriteLine("Ingredients have been successfully updated!");
            }
            else
            {
                Console.WriteLine("An invalid transaction!");
            }
        }

        static void DeleteIngredient()
        {
            ListIngredients();
            Console.Write("Select the ingredient number you want to delete: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < ingredientList.Count)
            {
                ingredientList.RemoveAt(index);
                Console.WriteLine("Ingredients successfully deleted!");
            }
            else
            {
                Console.WriteLine("Invalid selection!");
            }
        }

        //MENU
        static void ManageMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Management ===");
                Console.WriteLine("1. List Menu");
                Console.WriteLine("2. Add New Menu");
                Console.WriteLine("3. Add Sub Menu");
                Console.WriteLine("4. Go back");
                Console.Write("Select the action you want to perform: ");

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
                        Console.WriteLine("Invalid selection! Please try again.");
                        break ;
                        
                }
                Console.Write("Press any key to continue.");
                Console.ReadKey();
            }
        }

        static void ListMenu(List<MenuItem> menu, int level)
        {
            foreach (var item in menu)
            {
                Console.WriteLine(new string('-', level * 6) + $" {item.Name} - {item.Price}TL - {item.Description}\n - {item.AnaYemek}\n - {item.Tatli}\n - {item.Icecek}");
                if (item.SubMenu.Count > 0)
                {
                    ListMenu(item.SubMenu, level + 1);

                }
            }
        }

        static void AddMenu()
        {
            Console.Clear();
            Console.Write("Menu Name: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Explanation: ");
            string description = Console.ReadLine();

            Console.Write("Yemek: ");
            string anayemek = Console.ReadLine();

            Console.Write("Tatlı: ");
            string tatli = Console.ReadLine();

            Console.Write("İçecek: ");
            string icecek = Console.ReadLine();

            menuList.Add(new MenuItem(name, price, description, anayemek, tatli, icecek));
            Console.WriteLine("Menu added successfully.");
        }

        static void AddSubMenu()
        {
            Console.Clear();
            Console.Write("Select the main menu to which you want to add a submenu: ");
            ListMenu(menuList, 0);
            Console.WriteLine("Enter the main menu number (starting from 0)");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < menuList.Count)
            {
                Console.Write("Submenu name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                int price = int.Parse(Console.ReadLine());

                Console.Write("Explanation: ");
                string description = Console.ReadLine();

                Console.Write("Ana Yemek: ");
                string anayemek = Console.ReadLine();

                Console.Write("Tatli: ");
                string tatli = Console.ReadLine();

                Console.Write("İçecek: ");
                string icecek = Console.ReadLine();

                menuList[index].SubMenu.Add(new MenuItem(name, price, description, anayemek, tatli, icecek));
                Console.WriteLine("Submenu added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid main menu selection.");
            }
        }
    }
}
