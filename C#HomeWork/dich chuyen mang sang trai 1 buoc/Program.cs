int[] array = { 1, 2, 3, 4, 5, 6 };

Console.WriteLine("Ta co 1 mang la array = { 1, 2, 3, 4, 5, 6 }");
Console.Write("Noi dung cua mang: ");
for (int i = 0; i < array.Length; i++)
{
    Console.Write($"{array[i]} ");
}
Console.WriteLine();

int firstE = array[0];
for(int i = 0; i < array.Length - 1; i++)
{
    array[i] = array[i+1];
}
array[array.Length-1] = firstE;

Console.Write("Noi dung cua mang sau khi duoc dich sang trai 1 buoc: ");
for (int i = 0; i < array.Length; i++)
{
    Console.Write($"{array[i]} ");
}
Console.WriteLine();
