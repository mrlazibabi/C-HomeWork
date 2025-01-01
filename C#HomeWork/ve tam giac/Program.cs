int chieuCao;

do
{
    Console.Write("Hay nhap chieu cao: ");
    chieuCao = Convert.ToInt32(Console.ReadLine());

    for(int i = 1; i <= chieuCao; i++)
    {
        for(int j = 0; j < i; j++)
            Console.Write("* ");

        Console.WriteLine("");
    }
    break;

}while (true);