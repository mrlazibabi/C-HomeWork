using ArrayUtilsDoubleArrayElements;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Write("Nhập các số nguyên, cách nhau bởi dấu cách: ");
string[] inputs = Console.ReadLine().Split(' ');

int[] numbers = Array.ConvertAll(inputs, int.Parse);

int[] doubledNumbers = ArrayUtils.DoubleArrayElements(numbers);

Console.WriteLine("Mảng sau khi nhân đôi:");
Console.WriteLine(string.Join(" ", doubledNumbers));