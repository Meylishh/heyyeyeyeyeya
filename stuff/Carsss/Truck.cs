using System;
// ReSharper disable All

namespace stuff.Carsss
{
    public class Truck : Vehicle
    {
        public readonly float MaxLoadCapacity;
        public float CurrentCargoWeight { get; private set; }
        public Truck(string make, string model, int yearOfManufacture, float weight, float maxLoadCapacity) : base(make, model, yearOfManufacture, weight)
        {
            MaxLoadCapacity = maxLoadCapacity;
            CurrentCargoWeight = 0;
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
                Console.WriteLine($"The weight has been loaded, remained space: {MaxLoadCapacity - weight}");
            }
            
        }

        public override void TurnOnRadio(RadioStation station)
        {
            Console.WriteLine($"You turned the {station} on, like a true trucker");
        }
    }
}