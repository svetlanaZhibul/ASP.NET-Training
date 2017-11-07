using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf
{
    public class BookSearchEngine
    {
        public interface ISearchEngine
        {
            Book Find(List<Book> books);
        }
        public class FindBookByMaxPages : ISearchEngine
        {
            public Book Find(List<Book> books)
            {
                if (books == null)
                {
                    return null;
                }

                int maxPages = books[0].NumberOfPages;
                int index = 0;
                for (int i = 1; i < books.Count; i++)
                {
                    if (maxPages < books[i].NumberOfPages)
                    {
                        maxPages = books[i].NumberOfPages;
                        index = i;
                    }
                }
                return books[index];
            }
        }
        public class FindBookByMinPages : ISearchEngine
        {
            public Book Find(List<Book> books)
            {
                if (books == null)
                {
                    return null;
                }

                int minPages = books[0].NumberOfPages;
                int index = 0;
                for (int i = 1; i < books.Count; i++)
                {
                    if (minPages > books[i].NumberOfPages)
                    {
                        minPages = books[i].NumberOfPages;
                        index = i;
                    }
                }
                return books[index];
            }
        }
        public class FindBookByMaxPrice : ISearchEngine
        {
            public Book Find(List<Book> books)
            {
                if (books == null)
                {
                    return null;
                }

                double maxPrice = books[0].Price;
                int index = 0;
                for (int i = 1; i < books.Count; i++)
                {
                    if (maxPrice < books[i].Price)
                    {
                        maxPrice = books[i].Price;
                        index = i;
                    }
                }
                return books[index];
            }
        }
        public class FindBookByMinPrice : ISearchEngine
        {
            public Book Find(List<Book> books)
            {
                if (books == null)
                {
                    return null;
                }

                double minPrice = books[0].Price;
                int index = 0;
                for (int i = 1; i < books.Count; i++)
                {
                    if (minPrice > books[i].Price)
                    {
                        minPrice = books[i].Price;
                        index = i;
                    }
                }
                return books[index];
            }
        }
        public class FindBookByLatestYear : ISearchEngine
        {
            public Book Find(List<Book> books)
            {
                if (books == null)
                {
                    return null;
                }

                int year = books[0].PublishingYear;
                int index = 0;
                for (int i = 1; i < books.Count; i++)
                {
                    if (year < books[i].PublishingYear)
                    {
                        year = books[i].PublishingYear;
                        index = i;
                    }
                }
                return books[index];
            }
        }
        public class FindBookByEarliestYear : ISearchEngine
        {
            public Book Find(List<Book> books)
            {
                if (books == null)
                {
                    return null;
                }

                int year = books[0].PublishingYear;
                int index = 0;
                for (int i = 1; i < books.Count; i++)
                {
                    if (year > books[i].PublishingYear)
                    {
                        year = books[i].PublishingYear;
                        index = i;
                    }
                }
                return books[index];
            }
        }
    }
}
