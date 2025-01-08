bool IsPrime(int number)
{
    if (number < 2)
    {
        return false;
    }

    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}

int SumPrimeNumbers(int[] numbers)
{
    int sum = 0;

    for (int i = 0; i < numbers.Length; i++)
    {
        if (IsPrime(numbers[i]))
        {
            sum += numbers[i];
        }
    }
    return sum;
}

int[] array1 = { 1, 2, 3, 4, 5 };
int[] array2 = { 4, 6, 8, 10 };
int[] array3 = { 11, 13, 17, 19, 23, 50 };

int sum1 = SumPrimeNumbers(array1);
int sum2 = SumPrimeNumbers(array2);
int sum3 = SumPrimeNumbers(array3);

Console.WriteLine("Sum of prime numbers in arry1: " + sum1);
Console.WriteLine("Sum of prime numbers in arry2: " + sum2);
Console.WriteLine("Sum of prime numbers in arry3: " + sum3);
