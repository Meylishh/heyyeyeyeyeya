using System;
// ReSharper disable All

namespace stuff.Carsss
{
    public class TeslaTruck: ElectricVehicle
    {
        public readonly float MaxLoadCapacity;
        public float CurrentCargoWeight { get; private set; }
        
        public string CurrentRoute { get; private set; }
        
        public TeslaTruck(string make, string model, int yearOfManufacture, float weight, float rangePerCharge, float batteryCapacity, float maxLoadCapacity) 
            : base(make, model, yearOfManufacture, weight, rangePerCharge, batteryCapacity)
        {
            MaxLoadCapacity = maxLoadCapacity;
            CurrentCargoWeight = 0;
            CurrentRoute = "No route set";
        }
        
        public void LoadCargo(float weight)
        {
            if (weight > MaxLoadCapacity)
            {
                Console.WriteLine($"Couldn't load the cargo, max allowed weight is {MaxLoadCapacity}");
            }
            else if (CurrentCargoWeight + weight > MaxLoadCapacity)
            {
                Console.WriteLine($"Couldn't load the cargo, the weight is more than max weight");

            }
            else
            {
                CurrentCargoWeight += weight;
                Console.WriteLine($"The weight has been loaded into {Make} model {Model}, remained space: {MaxLoadCapacity - weight}");
            }
            
        }

        public void SetRoute(City from, City to)
        {
            CurrentRoute = $"{from} - {to}";
            Console.WriteLine($"{Make} model {Model}'s current route is set to: {CurrentRoute}");
        }

        public void CancelRoute()
        {
            CurrentRoute = $"No route set for {Make} model {Model}";
            Console.WriteLine("The route was canceled");
        }
    }
}