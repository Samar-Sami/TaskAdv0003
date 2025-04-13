namespace ConsoleApp1
{
    internal class Program
    {

        #region Question  Book Class and BookFunctions Methods
        public class Book
        {
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string[] Authors { get; set; }
            public DateTime PublicationDate { get; set; }
            public decimal Price { get; set; }

            public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
            {
                ISBN = _ISBN;
                Title = _Title;
                Authors = _Authors;
                PublicationDate = _PublicationDate;
                Price = _Price;
            }

            public override string ToString()
            {
                return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, " +
                       $"Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
            }
        }

        public class BookFunctions
        {
            public static string GetTitle(Book B)
            {
                return B.Title;
            }

            public static string GetAuthors(Book B)
            {
                return string.Join(", ", B.Authors);
            }

            public static string GetPrice(Book B)
            {
                return B.Price.ToString("C");
            }
        }
        #endregion

        #region Question : LibraryEngine with Various Delegate Types
        public delegate string BookDelegate(Book B);

        public class LibraryEngine
        {
            public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
            {
                foreach (Book B in bList)
                {
                    Console.WriteLine(fPtr(B));
                }
            }

            public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
            {
                foreach (Book B in bList)
                {
                    Console.WriteLine(fPtr(B));
                }
            }
        }

       
            static void Main()
            {

                // Create sample books
                List<Book> books = new List<Book>
        {
            new Book("1234567890", "Book Title 1", new string[] { "Author A", "Author B" }, new DateTime(2020, 1, 1), 19.99m),
            new Book("0987654321", "Book Title 2", new string[] { "Author C" }, new DateTime(2021, 6, 15), 25.99m)
        };

                // Question  ProcessBooks with various methods

                // Using user-defined delegate
                LibraryEngine.ProcessBooks(books, new BookDelegate(BookFunctions.GetTitle));

                // Using built-in delegate Func
                LibraryEngine.ProcessBooks(books, new Func<Book, string>(BookFunctions.GetAuthors));

                //Anonymous Method (GetISBN).
                LibraryEngine.ProcessBooks(books, new Func<Book, string>(delegate (Book B) { return B.ISBN; }));

                // Using lambda expression for GetPublicationDate
                LibraryEngine.ProcessBooks(books, new Func<Book, string>(B => B.PublicationDate.ToShortDateString()));
            }
        }
        #endregion

    }
