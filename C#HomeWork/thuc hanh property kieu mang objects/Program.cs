Library libraryA = new Library
{
    Name = "Nha Sach Thu Duc",
    Address = "123 Vo Van Ngan",
    Book = new Book[]
    {
        new Book {Title = "A Normal Book For Dummy", Author = "Le Tuan Anh"},
        new Book {Title = "A Normal Book, Maybe...", Author = "Le Tuan Anh"}
    }
};
Console.WriteLine("===Library A===");
Console.WriteLine($"Name: {libraryA.Name}");
Console.WriteLine($"Address: {libraryA.Address}");
Console.WriteLine("Books:");
foreach (Book book in libraryA.Book)
{
    Console.WriteLine($"- \"{book.Title}\" by {book.Author}");
}
Console.WriteLine("\n");

Library libraryB = new Library
{
    Name = "Nha Sach Ho Chi Minh",
    Address = "321 To Ngoc Van",
    Book = new Book[]
    {
        new Book{Title = "Lemon Tree", Author = "Johnny Lemon"},
        new Book{Title = "Blue Sky", Author = "Mr.Brown"}
    }
};
Console.WriteLine("===Library B===");
Console.WriteLine($"Name: {libraryB.Name}");
Console.WriteLine($"Address: {libraryB.Address}");
Console.WriteLine("Books:");
foreach (Book book in libraryB.Book)
{
    Console.WriteLine($"\"{book.Title}\" by {book.Author}");
}
Console.WriteLine("\n");

Library libraryC = new Library
{
    Name = "Nha Sach Ha Noi",
    Address = "Ha Noi",
    Book = new Book[]
    {
        new Book{Title = "Nguoi Ha Noi", Author = "hanoi-er"},
        new Book{Title = "Nguoi Thanh Pho", Author = "hanoi-er"}
    }
};
Console.WriteLine("===Library C===");
Console.WriteLine($"Name: {libraryC.Name}");
Console.WriteLine($"Address: {libraryC.Address}");
Console.WriteLine("Books:");
foreach (Book book in libraryC.Book)
{
    Console.WriteLine($"\"{book.Title}\" by {book.Author}");
}
Console.WriteLine("\n");

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
}

class Library
{
    public string Name { get; set; }
    public string Address { get; set; }
    public Book[] Book { get; set; }
}