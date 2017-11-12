using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf
{
        public interface IOutputProvider
        {
            string Print(Book book);
        }

        public class FormatOutputAuthorandTitle : IOutputProvider
    {
        public string Print(Book book)
            {
                return $"{book.Author}, {book.Title}";
            }
        }

        public class FormatOutputAuthorTitlePublisherYear : IOutputProvider
    {
        public string Print(Book book)
            {
                return $"{new FormatOutputAuthorandTitle().Print(book)}, \"{book.Publisher}\", {book.PublishingYear}";
            }
        }

        public class FormatOutputISBNAuthorTitlePublisherYearPages : IOutputProvider
    {
        public string Print(Book book)
            {
                return $"ISBN 13: {book.ISBN}, {new FormatOutputAuthorTitlePublisherYear().Print(book)}, P. {book.NumberOfPages}";
            }
        }

        public class FormatOutputISBNAuthorTitlePublisherYearPagesPrice : IOutputProvider
    {
        public string Print(Book book)
            {
            NumberFormatInfo f = new NumberFormatInfo();
            f.CurrencySymbol = "$";
            string formatPrice = book.Price.ToString("C", f);
                return $"{new FormatOutputISBNAuthorTitlePublisherYearPages().Print(book)}, {formatPrice}";
            }
        }

    public class BookFormat : IFormatProvider
    {
        private static Dictionary<string, Func<Book, string>> formats = new Dictionary<string, Func<Book, string>>
        {
            { "AT", (book) => Format(new FormatOutputAuthorandTitle(), book) },
            { "PY", (book) => Format(new FormatOutputAuthorTitlePublisherYear(), book) },
            { "IP", (book) => Format(new FormatOutputISBNAuthorTitlePublisherYearPages(), book) },
            { "P", (book) => Format(new FormatOutputISBNAuthorTitlePublisherYearPagesPrice(), book) }
        };

        public static string PerformFormatting(string format, Book book)
        {
            if (!formats.ContainsKey(format))
                throw new ArgumentException(string.Format("Format {0} is invalid", format));
            return formats[format](book);
        }

        public object GetFormat(Type formatType)
        {
            return this;
        }

        public static string Format(IOutputProvider output, Book book)
        {
            return output.Print(book);
        }
    }
}
