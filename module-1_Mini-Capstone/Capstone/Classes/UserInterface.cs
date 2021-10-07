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
        private Catering catering = new Catering();

        public void RunMainMenu()
        {
            //Run input file method to create inventory


            bool done = false;

            while (!done)
            {
                Console.WriteLine("​(1) Display Catering Items");
                Console.WriteLine("​(2) Order");
                Console.WriteLine(​"(3) Quit");

                Console.ReadLine();
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
