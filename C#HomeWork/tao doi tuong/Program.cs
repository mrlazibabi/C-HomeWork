Person personA = new Person
{
    Name = "Le Tuan Anh",
    Age = 21,
    HomeAddress = new Address
    {
        Street = "Duong 16",
        City = "Thu Duc"
    }
};
Console.WriteLine("===Person A===");
Console.WriteLine($"Name: {personA.Name}");
Console.WriteLine($"Age: {personA.Age}");
Console.WriteLine($"HomeAddress: {personA.HomeAddress.Street}, {personA.HomeAddress.City}");
Console.WriteLine("\n");

Person personB = new Person
{
    Name = "Le Anh Tuan",
    Age = 21,
    HomeAddress = new Address
    {
        Street = "Hoang Dieu 2",
        City = "Thu Duc"
    }
};
Console.WriteLine("===Person B===");
Console.WriteLine($"Name: {personB.Name}");
Console.WriteLine($"Age: {personB.Age}");
Console.WriteLine($"HomeAddress: {personB.HomeAddress.Street}, {personB.HomeAddress.City}");
Console.WriteLine("\n");

Person personC = new Person
{
    Name = "Anh Tuan Le",
    Age = 21,
    HomeAddress = new Address
    {
        Street = "Xa lo Ha Noi",
        City = "Ho Chi Minh"
    }
};
Console.WriteLine("===Person C===");
Console.WriteLine($"Name: {personC.Name}");
Console.WriteLine($"Age: {personC.Age}");
Console.WriteLine($"HomeAddress: {personC.HomeAddress.Street}, {personC.HomeAddress.City}");
Console.WriteLine("\n");



class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Address HomeAddress { get; set; }
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}