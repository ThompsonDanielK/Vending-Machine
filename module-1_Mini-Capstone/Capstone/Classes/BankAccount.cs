using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class BankAccount
    {
        public decimal Balance { get; private set; } = 0M;

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
        public void SetBalanceToZero()
        {
            this.Balance = 0M;
        }

        public void SubtractFromBalance(decimal price)
        {
            Balance -= price;
        }

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
