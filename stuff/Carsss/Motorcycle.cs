using System;
// ReSharper disable All

namespace stuff.Carsss
{
    public class Motorcycle : Vehicle
    {
        private static Random random = new Random();
        public readonly MotorcycleType Type;
        public Motorcycle(string make, string model, int yearOfManufacture, float weight, MotorcycleType type) 
            : base(make, model, yearOfManufacture, weight)
        {
            Type = type;
        }

        public void DoWheelie()
        {
            if (Type == MotorcycleType.Sport)
            {
                if (random.Next(0, 2) == 1)
                {
                    Console.WriteLine($"Omg!!! You did wheelie on {Model} {Make}, and made people gasp from excitement");
                }
                else
                {
                    Console.WriteLine(
                        "You tried to do a wheelie! but something went wrong and you fell down at the ground. Well, fall seven times, stand up eight, right?");
                }
            }
            else
                Console.WriteLine("Wheelie on a cruise motorcycle is would be incredible, but i won't allow you to do that");
        }

        public override void StartEngine()
        {
            Console.WriteLine($"The {Make} {Model}'s engine has started and roaring so loudly, everyone looks angrily at you");
        }

        public override void TurnOnRadio(RadioStation station)
        {
            Console.WriteLine("You tried to turn the radio on, but couldn't find one... Does radio in the motorcycle make sense?");
        }
    }
    
    public enum MotorcycleType
    {
        Sport,
        Cruise
    }
}