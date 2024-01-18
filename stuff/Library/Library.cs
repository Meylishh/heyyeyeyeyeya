using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace stuff
{
    // Создать хранилище книг.
    // Каждая книга имеет название, автора и год выпуска (можно добавить
    // еще параметры). В хранилище можно добавить книгу, убрать книгу,
    // показать все книги и показать книги по указанному параметру (по
    // названию, по автору, по году выпуска).
    
    public class Library
    {
        private Dictionary<string,Book> bookList = new Dictionary<string,Book>();
        public void AddBook(Book book)
        {
            if (!bookList.ContainsKey(book.Name))
                bookList.Add(book.Name, book);
            else
                Console.WriteLine("There is already such book in the library.");
        }

        public void RemoveBook(string bookName)
        {
            bookList.Remove(bookName);
        }

        public void ShowAllBooks()
        {
            if (bookList.Any())
            {
                foreach (var book in bookList.Values)
                {
                    Console.WriteLine($"\"{book.Name}\" by {book.Author}, released in {book.ReleaseYear}");
                }                
            }
            else
                Console.WriteLine("There are no books in the library.");
        }

        public void ShowBooksByYear(int year)
        {
            if (bookList.Any())
            {
                var booksByYear = bookList.Values.Where(b => b.ReleaseYear == year).ToList();

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
            if (bookList.Any())
            {
                var booksByAuthor = bookList.Values.Where(b => b.Author == author).ToList();
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
            if (bookList.Any())
            {
                var booksByName = bookList.Values.OrderBy(b => b.Name).ToList();
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
            if (bookList.ContainsKey(name))
            {
                book = bookList[name];
                return true;
            }
            return false;
        }
    }
}