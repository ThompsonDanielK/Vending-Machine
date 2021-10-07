﻿using System;
using System.Collections.Generic;
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
        public string[] SelectProducts(string userInputID, int userInputQuantity)
        {
            foreach (CateringItem product in items)
            {

                if (product.ProductCode.ToUpper().Contains(userInputID))
                {
                    
                    if (product.Quantity == 0)
                    {
                        return new string[] { "Out of stock", "0"};
                    }
                    else if (userInputQuantity > product.Quantity)
                    {
                        return new string[] { "Order quantity exceeds in-stock quantity", "0" };
                    }

                    product.Quantity -= userInputQuantity;
                    
                    orderList.Add($"{userInputID}|{userInputQuantity}");
                    return new string[] { "Order added", $"{userInputQuantity} * {product.Price}" };
                        
                }
            }
                return new string[] { "No matching product ID found", "0" };
        }

    }

}
