using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf
{
    public struct Author : IComparable
    {
        [Required]
        private string firstname;
        [Required]
        private string lastname;

        public Author(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() == GetType())
            {
                Author author = (Author)obj;
                if (author.firstname == this.firstname && author.lastname == this.lastname)
                    return 0;
                else
                {
                    string name = (firstname + lastname).ToLower();
                    string aname = (author.firstname + author.lastname).ToLower();
                    return name.CompareTo(aname);
                }
            }
            return 1;
        }
        // сразу сравнивать с author
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            else
            {
                if (obj.GetType() != GetType())
                {
                    return false;
                }
                else
                {
                    Author author = (Author)obj;
                    if (author.firstname == this.firstname && author.lastname == this.lastname)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
    }

    public class Book 
    {
        #region Fields
        [Key]
        [StringLength(10, MinimumLength = 10)]
        private string isbn;
        [Required]
        private Author author;
        [Required]
        private string title;
        private string publisher;
        private int publishingYear;
        [Range(0, Int32.MaxValue)]
        private int numberOfPages;
        [Range(0, Double.MaxValue)]
        private double price;
        #endregion

        #region Constructors
        public Book()
        {

        }
        public Book(string isbn, Author author, string title, string publisher, int publishingYear, int numberOfPages, double price)
        {
            this.isbn = isbn;
            this.author = author;
            this.title = title;
            this.publisher = publisher;
            this.publishingYear = publishingYear;
            this.numberOfPages = numberOfPages;
            this.price = price;
        } 
        #endregion

        #region Properties
        public Author Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        public string ISBN
        {
            get
            {
                return isbn;
            }
            internal set
            {
                isbn = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            internal set
            {
                title = value;
            }
        }
        public string Publisher
        {
            get
            {
                return publisher;
            }
            internal set
            {
                publisher = value;
            }
        }
        public int PublishingYear
        {
            get
            {
                return publishingYear;
            }
            internal set
            {
                publishingYear = value;
            }
        }
        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }
            internal set
            {
                numberOfPages = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            internal set
            {
                price = value;
            }
        }
        #endregion

        #region OverridedObjectMethods
        public bool Equals(Book book)
        {
            if (ReferenceEquals(this, book))
            {
                return true;
            }
            else
            {
                if (this.isbn != book.isbn)
                    return false;
                else
                {
                    if (!author.Equals(book.author) || title != book.title || publisher != book.publisher
                        || publishingYear != book.publishingYear /*|| price != book.price*/)
                        return false;
                    else
                        return true;
                }

            }
            //return false;
        }

        //public static bool Equals(object lhs, object rhs)
        //{
        //    if (lhs == null || rhs == null)
        //    {
        //        return false;
        //    }
        //}

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() == GetType())
            {
                return Equals((Book)obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return isbn.GetHashCode();
        }

        public override string ToString()
        {
            string output = String.Format("{0}, {1} pages\nISBN: {2}\nAuthor: {3} {4}\nPublisher: {5}\nPublished: {6}\nPrice: {7}", title, numberOfPages, isbn, author.Firstname, author.Lastname, publisher, publishingYear, price);

            return output;
        } 
        #endregion

    }

}
