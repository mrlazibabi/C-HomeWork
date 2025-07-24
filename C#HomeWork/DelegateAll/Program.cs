List<int> items = new List<int> { 2, 4, 6, 8 };
List<int> items2 = new List<int> { 2, 4, 5, 8 };
NumberProcessor processor = new NumberProcessor();

bool a = processor.All(items, item => item % 2 == 0);
Console.WriteLine(a);

try
{
    bool b = processor.All(items2, item => item % 2 == 0);
    Console.WriteLine(b);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
class NumberProcessor
{
    public bool All(List<int> items, Condition condition)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        foreach (int item in items)
        {
            if (!condition(item))
            {
                return false;
            }
        }
        return true;
    }
}

public delegate bool Condition(int item);