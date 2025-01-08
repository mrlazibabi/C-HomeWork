bool IsArraySymmetric(int[] arr)
{
    for (int i = 0; i < arr.Length / 2; i++)
    {
        if (arr[i] != arr[arr.Length - 1 - i])
        {
            return false; 
        }
    }
    return true; 
}

int[] array1 = { 1, 2, 3, 4, 5 };         
int[] array2 = { 1, 2, 3, 2, 1 };         
int[] array3 = { 1, 2, 3, 4, 3, 2, 1 };   

bool isSymmetric1 = IsArraySymmetric(array1);
bool isSymmetric2 = IsArraySymmetric(array2);
bool isSymmetric3 = IsArraySymmetric(array3);

Console.WriteLine($"Result isSymmetric1: " + isSymmetric1); 
Console.WriteLine($"Result isSymmetric2: " + isSymmetric2); 
Console.WriteLine($"Result isSymmetric3: " + isSymmetric3); 
