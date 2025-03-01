using ArrayUtilsAreEqualArray;

int[] array1 = { 1, 2, 3, 4, 5 };
int[] array2 = { 1, 2, 3, 4, 5 };
int[] array3 = { 1, 2, 3, 4, 6 };

Console.WriteLine("So sánh array1 và array2: " + ArrayUtils.AreArraysEqual(array1, array2));
Console.WriteLine("So sánh array1 và array3: " + ArrayUtils.AreArraysEqual(array1, array3));

Console.ReadLine(); 