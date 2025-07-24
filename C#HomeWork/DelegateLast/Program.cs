List<int> items = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
NumberProcessor processor = new NumberProcessor();

int a = processor.Last(items, item => item > 5);
Console.WriteLine(a);

int b = processor.Last(items, item => item > 9);
Console.WriteLine(b);

class NumberProcessor
{
    public int Last(List<int> items, Condition condition)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        int LastValid = 0;
        bool found = false;
        foreach (int item in items)
        {
            if (condition(item))
            {
                LastValid = item;
                found = true;
            }
        }

        if (!found) throw new InvalidOperationException("Operation invalid!");
        return LastValid;
    }
}

public delegate bool Condition(int item);