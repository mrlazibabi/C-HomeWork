int number;
int giaiThua = 1;

do
{
    Console.Write("Hay nhap 1 so nguyen duong de tinh giai thua: ");
    number = Convert.ToInt32(Console.ReadLine());

    for (int i = 1; i <= number; i++)
    {
        giaiThua *= i;
    }
    Console.WriteLine("Ta co giai thua la: "+giaiThua);
}while (true);