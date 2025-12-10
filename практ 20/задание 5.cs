using System;
using System.Collections.Generic;

class Program
{
    
    class BookAlreadyTakenException : Exception
    {
        public BookAlreadyTakenException(string book, string reader)
            : base($"Книга '{book}' уже выдана читателю {reader}") { }
    }

    class Library
    {
        Dictionary<string, string> books = new()
        {
            ["Война и мир"] = null,
            ["Преступление и наказание"] = "Иван",
            ["1984"] = null
        };

        public void TakeBook(string book, string reader)
        {
            if (!books.ContainsKey(book))
                throw new Exception($"Книги '{book}' нет в библиотеке");

            if (books[book] != null)
                throw new BookAlreadyTakenException(book, books[book]);

            books[book] = reader;
            Console.WriteLine($"Книга '{book}' выдана {reader}");
        }

        public void ReturnBook(string book)
        {
            if (books[book] == null)
                throw new Exception($"Книга '{book}' не была выдана");

            books[book] = null;
            Console.WriteLine($"Книга '{book}' возвращена");
        }
    }

    static void Main()
    {
        
        Console.WriteLine("=== Библиотека ===\n");
        var lib = new Library();

        try { lib.TakeBook("Преступление и наказание", "Петр"); }
        catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}"); }

        try { lib.TakeBook("Война и мир", "Анна"); }
        catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}"); }

        try { lib.ReturnBook("1984"); }
        catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}"); }
    }
}