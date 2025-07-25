List<int> items = new List<int> { 3, 7, 6, 8 };
List<string> items2 = new List<string> { "apple", "banana", "cherry" };

NumberProcessor processor = new NumberProcessor();

int a = processor.FirstOrDefault(items, item => item % 2 == 0);
Console.WriteLine(a);

try
{
    string b = processor.FirstOrDefault(items2, item => item.Length > 10);
    Console.WriteLine(b);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
class NumberProcessor
{
    public T FirstOrDefault<T>(List<T> items, Condition<T> condition)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        foreach (T item in items)
        {
            if (condition(item))
            {
                return item;
            }
        }
        return default;
    }
}

public delegate bool Condition<T>(T item);