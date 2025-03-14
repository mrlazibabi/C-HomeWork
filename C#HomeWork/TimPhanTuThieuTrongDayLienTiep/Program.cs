MissingNumberFinder finder = new MissingNumberFinder();

try
{
    int[] arr1 = { 3, 7, 1, 2, 8, 4, 5 };
    int[] arr2 = { 1, 2, 3, 4, 5, 6, 8 };
    int[] arr3 = { 1, 3 };
    int[] arr4 = { 1, 2, 3, 4 };

    Console.WriteLine(finder.FindMissingNumber(arr1)); // 6
    Console.WriteLine(finder.FindMissingNumber(arr2)); // 7
    Console.WriteLine(finder.FindMissingNumber(arr3)); // 2
    Console.WriteLine(finder.FindMissingNumber(arr4)); // 5
}
catch (Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}

public class MissingNumberFinder
{
    public int FindMissingNumber(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
        {
            throw new ArgumentNullException("Array cannot be null or empty.");
        }

        int n = numbers.Length + 1; //Thiếu 1 phần từ để có expected
        int expected = n * (n + 1) / 2; //Công thức tính tổng của 1 dãy số từ 1-n
        int actual = 0; //Tổng thực tế

        foreach (int num in numbers)
        {
            actual += num;
        }

        return expected - actual;
    }
}