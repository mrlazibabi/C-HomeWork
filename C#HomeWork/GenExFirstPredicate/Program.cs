
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstNumber = numbers.First(number => number > 4);
Console.WriteLine(firstNumber);

public static class ListExtensions
{
    public static T First<T>(this List<T> list, Predicate<T> predicate)
    {
        if (list == null || list.Count == 0)
        {
            throw new InvalidOperationException("The list is empty or null.");
        }
        if(predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
        }

        foreach (var item in list)
        {
            if (predicate(item))
            {
                return item;
            }
        }
        throw new InvalidOperationException("No item in the list satisfies the predicate.");
    }
}
