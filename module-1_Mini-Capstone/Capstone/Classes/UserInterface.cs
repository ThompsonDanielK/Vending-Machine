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

        /// <summary>
        /// This method displays the main menu and reads user input
        /// </summary>
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
                Console.WriteLine();

                switch (userInput)
                {
                    // Loops through each instance of CateringItem and writes out properties of each
                    case "1":
                        foreach (CateringItem item in catering.items)
                        {
                            Console.WriteLine(item.DisplayInfo());
                        }
                        break;

                    // Takes user to PurchaseMenu method
                    case "2":
                        PurchaseMenu();
                        break;

                    // Ends while loop and ends application
                    case "3":
                        done = true;
                        break;
                }
                Console.WriteLine();

            }
        }
        /// <summary>
        /// This method displays a purchase menu and reads user input
        /// </summary>
        public void PurchaseMenu()
        {
            // Display Order Menu, get user input, loop through until Complete Transaction selected
            bool done = false;

            // List pending to be written to log file
            List<string> writeList = new List<string>();

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
                Console.WriteLine();

                switch (userInput)
                {
                    // Banking app
                    case "1":
                        try
                        {

                            Console.Write("How much money would you like to deposit: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine()); ;
                            decimal overageAmount = bankAccount.Balance + depositAmount - 4200M;

                            // User cannot input value less than 0
                            if (depositAmount >= 0)
                            {
                                //  If AddMoney method returns false, the deposit is made but only up to $4200
                                if (!bankAccount.AddMoney(depositAmount))
                                {
                                    // Line to be written to log
                                    writeList.Add($"{DateTime.Now} ADD MONEY: {(depositAmount - overageAmount).ToString("C")} {bankAccount.Balance.ToString("C")}");

                                    Console.WriteLine($"You can only have a maximum of $4,200.00");
                                    Console.WriteLine($"Only {(depositAmount - overageAmount).ToString("C")} was deposited to your account.");
                                }

                                // If AddMoney returns true, the deposit is made
                                else
                                {
                                    // Line to be written to log
                                    writeList.Add($"{DateTime.Now} ADD MONEY: {depositAmount.ToString("C")} {bankAccount.Balance.ToString("C")}");
                                    Console.WriteLine();
                                    Console.WriteLine($"{depositAmount.ToString("C")} has been deposited to your account.");
                                }
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Please enter a positive value");
                            }
                        }
                        catch (FormatException exc)
                        {
                            Console.WriteLine("Please enter a valid deposit amount.");
                            Console.WriteLine();
                        }
                        break;

                    //Catering app
                    case "2":
                        try
                        {
                            Console.Write("Please input a product ID: ");
                            string userInputID = Console.ReadLine().ToUpper();

                            Console.WriteLine();

                            Console.Write("Please input your desired quantity: ");

                            int userInputQuantity = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            // Ensures user cannot input an order for 0 or less
                            if (userInputQuantity > 0)
                            {
                                decimal currentBalance = bankAccount.Balance;
                                string[] orderProducts = new string[3];
                                orderProducts = catering.SelectProducts(userInputID, userInputQuantity, currentBalance);

                                if (orderProducts[0] == "Order added")
                                {
                                    bankAccount.SubtractFromBalance(Convert.ToDecimal(orderProducts[1]));

                                    // Line to be written to log
                                    writeList.Add($"{DateTime.Now} {userInputQuantity} {orderProducts[2]} {userInputID} {Convert.ToDecimal(orderProducts[1]).ToString("C")} {bankAccount.Balance.ToString("C")}");
                                }

                                Console.WriteLine(orderProducts[0]);
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Desired quantity must be greater than 0");
                            }
                        }
                        catch (FormatException exc)
                        {
                            Console.WriteLine("Please enter a valid quantity.");
                            Console.WriteLine();
                        }
                        break;

                    case "3":
                        // Closing actions

                        // Line to be written to log
                        writeList.Add($"{DateTime.Now} GIVE CHANGE: {bankAccount.Balance.ToString("C")} $0.00");

                        // Writing list to log
                        fileAccess.WriteInventoryFile(writeList);

                        bankAccount.SetBalanceToZero();

                        // Displays purchases made before transaction was completed
                        foreach (string orderedItem in catering.orderList)
                        {
                            Console.WriteLine(catering.OrderReport(orderedItem));
                        }
                        Console.WriteLine();
                        Console.WriteLine(catering.OrderTotal());
                        Console.WriteLine();

                        // Display change
                        Console.WriteLine();
                        Console.WriteLine("Change owed");
                        Console.WriteLine(bankAccount.MakeChange(runningBalance));
                        Console.WriteLine("Press enter key to continue...");
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
