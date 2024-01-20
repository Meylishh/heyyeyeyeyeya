using System;
// ReSharper disable All

namespace stuff.ZOOO
{
    public class Bird : Animal
    {
        public readonly float WingSpan;
        public Bird(string name, uint age, FoodType foodType, float wingSpan) : base(name, age, foodType)
        {
            WingSpan = wingSpan;
        }
        public void ReadSign()
        {
            Console.WriteLine($"Omg! The sign says that {Name}'s wing span is {WingSpan}! " +
                              $"How could you live without knowing this information?");
        }
    }
    public class Mammal : Animal
    {
        public bool IsWild { get; private set; }

        public Mammal(string name, uint age, FoodType foodType, bool isWild) : base(name, age, foodType)
        {
            IsWild = isWild;
        }
        
        public void Pat()
        {
            if (IsWild)
                Console.WriteLine($"You tried to pat {Name}, but it almost bit off your hand! The sign \"do not pat wild animals\" is for cowards, definitely");
            else
                Console.WriteLine($"You pat {Name}. It lets out a satisfied {Sound}, how cute");
        }
    }
    public class Reptile : Animal
    {
        public bool IsVenomous { get; private set; }
        public Reptile(string name, uint age, FoodType foodType, bool isVenomous) : base(name, age, foodType)
        {
            IsVenomous = isVenomous;
        }
        public void TakeALook()
        {
            if(IsVenomous)
                Console.WriteLine($"{Name} looks certainly amazing, but you're happy it's behind the glass");
            else
                Console.WriteLine($"Woah, {Name} looks amazing! Oh, it's not venomous, boring");
        }
    }
}