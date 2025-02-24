using System.IO;
using System.Collections.Generic;
using System.Reflection;

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
                string item = VendItem(selection, vendingItems);

                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    VendLog(item, w);
                }

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
                "Potion of Instant Recovery",
                "Demon Kings Daggers",
                "Sung Jin-Woo's Sense of Humor",
                "A DATE FOR SUNG JIN-WOO!!! (Inflatable)",
                "Statue Of God (Double dungeon version)"
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

        static string VendItem(int selection, List<string> items)
        {
            string item = items[selection - 1];
            Console.WriteLine($"\nVending... {item}");
            Console.WriteLine("Enjoy your magical item!\n");
            return item;
        }

        static void VendLog(string logMessage, TextWriter w)
        {
            w.WriteLine($"Item aquired {logMessage}" + $"  ::  {DateTime.Now.ToLongTimeString()} | {DateTime.Now.ToLongDateString()}");
        }

        static bool AskToContinue() 
        {
            ConsoleKeyInfo KeyPressed = new ConsoleKeyInfo();

            Console.WriteLine();
            Console.Write("Would you like to select another item? ");
            Console.WriteLine("Press '1' for yes or '2' for no");

            do
            {
                KeyPressed = Console.ReadKey(true);

            } while (KeyPressed.Key != ConsoleKey.D1 && KeyPressed.Key != ConsoleKey.D2);

            if (KeyPressed.Key == ConsoleKey.D1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
