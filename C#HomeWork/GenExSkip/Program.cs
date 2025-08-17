using Dumpify;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
var skipped = numbers.Skip(2);
skipped.Dump(); 

List<int> numbers2 = new List<int> { 1, 2 };
var skipped2 = numbers2.Skip(5);
skipped2.Dump();

public static class ListExtensions
{
    public static List<T> Skip<T>(List<T> items, int count)
    {
        List<T> result = new List<T>();

        int skippedCount = 0;

        foreach (T item in items)
        {
            if (skippedCount < count)
            {
                skippedCount++;
                continue;
            }

            if (skippedCount == count && items != null)
            {
                result.Add(item);
            }
        }
        return result;
    }
}