DuplicateFinder finder = new DuplicateFinder();

try
{
    int[] array1 = { 1, 2, 3, 4, 5, 3, 6 };
    int[] array2 = { 10, 15, 20, 25, 30 };
    int[] array3 = { 4, 5, 6, 4, 7, 8, 9 };

    Console.WriteLine(finder.FindFirstDuplicate(array1));
    Console.WriteLine(finder.FindFirstDuplicate(array2));
    Console.WriteLine(finder.FindFirstDuplicate(array3));
}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}


public class DuplicateFinder
{
    public int FindFirstDuplicate(int[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException("Array cannot be null");
        }

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                    return array[i];
            }
        }
        return -1;
    }
}