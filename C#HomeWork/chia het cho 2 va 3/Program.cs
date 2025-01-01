Console.WriteLine("Hay nhap 1 so nguyen:");
int num  = Convert.ToInt32(Console.ReadLine());

switch(num % 6)
{
    case 0:
        Console.WriteLine($"So nguyen {num} chia het cho ca 2 va 3");
        break;
    default:
        Console.WriteLine($"So nguyen {num} khong chia het cho ca 2 va 3");
        break;
}