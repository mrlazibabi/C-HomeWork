Console.Write("Hay nhap 1 so nguyen duong lon hon 2: ");
int number = Convert.ToInt32(Console.ReadLine());

if(number < 2)
{
    Console.WriteLine("Vui long nhap lai 1 so nguyen duong lon hon 2");
    number = Convert.ToInt32(Console.ReadLine());
}
else
{
    int f1 = 0;
    int f2 = 1;
    int f3;

    Console.Write($"Day so fibonacci: {f1} {f2} ");

    for(int i = 2; i < number; i++)
    {
        f3 = f1 + f2;
        Console.Write($"{f3} ");
        f1 = f2;
        f2 = f3;
    }
}