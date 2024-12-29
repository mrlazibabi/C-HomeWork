Console.WriteLine("Hay nhap so thu nhap ca nhan cua ban:");
double income = Convert.ToDouble(Console.ReadLine());

double tax = 0;

double tren50tr = Math.Max(0, income - 50) * 0.3;
double from30trTo50tr = Math.Max(0, Math.Min(50, income) - 30) * 0.2;
double from10trTo30tr = Math.Max(0, Math.Min(30, income) - 10) * 0.1; 

tax = tren50tr + from30trTo50tr + from10trTo30tr;

Console.WriteLine($"Ban co thu nhap ca nhan la {income} trieu");
Console.WriteLine($"Tong so thue phai nop la {tax} trieu dong");
