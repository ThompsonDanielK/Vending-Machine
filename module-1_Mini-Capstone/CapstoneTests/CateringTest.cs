using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        [DataRow(3000, 3000)]
        [DataRow(1234, 1234)]
        public void AddMoney_AddsCorrectAmountToBalance(double deposit, double expected)
        {
            // Arrange 
            BankAccount ops = new BankAccount();

            // Act
            ops.AddMoney(Convert.ToDecimal(deposit));

            // Assert
            Assert.AreEqual(Convert.ToDecimal(expected), ops.Balance);
        }

        [TestMethod]
        [DataRow(5000, 4200)]
        [DataRow(4201, 4200)]
        public void AddMoney_DoesNotAddMoreThan4200 (double deposit, double expected)
        {
            // Arrange 
            BankAccount ops = new BankAccount();

            // Act
            ops.AddMoney(Convert.ToDecimal(deposit));

            // Assert
            Assert.AreEqual(Convert.ToDecimal(expected), ops.Balance);
        }

        [TestMethod]
        [DataRow(3000)]
        [DataRow(1)]
        public void AddMoney_ReturnsTrueIfBalanceDoesNotExceed4200(double deposit)
        {
            // Arrange 
            BankAccount ops = new BankAccount();

            // Act
            bool result = ops.AddMoney(Convert.ToDecimal(deposit));

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(5000)]
        [DataRow(4201)]
        public void AddMoney_ReturnsFalseIfBalanceExceeds4200(double deposit)
        {
            // Arrange 
            BankAccount ops = new BankAccount();

            // Act
            bool result = ops.AddMoney(Convert.ToDecimal(deposit));

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("B1", 2, 1000, new string[] { "Order added", "3.00" })]        
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
        public void SelectProducts_ReturnsOutOfStockStringArray(string userInputID, int userInputQuantity, double customerBalance, string[] expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();
            string[] result = new string[2];
            // Act
            fileAccess.ReadInventoryFile(ops);
            
            foreach (CateringItem product in ops.items)
            {
                if (product.ProductCode == userInputID)
                {
                    product.Quantity = 0;
                }
            }
            result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("B1", 2, 1000, new string[] { "Order quantity exceeds in-stock quantity", "0" })]
        public void SelectProducts_ReturnsOrderQuantityExceedsInStockQuantityStringArray(string userInputID, int userInputQuantity, double customerBalance, string[] expected)
        {
            // Arrange 
            Catering ops = new Catering();
            FileAccess fileAccess = new FileAccess();
            string[] result = new string[2];
            // Act
            fileAccess.ReadInventoryFile(ops);

            foreach (CateringItem product in ops.items)
            {
                if (product.ProductCode == userInputID)
                {
                    product.Quantity = 1;
                }
            }
            result = ops.SelectProducts(userInputID, userInputQuantity, Convert.ToDecimal(customerBalance));

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
