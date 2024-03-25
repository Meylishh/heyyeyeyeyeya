using System;
// ReSharper disable All

namespace stuff.BookStorage
{
    public class Book
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string Author;
        public readonly int YearOfRelease;
        public int CopiesAvailable { get; private set; }

        public Book(string name, string author, int yearOfRelease)
        {
            Name = name;
            Author = author;
            YearOfRelease = yearOfRelease;
            Id = GetHashCode();
            CopiesAvailable = 1;
        }

        public void AddCopies(int amount)
        {
            CopiesAvailable += amount;
            Console.WriteLine($"{Name}'s copies: {CopiesAvailable}");
        }
        public void RemoveCopies(int amount)
        {
            if (amount > CopiesAvailable)
            {
                throw new NegativeNumberOfCopiesException();
            }
            CopiesAvailable -= amount;
            Console.WriteLine($"{Name}'s copies: {CopiesAvailable}");
        }
    }
}