using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShelf;
using static BookShelf.BooksComparer;
using static BookShelf.BookSearchEngine;

namespace BookShelfRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Books list initialisation
            Book book1 = new Book("0140448101", new Author("Alexander", "Pushkin"), "Eugene Onegin", "Penguin Classics", 2008, 55, 14.00);
            Book book2 = new Book("0486264726", new Author("Jack", "London"), "The Call of the Wild", "Dover Publications", 1990, 268, 3.00);
            Book book3 = new Book("0061122416", new Author("Paulo", "Coelho"), "The Alchemist", "Harper", 1998, 222, 4.40);
            Book book4 = new Book("0060528001", new Author("Paulo", "Coelho"), "The Devil and Miss Prym", "Harper", 2007, 235, 14.99);
            Book book5 = new Book("0140449264", new Author("Alexandre", "Dumas"), "The Count of Monte Cristo", "Penguin Classics", 2003, 780, 16.00);
            Book book6 = new Book("1629914665", new Author("Jules", "Verne"), "The Children of Captain Grant", "Papercutz", 2017, 439, 14.99);

            BookListService boxOfBooks = new BookListService();
            boxOfBooks.AddBook(book1);
            boxOfBooks.AddBook(book2);
            boxOfBooks.AddBook(book3);
            boxOfBooks.AddBook(book4);
            boxOfBooks.AddBook(book5);
            boxOfBooks.AddBook(book6);

            // Write to storage
            BookListServiceStorage storage = new BookListServiceStorage();
            storage.WriteToBookStorage(boxOfBooks.BookList);
            // Read from storage
            BookListService copyBoxOfBooks = new BookListService(storage.ReadFromBookStorage());
            // Console output
            copyBoxOfBooks.PrintList();

            // Sort books by creterion and order
            Console.WriteLine("Choose a creterion of sorting from listed below:");
            Console.WriteLine("ISBN, author, title, publisher, release year (just type \"year\"), number of pages (just type \"pages\"), price");
            string creterion = Console.ReadLine();

            Console.WriteLine("Choose an order of sorting: write \"asc\" or \"desc\"");
            string order = Console.ReadLine();

            BookListServiceHelper helper = new BookListServiceHelper();
            IComparer comparer = helper.ChooseSortingMethod(creterion, order);

            boxOfBooks.SortBooksByTag(comparer);
            boxOfBooks.PrintList();

            // Remove book from list and print new list
            boxOfBooks.RemoveBook(new Book("1629914665", new Author("Jules", "Verne"), "The Children of Captain Grant", "Papercutz", 2017, 439, 14.99));
            Console.WriteLine("\nList of books after one was deleted.");
            boxOfBooks.PrintList();


            // Search for books by creteria
            Console.WriteLine("Choose a creterion of search from listed below:");
            Console.WriteLine("release year (just type \"year\"), number of pages (just type \"pages\"), price");
            string tag = Console.ReadLine();

            Console.WriteLine("Choose maxmin creterion: write \"max\" or \"min\"");
            string maxmin = Console.ReadLine();

            try
            {
                ISearchEngine tagComparer = helper.ChooseSearchMethod(tag, maxmin);
                Book book = boxOfBooks.FindBookByTag(tagComparer);
                Console.WriteLine("\nA book found by tag \"{0} {1}\":\n{2}", maxmin, tag, book);

            }
            catch (Exception)
            {
                Console.WriteLine("No book found by a given creterion.");
                //throw;
            }

            Console.ReadKey();
        }
    }
}
