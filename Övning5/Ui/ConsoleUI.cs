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
                + "\n6. Add A Vehicle with ID, COLOR, and, number of WHEELS.(Auto-park included) "
                + "\n0. Exit");
        }
    }
}