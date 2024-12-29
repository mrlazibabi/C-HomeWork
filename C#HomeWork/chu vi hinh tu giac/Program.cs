Console.WriteLine("Nhap toa do diem x1 cua diem A: ");
int x1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem y1 cua diem A: ");
int y1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem x2 cua diem B: ");
int x2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem y2 cua diem B: ");
int y2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem x3 cua diem C: ");
int x3 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem y3 cua diem C: ");
int y3 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem x4 cua diem D: ");
int x4 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap toa do diem y4 cua diem D: ");
int y4 = Convert.ToInt32(Console.ReadLine());

double khoangCachAB = Math.Sqrt((Math.Pow((x2 - x1), 2)) + (Math.Pow((y2 - y1), 2)));
Console.WriteLine("ta tinh duoc do dai AB la :"+khoangCachAB);

double khoangCachAD = Math.Sqrt((Math.Pow((x4 - x1), 2)) + (Math.Pow((y4 - y1), 2)));
Console.WriteLine("ta tinh duoc do dai AD la :" + khoangCachAD);

double khoangCachBC = Math.Sqrt((Math.Pow((x3 - x2), 2)) + (Math.Pow((y3 - y2), 2)));
Console.WriteLine("ta tinh duoc do dai BC la :" + khoangCachBC);

double khoangCachCD = Math.Sqrt((Math.Pow((x4 - x3), 2)) + (Math.Pow((y4 - y3), 2)));
Console.WriteLine("ta tinh duoc do dai CD la :" + khoangCachCD);

double P = khoangCachAB + khoangCachAD + khoangCachBC + khoangCachCD; 

Console.WriteLine("Vay chu vi hinh tu giac la: "+P);