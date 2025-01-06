int[] array = { 5, 1, 9, 3, 7 };
int temp = 0;

Console.Write("Ta co mang la array = ");
for (int i = 0; i < array.Length; i++)
{
    Console.Write($"{array[i]} ");
}

for (int i = 0; i < array.Length-1; i++)
{
    for(int j = 0; j < array.Length - 1 - i; j++)
    {
        if (array[j] < array[j + 1])
        {
            temp = array[j];
            array[j] = array[j + 1];
            array[j + 1] = temp;
        }
    } 
}
Console.Write("\nTa co mang sau khi sap xep giam dan la array = ");
for (int i = 0;i < array.Length; i++)
{
    Console.Write($"{array[i]} ");
}
Console.WriteLine();
