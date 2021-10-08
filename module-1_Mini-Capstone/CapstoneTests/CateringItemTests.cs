using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class CateringItemTests
    {
        [TestMethod]
        [DataRow("A","Appetizer")]
        [DataRow("B", "Beverage")]
        [DataRow("D", "Dessert")]
        [DataRow("E", "Entree")]
        [DataRow("Z", "")]

        public void ProductCodeNameReturnsCorrectName(string itemType, string expected)
        {
            //Arrange
            CateringItem ops = new CateringItem(itemType, "PC", "Name", 1M);

            //Act
            string result = ops.ProductCodeName;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InitialQuantitySetToTwentyFive()
        {
            //Arrange
            CateringItem ops = new CateringItem("X", "PC", "Name", 1M);

            //Act
            int result = ops.Quantity;

            //Assert
            Assert.AreEqual(25, result);

        }
    }
}
