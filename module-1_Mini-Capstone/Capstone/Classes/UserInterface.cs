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

        public void RunMainMenu()
        {
            //Run input file method to create inventory
            Catering catering = new Catering();
            FileAccess fileAccess = new FileAccess();

            fileAccess.ReadInventoryFile(catering);

            


            bool done = false;

            while (!done)
            {
                
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");

               string userInput = Console.ReadLine();
               Console.WriteLine();

                switch (userInput)
                {
                    case "1":
                        foreach (CateringItem item in catering.items)
                        {
                            Console.WriteLine(item.DisplayInfo());
                        }
                        break;

                    case "2":
                    //   return Order();

                    case "3":
                        done = true;
                        break;
                }
                        Console.WriteLine();

            }
        }
            public void PurchaseMenu()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine($"Current Account Balance: "); //Add in proper balance

        }
    }
}
