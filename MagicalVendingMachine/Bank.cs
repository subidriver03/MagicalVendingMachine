using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalVendingMachine
{
    public static class Bank
    {
        private static int _balance;

        private static int ConvertCashToMagicalCoins(decimal Amount)
        {
            int CoinsCount = 0;

            while (Amount >= 0.25M)
            {
                Amount -= 0.25M;
                CoinsCount++;
            }
            return CoinsCount;
        }

        private static decimal ConvertMagicalCoinsToCash(int CoinsCount)
        {
            decimal Amount = 0;

            Amount = (decimal)CoinsCount / 4;
            return Amount;
        }

        public static void SetBalance(decimal Amount)
        {
            _balance = ConvertCashToMagicalCoins(Amount);
        }

        public static int GetBalance()
        {
            return _balance;
        }

        public static void UpdateBalance(int CoinsCount)
        {
            _balance -= CoinsCount;
        }

        public static decimal CloseAccount()
        {
            decimal Amount = 0;

            Amount = ConvertMagicalCoinsToCash(_balance);
            return Amount;
        }

    }
}
