using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {

        [TestMethod]
        [DataRow("B1", 2, 1000, new string[] { "3.00" , "Soda"})]
        [DataRow("A1", 2, 1000, new string[] { "7.00", "Pretzels and Mustard" })]
        [DataRow("A3", 3, 1000, new string[] { "12.45", "Bacon Wrapped Shrimp"})]
        [DataRow("E4", 20, 1000, new string[] { "103.00", "Glass Shards Pizza"})]
        [DataRow("D2", 10, 1000, new string[] { "18.00", "Cake"})]


        public void SelectProducts_ReturnsCorrectValue(string userInputID, int userInputQuantity, double customerBalance, string[] expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();
            
            // Act
            fileAccess.ReadInventoryFile(ops);
            CateringItem result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            Assert.AreEqual(expected[0], result.Price.ToString());
            Assert.AreEqual(expected[1], result.Name);
        }

        [TestMethod]
        [DataRow("B1", 2, 1000, 0)]
        [DataRow("E3", 2, 1000, 0)]
        [DataRow("D4", 2, 1000, 0)]

        public void SelectProducts_ReturnsOutOfStock(string userInputID, int userInputQuantity, double customerBalance, int expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();
            fileAccess.ReadInventoryFile(ops);
            
            foreach (CateringItem product in ops.items)
            {
                if (product.ProductCode == userInputID)
                {
                    product.Quantity = 0;
                }
            }

            // Act
            CateringItem result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            Assert.AreEqual(expected, result.Quantity);
        }

        [TestMethod]
        [DataRow("B1", 2, 1000, -1)]
        [DataRow("A3", 2, 1000, -1)]
        [DataRow("D4", 2, 1000, -1)]
        [DataRow("E2", 2, 1000, -1)]
        public void SelectProducts_ReturnsOrderQuantityExceedsInStockQuantity(string userInputID, int userInputQuantity, double customerBalance, int expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();            
            fileAccess.ReadInventoryFile(ops);

            foreach (CateringItem product in ops.items)
            {
                if (product.ProductCode == userInputID)
                {
                    product.Quantity = 1;
                }
            }

            // Act
            CateringItem result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            Assert.AreEqual(expected, result.Quantity);
        }

        [TestMethod]
        [DataRow("B4", 3, 0, -2)]
        [DataRow("E3", 1, 0, -2)]
        public void SelectProductsDoesNotAllowPurchaseGreaterThanBalance(string userInputID, int userInputQuantity, double customerBalance, int expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();            
            fileAccess.ReadInventoryFile(ops);

            foreach (CateringItem product in ops.items)
            {
                if (product.ProductCode == userInputID)
                {
                    product.Quantity = userInputQuantity;
                }
            }

            // Act
            CateringItem result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            Assert.AreEqual(expected, result.Quantity);
        }

    }
}
