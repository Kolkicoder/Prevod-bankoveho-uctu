using System;
using System.Collections.Generic;

namespace BankAccountTransfer
{
    internal class Calculator : Movies
    {
        public decimal CalculateSnacks(Dictionary<string, int> snacks)
        {
            decimal total = 0;

            foreach (var snack in snacks)
            {
                if (snack.Key == "Popcorn")
                    total += snack.Value * 2m;
                else if (snack.Key == "Nachos")
                    total += snack.Value * 2.5m;
                else if (snack.Key == "Sweets")
                    total += snack.Value * 1m;
                else if (snack.Key == "Drinks")
                    total += snack.Value * 2.5m;
            }

            return total;
        }

        public decimal CalculateTotal(decimal moviePrice, Dictionary<string, int> snacks)
        {
            return moviePrice + CalculateSnacks(snacks);
        }
    }
}