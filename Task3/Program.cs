namespace Task3
{
    class Book
    {
        string Title;
        string Author;
        int ISBN;
        bool isAvailable;

        public Book(string title, string author, int iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            isAvailable = true;
        }

        public string GetTitle()
        {
            return Title;
        }
        public void SetTitel(string value)
        {
            Title = value;
        }
        public string GetAuthor()
        {
            return Author;
        }
        public void SetAuthor(string value)
        {
            Author = value;
        }
        public int GetISBN()
        {
            return ISBN;
        }
        public void SetISBN(int value)
        {
            ISBN = value;
        }
        public bool GetAvailability()
        {
            return isAvailable;
        }
        public void SetAvailability(bool value)
        {
            isAvailable = value;
        }
    }
    class Library
    {
        List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void SearchBook(string keyword)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.GetTitle() == keyword || book.GetAuthor() == keyword)
                {
                    Console.WriteLine("Title: " + book.GetTitle());
                    Console.WriteLine("Author: " + book.GetAuthor());
                    Console.WriteLine("ISBN: " + book.GetISBN());
                    Console.WriteLine("Available?: " + (book.GetAvailability() ? "Yes" : "No"));
                    Console.WriteLine("------------------------");
                    found = true;
                } 
            }
            if (!found)
            {
                Console.WriteLine("There is no book with this word ");
            }
        }
        public void BorrowBook(string keyword)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if ((book.GetTitle() == keyword || book.GetAuthor() == keyword) && book.GetAvailability())
                {
                    book.SetAvailability(false);
                    Console.WriteLine("You have borrowed the book: " + book.GetTitle());
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Book not available or not found.");
            }
        }
        public void ReturnBook(string keyword)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if ((book.GetTitle() == keyword || book.GetAuthor() == keyword) && !book.GetAvailability())
                {
                    book.SetAvailability(true);
                    Console.WriteLine("You have returned the book: " + book.GetTitle());
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine(" Book not found or already returned.");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("C# Programming", "Anders Hejlsberg", 101));
            library.AddBook(new Book("Python Essentials", "Guido van Rossum", 102));
            library.AddBook(new Book("Java Basics", "James Gosling", 103));
            library.AddBook(new Book("JavaScript Guide", "Brendan Eich", 104));
            library.AddBook(new Book("C++ Advanced Concepts", "Bjarne Stroustrup", 105));
            library.AddBook(new Book("Ruby Programming", "Yukihiro Matsumoto", 106));
            library.AddBook(new Book("Swift Development", "Chris Lattner", 107));
            library.AddBook(new Book("Go Language", "Robert Griesemer, Rob Pike, Ken Thompson", 108));
            library.AddBook(new Book("PHP Programming", "Rasmus Lerdorf", 109));
            library.AddBook(new Book("Kotlin Programming", "JetBrains Team", 200));


            Console.WriteLine("Searching for 'Brendan Eich'");
            library.SearchBook("Brendan Eich");

            Console.WriteLine("Borrowing 'Python Essentials'");
            library.BorrowBook("Python Essentials");

            Console.WriteLine("Trying to borrow it again:");
            library.BorrowBook("Python Essentials");

            Console.WriteLine("Returning 'Python Essentials':");
            library.ReturnBook("Python Essentials");

            Console.WriteLine("Returning 'Python Essentials' again:");
            library.ReturnBook("Python Essentials");
        }
    }
}
