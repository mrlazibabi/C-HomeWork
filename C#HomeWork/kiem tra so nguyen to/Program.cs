Console.Write("Hay nhap 1 so nguyen duong: ");
int number = Convert.ToInt32(Console.ReadLine());

while (number < 0)
{
    Console.Write("Hay nhap lai 1 so nguyen duong: ");
    number = int.Parse(Console.ReadLine());
}

if (number < 2)
{
    Console.WriteLine($"{number} khong phai la so nguyen to");
}
else
{
    bool isPrime = true;

    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            isPrime = false;
            break;
        }
    }

    if (isPrime)
        Console.WriteLine($"{number} la so nguyen to");
    else
        Console.WriteLine($"{number} khong phai la so nguyen to");
}
