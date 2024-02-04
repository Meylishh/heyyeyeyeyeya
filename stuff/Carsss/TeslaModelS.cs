using System;
// ReSharper disable All

namespace stuff.Carsss
{
    public class TeslaModelS: ElectricVehicle
    {
        public bool AutoPilotEnabled;
        public readonly int DoorAmount;
        private bool doorsLocked;
        public TeslaModelS(string make, string model, int yearOfManufacture, float weight, float rangePerCharge, float batteryCapacity, int doorAmount) 
            : base(make, model, yearOfManufacture, weight, rangePerCharge, batteryCapacity)
        {
            AutoPilotEnabled = true;
            DoorAmount = doorAmount;
            doorsLocked = false;
        }
        
        public void Park()
        {
            if (AutoPilotEnabled) 
                Console.WriteLine($"The {Make} model {Model} is parking. Probably better than you ever did");
            else
            {
                Console.WriteLine("You decided to go against the whole technical progress and park by yourself. What a rebel");
            }
        }
        
        public void LockAllDoors()
        {
            if (!doorsLocked)
            {
                if (DoorAmount > 0) 
                    Console.WriteLine($"{Make} model {Model}'s {DoorAmount} doors all locked");
                else
                    Console.WriteLine("You tried to lock all doors, but couldn't find one...");
                doorsLocked = true;
            }
            else
                Console.WriteLine("All doors are already locked");
        }

        public void UnlockAllDoors()
        {
            if (doorsLocked)
            {
                if (DoorAmount > 0) 
                    Console.WriteLine($"{Make} model {Model}'s {DoorAmount} doors all unlocked");
                else
                    Console.WriteLine("Unfortunately, there's nothing to unlock... You stuck here");
            }
            else
                Console.WriteLine("All doors are already unlocked");

        }
    }
}