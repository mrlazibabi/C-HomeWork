bool IsPrime(int number)
{
    bool isPrime = true;
    if (number < 2)
    {
        return false;
    }
    else
    {
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
    }
    return isPrime;
}

Console.WriteLine("Number 2 is a Prime number: " + IsPrime(2));
Console.WriteLine("Number 7 is a Prime number: " + IsPrime(7));
Console.WriteLine("Number 10 is a Prime number: " + IsPrime(10));
Console.WriteLine("Number 17 is a Prime number: " + IsPrime(17));