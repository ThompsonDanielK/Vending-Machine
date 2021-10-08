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
    }
}
