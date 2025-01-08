int SearchMaxIdex(int[] searchArray)
{
    int maxIndex = 0;
    for (int i = 1; i < searchArray.Length; i++)
    {
        if (searchArray[i] > searchArray[maxIndex])
        {
            maxIndex = i;
        }
    }
    return maxIndex;
}

int[] number1 = { 1, 3, 5, 7, 9 };
int[] number2 = { 2, 40, 6, 8, 10 };
int[] number3 = { 11, 22, 33, 44, 55, 30, 55 };

int maxIndex1 = SearchMaxIdex(number1);
int maxIndex2 = SearchMaxIdex(number2);
int maxIndex3 = SearchMaxIdex(number3);

Console.WriteLine($"Max Index 1 is at {maxIndex1}");
Console.WriteLine($"Max Index 2 is at {maxIndex2}");
Console.WriteLine($"Max Index 3 is at {maxIndex3}");
