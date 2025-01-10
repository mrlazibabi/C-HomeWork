Book book1 = new Book
{
    Title = "The meaning of life",
    Author = "God",
    PublishedYear = 0,
    ISBN = "978-3-16-148410-0"
};

Book book2 = new Book
{
    Title = "When life give you lemon",
    Author = "Mr.Tree",
    PublishedYear = 2000,
    ISBN = "697-1-84-583951-0"
};

Book book3 = new Book
{
    Title = "You make lemonade",
    Author = "Mr.Tree",
    PublishedYear = 2001,
    ISBN = "697-1-84-583952-0"
};

Console.WriteLine("---Book1---: ");
Console.WriteLine($"Title: {book1.Title}");
Console.WriteLine($"Author: {book1.Author}");
Console.WriteLine($"PublishedYear: {book1.PublishedYear}");
Console.WriteLine($"ISBN: {book1.ISBN}");
Console.WriteLine();

Console.WriteLine("---Book2---: ");
Console.WriteLine($"Title: {book2.Title}");
Console.WriteLine($"Author: {book2.Author}");
Console.WriteLine($"PublishedYear: {book2.PublishedYear}");
Console.WriteLine($"ISBN: {book2.ISBN}");
Console.WriteLine();

Console.WriteLine("---Book3---: ");
Console.WriteLine($"Title: {book3.Title}");
Console.WriteLine($"Author: {book3.Author}");
Console.WriteLine($"PublishedYear: {book3.PublishedYear}");
Console.WriteLine($"ISBN: {book3.ISBN}");
Console.WriteLine();

class Book
{
    public string Title;
    public string Author;
    public int PublishedYear;
    public string ISBN;
}
