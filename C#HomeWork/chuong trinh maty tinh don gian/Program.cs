Console.WriteLine("Hay nhap so thu nhat: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Hay nhap so thu hai: ");
double num2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Hay chon mot trong cac phep toan sau (+, -, *, /): ");
string mathOperator = Console.ReadLine();

switch (mathOperator)
{
    case "+":
        Console.WriteLine($"Ket qua: {num1 + num2}");
        break;
    case "-":
        Console.WriteLine($"Ket qua: {num1 - num2}");
        break;
    case "*":
        Console.WriteLine($"Ket qua: {num1 * num2}");
        break;
    case "/":
        Console.WriteLine($"Ket qua: {num1 + num2}");
        break;
    default:
        Console.WriteLine("Khong co phep tinh nay!");
        break;
}