using System;
using System.Collections.Generic;
using System.Linq;

namespace stuff.BookStorage
{

    public class Storage
    {
        public IReadOnlyDictionary<int, Book> Books => books;
        private Dictionary<int, Book> books = new();

        public void AddBook(Book newBook)
        {
            if (books.ContainsKey(newBook.Id))
            {
                throw new IdAlreadyPresentedInStorageException();
            }
            books.Add(newBook.Id, newBook);
            Console.WriteLine($"{newBook.Name} by {newBook.Author} was added to storage");
        }

        public void RemoveBook(int bookId)
        {
            if (!books.ContainsKey(bookId))
            {
                throw new IdNotFoundException();
            }
            var temp = books[bookId];
            books.Remove(bookId);
            Console.WriteLine($"{temp.Name} by {temp.Author} was removed from the storage");
        }

        public void FindBookByName(string name)
        {
            var bookWithName = books.Values.Where(b => b.Name == name).ToList();
            if (bookWithName.Count > 0)
            {
                foreach (var book in bookWithName)
                {
                    Console.WriteLine($"{book.Name} by {book.Author}");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find any books with such name");
            }
        }

        public void ShowAllBooks()
        {
            foreach (var book in books.Values)
            {
                Console.WriteLine($"{book.Name} by {book.Author}, released in {book.YearOfRelease}. {book.CopiesAvailable} copies");
            }
        }
    }

    public class IdNotFoundException : Exception
    {
        public override string Message { get; } =
            "Id Not Found Exception: book with the provided ID does not exist in this storage.";
    }

    public class IdAlreadyPresentedInStorageException : Exception
    {
        public override string Message { get; } =
            "Id Already Presented In Storage Exception: the book with such ID already exists in the storage";
    }

    public class NegativeNumberOfCopiesException : Exception
    {
        public override string Message { get; } =
            "Negative Number Of Copies Exception: book's copies amount was negative";
    }
}