using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Övning5
{
    internal class GarageHandler: IHandler
    {

        private readonly IConsoleUI Ui;

        public Garage<Vehicle> MyGarage;
        int capacity;
        private bool garageSeeded = false;
        HashSet<string> uniqueList = new HashSet<string>();

        public GarageHandler(IConsoleUI ui)
        {
            Ui = ui;
        }
        

        public void Run()
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
                        if (MyGarage.Count == 0)
                        {
                            Ui.Print("Nothing in Garage");
                            break;
                        }
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
                    case "4":
                        try
                        {
                            FindMatches();
                            break;
                        }
                        catch (NullReferenceException)
                        {
                            Ui.Print("More vehicles could not be found");
                            break;
                        }
                    case "5":
                        Remove();

                        break;
                    case "6":
                        try
                        {
                            AddVehicle();
                            break;
                        }
                        catch (NullReferenceException)
                        {
                            Ui.Print("Null Exception Not handeled in membership test");
                            
                            break;
                        }
                    default:
                        Ui.Print("Invalid Input. Try a Menu option");
                        break;

                }


            }
            
        }

        private void AddVehicle()
        {
            string id;
            bool membership = true;
            do
            {
                Ui.Print("please enter the ID of the Vehicle");
                id = Ui.ReadKey();
                try
                {
                    membership = MyGarage.Any(a => a.Id == id);
                }
                catch (NullReferenceException)
                {
                    membership = false;
                }
                   
                //membership =  true;
                if (membership)
                {
                    Ui.Print("That ID is already Taken. Try another like password123.");
                }

            } while (membership);
            
            
            Ui.Print("please enter the Color of the Vehicle");
            string color = Ui.ReadKey();
            Ui.Print("please enter the number of wheels of the Vehicle");
            string wheels = Ui.ReadKey();
            
            try
            {
                int result = Int32.Parse(wheels);
                Vehicle newVehicle = new(id, color, result);
                MyGarage.ParkVehicle(newVehicle);
            }
            catch (NullReferenceException)
            {
                Ui.Print("Vehicle could not be created");

            }


           
            // WHAT KIND OF VEHICLE WOULD YOU WANT?

        }

        private void Remove()
        {
            bool removeVehicle = true; // NOT EXITING A LOOP IS GOOD WHEN TESTING IN CONSOLE.
            do
            {
                Ui.Print("Please enter the index of the car you want to remove. 0 Indexing does apply!");
                string input = Ui.ReadKey();
                try
                {
                    int result = Int32.Parse(input);
                    if (result >= 0 || result <= MyGarage.Size)
                    {
                        Ui.Print($"Trying to remove Vehicle at {input}");
                        MyGarage.RemoveVehicle(result);
                        removeVehicle = false;
                    }
                    else
                    {
                        Ui.Print($"Unable to comply with '{input}'");
                    }

                }
                catch (FormatException)
                {
                    continue;
                }

            } while (removeVehicle); 


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
            var result = MyGarage.FirstOrDefault(pv => pv.Id.ToLower() == searchId); // Dictionary
            return result;
        }

        internal void FindMatches()
        {
            Ui.Print("Enter search term");
            string term = Ui.ReadKey();
            //Todo VALIDATION
            string searchTerm = term.ToLower();
            //var result = MyGarage.ReturnIfTrue(CheckProps); // EXTENSION METHOD
            
            
            Console.WriteLine("Looking for Vehicle...");
            foreach (var item in MyGarage)
            {
                Type t = item.GetType(); // Has to be in vehicle methods SO that is EXTENSION. THis is garage handler here.
                if (searchTerm == t.Name.ToLower())
                {
                    Ui.Print($"Possible match found \n{item.Stats()}");
                    Ui.Print(t.Name);
                    
                    continue;
                }

                PropertyInfo[] props = t.GetProperties();
                foreach (var prop in props)
                {
                    string property = $"{prop.GetValue(item)}";
                    if(searchTerm == property.ToLower())
                    {
                        Ui.Print($"Possible match found \n{item.Stats()}");
                        //goto OutLoop;
                        break;
                    }

                }

            }

        }


    }
}