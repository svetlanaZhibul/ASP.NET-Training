using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookShelf.BooksComparer;
using static BookShelf.BookSearchEngine;

namespace BookShelf
{
    public class BookListServiceHelper
    {
        public IComparer ChooseSortingMethod(string sortCreterion, string order)
        {
            if (sortCreterion == null)
            {
                Console.WriteLine("No creterion was entered.");
                return null;
            }

            if (order == null)
            {
                Console.WriteLine("No order was entered. Default order(desc) will be applied.");
                order = "desc";
            }

            IComparer comparer = null;

            if (order.ToLower() == "desc")
            {
                switch (sortCreterion.ToLower())
                {
                    case "isbn":
                        comparer = new CompareByISBNDesc();
                        break;
                    case "author":
                        comparer = new CompareByAuthorAlphabetically();
                        break;
                    case "title":
                        comparer = new CompareByTitleAlphabetically();
                        break;
                    case "publisher":
                        comparer = new CompareByPublisherAlphabetically();
                        break;
                    case "year":
                        comparer = new CompareByReleaseYearDesc();
                        break;
                    case "pages":
                        comparer = new CompareByPagesDesc();
                        break;
                    case "price":
                        comparer = new CompareByPriceDesc();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            if (order.ToLower() == "asc")
            {
                switch (sortCreterion.ToLower())
                {
                    case "isbn":
                        comparer = new CompareByISBNAsc();
                        break;
                    case "author":
                        comparer = new CompareByAuthorReverseAlphabetically();
                        break;
                    case "title":
                        comparer = new CompareByTitleReverseAlphabetically();
                        break;
                    case "publisher":
                        comparer = new CompareByPublisherReverseAlphabetically();
                        break;
                    case "year":
                        comparer = new CompareByReleaseYearAsc();
                        break;
                    case "pages":
                        comparer = new CompareByPagesAsc();
                        break;
                    case "price":
                        comparer = new CompareByPriceAsc();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return comparer;
        }

        public ISearchEngine ChooseSearchMethod(string searchCreterion, string maxmin)
        {
            if (searchCreterion == null)
            {
                Console.WriteLine("No creterion was entered.");
                return null;
            }

            ISearchEngine finder = null;

            if (maxmin.ToLower() == "max")
            {
                switch (searchCreterion.ToLower())
                {
                    case "year":
                        finder = new FindBookByLatestYear();
                        break;
                    case "price":
                        finder = new FindBookByMaxPrice();
                        break;
                    case "pages":
                        finder = new FindBookByMaxPages();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            if (maxmin.ToLower() == "min")
            {
                switch (searchCreterion.ToLower())
                {
                    case "year":
                        finder = new FindBookByEarliestYear();
                        break;
                    case "price":
                        finder = new FindBookByMinPrice();
                        break;
                    case "pages":
                        finder = new FindBookByMinPages();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return finder;
        }
    }
}
