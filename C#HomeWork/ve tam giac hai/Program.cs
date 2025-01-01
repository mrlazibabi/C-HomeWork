int chieuCao;

do
{
    Console.Write("Hay nhap chieu cao: ");
    chieuCao = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i <= chieuCao; i++)
    {
        for (int j = chieuCao; j >= i; j--)
        {
            Console.Write("  ");
        }

        for (int j = 1; j <= i; j++)
        {
            Console.Write("* ");
        }

        Console.WriteLine("");
    }
    break;

} while (true);
