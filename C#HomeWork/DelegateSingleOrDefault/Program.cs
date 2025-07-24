List<int> items = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
List<int> items2 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
NumberProcessor processor = new NumberProcessor();

int a = processor.Last(items, item => item > 5);
Console.WriteLine(a);

try
{
    int b = processor.Last(items2, item => item > 5);
    Console.WriteLine(b);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
class NumberProcessor
{
    public int Last(List<int> items, Condition condition)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        int valid = 0;
        int count = 0;
        foreach (int item in items)
        {
            if (condition(item))
            {
                valid = item;
                count++;

                if (count > 1)
                {
                    throw new InvalidOperationException("Opearion invalid!");
                }
            }
        }
        return count == 1 ? valid : 0;
    }
}

public delegate bool Condition(int item);