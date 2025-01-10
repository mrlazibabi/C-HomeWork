Teacher teacher = new Teacher
{
    Name = "Mr.Smitch",
    Students = new Student[]
    {
        new Student{Name = "Alice",
                    Age = 10,
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Springfield",
                        State = "IL",
                        ZipCode = "62701"
                    }
        },
        new Student{Name = "Bob",
                    Age = 11,
                    Address = new Address
                    {
                        Street = "456 Elm St",
                        City = "Springfield",
                        State = "IL",
                        ZipCode = "62702"
                    }
        }
    }
};
Console.WriteLine($"Teacher: {teacher.Name}");
Console.WriteLine("Students: ");
foreach (Student student in teacher.Students)
{
    Console.WriteLine($"- {student.Name}, {student.Age}");
    Console.WriteLine($"{student.Address.Street}, {student.Address.City}, {student.Address.State}, {student.Address.ZipCode}");
}
Console.WriteLine("\n");




class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }
}

class Teacher
{
    public string Name { get; set; }
    public Student[] Students { get; set; }
}