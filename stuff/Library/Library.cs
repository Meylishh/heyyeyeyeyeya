using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace stuff
{
    public class Library
    {
        private Dictionary<string,Book> libraryBooks = new Dictionary<string,Book>();
        
        public void AddBook(Book book)
        {
            if (!libraryBooks.ContainsKey(book.Name))
                libraryBooks.Add(book.Name, book);
            else
                Console.WriteLine("There is already such book in the library.");
        }

        public void RemoveBook(string name, bool showResult = false)
        {
            if (libraryBooks.ContainsKey(name))
            {
                libraryBooks.Remove(name);
                if(showResult)
                    Console.WriteLine($"{name} was removed from the library");
            }
            else
            {
                if (showResult)
                    Console.WriteLine("Couldn't find such book in the library");
            }
        }

        public void ShowAllBooks()
        {
            if (libraryBooks.Any())
            {
                foreach (var book in libraryBooks.Values)
                {
                    Console.WriteLine($"\"{book.Name}\" by {book.Author}, released in {book.ReleaseYear}");
                }                
            }
            else
                Console.WriteLine("There are no books in the library.");
        }

        public void ShowBooksByYear(int year)
        {
            if (libraryBooks.Any())
            {
                var booksByYear = libraryBooks.Values.Where(b => b.ReleaseYear == year).ToList();

                if (booksByYear.Any())
                {
                    foreach (var book in booksByYear)
                    {
                        Console.WriteLine($"\"{book.Name}\" by {book.Author}, released in {book.ReleaseYear}");
                    }
                }
                else
                {
                    Console.WriteLine("Couldn't find any books released in such year.");
                }
            }
            else
                Console.WriteLine("There are no books in the library.");

        }

        public void ShowBooksByAuthor(string author)
        {
            if (libraryBooks.Any())
            {
                var booksByAuthor = libraryBooks.Values.Where(b => b.Author == author).ToList();
                if (booksByAuthor.Any())
                {
                    foreach (var book in booksByAuthor)
                    {
                        Console.WriteLine($"\"{book.Name}\" by {book.Author}, released in {book.ReleaseYear}");
                    }
                }
                else
                    Console.WriteLine("Couldn't find anything.");

            }
            else
                Console.WriteLine("There are no books in the library.");
        }

        public void ShowBooksByName()
        {
            if (libraryBooks.Any())
            {
                var booksByName = libraryBooks.Values.OrderBy(b => b.Name).ToList();
                foreach (var book in booksByName)
                {
                    Console.WriteLine($"\"{book.Name}\" by {book.Author}, released in {book.ReleaseYear}");
                }   
            }
            else
                Console.WriteLine("There are no books in the library.");
        }
        

        public bool TryGetBook(string name, out Book book)
        {
            book = null;
            if (libraryBooks.ContainsKey(name))
            {
                book = libraryBooks[name];
                return true;
            }
            return false;
        }
    }
}