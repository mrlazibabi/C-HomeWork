List<int> items = new List<int> { 3, 7, 5, 8 };
List<string> items2 = new List<string> { "apple", "banana", "cherry" };

NumberProcessor processor = new NumberProcessor();

int a = processor.Single(items, item => item % 2 == 0);
Console.WriteLine(a);

try
{
    string b = processor.Single(items2, item => item.Length > 10);
    Console.WriteLine(b);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
class NumberProcessor
{
    public T Single<T>(List<T> items, Condition<T> condition)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        T only = default(T);
        int count = 0;

        foreach (T item in items)
        {
            if (condition(item))
            {
                count++;
                only = item;
            }
        }

        if (count > 1 || count == 0)
        {
            throw new InvalidOperationException("Operation Invalid!");
        }
        return only;
    }
}

public delegate bool Condition<T>(T item);