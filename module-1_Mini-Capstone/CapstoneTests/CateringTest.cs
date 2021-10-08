using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {

        [TestMethod]
        [DataRow("B1", 2, 1000, new string[] { "Order added", "3.00" , "Soda"})]
        [DataRow("A1", 2, 1000, new string[] { "Order added", "7.00", "Pretzels and Mustard" })]
        [DataRow("A3", 3, 1000, new string[] { "Order added", "12.45", "Bacon Wrapped Shrimp"})]
        [DataRow("E4", 20, 1000, new string[] { "Order added", "103.00", "Glass Shards Pizza"})]
        [DataRow("D2", 10, 1000, new string[] { "Order added", "18.00", "Cake"})]


        public void SelectProducts_ReturnsCorrectArrayOfStrings(string userInputID, int userInputQuantity, double customerBalance, string[] expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();
            string[] result = new string[2];
            // Act
            fileAccess.ReadInventoryFile(ops);
            result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("B1", 2, 1000, new string[] { "Out of stock", "0" })]
        [DataRow("E3", 2, 1000, new string[] { "Out of stock", "0" })]
        [DataRow("D4", 2, 1000, new string[] { "Out of stock", "0" })]

        public void SelectProducts_ReturnsOutOfStockStringArray(string userInputID, int userInputQuantity, double customerBalance, string[] expected)
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
            string[] result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("B1", 2, 1000, new string[] { "Order quantity exceeds in-stock quantity", "0" })]
        [DataRow("A3", 2, 1000, new string[] { "Order quantity exceeds in-stock quantity", "0" })]
        [DataRow("D4", 2, 1000, new string[] { "Order quantity exceeds in-stock quantity", "0" })]
        [DataRow("E2", 2, 1000, new string[] { "Order quantity exceeds in-stock quantity", "0" })]
        public void SelectProducts_ReturnsOrderQuantityExceedsInStockQuantityStringArray(string userInputID, int userInputQuantity, double customerBalance, string[] expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();
            string[] result = new string[2];
            fileAccess.ReadInventoryFile(ops);

            foreach (CateringItem product in ops.items)
            {
                if (product.ProductCode == userInputID)
                {
                    product.Quantity = 1;
                }
            }

            // Act
            result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("B4", 3, 0, new string[] { "Your account balance is too low to select these products", "0" })]
        [DataRow("E3", 1, 0, new string[] { "Your account balance is too low to select these products", "0" })]
        public void SelectProductsDoesNotAllowPurchaseGreaterThanBalance(string userInputID, int userInputQuantity, double customerBalance, string[] expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();
            string[] result = new string[2];
            fileAccess.ReadInventoryFile(ops);

            foreach (CateringItem product in ops.items)
            {
                if (product.ProductCode == userInputID)
                {
                    product.Quantity = userInputQuantity;
                }
            }

            // Act
            result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

    }
}
