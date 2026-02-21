using System;
using InventoryApp.Services;

namespace InventoryApp.Views
{
    public class InventoryView
    {
        private InventoryService service;

        public InventoryView()
        {
            service = new InventoryService();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== INVENTORY MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewInventory();
                        break;

                    case "2":
                        UpdateStock();
                        break;

                    case "3":
                        service.ResetInventory();
                        Console.WriteLine("Inventory has been reset to original values.");
                        Pause();
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Pause();
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            Console.Clear();
            string[,] products = service.GetInventory();

            Console.WriteLine("Product\tStock");
            Console.WriteLine("----------------");

            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]}\t{products[1, i]}");
            }

            Pause();
        }

        private void UpdateStock()
        {
            Console.Clear();
            string[,] products = service.GetInventory();

            Console.WriteLine("Select product to update:");

            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]}");
            }

            Console.Write("Enter product number: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter new stock quantity: ");
            string newStock = Console.ReadLine();

            service.UpdateStock(index, newStock);

            Console.WriteLine("Stock updated successfully!");
            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
