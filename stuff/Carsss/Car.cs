using System;
using System.Collections.Generic;
// ReSharper disable All

namespace stuff.Carsss
{
    public class Car : Vehicle
    {
        public readonly int DoorAmount;
        private bool doorsLocked;
        public Car(string make, string model, int yearOfManufacture, float weight, int doorAmount) : base(make, model, yearOfManufacture, weight)
        {
            DoorAmount = doorAmount;
            doorsLocked = false;
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

        public override void TurnOnRadio(RadioStation station)
        {
            Console.WriteLine($"You turned the {station} on...");
        }
    }
    
}