List<int> items = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
NumberProcessor processor = new NumberProcessor();

int a = processor.First(items, item => item > 5);
Console.WriteLine(a);

int b = processor.First(items, item => item / 3 == 1);
Console.WriteLine(b);

class NumberProcessor
{
    public int First(List<int> items, Condition condition)
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
        throw new InvalidOperationException("Operation Invalid!");
    }
}

public delegate bool Condition(int item);