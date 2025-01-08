int SumEvenNumbers(int limit)
{
    int sum = 0;

    for (int i = 0; i <= limit; i++)
    {
        if (i % 2 == 0)
        {
            sum += i;
        }
    }
    return sum;
}

Console.WriteLine("SumEvenNumber(5): " + SumEvenNumbers(5));
Console.WriteLine("SumEvenNumber(10): " + SumEvenNumbers(10));
Console.WriteLine("SumEvenNumber(15): " + SumEvenNumbers(15));

