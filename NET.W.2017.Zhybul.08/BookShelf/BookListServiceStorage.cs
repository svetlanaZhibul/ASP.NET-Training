using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf
{
    public class BookListServiceStorage
    {
        // optional dependency 
        // or hard dependency compare

        public BookListServiceStorage()
        {
            DefaultStorage = @"books.dat";
            DefaultStorageDirectory = @"bookshelf";
            Storage = $"{DefaultStorageDirectory}\\{DefaultStorage}";
        }

        public string DefaultStorage { get; set; }

        public string DefaultStorageDirectory { get; set; }

        public string Storage { get; private set; }

        // принимать IEnumerable
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

            //string value = System.Configuration.Assemblies.AssemblyHash[];

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
}
