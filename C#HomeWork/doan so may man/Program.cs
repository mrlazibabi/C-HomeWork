Console.WriteLine("Hay nhap 1 so nguyen bat ki trong khoang 1-10");
int num = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"So ban chon la: "+num);

int random = Random.Shared.Next(1, 11);
Console.WriteLine("So may man la: "+random);

if (num == random)
{
    Console.WriteLine("Ban that la may man!!! Hay mau chong di mua ve so.");
}
else
{
    Console.WriteLine("Try again next time.");
}

