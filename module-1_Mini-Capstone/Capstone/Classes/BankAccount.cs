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


    }
}
