Console.WriteLine("Nhap canh a: ");
int a = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap canh b: ");
int b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhap canh c: ");
int c = Convert.ToInt32(Console.ReadLine());

double sumHaiCanhGocVuongA_B = Math.Pow(a, 2) + Math.Pow(b, 2);
double canhHuyenC = Math.Pow(c, 2);

double sumHaiCanhGocVuongA_C = Math.Pow(a, 2) + Math.Pow(c, 2);
double canhHuyenB = Math.Pow(b, 2);

double sumHaiCanhGocVuongB_C = Math.Pow(b, 2) + Math.Pow(c, 2);
double canhHuyenA = Math.Pow(a, 2);

if (sumHaiCanhGocVuongA_B == canhHuyenC)
{
    Console.WriteLine("Day la tam giac vuong");
}else if (sumHaiCanhGocVuongA_C == canhHuyenB)
{
    Console.WriteLine("Day la tam giac vuong");
}else if(sumHaiCanhGocVuongB_C == canhHuyenA)
{
    Console.WriteLine("Day la tam giac vuong");
}
else
{
    Console.WriteLine("Day khong phai la tam giac vuong");
}