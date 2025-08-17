List<int> numbers = new List<int> { 2, 2, 4, 4, 6, 7 };
bool anyNumberEven = numbers.Any(x => x % 2 == 0);
Console.WriteLine(anyNumberEven);

bool anyNumberOdd = numbers.Any(x => x % 2 != 0);
Console.WriteLine(anyNumberOdd);


public static class ListExtensions
{
    public static bool Any<T>(this List<T> list, Func<T, bool> predicate)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "List cannot be null.");
        }

        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
        }

        foreach (T item in list)
        {
            if (predicate(item))
            {
                return true;
            }
        }
        return false;
    }
}