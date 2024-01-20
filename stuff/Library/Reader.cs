using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable All

namespace stuff
{
    public class Reader
    {
        public IReadOnlyDictionary<string, Book> CurrentBooks => currentBooks;
        private Dictionary<string, Book> currentBooks = new Dictionary<string, Book>();
        
        public void BorrowBook(string name, Library library)
        {
            if (library.TryGetBook(name, out Book book))
            {
                library.RemoveBook(name);
                currentBooks.Add(name, book);
                Console.WriteLine($"You took the book \"{book.Name}\" by {book.Author}");
            }
            else
                Console.WriteLine("Couldn't find such book in the library");
        }

        public void ReturnBook(string name, Library library)
        {
            if (currentBooks.ContainsKey(name))
            {
                var book = currentBooks[name];
                currentBooks.Remove(name);
                library.AddBook(book);
                Console.WriteLine($"You returned a \"{name}\" back to library");
            }
            else
                Console.WriteLine("You don't have such book, could not return");
        }

        public void ShowAllBooks()
        {
            if (currentBooks.Any())
            {
                foreach (var book in currentBooks.Values)
                {
                    Console.WriteLine($"\"{book.Name}\" by {book.Author}, released in {book.ReleaseYear}");
                }
            }
            else
                Console.WriteLine("You don't have any books");
        }
    }
}