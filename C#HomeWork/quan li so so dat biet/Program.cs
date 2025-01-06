int[] soXo = { 123456, 654321 };

while (true)
{
    Console.WriteLine("Chao mung ban den voi chuong trinh quan li so so dac biet");
    Console.WriteLine("1. Xem tap hop so da duoc luu.");
    Console.WriteLine("2. Them 1 so moi vao tap hop.");
    Console.WriteLine("3. Thoat chuong trinh");

    Console.Write("Hay lua chon 1 tinh nang: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Write("Tap hop cac so da duoc luu: ");
            for (int i = 0; i < soXo.Length; i++)
            {
                Console.Write($"{soXo[i]}, ");
            }
            Console.WriteLine();
            Console.WriteLine();
            break;

        case 2:
            Console.Write("Hay nhap 1 so moi de them vao tap hop: ");
            int newNum = Convert.ToInt32(Console.ReadLine());

            Array.Resize(ref soXo, soXo.Length + 1);
            soXo[soXo.Length - 1] = newNum;
            Console.WriteLine("Luu thanh cong!");
            Console.WriteLine();
            Console.WriteLine();
            break;

        case 3:
            Console.WriteLine("Cam on ban da su dung chuong trinh!");
            return;

        default:
            Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
            break;
    }
}