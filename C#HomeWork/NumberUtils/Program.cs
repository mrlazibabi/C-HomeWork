NumberUtils numberUtils = new NumberUtils();

// Kiểm tra một số có phải số nguyên tố không
Console.Write("Nhập một số để kiểm tra số nguyên tố: ");
int inputNumber = Convert.ToInt32(Console.ReadLine());
bool isPrime = numberUtils.IsPrime(inputNumber);
Console.WriteLine($"Số {inputNumber} {(isPrime ? "là" : "không phải")} số nguyên tố.");

// Tính tổng các số nguyên tố trong một mảng
Console.Write("Nhập các số, cách nhau bởi dấu cách: ");
string[] inputs = Console.ReadLine().Split(' ');
int[] numbers = Array.ConvertAll(inputs, int.Parse);

int sumOfPrimes = numberUtils.SumPrimeNumbers(numbers);
Console.WriteLine($"Tổng các số nguyên tố trong mảng: {sumOfPrimes}");