int[] array = { 8, 4, 5, 9, 6, 1, 2, 7, 3 };
int maxNum = 0;

for (int i = 0; i < array.Length; i++)
{
    if (array[i] > maxNum)
    {
        maxNum = array[i];
    }
}

Console.WriteLine("Ta co 1 mang la array = { 8, 4, 5, 9, 6, 1, 2, 7, 3 }");
Console.WriteLine($"Gia tri lon nhat trong mang la {maxNum}");