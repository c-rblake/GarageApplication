using Microsoft.VisualStudio.TestTools.UnitTesting;
using Övning5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5
{
    [TestClass]
    public class GarageTest
    {
        [TestMethod]
        public void CreateGarage()
        {
            // Arrange
            const int expected = 16;
            var garage = new Garage<Vehicle>(expected);
            // Act
            int actual = garage.Size;
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}