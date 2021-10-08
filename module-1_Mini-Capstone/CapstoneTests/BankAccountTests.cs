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
