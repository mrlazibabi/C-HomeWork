List<int> numbers = new List<int> { 2, 2, 4, 4, 6, 7 };
bool existNumberEven = numbers.Exist(x => x % 2 == 0);
Console.WriteLine(existNumberEven);

bool existNumberOdd = numbers.Exist(x => x % 2 != 0);
Console.WriteLine(existNumberOdd);


public static class ListExtensions
{
    public static bool Exist<T>(this List<T> list, Func<T, bool> predicate)
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