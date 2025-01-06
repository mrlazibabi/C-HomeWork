int[] numbers = { 5, 10, 9, 3, 15, 8, 7 };
int sum = 0;

foreach (var number in numbers)
{
    bool isPrime = true;
    if (number < 2) { isPrime = false; }

    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            isPrime = false;
            break;
        } 
    }

    if (isPrime)
    {
        sum += number;
    }
}

Console.Write("Ta co mang sau la number = ");
foreach (var number in numbers)
{
    Console.Write($"{number} ");
}
Console.WriteLine($"\nTong cac so nguyen to trong mang la {sum}");

