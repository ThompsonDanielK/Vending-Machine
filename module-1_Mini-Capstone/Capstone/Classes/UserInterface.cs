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
        //Instantiate objects for Catering, BankAccount, and FileAccess classes
        Catering catering = new Catering();
        BankAccount bankAccount = new BankAccount();
        FileAccess fileAccess = new FileAccess();
        public void RunMainMenu()
        {
            //Run input file method to create inventory list in Catering
            fileAccess.ReadInventoryFile(catering);
            
            //Display Main Menu, ask for user input, loop through until Quit selected
            bool done = false;
            while (!done)
            {

                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");
                Console.WriteLine();
                Console.Write("Please enter a selection: ");
                string userInput = Console.ReadLine();
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
            //Display Order Menu, get user input, loop through until Complete Transaction selected
            bool done = false;

            while (!done)
            {
                decimal runningBalance = bankAccount.Balance;

                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
                Console.WriteLine($"Current Account Balance: {runningBalance.ToString("C")}");
                Console.WriteLine();
                Console.Write("Please enter a selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Banking app
                        try
                        {

                            Console.Write("How much money would you like to deposit: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine()); ;
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
                            Console.WriteLine();
                        }
                        catch (FormatException exc)
                        {
                            Console.WriteLine("Please enter a valid deposit amount.");
                            Console.WriteLine();
                        }
                        break;

                    case "2":
                        //Catering app
                        Console.Write("Please input a product ID: ");
                        string userInputID = Console.ReadLine().ToUpper();

                        Console.WriteLine();

                        Console.Write("Please input your desired quantity: ");
                        int userInputQuantity = int.Parse(Console.ReadLine());


                        decimal currentBalance = bankAccount.Balance;
                        string[] orderProducts = new string[2];
                        orderProducts = catering.SelectProducts(userInputID, userInputQuantity, currentBalance);

                        if (orderProducts[0] == "Order added")
                        {
                            bankAccount.SubtractFromBalance(Convert.ToDecimal(orderProducts[1]));
                        }

                        Console.WriteLine(orderProducts[0]);
                        Console.WriteLine();
                        break;

                    case "3":
                        //Closing actions

                        bankAccount.SetBalanceToZero();

                        foreach (string orderedItem in catering.orderList)
                        {
                            string[] itemArray = orderedItem.Split("|");

                            Console.WriteLine(String.Format("{0,-2} {1,-12} {2,-10} {3,-4} {4,10}", itemArray[1], itemArray[2], itemArray[3], decimal.Parse(itemArray[4]).ToString("C"),(decimal.Parse(itemArray[4]) * decimal.Parse(itemArray[1])).ToString("C")));

                        }

                        //Display change
                        Console.WriteLine();
                        Console.WriteLine("Change owed");
                        Console.WriteLine(bankAccount.MakeChange(runningBalance));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        done = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
