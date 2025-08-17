
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int lastNumber = numbers.Last(number => number > 4);
Console.WriteLine(lastNumber);

public static class ListExtensions
{
    public static T Last<T>(this List<T> list, Func<T, bool> predicate)
    {
        if (list == null || list.Count == 0)
        {
            throw new InvalidOperationException("The list is empty.");
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
        throw new InvalidOperationException("No element satisfies the condition.");

    }
}
