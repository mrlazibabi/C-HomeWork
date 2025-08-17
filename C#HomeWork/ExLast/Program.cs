using Dumpify;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstEven = numbers.Last(n => n % 2 == 0);
firstEven.Dump("Last number to be an Even Number: ");

public static class LastExtension
{
    public static int Last(this IEnumerable<int> items, Predicate<int> predicate)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        int lastItem = default(int);
        bool found = false;
        foreach (int item in items)
        {
            if (predicate(item))
            {
                lastItem = item;
                found = true;
            }
        }

        if (!found)
        {
            throw new InvalidOperationException("No item found matching the predicate.");
        }

        return lastItem;
    }
}