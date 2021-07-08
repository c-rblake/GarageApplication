using System;

namespace Övning5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Garage<Vehicle> myGarage = new(5);

            Vehicle vehicle = new Vehicle("abc123", "pink", 5);

            myGarage.ParkVehicle(vehicle);

            Console.WriteLine(vehicle.ToString());

        }
    }
}
