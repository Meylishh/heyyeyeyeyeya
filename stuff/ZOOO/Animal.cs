using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable All

namespace stuff.ZOOO
{
    public class Animal
    {
        private static Random random = new Random();
        public readonly string Name;
        public readonly string Sound;
        public readonly FoodType FoodType;
        public uint Age { get; private set; }
        protected Animal(string name, uint age, FoodType foodType)
        {
            Name = name;
            Age = age;
            FoodType = foodType;
            Sound = GenerateSound();
        }

        protected string GenerateSound()
        {
            const string vowels = "aeiouy";
            const string consonants = "bcdfghjklmnpqrstvwxz";
            var sound = Convert.ToString(consonants[random.Next(consonants.Length)])
                        + new string(Enumerable.Range(1, 4).Select(s => vowels[random.Next(vowels.Length)]).ToArray());
            return sound;
        }
        
        public void Eat()
        {
            var eatableItems = new List<string>()
            {
                "Paper box",
                "Desk lamp",
                "Toaster",
                "Alarm clock",
                "Blender",
                "Shoe rack",
                "Folding chair",
                "Candle holder",
                "Wall clock",
                "Cutlery set",
                "Kettle",
                "Clothes hanger",
                "Toilet brush",
                "Cushions",
                "Kitchen scale",
                "Coat rack",
                "Trash can",
                "Utensil holder"
            };
            
            switch (FoodType)
            {
                case FoodType.Carnivorous:
                    Console.WriteLine($"{Name} is eating a small rat... gross");
                    break;
                case FoodType.Herbivore:
                    Console.WriteLine($"{Name} eats grass with such a joyful expression, you're beginning to want to try it yourself");
                    break;
                case FoodType.Omnivorous:
                    Console.WriteLine($"{Name} eats {eatableItems[random.Next(eatableItems.Count-1)].ToLower()} and seems completely fine about it");
                    break;
            }

        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping peacefully");
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}! What a charming sound");
        }
    }
}