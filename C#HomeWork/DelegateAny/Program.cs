List<int> items = new List<int> { 1, 2, 3, 4 };
List<int> items2 = new List<int> { 1, 2, 3 };
NumberProcessor processor = new NumberProcessor();

bool a = processor.Any(items, item => item > 2);
Console.WriteLine(a);

try
{
    bool b = processor.Any(items2, item => item > 5);
    Console.WriteLine(b);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
class NumberProcessor
{
    public bool Any(List<int> items, Condition condition)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        foreach (int item in items)
        {
            if (condition(item))
            {
                return true;
            }
        }
        return false;
    }
}

public delegate bool Condition(int item);