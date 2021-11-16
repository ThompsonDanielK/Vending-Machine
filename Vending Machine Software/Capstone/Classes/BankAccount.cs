using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class BankAccount
    {
        public decimal Balance { get; private set; } = 0M;

        /// <summary>
        /// Adds money to balance and returns false if balance would exceed $4200
        /// </summary>
        /// <param name="deposit"></param>
        /// <returns>bool</returns>
        public bool AddMoney(decimal deposit)
        {
            if (Balance + deposit > 4200M)
            {
                Balance = 4200M;
                return false;                
            }

            Balance += deposit;
            return true;
        }

        /// <summary>
        /// Sets balance to 0
        /// </summary>
        public void SetBalanceToZero()
        {
            this.Balance = 0M;
        }

        /// <summary>
        /// Subtracts price from balance
        /// </summary>
        /// <param name="price"></param>
        public void SubtractFromBalance(decimal price)
        {
            Balance -= price;
        }

        /// <summary>
        /// Breaks users change into the smallest amount of bills and coins
        /// </summary>
        /// <param name="changeAmount"></param>
        /// <returns>string</returns>
        public string MakeChange(decimal changeAmount)
        {
            decimal change = changeAmount;

            int twenties = decimal.ToInt32(change / 20M);
            change = decimal.Remainder(change, 20M);
            
            int tens = decimal.ToInt32(change / 10M);
            change = decimal.Remainder(change, 10M);

            int fives = decimal.ToInt32(change / 5M);
            change = decimal.Remainder(change, 5M);

            int ones = decimal.ToInt32(change);
            change = decimal.Remainder(change, 1M);

            int quarters = decimal.ToInt32(change / 0.25M);
            change = decimal.Remainder(change, 0.25M);

            int dimes = decimal.ToInt32(change / 0.10M);
            change = decimal.Remainder(change, 0.10M);

            int nickels = decimal.ToInt32(change / 0.05M);
            change = decimal.Remainder(change, 0.05M);

            return $"Twenties: {twenties}\nTens: {tens}\nFives: {fives}\nOnes: {ones}\nQuarters: {quarters}\nDimes: {dimes}\nNickels: {nickels}";

        }
    }
}
