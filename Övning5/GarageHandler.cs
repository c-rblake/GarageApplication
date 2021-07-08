using System;
using System.Linq;

namespace Övning5
{
    internal class GarageHandler
    {

        private readonly IConsoleUI Ui;

        public Garage<Vehicle> MyGarage;
        int capacity;
        private bool garageSeeded = false;
        
        public GarageHandler(IConsoleUI ui)
        {
            Ui = ui;
        }

        internal void Run()
        {
            
            Ui.Print("Welcome to Garage 1.0");
            SetGarageSize();
            while (true)
            {
                Ui.Print($"--- Garage--- {MyGarage.Size - MyGarage.Count} Spots are availible");
                Ui.ViewMenu();
                string choice = Ui.ReadKey();
                switch(choice)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        SeedGarage();
                        break;
                    case "2":
                        try { 
                            if (MyGarage.Count != 0) ListVehicles();
                            else Ui.Print("This Garage seems empty");
                            }
                        catch(NullReferenceException)
                        {
                            break;
                            //Ui.Print("Try adding some vehicles to the Garage");
                        }
                        break;
                    case "3":
                        try
                        {
                            Vehicle searchResult = FindMyVehicle();
                            Ui.Print(searchResult.Stats());
                            break;
                        }
                        catch(NullReferenceException)
                        {
                            Ui.Print("Vehicle could not be found");
                            break;
                        }

                }


            }
            
        }

        private void SetGarageSize()
        {
            bool settingGarageSize = true;
            do
            {
                Ui.Print("Please enter a size of the garage in the range 5-25");
                string input = Ui.ReadKey();

                try
                {
                    int result = Int32.Parse(input);
                    if (result >= 5 && result <= 25)
                    {
                        settingGarageSize = false;
                        MyGarage = new Garage<Vehicle>(result);
                        Ui.Print($"A garage with size {MyGarage.Size} has been created. Please hit any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Ui.Print($"Unable to parse '{input}'");
                    }
                }
                catch (FormatException)
                {
                    continue;
                }

            } while (settingGarageSize);
        }

        //public GarageHandler(int capacity)
        //{
        //    MyGarage = new Garage<Vehicle>(capacity);
        //    SeedGarage();
        //    Ui.Print("Garage created with default Vehicles");
        //}

        private void SeedGarage()
        {
            if(!garageSeeded)
            { 
                MyGarage.ParkVehicle(new Car("ABD145", "Pink", 4, 5));
                MyGarage.ParkVehicle(new Boat("The Ahab", "White", 0, 55));
                MyGarage.ParkVehicle(new Airplane("Emirates", "White", 32, 4));
                MyGarage.ParkVehicle(new Bus("ABQ189", "Red", 32, "diesel"));
                garageSeeded = true;
                Ui.Print("Hit any key to continue");
                Console.ReadKey();
            }
            else Ui.Print("Garage has already been seeded. Hit any key to continue");
            Console.ReadKey();
        }

        private void ListVehicles()
        {
            foreach (var item in MyGarage)
            {
                Ui.Print(item.Stats());
            }
            Ui.Print("Hit any key to continue");
            Console.ReadKey();
        }

        internal Vehicle FindMyVehicle()
        {
            Ui.Print("Enter Id of Vehicle");
            string id = Ui.ReadKey();
            //Todo VALIDATION
            string searchId = id.ToLower();
            var result = MyGarage.FirstOrDefault(pv => pv.Id.ToLower() == searchId);
            return result;
        }


    }
}