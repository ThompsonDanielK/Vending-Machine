using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        [DataRow(3000, 3000)]
        [DataRow(1234, 1234)]
        [DataRow(0, 0)]

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
        [DataRow(1000, 2000)]
        [DataRow(1234, 2234)]
        [DataRow(0, 1000)]
        [DataRow(4000, 4200)]

        public void AddMoneyToExistingBalance(double deposit, double expected)
        {
            // Arrange 
            BankAccount ops = new BankAccount();
            ops.AddMoney(1000);

            // Act
            ops.AddMoney(Convert.ToDecimal(deposit));

            // Assert
            Assert.AreEqual(Convert.ToDecimal(expected), ops.Balance);
        }

        [TestMethod]
        [DataRow(5000, 4200)]
        [DataRow(4201, 4200)]
        public void AddMoney_DoesNotAddMoreThan4200(double deposit, double expected)
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
        [DataRow(0)]

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
        [DataRow(42.00, "Twenties: 2\nTens: 0\nFives: 0\nOnes: 2\nQuarters: 0\nDimes: 0\nNickels: 0")]
        [DataRow(19.15, "Twenties: 0\nTens: 1\nFives: 1\nOnes: 4\nQuarters: 0\nDimes: 1\nNickels: 1")]
        [DataRow(0.00, "Twenties: 0\nTens: 0\nFives: 0\nOnes: 0\nQuarters: 0\nDimes: 0\nNickels: 0")]
        [DataRow(256.90, "Twenties: 12\nTens: 1\nFives: 1\nOnes: 1\nQuarters: 3\nDimes: 1\nNickels: 1")]

        public void MakeChangeGivesCorrectChange(double changeAmount, string expected)
        {
            //Arrange
            BankAccount ops = new BankAccount();
            decimal changeAmountDecimal = Convert.ToDecimal(changeAmount);
            //Act
            string changeDisplay = ops.MakeChange(changeAmountDecimal);

            //Assert
            Assert.AreEqual(expected, changeDisplay);
        }
    }
}
