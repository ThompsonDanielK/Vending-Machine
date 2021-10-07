using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    public class UserInterface
    {

            Catering catering = new Catering();
            BankAccount bankAccount = new BankAccount();
            FileAccess fileAccess = new FileAccess();
        public void RunMainMenu()
        {
            //Run input file method to create inventory
            fileAccess.ReadInventoryFile(catering);




            bool done = false;

            while (!done)
            {

                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");

                string userInput = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        foreach (CateringItem item in catering.items)
                        {
                            Console.WriteLine(item.DisplayInfo());
                        }
                        break;

                    case "2":
                        PurchaseMenu();
                        break;

                    case "3":
                        done = true;
                        break;
                }
                Console.WriteLine();

            }
        }
        public void PurchaseMenu()
        {
            bool done = false;

            while (!done)
            {

                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
                Console.WriteLine($"Current Account Balance: {bankAccount.Balance.ToString("C")}");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Banking app
                        Console.Write("How much money would you like to deposit: ");                        
                        decimal depositAmount = decimal.Parse(Console.ReadLine());;
                        decimal overageAmount = bankAccount.Balance + depositAmount - 4200M;
                        if (!bankAccount.AddMoney(depositAmount))
                        {
                            Console.WriteLine($"You can only have a maximum of $4,200");
                            Console.WriteLine($"Only {(depositAmount - overageAmount).ToString("C")} was deposited to your account.");
                        }
                        else
                        {
                            Console.WriteLine($"{depositAmount.ToString("C")} has been deposited to your account.");
                        }
                        break;

                    case "2":
                        //Catering app
                        break;

                    case "3":
                        //Closing actions
                        done = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
