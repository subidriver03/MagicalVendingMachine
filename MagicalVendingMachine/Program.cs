using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MagicalVendingMachine
{
    class Program
    {
        private static readonly string inventoryFile = "inventory.json";

        static void Main()
        {
            var vendingItems = LoadInventory();
            bool keepRunning = true;
            var itemsPrices = GetItemsPrices();

            DisplayWelcomeMessage(vendingItems, itemsPrices);

            while (keepRunning)
            {
                Console.Clear();
                if (!CheckBalance(itemsPrices.Min())) break;

                DisplayVendingOptions(vendingItems, itemsPrices);
                int selection = GetUserSelection(vendingItems.Count);

                if (Bank.GetBalance() < itemsPrices[selection - 1])
                {
                    Console.Clear();
                    Console.WriteLine($"You don't have enough coins to purchase this item.\nBalance: {Bank.GetBalance()} MC");
                    continue;
                }

                if (vendingItems[selection - 1].Stock <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Sorry, {vendingItems[selection - 1].Name} is out of stock!");
                    continue;
                }

                Console.Clear();
                string itemPurchased = VendItem(selection, vendingItems, itemsPrices);

                using (StreamWriter w = File.AppendText("log.txt"))
                    VendLog(itemPurchased, w);

                SaveInventory(vendingItems);
                keepRunning = AskToContinue();
            }

            if (Bank.GetBalance() > 0)
            {
                Console.WriteLine("\nPress any key to go to the bank to return the coin(s) left.");
                Console.ReadKey();
                TerminateShopping(Bank.GetBalance());
            }

            Console.WriteLine("\nThank you for using the Magical Vending Machine. Have a great day!");
        }

        static List<VendingItem> LoadInventory()
        {
            if (!File.Exists(inventoryFile))
            {
                var defaultItems = GetDefaultVendingItems();
                SaveInventory(defaultItems);
                return defaultItems;
            }

            string json = File.ReadAllText(inventoryFile);
            return JsonConvert.DeserializeObject<List<VendingItem>>(json) ?? GetDefaultVendingItems();
        }

        static void SaveInventory(List<VendingItem> inventory) =>
            File.WriteAllText(inventoryFile, JsonConvert.SerializeObject(inventory, Formatting.Indented));

        static List<int> GetItemsPrices() => new() { 30, 26, 10, 7, 32, 68, 35, 42, 37, 74 };

        static void TerminateShopping(int balance)
        {
            Console.Clear();
            Console.WriteLine("Welcome back to the Exchange Bank!");
            Console.WriteLine($"\nExchanged: {balance} MC     Cash Rendered: {Bank.CloseAccount():C}\n");
        }

        static bool CheckBalance(int minimumPrice)
        {
            int balance = Bank.GetBalance();
            if (balance < minimumPrice)
            {
                Console.WriteLine($"Sorry, you do not have enough coins to continue shopping.\nBalance: {balance} MC");
                return false;
            }
            return true;
        }

        static void DisplayWelcomeMessage(List<VendingItem> items, List<int> prices)
        {
            Console.WriteLine("Welcome to the Magical Vending Machine from Solo Leveling!\n");
            DisplayVendingOptions(items, prices);
            Console.WriteLine("\nYou need to get some Magical Coins (MC) in order to purchase any item.");
            Console.WriteLine("\nPress any key to go to the Bank to get some magical coins.");
            Console.ReadKey();
            Console.Clear();
            GetInitialBalance();
            Console.WriteLine("Press any key to start shopping.");
            Console.ReadKey();
        }

        static void GetInitialBalance()
        {
            Console.WriteLine("Welcome to the Exchange Bank!");
            Console.WriteLine("\nExchange Rate: 1 USD = 4 MC");
            Console.Write("\nHow much cash do you want to exchange? ");

            decimal cashAmount;
            while (!decimal.TryParse(Console.ReadLine(), out cashAmount) || cashAmount <= 0)
                Console.Write("Invalid input. Try again: ");

            Bank.SetBalance(cashAmount);
            Console.WriteLine($"\nYour balance: {Bank.GetBalance()} MC");
        }

        static void DisplayVendingOptions(List<VendingItem> items, List<int> prices)
        {
            Console.WriteLine("\nAvailable items:");
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine($"{i + 1}. {items[i].Name}: {prices[i]} MC [Stock: {items[i].Stock}]");
        }

        static int GetUserSelection(int itemCount)
        {
            while (true)
            {
                Console.Write("\nEnter the number of your selection: ");
                if (int.TryParse(Console.ReadLine(), out int selection) && selection >= 1 && selection <= itemCount)
                    return selection;
                Console.WriteLine("Invalid selection. Please enter a valid number.");
            }
        }

        static string VendItem(int selection, List<VendingItem> items, List<int> itemsPrices)
        {
            var item = items[selection - 1];

            Bank.UpdateBalance(itemsPrices[selection - 1]);
            item.Stock--;

            SaveInventory(items);

            Console.WriteLine($"\nVending... {item.Name} for {itemsPrices[selection - 1]} MC");
            Console.WriteLine($"Balance: {Bank.GetBalance()} MC");
            Console.WriteLine("Enjoy your magical item!\n");

            return item.Name;
        }

        static void VendLog(string logMessage, TextWriter w) =>
            w.WriteLine($"Item acquired: {logMessage}  ::  {DateTime.Now.ToLongTimeString()} | {DateTime.Now.ToLongDateString()}");

        static bool AskToContinue()
        {
            Console.WriteLine("\nWould you like to select another item? Press '1' for yes or '2' for no.");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1) return true;
                if (key == ConsoleKey.D2) return false;
            }
        }

        static List<VendingItem> GetDefaultVendingItems() => new()
        {
            new("Elixir of Eternal Stamina", 5),
            new("Mana Crystal", 5),
            new("Shadow Warrior's Ring", 5),
            new("Gate Key", 5),
            new("Sung Jin-Woo's Cloak of Shadows", 5),
            new("Potion of Instant Recovery", 5),
            new("Demon Kings Daggers", 5),
            new("Sung Jin-Woo's Sense of Humor", 5),
            new("A DATE FOR SUNG JIN-WOO!!! (Inflatable)", 5),
            new("Statue Of God (Double Dungeon Version)", 5)
        };
    }

    class VendingItem
    {
        public string Name { get; }
        public int Stock { get; set; }

        public VendingItem(string name, int stock)
        {
            Name = name;
            Stock = stock;
        }
    }
}
