Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Nhập chiều dài hình chữ nhật: ");
double length = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Nhập chiều rộng hình chữ nhật: ");
double width = Convert.ToDouble(Console.ReadLine());

double p = 2 * (width + length);
double s = width * length;

Console.WriteLine($"Ta có chu vi hình chữ nhật là : 2 * ( {width} + {length}) = {p}");
Console.WriteLine($"Ta có diện tích hình chữ nhật là : {width} * {length} = {s}");
