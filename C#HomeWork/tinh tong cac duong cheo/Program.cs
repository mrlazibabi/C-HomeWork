int[,] array = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

int sumMain = 0;  
int sumSecondary = 0;

for (int i = 0; i < array.GetLength(1); i++)
{
    sumMain += array[i, i];  
    sumSecondary += array[i, array.GetLength(1) - i - 1];  
}

Console.WriteLine($"Tong duong cheo chinh: {sumMain}");
Console.WriteLine($"Tong duong cheo phu: {sumSecondary}");