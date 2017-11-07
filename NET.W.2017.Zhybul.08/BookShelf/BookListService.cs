using System;
using System.Collections.Generic;
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
        private List<Book> books;
        
        public List<Book> BookList => books;

        #region Constructors
        public BookListService()
        {
            books = new List<Book>();
        }
        public BookListService(List<Book> books)
        {
            this.books = books;
        } 
        #endregion

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

        #region PrivateMethods
        private void SwapBooksInList(int lhs, int rhs)
        {
            Book temp = books[lhs];
            books[lhs] = books[rhs];
            books[rhs] = temp;
        } 
        #endregion

    }

    public class BookListServiceStorage
    {
        public string DefaultStorage { get; set; }
        public string DefaultStorageDirectory { get; set; }
        public string Storage { get; private set; }

        public BookListServiceStorage()
        {
            DefaultStorage = @"books.dat";
            DefaultStorageDirectory = @"bookshelf";
            Storage = $"{DefaultStorageDirectory}\\{DefaultStorage}";
        }
        public void WriteToBookStorage(List<Book> books)
        {
            if (!Directory.Exists(DefaultStorageDirectory))
            {
                DefaultStorageDirectory = $"{Environment.CurrentDirectory}\\{DefaultStorageDirectory}";
                Directory.CreateDirectory(DefaultStorageDirectory);
                Storage = $"{DefaultStorageDirectory}\\{DefaultStorage}";
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(Storage, FileMode.OpenOrCreate)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.ISBN);
                    writer.Write(book.Author.Firstname);
                    writer.Write(book.Author.Lastname);
                    writer.Write(book.Title);
                    writer.Write(book.Publisher);
                    writer.Write(book.PublishingYear);
                    writer.Write(book.NumberOfPages);
                    writer.Write(book.Price);
                }
            }
        }
        public List<Book> ReadFromBookStorage()
        {
            List<Book> list = new List<Book>();
            //Book temp = new Book();

            string storage = $"{DefaultStorageDirectory}\\{DefaultStorage}";

            if (File.Exists(Storage))
            {
                Author tempAuthor = new Author();
                using (BinaryReader reader = new BinaryReader(File.Open(Storage, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        Book temp = new Book();

                        temp.ISBN = reader.ReadString();

                        tempAuthor.Firstname = reader.ReadString();
                        tempAuthor.Lastname = reader.ReadString();
                        temp.Author = tempAuthor;

                        temp.Title = reader.ReadString();
                        temp.Publisher = reader.ReadString();
                        temp.PublishingYear = reader.ReadInt32();
                        temp.NumberOfPages = reader.ReadInt32();
                        temp.Price = reader.ReadDouble();


                        list.Add(temp);
                        //Console.WriteLine(temp);

                    }
                }
                //books = list;
                return list;                
            }
            else
            {
                Console.WriteLine("Invalid path was entered!");
                return null;
            }
        }

        public void ChangeStorageDirectory(string anotherDirectory)
        {
            DefaultStorageDirectory = anotherDirectory;
            Storage = $"{DefaultStorageDirectory}//{DefaultStorage}";
        }
        public void ChangeStorage(string anotherDirectory, string anotherFile)
        {
            DefaultStorageDirectory = anotherDirectory;
            DefaultStorage = anotherFile;
            Storage = $"{DefaultStorageDirectory}//{DefaultStorage}";
        }
        public void ChangeStorageFile(string anotherFile)
        {
            DefaultStorage = anotherFile;
            Storage = $"{DefaultStorageDirectory}//{DefaultStorage}";
        }

    }
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
