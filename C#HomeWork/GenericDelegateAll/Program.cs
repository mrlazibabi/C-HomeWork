List<int> items = new List<int> { 3, 7, 5, 8, 6 };
List<string> items2 = new List<string> { "apple", "banana", "cherry" };

NumberProcessor processor = new NumberProcessor();

bool a = processor.All(items, item => item % 2 == 0);
Console.WriteLine(a);

try
{
    bool b = processor.All(items2, item => item.Length > 10);
    Console.WriteLine(b);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
class NumberProcessor
{
    public bool All<T>(List<T> items, Condition<T> condition)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        foreach (T item in items)
        {
            if (!condition(item))
            {
                return false;
            }

        }
        return true;
    }
}

public delegate bool Condition<T>(T item);