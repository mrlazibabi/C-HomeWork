//double TinhChuViCuaTuGiac(double AB, double BC, double CD, double DA)
//{
//    return AB + BC + CD + DA;
//}
double TinhChuViCuaTuGiac(double AB, double BC, double CD, double DA) => AB + BC + CD + DA;

double TinhKhoangCach(int x1, int y1, int x2, int y2)
{
    double length = Math.Sqrt((Math.Pow((x2 - x1), 2)) + (Math.Pow((y2 - y1), 2)));
    return length;
}

Console.WriteLine("Example1: A(1,2); B(4,6); C(7,2); D(3,1)");
double AB = TinhKhoangCach(1, 2, 4, 6);
double BC = TinhKhoangCach(4, 6, 7, 2);
double CD = TinhKhoangCach(7, 2, 3, 1);
double DA = TinhKhoangCach(3, 1, 1, 2);

double P1 = TinhChuViCuaTuGiac(AB, BC, CD, DA);
Console.WriteLine($"P1 = {Math.Round(P1)}");
Console.WriteLine();

Console.WriteLine("Example2: A(0,0); B(3,4); C(8,4); D(5,0)");
AB = TinhKhoangCach(0, 0, 3, 4);
BC = TinhKhoangCach(3, 4, 8, 4);
CD = TinhKhoangCach(8, 4, 5, 0);
DA = TinhKhoangCach(5, 0, 0, 0);

double P2 = TinhChuViCuaTuGiac(AB, BC, CD, DA);
Console.WriteLine($"P2 = {Math.Round(P2)}");
Console.WriteLine();

Console.WriteLine("Example3: A(-2,-3); B(-1,2); C(3,2); D(2,-3)");
AB = TinhKhoangCach(-2, -3, -1, 2);
BC = TinhKhoangCach(-1, 2, 3, 2);
CD = TinhKhoangCach(3, 2, 2, -3);
DA = TinhKhoangCach(2, -3, -2, -3);

double P3 = TinhChuViCuaTuGiac(AB, BC, CD, DA);
Console.WriteLine($"P3 = {Math.Round(P3)}");
Console.WriteLine();

Console.WriteLine("Example4: A(0,0); B(0,5); C(5,5); D(5,0)");
AB = TinhKhoangCach(0, 0, 0, 5);
BC = TinhKhoangCach(0, 5, 5, 5);
CD = TinhKhoangCach(5, 5, 5, 0);
DA = TinhKhoangCach(5, 0, 0, 0);

double P4 = TinhChuViCuaTuGiac(AB, BC, CD, DA);
Console.WriteLine($"P4 = {Math.Round(P4)}");
