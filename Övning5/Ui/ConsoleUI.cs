using System;

namespace Övning5
{
    internal class ConsoleUI : IConsoleUI //ctr R ctr I extract interface
    {
        public ConsoleUI()
        {
        }
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadKey()
        {
            return Console.ReadLine();
        }

        public void ViewMenu()
        {
            //Console.Clear();
            Console.WriteLine("" +
                "\n1. Seed The Garage. (Works once, adds 4 vehicles)"
                + "\n2. List all vehicles"
                + "\n3. Search for a Vehicle with ID. "
                + "\n4. BIG Search for a Vehicle with anything. "
                + "\n5. Remove a single Vehicle. "
                + "\n6. Add A Vehicle with Id, Color, Wheels and any idiosyncratic attribute.(Auto-park included)"
                + "\n0. Exit");
        }
        public void createVehicle()
        {
            Console.Clear();
            Console.WriteLine("" +
                "\n1. Create Airplane"
                + "\n2. Create Boat"
                + "\n3. Create Bus"
                + "\n4. Create Car"
                + "\n5. Create MotorCycle"
                + "\n6. Create Nothing"
                + "\n0. Exit");
        }
    }
}