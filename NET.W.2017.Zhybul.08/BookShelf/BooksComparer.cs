using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf
{
    public class BooksComparer
    {
        public interface IComparer
        {
            int Compare(Book lhs, Book rhs);
        }

        public class CompareByISBNAsc : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return lhs.ISBN.CompareTo(rhs.ISBN);
            }
        }

        public class CompareByISBNDesc : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return rhs.ISBN.CompareTo(lhs.ISBN);
            }
        }

        public class CompareByAuthorAlphabetically : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return lhs.Author.CompareTo(rhs.Author);
            }
        }

        public class CompareByAuthorReverseAlphabetically : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return rhs.Author.CompareTo(lhs.Author);
            }
        }

        public class CompareByTitleAlphabetically : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return lhs.Title.CompareTo(rhs.Title);
            }
        }

        public class CompareByTitleReverseAlphabetically : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return rhs.Title.CompareTo(lhs.Title);
            }
        }

        public class CompareByPublisherAlphabetically : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return lhs.Publisher.CompareTo(rhs.Publisher);
            }
        }

        public class CompareByPublisherReverseAlphabetically : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return rhs.Publisher.CompareTo(lhs.Publisher);
            }
        }

        public class CompareByReleaseYearDesc : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return lhs.PublishingYear - rhs.PublishingYear;
            }
        }

        public class CompareByReleaseYearAsc : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return rhs.PublishingYear - lhs.PublishingYear;
            }
        }

        public class CompareByPagesDesc : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return lhs.NumberOfPages - rhs.NumberOfPages;
            }
        }

        public class CompareByPagesAsc : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                return rhs.NumberOfPages - lhs.NumberOfPages;
            }
        }

        public class CompareByPriceDesc : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (Math.Round(lhs.Price - rhs.Price, 2) == 0)
                {
                    return 0;
                }

                if (Math.Round(lhs.Price - rhs.Price, 2) < 0)
                {
                    return -1;
                }

                return 1;
            }
        }

        public class CompareByPriceAsc : IComparer
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (Math.Round(rhs.Price - lhs.Price, 2) == 0)
                {
                    return 0;
                }

                if (Math.Round(rhs.Price - lhs.Price, 2) < 0)
                {
                    return -1;
                }

                return 1;
            }
        }
    }
}
