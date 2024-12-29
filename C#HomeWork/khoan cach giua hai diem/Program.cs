using static System.Math;

Console.WriteLine("Nhap toa do diem x1: ");
int x1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem y1: ");
int y1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem x2: ");
int x2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem y2: ");
int y2 = Convert.ToInt32(Console.ReadLine());

double khoangCach = Math.Sqrt((Math.Pow((x2-x1),2)) + (Math.Pow((y2 - y1),2)));

Console.WriteLine("Khoang cach giua hai diem la: " + khoangCach);