List<int> items = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
NumberProcessor processor = new NumberProcessor();

int a = processor.FirstOrDefault(items, item => item > 5);
Console.WriteLine(a);

int b = processor.FirstOrDefault(items, item => item / 3 == 3);
Console.WriteLine(b);

class NumberProcessor
{
    public int FirstOrDefault(List<int> items, Condition condition)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        foreach (int item in items)
        {
            if (condition(item) == true)
            {
                return item;
            }
        }
        return 0;
    }
}

public delegate bool Condition(int item);