List<int> numbers = new List<int> { 2, 2, 3, 4, 5 };
int singleNumber3 = numbers.Single(x => x == 3);
Console.WriteLine(singleNumber3);

int singleNumber0 = numbers.Single(x => x == 0);
Console.WriteLine(singleNumber0);

int singleNumber2 = numbers.Single(x => x == 2);
Console.WriteLine(singleNumber2);

public static class ListExtensions
{
    public static T Single<T>(this List<T> list, Func<T,bool> predicate)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "List cannot be null.");
        }

        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
        }
        T result = default;
        bool found = false;
        foreach (T item in list)
        {
            if (predicate(item))
            {
                if (found)
                {
                    throw new InvalidOperationException("Sequence contains more than one element satisfying the condition in predicate.");
                }
                result = item;
                found = true;
            }
        }

        if (!found)
        {
            throw new InvalidOperationException("No element satisfies the condition in predicate.");
        }

        return result;
    }
}