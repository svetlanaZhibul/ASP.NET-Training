using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookShelf.BooksComparer;
using static BookShelf.BookSearchEngine;

namespace BookShelf
{
    public class BookListService
    {
        private List<Book> books = new List<Book>();

        #region Constructors
        public BookListService()
        {
        }

        public BookListService(List<Book> books)
        {
            this.books = books;
        }
        #endregion
        public List<Book> BookList => books;

        #region PublicMethods
        public void AddBook(Book book)
        {
            if (books.Contains(book))
            {
                throw new ArgumentException(nameof(book));
            }
            else
            {
                books.Add(book);
            }
        }

        public void RemoveBook(Book book)
        {
            if (!books.Contains(book))
            {
                throw new ArgumentException(nameof(book));
            }
            else
            {
                books.Remove(book);
            }
        }

        public Book FindBookByTag(ISearchEngine finder)
        {
            return finder.Find(books);
        }

        public void SortBooksByTag(IComparer tag)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < books.Count - 1; i++)
                {
                    if (tag.Compare(books[i], books[i + 1]) < 0)
                    {
                        flag = true;
                        SwapBooksInList(i, i + 1);
                    }
                } 
            }
        }

        public void PrintList()
        {
            foreach (Book b in books)
            {
                Console.WriteLine(b);
                Console.WriteLine("------------------------------------------------");
            }
        }
        #endregion
        // Save to storage method
        // Load from storage method 
        #region PrivateMethods
        private void SwapBooksInList(int lhs, int rhs)
        {
            Book temp = books[lhs];
            books[lhs] = books[rhs];
            books[rhs] = temp;
        } 
        #endregion
    }
}
