using Dumpify;

List<int> numbers = new List<int> { 3, 6, 9, 12 };
List<int> numbers2 = new List<int> { 2, 4, 6, 12 };

bool divideByThree = numbers.Any(n => n % 3 == 0);
divideByThree.Dump("Any number can divide by 3 : ");

bool altDivideByThree = numbers2.Any(n => n % 3 == 0);
altDivideByThree.Dump("Any number can divide by 3 : ");

public static class AnyExtension
{
    public static bool Any(this IEnumerable<int> items, Predicate<int> predicate)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (int item in items)
        {
            if (predicate(item))
            {
                return true;
            }
        }
        return false;
    }
}