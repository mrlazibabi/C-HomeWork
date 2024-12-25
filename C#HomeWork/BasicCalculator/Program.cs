using MathLibrary;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"1+1= {MathOperations.Add(1, 1)}");
        Console.WriteLine($"2-1= {MathOperations.Subtract(2, 1)}");
        Console.WriteLine($"2*1= {MathOperations.Multiply(2, 1)}");
        Console.WriteLine($"2/1= {MathOperations.Divide(2, 1)}");
    }
}


