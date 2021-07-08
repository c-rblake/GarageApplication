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
            Console.WriteLine("\n1. Seed The Garage. (Works once, adds 4 vehicles)"
                + "\n2. List all vehicles"
                + "\n3. Populera garaget med några fordon. "
                + "\n0. Exit");
        }
    }
}