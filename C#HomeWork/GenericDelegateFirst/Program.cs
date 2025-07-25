List<int> items = new List<int> { 3, 7, 6, 8 };
List<string> items2 = new List<string> { "apple", "banana", "cherry"};

NumberProcessor processor = new NumberProcessor();

int a = processor.First(items, item => item % 2 == 0);
Console.WriteLine(a);

try
{
    string b = processor.First(items2, item => item.Length > 5);
    Console.WriteLine(b);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
class NumberProcessor
{
    public T First<T>(List<T> items, Condition<T> condition)
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
        throw new InvalidOperationException("Operation Invalid!");
    }
}

public delegate bool Condition<T>(T item);