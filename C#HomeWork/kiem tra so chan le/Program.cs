Console.WriteLine("Hay nhap so de kiem tra: ");
int number = Convert.ToInt32(Console.ReadLine());

if (number % 2 == 0)
{
    Console.WriteLine($"{number} la so chan!");
}else
{
    Console.WriteLine($"{number} la so le!");
}