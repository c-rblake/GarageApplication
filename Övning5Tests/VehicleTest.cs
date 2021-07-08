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
            Vehicle vehicle = new Vehicle("abc123", "green", 6);

            Assert.IsTrue(vehicle is Vehicle);
            
        }

        

    }
}
