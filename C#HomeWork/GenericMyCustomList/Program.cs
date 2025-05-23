
MyCustomList<int> list = new MyCustomList<int>();

// Test Add
Console.WriteLine("Testing Add:");
list.Add(1);
list.Add(2);
list.Add(3);
Console.WriteLine($"List: [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test Insert
Console.WriteLine("\nTesting Insert:");
list.Insert(1, 4);
Console.WriteLine($"After Insert(1, 4): [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test Remove
Console.WriteLine("\nTesting Remove:");
list.Remove(2);
Console.WriteLine($"After Remove(2): [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test RemoveAt
Console.WriteLine("\nTesting RemoveAt:");
list.RemoveAt(0);
Console.WriteLine($"After RemoveAt(0): [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test Contains
Console.WriteLine("\nTesting Contains:");
Console.WriteLine($"Contains(3): {list.Contains(3)}");
Console.WriteLine($"Contains(5): {list.Contains(5)}");

// Test IndexOf and LastIndexOf
Console.WriteLine("\nTesting IndexOf and LastIndexOf:");
list.Add(3); // Thêm lại 3 để test LastIndexOf
Console.WriteLine($"IndexOf(3): {list.IndexOf(3)}");
Console.WriteLine($"LastIndexOf(3): {list.LastIndexOf(3)}");

// Test Clear
Console.WriteLine("\nTesting Clear:");
list.Clear();
Console.WriteLine($"After Clear: [{string.Join(", ", list.ToArray())}], Count = {list.Count}, IsEmpty: {list.IsEmpty()}");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

public class MyCustomList<T>
{
    private T[] items;
    private int count;

    public MyCustomList()
    {
        items = new T[4]; 
        count = 0;
    }

    public void Add(T item)
    {
        if (count == items.Length) Resize();
        items[count++] = item;
    }

    public void Remove(T value)
    {
        int index = IndexOf(value);
        if (index >= 0) RemoveAt(index);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index));
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        items[count - 1] = default(T);
        count--;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public int Count => count;

    public void Clear()
    {
        Array.Clear(items, 0, count);
        count = 0;
    }

    public T[] ToArray()
    {
        T[] result = new T[count];
        Array.Copy(items, result, count);
        return result;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(items[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > count) throw new ArgumentOutOfRangeException(nameof(index));
        if (count == items.Length) Resize();
        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }
        items[index] = item;
        count++;
    }

    public int LastIndexOf(T item)
    {
        for (int i = count - 1; i >= 0; i--)
        {
            if (EqualityComparer<T>.Default.Equals(items[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    private void Resize()
    {
        Array.Resize(ref items, items.Length * 2);
    }
}