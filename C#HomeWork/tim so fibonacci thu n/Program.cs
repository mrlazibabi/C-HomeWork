
try
{
    Console.WriteLine("Hay nhap 1 so nguyen duong n: ");
    int n = int.Parse(Console.ReadLine());

    FibonacciCalculator calc = new FibonacciCalculator();
    Console.WriteLine($"so fibonacci cua {n} la: {calc.GetFibonacci(n)}");

}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}

public class FibonacciCalculator
{
    public int GetFibonacci(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("n phai la 1 so nguyen duong");
        }

        if (n == 0) return 0;
        if (n == 1) return 1;

        return GetFibonacci(n - 1) + GetFibonacci(n - 2);
    }
}