using Dumpify;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstEven = numbers.SingleOrDefault(n => n % 3 == 0);
firstEven.Dump("SingleOrDefault number that can divide 3 : ");

public static class SingleExtension
{
    public static int SingleOrDefault(this IEnumerable<int> items, Predicate<int> predicate)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        int onlyItem = default(int);
        int count = 0;
        foreach (int item in items)
        {
            if (predicate(item))
            {
                onlyItem = item;
                count++;
            }
        }

        if (count > 1)
        {
            return default(int);
        }

        return onlyItem;
    }
}