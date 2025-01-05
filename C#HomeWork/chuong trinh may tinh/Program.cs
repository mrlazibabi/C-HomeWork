while (true)
{
    Console.WriteLine("Chao mung ban den voi chuong trinh tinh toan");
    Console.WriteLine("1. Thuc hien phep cong");
    Console.WriteLine("2. Thuc hien phep tru");
    Console.WriteLine("3. Thuc hien phep nhan");
    Console.WriteLine("4. Thuc hien phep chia");
    Console.WriteLine("5. Thoat chuong trinh");

    Console.Write("Hay lua chon phep tinh: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Write("Hay nhap so thu nhat: ");
            int so1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hay nhap so thu hai: ");
            int so2 = Convert.ToInt32(Console.ReadLine());

            int sum = so1 + so2;
            Console.WriteLine($"Ket qua: {sum}");
            break;

        case 2:
            Console.Write("Hay nhap so thu nhat: ");
            so1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hay nhap so thu hai: ");
            so2 = Convert.ToInt32(Console.ReadLine());

            int difference = so1 - so2;
            Console.WriteLine($"Ket qua: {difference}");
            break;

        case 3:
            Console.Write("Hay nhap so thu nhat: ");
            so1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hay nhap so thu hai: ");
            so2 = Convert.ToInt32(Console.ReadLine());

            int product = so1 * so2;
            Console.WriteLine($"Ket qua: {product}");
            break;

        case 4:
            Console.Write("Hay nhap so thu nhat: ");
            so1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hay nhap so thu hai: ");
            so2 = Convert.ToInt32(Console.ReadLine());

            if (so2 != 0)
            {
                double quotient = (double)so1 / so2;
                Console.WriteLine($"Ket qua: {quotient}");
            }
            else
            {
                Console.WriteLine("Khong the chia cho 0!");
            }
            break;

        case 5:
            Console.WriteLine("Cam on ban da su dung chuong trinh!");
            return; 

        default:
            Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
            break;
    }
}
