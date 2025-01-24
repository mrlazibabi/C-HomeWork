Console.OutputEncoding = System.Text.Encoding.UTF8;
LibraryMenu menu = new LibraryMenu();
menu.ShowMenu();

public class LibraryMenu
{
    private Library library = new Library();

    public void ShowMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Quản Lý Thư Viện ---");
            Console.WriteLine("1. Thêm sách.");
            Console.WriteLine("2. Tìm sách theo ISBN.");
            Console.WriteLine("3. Hiển thị danh sách sách.");
            Console.WriteLine("4. Xóa sách theo ISBN.");
            Console.WriteLine("5. Tìm sách theo tác giả.");
            Console.WriteLine("6. Tìm sách theo năm xuất bản.");
            Console.WriteLine("7. Tìm sách theo danh mục.");
            Console.WriteLine("8. Cập nhật thông tin sách.");
            Console.WriteLine("9. Xem tổng số sách.");
            Console.WriteLine("10. Tạo 10 sách mẫu.");
            Console.WriteLine("0. Thoát.");
            Console.Write("Chọn một tùy chọn: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    FindBookByISBN();
                    break;
                case "3":
                    DisplayBooks();
                    break;
                case "4":
                    RemoveBookByISBN();
                    break;
                case "5":
                    FindBooksByAuthor();
                    break;
                case "6":
                    FindBooksByYear();
                    break;
                case "7":
                    FindBooksByCategory();
                    break;
                case "8":
                    UpdateBookInfo();
                    break;
                case "9":
                    DisplayTotalBooks();
                    break;
                case "10":
                    AddSampleBooks();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                    break;
            }
        }
    }

    public void AddBook()
    {
        Book newBook = new Book();

        Console.Write("Title: ");
        newBook.Title = Console.ReadLine();

        Console.Write("Author: ");
        newBook.Author = Console.ReadLine();

        Console.Write("Category: ");
        newBook.Category = Console.ReadLine();

        Console.Write("ISBN code(Nxxxx): ");
        newBook.ISBN = Console.ReadLine();

        Console.Write("Published Year: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            newBook.PublishedYear = year;
            library.AddBook(newBook);
        }
        else
        {
            Console.WriteLine("Published Year không hợp lệ.");
        }
    }

    public void FindBookByISBN()
    {
        Console.Write("Nhập mã ISBN để tìm sách: ");
        string isbn = Console.ReadLine();

        Book book = library.FindBookByISBN(isbn);
        if (book != null)
        {
            Console.WriteLine("Thông tin sách:");
            Console.WriteLine($"{book.Category} - {book.Author} - {book.Title} ({book.PublishedYear}) - {book.ISBN}");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sách với mã ISBN này.");
        }
    }

    public void DisplayBooks()
    {
        Book[] books = library.GetBooks();

        if (books.Length == 0)
        {
            Console.WriteLine("Thư viện hiện không có sách nào.");
        }
        else
        {
            Console.WriteLine("Danh sách sách trong thư viện:");

            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Category} - {book.Author} - {book.Title} ({book.PublishedYear}) - {book.ISBN}");
            }
        }
    }

    public void RemoveBookByISBN()
    {
        Console.Write("Nhập mã ISBN để xóa sách: ");
        string isbn = Console.ReadLine();
        bool removed = library.RemoveBook(isbn);

        if (removed)
        {
            Console.WriteLine("Đã xóa sách thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sách với mã ISBN này để xóa.");
        }
    }

    public void FindBooksByAuthor()
    {
        Console.Write("Nhập tên tác giả để tìm sách: ");
        string author = Console.ReadLine();
        Book[] books = library.FindBooksByAuthor(author);

        if (books.Length == 0)
        {
            Console.WriteLine("Không tìm thấy sách của tác giả này.");
        }
        else
        {
            Console.WriteLine("Danh sách sách của tác giả:");
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Category} - {book.Author} - {book.Title} ({book.PublishedYear}) - {book.ISBN}");
            }
        }
    }

    public void FindBooksByYear()
    {
        Console.Write("Nhập năm xuất bản để tìm sách: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            Book[] books = library.FindBooksByYear(year);

            if (books.Length == 0)
            {
                Console.WriteLine("Không tìm thấy sách xuất bản trong năm này.");
            }
            else
            {
                Console.WriteLine("Danh sách sách xuất bản trong năm:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"{book.Category} - {book.Author} - {book.Title} ({book.PublishedYear}) - {book.ISBN}");
                }
            }
        }
        else
        {
            Console.WriteLine("Năm xuất bản không hợp lệ.");
        }
    }

    public void FindBooksByCategory()
    {
        Console.Write("Nhập danh mục để tìm sách: ");
        string category = Console.ReadLine();
        Book[] books = library.FindBooksByCategory(category);

        if (books.Length == 0)
        {
            Console.WriteLine("Không tìm thấy sách thuộc danh mục này.");
        }
        else
        {
            Console.WriteLine("Danh sách sách thuộc danh mục:");
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Category} - {book.Author} - {book.Title} ({book.PublishedYear}) - {book.ISBN}");
            }
        }
    }

    public void UpdateBookInfo()
    {
        Console.Write("Nhập mã ISBN của sách cần cập nhật: ");
        string isbn = Console.ReadLine();

        Console.Write("Tiêu đề mới: ");
        string newTitle = Console.ReadLine();

        Console.Write("Tác giả mới: ");
        string newAuthor = Console.ReadLine();

        Console.Write("Danh mục mới: ");
        string newCategory = Console.ReadLine();

        Console.Write("Năm xuất bản mới: ");
        if (int.TryParse(Console.ReadLine(), out int newYear))
        {
            bool updated = library.UpdateBookInfo(isbn, newTitle, newAuthor, newCategory, newYear);

            if (updated)
            {
                Console.WriteLine("Cập nhật thông tin sách thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sách với mã ISBN này để cập nhật.");
            }
        }
        else
        {
            Console.WriteLine("Năm xuất bản không hợp lệ.");
        }
    }

    public void DisplayTotalBooks()
    {
        int total = library.TotalBooks();
        Console.WriteLine($"Tổng số sách trong thư viện: {total}");
    }

    public void AddSampleBooks()
    {
        Book[] sampleBooks = new Book[]
        {
        new Book { Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", ISBN = "N0001", PublishedYear = 2008 },
        new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Category = "Programming", ISBN = "N0002", PublishedYear = 1999 },
        new Book { Title = "Design Patterns", Author = "Erich Gamma", Category = "Programming", ISBN = "N0003", PublishedYear = 1994 },
        new Book { Title = "Effective Java", Author = "Joshua Bloch", Category = "Programming", ISBN = "N0004", PublishedYear = 2008 },
        new Book { Title = "Refactoring", Author = "Martin Fowler", Category = "Programming", ISBN = "N0005", PublishedYear = 1999 },
        new Book { Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Category = "Algorithms", ISBN = "N0006", PublishedYear = 2009 },
        new Book { Title = "Artificial Intelligence", Author = "Stuart Russell", Category = "AI", ISBN = "N0007", PublishedYear = 2016 },
        new Book { Title = "Deep Learning", Author = "Ian Goodfellow", Category = "AI", ISBN = "N0008", PublishedYear = 2016 },
        new Book { Title = "Computer Networking", Author = "James F. Kurose", Category = "Networking", ISBN = "N0009", PublishedYear = 2021 },
        new Book { Title = "Operating System Concepts", Author = "Abraham Silberschatz", Category = "Operating Systems", ISBN = "N0010", PublishedYear = 2018 }
        };

        foreach (Book book in sampleBooks)
        {
            library.AddBook(book);
        }

        Console.WriteLine("Đã thêm 10 sách mẫu vào thư viện.");
    }
}
