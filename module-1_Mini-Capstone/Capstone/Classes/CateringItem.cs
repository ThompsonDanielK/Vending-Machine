using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    public class CateringItem
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ItemType { get; set; }

        public string ProductCode { get; set; }

        public int Quantity { get; set; } = 25;

        public CateringItem(string name, decimal price, string itemType, string productCode)
        {
            this.Name = name;
            this.Price = price;
            this.ItemType = itemType;
            this.ProductCode = productCode;            
        }
    }
}
