Console.WriteLine("Hay nhap 1 so nguyen tu 1-100: ");
int number = Convert.ToInt32(Console.ReadLine());

if (number >= 0 && number <= 100)
{
    switch (number % 2)
    {
        case 0:
            Console.WriteLine($"{number} la so chan va nam trong day so 1-100");
            break;
        default:
            Console.WriteLine($"{number} la so le va nam trong day so 1-100");
            break;
    }
}
else
{
    Console.WriteLine($"{number} khong nam trong day so 1-100");
}
