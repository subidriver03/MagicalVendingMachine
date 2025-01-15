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
            DisplayVendingOptions(vendingItems);
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
    }
}
