int[] originalArray = { 1, 2, 3, 4, 5 };

int[] ResizeArray(int[] originalArray, int newSize)
{
    int[] newArray = new int[newSize];
    for (int i = 0; i < newSize; i++)
    {
        if (i < originalArray.Length)
        {
            newArray[i] = originalArray[i];
        }
        else
        {
            newArray[i] = -1;
        }
    }
    return newArray;
}

int[] resizedArray1 = ResizeArray(originalArray, 8);
Console.Write("Resized Array1 : ");
foreach (int i in resizedArray1)
{
    Console.Write($"{i} ");
}
Console.WriteLine();

int[] resizedArray2 = ResizeArray(originalArray, 3);
Console.Write("Resized Array2 : ");
foreach (int i in resizedArray2)
{
    Console.Write($"{i} ");
}
Console.WriteLine();