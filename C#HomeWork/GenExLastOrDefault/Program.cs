
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int lastNumber = numbers.LastOrDefault(number => number > 4);
Console.WriteLine(lastNumber);

int lastNumber2 = numbers.LastOrDefault(number => number > 5);
Console.WriteLine(lastNumber2);

public static class ListExtensions
{
    public static T LastOrDefault<T>(this List<T> list, Func<T, bool> predicate)
    {
        if (list == null || list.Count == 0)
        {
            throw new InvalidOperationException("The list is empty or null.");
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (predicate(list[i]))
            {
                return list[i];
            }
        }
        return default(T);
    }
}
