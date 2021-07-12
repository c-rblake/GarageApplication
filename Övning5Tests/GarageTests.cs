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
        Garage<Vehicle> myGarage = new(5);

        Car testCar = new Car("abc123", "green", 4, 5);


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

        [TestMethod]
        public void AddVehicleTest()
        {
            const int expected = 2;
            myGarage.ParkVehicle(testCar);
            myGarage.ParkVehicle(testCar);
            int actual = myGarage.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}