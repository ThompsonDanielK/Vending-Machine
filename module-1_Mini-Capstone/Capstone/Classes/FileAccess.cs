using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    public class FileAccess
    {
        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.
        //string filePath = @"C:\Catering\cateringsystem.csv";
        private string filePath = @"C:\Catering\";

      
        public void ReadInventoryFile(Catering catering)
        {
        List<CateringItem> inventoryList = new List<CateringItem>();

            using (StreamReader reader = new StreamReader(Path.Combine(filePath, "cateringsystem.csv")))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] inventoryLine = line.Split("|");

                    //ItemType | ProductCode | Name | Price
                    //Add to items List

                    catering.items.Add(new CateringItem(inventoryLine[0], inventoryLine[1], inventoryLine[2], Convert.ToDecimal(inventoryLine[3])));
                }
            }
            
        }

    }
}


