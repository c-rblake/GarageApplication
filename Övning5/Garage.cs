﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Övning5
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        ConsoleUI ui = new ConsoleUI();
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
                    ui.Print($"Vehicle has been parked at spot no: {i}");
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

        internal void RemoveVehicle(int index)
        {
            try
            {
                if (vehicles[index] != null)
                {
                    Console.WriteLine($"Vehicle has been removed at {index}");
                    vehicles[index] = null;
                    count--;
                }
                else
                {
                    Console.WriteLine($"There was no vechicle at {index}");
                    Console.WriteLine($"Try again or use another method to find the Vehicle");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Could not remove Vehicle at {index} the Garage is not of that size");
                Console.WriteLine($"Try the List Vehicles method too find the position of the vehicle");
                //Console.WriteLine($"Try the PrintSize method to find the size of the car");
            }
        }


    }
}