using System;
using System.Collections.Generic;



namespace MagicalVendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();

            var vendingItems = GetVendingItems();
            bool keepRunning = true;

            while (keepRunning)
            {
                DisplayVendingOptions(vendingItems);
                int selection = GetUserSelection(vendingItems.Count);
                VendItem(selection, vendingItems);

                keepRunning = AskToContinue();
            }

            Console.WriteLine("Thank you for using the Magical Vending Machine. Have a great day!");
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Magical Vending Machine from Solo Leveling!");
        }

        static List<string> GetVendingItems()
        {
            return new List<string>
            {
                "Elixir of Eternal Stamina",
                "Mana Crystal",
                "Shadow Warrior's Ring",
                "Gate Key",
                "Sung Jin-Woo's Cloak of Shadows",
                "Potion of Instant Recovery"
            };
        }

        static void DisplayVendingOptions(List<string> items)
        {
            Console.WriteLine("\nAvailable Items:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
        }

        static int GetUserSelection(int itemCount)
        {
            int selection;
            while (true)
            {
                Console.Write("\nEnter the number of your selection: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out selection) && selection >= 1 && selection <= itemCount)
                {
                    break;
                }
                Console.WriteLine("Invalid selection. Please enter a valid number.");
            }
            return selection;
        }

        static void VendItem(int selection, List<string> items)
        {
            string item = items[selection - 1];
            Console.WriteLine($"\nVending... {item}");
            Console.WriteLine("Enjoy your magical item!\n");
        }

        static bool AskToContinue()
        {
            Console.Write("Would you like to select another item? (yes/no): ");
            string response = Console.ReadLine()?.Trim().ToLower();
            return response == "yes" || response == "y";
        }
    }
}
