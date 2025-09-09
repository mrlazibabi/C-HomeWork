
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstNumber = numbers.FirstOrDefault(number => number > 4);
Console.WriteLine(firstNumber);

int firstNumber2 = numbers.FirstOrDefault(number => number > 5);
Console.WriteLine(firstNumber2);

public static class ListExtensions
{
    public static T FirstOrDefault<T>(this List<T> list, Func<T,bool> predicate)
    {
        if (list == null || list.Count == 0)
        {
            throw new InvalidOperationException("The list is empty or null.");
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
        }

        for(int i = 0; i < list.Count; i++)
        {
            if (predicate(list[i]))
            {
                return list[i];
            }
        }
        return default(T);
    }
}
