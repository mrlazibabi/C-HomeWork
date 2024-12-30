Console.WriteLine("Hay nhap 1 so tu 1-7: ");
int number = Convert.ToInt32(Console.ReadLine());

if (number == 1)
{
    Console.WriteLine("Ngay ban da nhap: Chu Nhat");
}
else if (number == 2)
{
    Console.WriteLine("Ngay ban da nhap: Thu Hai");
}
else if (number == 3)
{
    Console.WriteLine("Ngay ban da nhap: Thu Ba");
}
else if (number == 4)
{
    Console.WriteLine("Ngay ban da nhap: Thu Tu");
}
else if (number == 5)
{
    Console.WriteLine("Ngay ban da nhap: Thu Nam");
}
else if (number == 6)
{
    Console.WriteLine("Ngay ban da nhap: Thu Bay");
}
else
{
    Console.WriteLine("Ngay khong hop le!");
}