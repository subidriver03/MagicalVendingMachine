using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace MagicalVendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingItems = GetVendingItems();
            bool keepRunning = true;

            var ItemsPrices = getItemsPrices();
            int Balance = 0;
            string ItemPurchased = string.Empty;
            int selection;
            bool EnoughMoney;

            DisplayWelcomeMessage(vendingItems, ItemsPrices);

            while (keepRunning)
            {
                Console.Clear();

                EnoughMoney = CheckBalance(ItemsPrices.Min());

                if (!EnoughMoney)
                {
                    break;
                }
                Balance = Bank.GetBalance();
                DisplayVendingOptions(vendingItems, ItemsPrices);
                selection = GetUserSelection(vendingItems.Count);

                if (Balance < ItemsPrices[selection - 1])
                {
                    Console.Clear();
                    Console.WriteLine("You don't have enough coins to purchase this item");
                    Console.WriteLine($"Balance: {Balance} MC");
                }
                else
                {
                    Console.Clear();
                    ItemPurchased = VendItem(selection, vendingItems, ItemsPrices);

                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        VendLog(ItemPurchased, w);
                    }
                }

                keepRunning = AskToContinue();
            }

            Balance = Bank.GetBalance();

            if (Balance != 0)
            {
                Console.WriteLine();
                Console.WriteLine("press any key to go to the bank to return the coin(s) left");
                Console.ReadKey();
                TerminateShopping(Balance);
            }

            Console.WriteLine();
            Console.WriteLine("Thank you for using the Magical Vending Machine. Have a great day!");
        }

        static List<int> getItemsPrices()
        {
            return new List<int>
            {
                30, //"Elixir of Eternal Stamina"
                26, //"Mana Crystal"
                10, //"Shadow Warrior's Ring"
                7, //"Gate Key"
                32, //"Sung Jin-Woo's Cloak of Shadows"
                68, //"Potion of Instant Recovery"
                35, //"Demon Kings Daggers"
                42, //"Sung Jin-Woo's Sense of Humor"
                37, //"A DATE FOR SUNG JIN-WOO!!! (Inflatable)"
                74 //"Statue Of God (Double dungeon version)"
            };
        }

        static void TerminateShopping(int Balance)
        {
            decimal CashAmount;

            Console.Clear();
            Console.WriteLine("Welcome back to the Exchange Bank!");
            CashAmount = Bank.CloseAccount();
            Console.WriteLine();
            Console.WriteLine($"Exchanged: {Balance} MC     Cash Rendered: {CashAmount.ToString("C")}");
            Console.WriteLine();

        }

        static void GetInitialBalance()
        {
            decimal CashAmount = 0;
            int Balance = 0;
            string UserInput;

            Console.WriteLine("Welcome to the Exchange Bank!");
            Console.WriteLine();
            Console.Write("Exchange Rate: ");
            Console.WriteLine(1.ToString("C") + " = 4 MC");
            Console.WriteLine();
            Console.Write("How much cash to you want to exchange: ");

            UserInput = Console.ReadLine();

            while (!decimal.TryParse(UserInput, out CashAmount) || CashAmount <= 0)
            {
                Console.Write("invalid input. Try again: ");
                UserInput = Console.ReadLine();
            }

            Bank.SetBalance(CashAmount);
            Balance = Bank.GetBalance();
            Console.WriteLine();
            Console.WriteLine($"your balance: {Balance} MC");

        }

        static bool CheckBalance(int MinimumPrice)
        {
            int Balance;
            bool EnoughMoney = true;

            Balance = Bank.GetBalance();

            if (Balance == 0)
            {
                EnoughMoney = false;
                Console.WriteLine("Sorry, you have no more coins to continue shopping.");
                Console.WriteLine($"Balance: {Balance} MC");
            }
            else if (Balance < MinimumPrice)
            {
                EnoughMoney = false;
                Console.WriteLine("Sorry, you no longer have enough coins to continue shopping");
                Console.WriteLine($"Balance: {Balance} MC");

            }
            return EnoughMoney;
        }


        static void DisplayWelcomeMessage(List<string> items, List<int> prices)
        {
            Console.WriteLine("Welcome to the Magical Vending Machine " +
                "from Solo Leveling!");
            Console.WriteLine();

            DisplayVendingOptions(items, prices);

            Console.WriteLine();
            Console.WriteLine("you need to get some Magical Coins (MC) " +
            "in order to purchase any item.");
            Console.WriteLine();
            Console.WriteLine("press any key to go " +
                "to the Bank to get some magical coins");
            Console.ReadKey();
            Console.Clear();
            GetInitialBalance();
            Console.WriteLine("press any key to  start shopping");
            Console.ReadKey();

        }

        static List<string> GetVendingItems()
        {
            return new List<string>
            {
                "elixir of eternal stamina",
                "mana crystal",
                "shadow warrior's ring",
                "gate key",
                "sung jin-woo's cloak of shadows",
                "potion of instant recovery",
                "demon kings daggers",
                "sung jin-woo's sense of humor",
                "a date for sung jin-woo!!! (inflatable)",
                "statue of god (double dungeon version)"
            };
        }

        static void DisplayVendingOptions(List<string> items, List<int> prices)
        {
            Console.WriteLine("\navailable items:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write($"{i + 1}. {items[i]}: ");
                Console.WriteLine($"{prices[i]} MC");
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

        static string VendItem(int selection, List<string> items, List<int> ItemsPrices)
        {
            string item = items[selection - 1];

            int ItemPrice = ItemsPrices[selection - 1];
            int Balance;

            Bank.UpdateBalance(ItemPrice);
            Balance = Bank.GetBalance();
            Console.WriteLine($"\nVending... {item} for {ItemPrice} MC");
            Console.WriteLine($"Balance: {Balance} MC");
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
