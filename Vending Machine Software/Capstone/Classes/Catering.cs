using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for catering
    /// </summary>
    public class Catering
    {
        public List<CateringItem> items = new List<CateringItem>();

        public List<string> orderList = new List<string>();

        public List<CateringItem> Inventory { get; }

        /// <summary>
        /// Loops through instances of CateringItem checking to see if ProductCode is the same as user input.
        /// Removes desired quantity from inventory.
        /// </summary>
        /// <param name="userInputID"></param>
        /// <param name="userInputQuantity"></param>
        /// <param name="customerBalance"></param>
        /// <returns>string[]</returns>
        public string[] SelectProducts(string userInputID, int userInputQuantity, decimal customerBalance)
        {
            // Looping through each instance of CateringItem to see if userInputID matches the product code property
            foreach (CateringItem product in items)
            {
                
                if (product.ProductCode.ToUpper() == userInputID)
                {

                    if (product.Quantity == 0)
                    {
                        return new string[] { "Out of stock", "0" };
                    }

                    // If the user tries to order more than what's in stock
                    else if (userInputQuantity > product.Quantity)
                    {
                        return new string[] { "Order quantity exceeds in-stock quantity", "0" };
                    }

                    // This checks if the user has enough money and if so, it processes the purchase
                    else if (customerBalance >= product.Price * userInputQuantity)
                    {
                        product.Quantity -= userInputQuantity;

                        orderList.Add($"{userInputID}|{userInputQuantity}|{product.ProductCodeName}|{product.Name}|{product.Price}");
                        return new string[] { "Order added", $"{userInputQuantity * product.Price}", $"{product.Name}" };
                    }

                    // If the price of the desired quantity exceeds the users balance, it returns a message
                    else if (customerBalance < product.Price * userInputQuantity)
                    {
                        return new string[] { "Your account balance is too low to select these products", "0" };
                    }
                }
            }
            return new string[] { "No matching product ID found", "0" };
        }

        /// <summary>
        /// Makes a string containing purchase made
        /// </summary>
        /// <param name="orderedItem"></param>
        /// <returns>string</returns>
        public string OrderReport(string orderedItem)
        {
            string[] itemArray = orderedItem.Split("|");
            return String.Format("{0,-2} {1,-12} {2,-10} {3,-4} {4,10}", itemArray[1], itemArray[2], itemArray[3], decimal.Parse(itemArray[4]).ToString("C"), (decimal.Parse(itemArray[4]) * decimal.Parse(itemArray[1])).ToString("C"));
        }

        /// <summary>
        /// Calculates order total
        /// </summary>
        /// <returns>string</returns>
        public string OrderTotal()
        {
            decimal total = 0M;
            foreach (string orderedItem in orderList)
            {
                string[] itemArray = orderedItem.Split("|");
                total += Convert.ToInt32(itemArray[1]) * Convert.ToDecimal(itemArray[4]);

            }
            return $"Total: {total.ToString("C")}";
        }
    }
}
