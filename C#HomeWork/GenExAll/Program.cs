List<int> numbers = new List<int> { 2, 2, 4, 4, 6, 6 };
bool allNumberEven = numbers.All(x => x % 2 == 0);
Console.WriteLine(allNumberEven);

bool allNumberOdd = numbers.All(x => x % 2 != 0);
Console.WriteLine(allNumberOdd);


public static class ListExtensions
{
    public static bool All<T>(this List<T> list, Func<T, bool> predicate)
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
            if (!predicate(item))
            {
                return false; 
            }
        }
        return true; 
    }
}