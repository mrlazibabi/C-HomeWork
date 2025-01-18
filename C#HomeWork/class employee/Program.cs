Employee employee1 = new Employee();
Employee employee2 = new Employee(1, "Le Tuan Anh");
Employee employee3 = new Employee(2, "Le Tuan Anh", 30, 5000.0);

employee1.DisplayInfo();
employee2.DisplayInfo();
employee2.DisplayInfo();

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }

    public Employee()
    {
        Id = 0;
        Name = "Unknow";
        Age = 20;
        Salary = 5000.0;
    }

    public Employee(int id, string name)
    {
        Id = id; 
        Name = name;
        Age = 20;
        Salary = 5000.0;
    }

    public Employee(int id, string name, int age, double salary)
    {
        Id=id;
        Name = name;
        Age = age;
        Salary = salary;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Id:{Id} - Name:{Name} - Age:{Age} - Salary:{Salary}");
    }
}