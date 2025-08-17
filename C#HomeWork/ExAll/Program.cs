using Dumpify;

List<int> numbers = new List<int> { 3, 6, 9, 12};
List<int> numbers2 = new List<int> { 2, 4, 6, 12};

bool divideByThree = numbers.All(n => n % 3 == 0);
divideByThree.Dump("All number can divide by 3 : ");

bool altDivideByThree = numbers2.All(n => n % 3 == 0);
altDivideByThree.Dump("All number can divide by 3 : ");

public static class AllExtension
{
    public static bool All(this IEnumerable<int> items, Predicate<int> predicate)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (int item in items)
        {
            if (!predicate(item))
            {
                return false;
            }
        }
        return true;
    }
}