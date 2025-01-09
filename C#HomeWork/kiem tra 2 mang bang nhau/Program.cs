bool AreArrayEqual(int [] a, int[] b)
{
    if(a.Length != b.Length)
    {
        return false;
    }
    else
    {
        for(int i = 0; i < a.Length; i++)
        {
            if(a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }
}

int[] array1 = { 1, 2, 3, 4, 5 };
int[] array2 = { 1, 2, 3, 4, 5 };

bool result1 = AreArrayEqual(array1, array2);
Console.WriteLine("arr1 == arr2: " + result1);

int[] array3 = { 1, 2, 3, 4, 5 };
int[] array4 = { 1, 2, 3, 4, 6 };

bool result2 = AreArrayEqual(array3, array4);
Console.WriteLine("arr3 == arr4: " + result2);


int[] array5 = { 1, 2, 3, 4, 5 };
int[] array6 = { 1, 2, 3, 4, 6, 7, 8 };

bool result3 = AreArrayEqual(array5, array6);
Console.WriteLine("arr5 == arr6: " + result3);