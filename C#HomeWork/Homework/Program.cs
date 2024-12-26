Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Nhập năm sinh: ");
int birthday = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Nhập chiều cao (cm): ");
double height = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Nhập cân nặng (kg): ");
double weight = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Nhập điểm trung bình: ");
double averagePoint = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Nhập trạng thái hôn nhân: ");
string marriage = Console.ReadLine();

/////////////////////////////////////
Console.WriteLine("\n Thông tin đã nhập:");
Console.WriteLine("Năm sinh: "+birthday);
Console.WriteLine("Chiều cao: "+height);
Console.WriteLine("Cân nặng: "+weight);
Console.WriteLine("Điểm trung bình: "+averagePoint);
Console.WriteLine("Trạng thái hôn nhân: "+marriage);