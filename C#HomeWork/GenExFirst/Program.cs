
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstNumber = numbers.First();

public static class ListExtensions
{
    public static T First<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            throw new InvalidOperationException("The list is empty or null.");
        }
        return list[0];
    }
}
