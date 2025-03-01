using TestNumberUtils;

Console.OutputEncoding = System.Text.Encoding.UTF8;
NumberUtils numberUtils = new NumberUtils();

Console.Write("Nhập các số, cách nhau bởi dấu cách: ");
string input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Bạn chưa nhập số nào!");
    return;
}

string[] inputs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
List<int> numbers = new List<int>();

foreach (string s in inputs)
{
    if (int.TryParse(s, out int num))
    {
        numbers.Add(num);
    }
    else
    {
        Console.WriteLine($"'{s}' không phải là số hợp lệ và sẽ bị bỏ qua.");
    }
}

if (numbers.Count == 0)
{
    Console.WriteLine("Không có số hợp lệ để tính toán.");
    return;
}

int sumOfPrimes = numberUtils.SumPrimeNumbers(numbers.ToArray());
Console.WriteLine($"Tổng các số nguyên tố trong mảng: {sumOfPrimes}");
