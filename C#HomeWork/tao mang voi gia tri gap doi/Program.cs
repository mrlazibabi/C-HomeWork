
int[] DoubleArrayElements(int[] arr)
{
    int[] doubledArray = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        doubledArray[i] = arr[i] * 2; 
    }
    return doubledArray;
}

int[] originalaArray = { 1, 2, 3, 4, 5 };
int[] originalaArray2 = { 2, 4, 6, 8, 10 };
int[] originalaArray3 = { 1, 3, 5, 7, 9 };

int[] doubledArray = DoubleArrayElements(originalaArray);
int[] doubledArray2 = DoubleArrayElements(originalaArray2);
int[] doubledArray3 = DoubleArrayElements(originalaArray3);

Console.Write("originalArray: ");
for (int i = 0; i < originalaArray.Length; i++)
{
    Console.Write($"{originalaArray[i]} ");
}
Console.WriteLine();

Console.Write("doubledArray: ");
for (int i = 0; i < doubledArray.Length; i++)
{
    Console.Write($"{doubledArray[i]} ");
}
Console.WriteLine();
Console.WriteLine();

Console.Write("originalArray2: ");
for (int i = 0; i < originalaArray2.Length; i++)
{
    Console.Write($"{originalaArray2[i]} ");
}
Console.WriteLine();

Console.Write("doubledArray2: ");
for (int i = 0; i < doubledArray2.Length; i++)
{
    Console.Write($"{doubledArray2[i]} ");
}
Console.WriteLine();
Console.WriteLine();

Console.Write("originalArray3: ");
for (int i = 0; i < originalaArray3.Length; i++)
{
    Console.Write($"{originalaArray3[i]} ");
}
Console.WriteLine();

Console.Write("doubledArray3: ");
for (int i = 0; i < doubledArray3.Length; i++)
{
    Console.Write($"{doubledArray3[i]} ");
}
Console.WriteLine();
Console.WriteLine();
