using System;
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

       // public Catering(List<CateringItem> inventory) { }

        public List<CateringItem> Inventory { get; }
       
    }
}
