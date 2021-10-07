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
        public string Name { get; }

        public decimal Price { get; }

        public string ItemType {get; }

        public string ProductCode { get; }

        public string ProductCodeName
        {
            get
            {
                switch (ItemType)
                {
                    case "B":
                        return "Beverage";
                    case "E":
                        return "Entree";
                    case "D":
                        return "Dessert";
                    case "A":
                        return "Appetizer";
                    default:
                        return "";
                }
            }
        }
        public int Quantity { get; set; } = 25;

        public CateringItem(string itemType, string productCode, string name, decimal price)
        {
            this.ItemType = itemType;
            this.ProductCode = productCode;            
            this.Name = name;
            this.Price = price;
        }

        public string DisplayInfo()
        {
            if (Quantity < 1)
            {
                return $"{ProductCodeName} {Name} {Price} SOLD OUT";
            }
            return $"{ProductCodeName} {Name} {Price} {Quantity}";
        }
    }
}
