using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5
{
    class Airplane : Vehicle
    {
        //private readonly..?
        public string Id { get; }
        public string Color { get; }
        public int Wheels { get; }
        public int NumberOfEngines { get; }

        public Airplane(string id, string color, int wheels, int numberOfEngines) : base(id, color, wheels)
        {
            Id = id;
            Color = color;
            Wheels = wheels;
            NumberOfEngines = numberOfEngines;
        }
        

    }



}
