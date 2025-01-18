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
            Console.WriteLine("2. Tìm sách.");
            Console.WriteLine("3. Hiển thị danh sách sách.");
            Console.WriteLine("4. Xóa sách.");
            Console.WriteLine("5. Thoát.");
            Console.Write("Chọn một tùy chọn: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    FindBook();
                    break;
                case "3":
                    DisplayBooks();
                    break;
                case "4":
                    RemoveBook();
                    break;
                case "5":
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

    public void FindBook()
    {
        Console.Write("Nhập mã ISBN để tìm sách: ");
        string isbn = Console.ReadLine();

        Book book = library.FindBookByISBN(isbn);
        if (book != null)
        {
            Console.WriteLine("Thông tin sách:");
            Console.WriteLine($"{book.Author} - {book.Title}({book.PublishedYear}) - {book.ISBN}");
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

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    Console.WriteLine($"{books[i].Author} - {books[i].Title}({books[i].PublishedYear}) - {books[i].ISBN}");
                }
            }
        }
    }

    public void RemoveBook()
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
}
