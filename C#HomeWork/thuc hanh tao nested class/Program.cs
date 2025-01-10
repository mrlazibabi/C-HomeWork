Book bookA = new Book
{
    Title = "A Normal Book",
    Price = 12.000m,
    Publisher = new Publisher
    {
        Name = "Le Tuan Anh",
        Address = "Tp.Thu Duc"
    }
};
Console.WriteLine("===Book A===");
Console.WriteLine($"Tile: {bookA.Title}");
Console.WriteLine($"Price: {bookA.Price} dong");
Console.WriteLine($"Publisher: {bookA.Publisher.Name}, in {bookA.Publisher.Address}");
Console.WriteLine("\n");

Book bookB = new Book
{
    Title = "Not A Normal Book",
    Price = 21.000m,
    Publisher = new Publisher
    {
        Name = "Anh Tuan Le",
        Address = "Ho Chi Minh"
    }
};
Console.WriteLine("===Book B===");
Console.WriteLine($"Tile: {bookB.Title}");
Console.WriteLine($"Price: {bookB.Price} dong");
Console.WriteLine($"Publisher: {bookB.Publisher.Name}, in {bookB.Publisher.Address}");
Console.WriteLine("\n");

Book bookC = new Book
{
    Title = "Not A Book, but a Journal",
    Price = 50.000m,
    Publisher = new Publisher
    {
        Name = "Nobody",
        Address = "Nowhere"
    }
};
Console.WriteLine("===Book C===");
Console.WriteLine($"Tile: {bookC.Title}");
Console.WriteLine($"Price: {bookC.Price} dong");
Console.WriteLine($"Publisher: {bookC.Publisher.Name}, in {bookC.Publisher.Address}");
Console.WriteLine("\n");

Book bookD = new Book
{
    Title = "THE END",
    Price = 100.000m,
    Publisher = new Publisher
    {
        Name = "GOD",
        Address = "HEAVEN"
    }
};
Console.WriteLine("===Book D===");
Console.WriteLine($"Tile: {bookD.Title}");
Console.WriteLine($"Price: {bookD.Price} dong");
Console.WriteLine($"Publisher: {bookD.Publisher.Name}, in {bookD.Publisher.Address}");
Console.WriteLine("\n");

class Publisher
{
    public string Name { get; set; }
    public string Address { get; set; }
}

class Book
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public Publisher Publisher { get; set; }
}