using Dumpify;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
var taken = numbers.Take(2);
taken.Dump();

List<int> numbers2 = new List<int> { 1, 2 };
var taken2 = numbers2.Take(5);
taken2.Dump();


public static class ListExtensions
{
    public static IEnumerable<T> Take<T>(List<T> items, int count)
    {
        List<T> result = new List<T>();

        int takenCount = 0;

        foreach (T item in items)
        {
            if (takenCount < count && items != null)
            {
                result.Add(item);
                takenCount++;
                continue;
            }

            if (takenCount == count)
            {
                break;
            }
        }
        return result;
    }
}