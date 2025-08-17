using Dumpify;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstEven = numbers.FirstOrDefault(n => n % 2 == 0);
firstEven.Dump("FirstOrDefault number to be an Even Number: ");

public static class FirstExtension
{
    public static int FirstOrDefault(this IEnumerable<int> items, Predicate<int> predicate)
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
        return default(int);
    }
}