using System;
using System.Collections.Generic;
// ReSharper disable All

namespace stuff.ZOOO
{
    public class Zoo
    {
        public IReadOnlyList<Animal> Animals => animals;
        private List<Animal> animals = new List<Animal>();
        
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            Console.WriteLine($"{animal.Name} was added to the zoo. Welcome to the club, buddy!");
        }
        public void FeedAnimals()
        {
            foreach (var animal in animals)
            {
                animal.Eat();
            }
        }
        public void PrintAllAnimals()
        {
            Console.WriteLine("Take a look at our cuties animals!");
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} - {animal.GetType().Name}");
            }
        }
    }
}