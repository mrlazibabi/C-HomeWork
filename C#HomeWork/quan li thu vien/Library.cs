public class Library
{
    public Book[] Books = new Book[0];

    public void AddBook(Book newBook)
    {
        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].ISBN.Equals(newBook.ISBN, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Sách với mã ISBN này đã tồn tại!");
                return;
            }
        }

        Array.Resize(ref Books, Books.Length + 1);
        Books[Books.Length - 1] = newBook;
        Console.WriteLine("Đã thêm sách thành công.");
    }

    public Book FindBookByISBN(string isbn)
    {
        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
            {
                return Books[i];
            }
        }
        return null;
    }

    public Book[] GetBooks()
    {
        return Books;
    }

    public bool RemoveBook(string isbn)
    {
        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
            {
                for (int j = i; j < Books.Length - 1; j++)
                {
                    Books[j] = Books[j + 1];
                }

                Array.Resize(ref Books, Books.Length - 1);
                return true;
            }
        }
        return false;
    }

    public Book[] FindBooksByAuthor(string author)
    {
        int count = 0;

        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        Book[] books = new Book[count];
        int index = 0;

        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                books[index++] = Books[i];
            }
        }

        return books;
    }

    public Book[] FindBooksByYear(int year)
    {
        int count = 0;

        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].PublishedYear == year)
            {
                count++;
            }
        }

        Book[] books = new Book[count];
        int index = 0;

        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].PublishedYear == year)
            {
                books[index++] = Books[i];
            }
        }

        return books;
    }
    public Book[] FindBooksByCategory(string category)
    {
        int count = 0;

        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        Book[] books = new Book[count];
        int index = 0;

        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            {
                books[index++] = Books[i];
            }
        }

        return books;
    }


    public bool UpdateBookInfo(string isbn, string newTitle, string newAuthor, string newCategory, int newPublishedYear)
    {
        for (int i = 0; i < Books.Length; i++)
        {
            if (Books[i] != null && Books[i].ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
            {
                Books[i].Title = newTitle;
                Books[i].Author = newAuthor;
                Books[i].Category = newCategory;
                Books[i].PublishedYear = newPublishedYear;
                return true;
            }
        }
        return false;
    }

    public int TotalBooks()
    {
        return Books.Length;
    }
}
