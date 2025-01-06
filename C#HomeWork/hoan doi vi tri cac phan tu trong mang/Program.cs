int[] array = { 1, 2, 3, 4, 5, 6 };
int[] temp = new int[6];

for (int i = 0; i < array.Length; i++)
{
    temp[i] = array[array.Length - 1 - i];
}

Console.WriteLine("Ta co 1 mang la array = { 1, 2, 3, 4, 5, 6 }");
Console.Write("Noi dung cua mang: ");
for (int i = 0;i < array.Length; i++)
{  
    Console.Write($"{array[i]} ");
}
Console.WriteLine();

Console.Write("Noi dung cua mang sau khi duoc hoan doi: ");
for (int i = 0; i < temp.Length; i++)
{
    Console.Write($"{temp[i]} ");
}
Console.WriteLine();
