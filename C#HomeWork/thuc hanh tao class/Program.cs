Employee emp1 = new Employee
{
    Name = "Trinh Tran Phuong Tuan",
    Age = 30,
    Position = "Project Manager"
};

Employee emp2 = new Employee
{
    Name = "Le Tuan Anh",
    Age = 21,
    Position = "Backend Developer"
};

Employee emp3 = new Employee
{
    Name = "Le Anh Tuan",
    Age = 21,
    Position = "Frontend Developer"
};

Employee emp4 = new Employee
{
    Name = "Tuan Anh Le",
    Age = 21,
    Position = "Tester"
};

Console.WriteLine($"Thong tin PM: {emp1.Name}, {emp1.Age}, {emp1.Position}");
Console.WriteLine($"Thong tin Dev1: {emp2.Name}, {emp2.Age}, {emp2.Position}");
Console.WriteLine($"Thong tin Dev2: {emp3.Name}, {emp3.Age}, {emp3.Position}");
Console.WriteLine($"Thong tin QC: {emp4.Name}, {emp4.Age}, {emp4.Position}");
class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
}