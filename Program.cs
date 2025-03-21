namespace Task4
{
    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public bool Avalabilty { get; set; }

        public Book(string title, string author, string iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Avalabilty = false;
        }
    }

    class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public bool AddBook(Book book)
        {
            foreach (Book i in Books)
            {
                if (book != null && i.Title.ToLowerInvariant != book.Title.ToLowerInvariant)
                {
                    Books.Add(book);
                    book.Avalabilty = true;
                    return true;
                }
            }

            return false;

        }
        public string SearchBooks(string title)
        {
            foreach (Book i in Books)
            {
                if (title.ToLowerInvariant == i.Title.ToLowerInvariant) return $"The {title} book is availabe at the library";
            }
            return $"Sorry the {title}book not found";
        }

        public string BorrowBook(Book book)
        {
            if (book.Avalabilty)
            {
                book.Avalabilty = false;
                return $"This {book.Title} book has been borrowed right now";
            }
            return $"This {book.Title}book has been already borrowed or not available";
        }

        public string ReturnBook(Book book)
        {
            if (!book.Avalabilty)
            {
                book.Avalabilty = true;
                return $"This {book.Title} book has been returned right now";
            }
            return $"This {book.Title} book has been already returned and available or may not be in the library";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book gatsby = new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
            Book toKill = new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084");
            Book oneNine = new Book("1984", "George Orwell", "9780451524935");
            Book harry = new Book("harry potter", "George", "9780451526545");
            // Adding books to the library
            library.AddBook(gatsby);
            library.AddBook(toKill);
            library.AddBook(oneNine);

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            Console.WriteLine(library.BorrowBook(gatsby));
            Console.WriteLine(library.BorrowBook(oneNine));
            Console.WriteLine(library.BorrowBook(harry)); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            Console.WriteLine(library.ReturnBook(gatsby));
            Console.WriteLine(library.ReturnBook(harry)); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
