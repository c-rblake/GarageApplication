using System.Collections;
using System.Collections.Generic;

namespace Övning5
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        static UI ui = new UI();
        /* #region Private Fields */
        private int count;
        private readonly T[] vehicles;
        private int size;
        /* #endregion */
        
        public int Size { get; }
        public int Count => count;

        /* #region Constructor */
        public Garage(int size)
        {
            this.size = size;
            Size = size;
            vehicles = new T[size];
        }
        /* #endregion */


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles)
            {
                yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public void ParkVehicle(T vehicle) // T vehicle
        {
            if (count == size)
                ui.Print("Parking is full");
            for (int i = 0; i < size; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    count++;
                    vehicle.ParkingSpot = i;
                    ui.Print($"Vehicle parked at {i}");
                    break;
                }
            }
            //ui.Print("Vehicle could not be parked. Contact manager");
        }

        public string RemoveVehicle(T vehicle)
        {
            for (int i = 0; i < size; i++)
            {
                if (vehicles[i] == vehicle)
                {
                    vehicles[i] = null;
                    count--;
                    vehicle.ParkingSpot = -1;
                    return $"Vehicle with id {vehicle.Id} has been removed from spot {i}";
                }
            }
        return $"Vehicle {vehicle.Id} is not parked in the Garage";

        }




    }
}