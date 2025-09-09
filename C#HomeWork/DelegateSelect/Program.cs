using Dumpify;

List<int> items = new List<int> { 1, 2, 3, 4, 5, 6 };
Projection projection = new Projection();

Transform transform = item => item.ToString();

List<string> first = projection.Select(items,transform);
first.Dump();
class Projection
{
    public List<string> Select(List<int> items, Transform transform)
    {
        if(items == null || items.Count == 0)
        {
            throw new ArgumentNullException("items cannot be null or empty");
        }

        List<string> result = new List<string>();
        foreach(int item in items)
        {
            result.Add(transform(item));
        }
        return result;
    }
}

public delegate string Transform(int item);