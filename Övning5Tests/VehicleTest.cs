using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Övning5
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void TestInconclusive()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CreateVehicle()
        {
            Car testCar = new Car("abc123", "green", 4, 5);

            Assert.IsTrue(testCar is Vehicle);   
        }

        

    }
}
