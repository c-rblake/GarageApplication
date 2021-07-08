using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Övning5
{
    public class Vehicle : IVehicle
    {
        private string id;
        private string color;
        private int wheels;

        public string Id { get; private set; }
        public string Color { get; private set; }
        public int Wheels { get; private set; }
        public int ParkingSpot = -1;

        public Vehicle(string id, string color, int wheels)
        {
            this.Id = id;
            this.Color = color;
            this.Wheels = wheels;
        }

        public override string ToString()
        {
            return $"Vehicle has id{Id}, color{Color} and wheels{Wheels} it is parked at {ParkingSpot} (if -1 it is not parked)";
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.type.getproperties?view=net-5.0
        public virtual string Stats() // Can override in subclasses
        {
            //var result = new StringBuilder();
            //PropertyInfo[] myPropertyInfo;
            //myPropertyInfo = this.GetType("System.Type").GetProperties();
            Type t = this.GetType();
            var result = new StringBuilder();
            string type = $"Type is: '{t.Name}'. It is comfortably parked at {ParkingSpot}";
            result.AppendLine(type);
            PropertyInfo[] props = t.GetProperties(); //Reflection
            result.AppendLine($"Properties (N = { props.Length})");
            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                    result.AppendLine($"   {prop.Name} ({prop.PropertyType.Name}): {prop.GetValue(this)}");
                else
                    Console.WriteLine($"   {prop.Name} ({prop.PropertyType.Name}): <Indexed>");

            return result.ToString();
        }

        





    }
}