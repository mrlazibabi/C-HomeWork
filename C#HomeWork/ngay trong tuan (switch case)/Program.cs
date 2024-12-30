Console.WriteLine("Hay nhap 1 so tu 1-7: ");
int day = Convert.ToInt32(Console.ReadLine());

switch (day)
{
    case 1:
        Console.WriteLine("Ngay ban da chon: Chu Nhat");
        break;
    case 2:
        Console.WriteLine("Ngay ban da chon: Thu Hai");
        break;
    case 3:
        Console.WriteLine("Ngay ban da chon: Thu Ba");
        break;
    case 4:
        Console.WriteLine("Ngay ban da chon: Thu Tu");
        break;
    case 5:
        Console.WriteLine("Ngay ban da chon: Thu Nam");
        break;
    case 6:
        Console.WriteLine("Ngay ban da chon: Thu Sau");
        break;
    case 7:
        Console.WriteLine("Ngay ban da chon: Thu Bay");
        break;
    default:
        Console.WriteLine("Ngay ban chon ko ton tai!");
        break;
}