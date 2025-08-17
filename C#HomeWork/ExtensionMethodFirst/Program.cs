using Dumpify;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstEven = numbers.First(n => n % 2 == 0);
firstEven.Dump("First number to be an Even Number: ");

public static class FirstExtension
{
    public static int First(this IEnumerable<int> items, Predicate<int> predicate)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        foreach (int item in items)
        {
            if (predicate(item))
            {
                return item;
            }
        }
        throw new InvalidOperationException("No element satisfies the condition in predicate.");
    }
}