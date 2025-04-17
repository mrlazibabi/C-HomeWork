//MyCustomList: Đảm bảo danh sách tùy chỉnh chỉ được thay đổi bằng các phương thức được cung cấp.
public class CustomList
{
    private int[] _items { get; set; } //set private field

    public CustomList(int _maxSize)
    {
        _items = new int[_maxSize];
    }

    public void Add(int item)
    {
        ListResize();
        _items[Count - 1] = item;
    }

    public void Remove(int item)
    {
        int index = IndexOf(item);

        if (index != -1)
        {
            RemoveAt(index);
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        ListResize(false);
    }

    public bool Contains(int item) => IndexOf(item) != -1;

    public int Count => _items.Length;

    public void Clear()
    {
        _items = new int[0];
    }

    public int[] ToArray() => _items;

    public int IndexOf(int item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i] == item)
                return i;
        }
        return -1;
    }

    public void Insert(int index, int item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        ListResize();
        for (int i = Count - 1; i > index; i--)
        {
            _items[i] = _items[i - 1];
        }
        _items[index] = item;
    }

    public int LastIndexOf(int item)
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            if (_items[i] == item)
                return i;
        }
        return -1;
    }

    public bool IsEmpty() => Count == 0;

    private void ListResize(bool isAdd = true)
    {
        int length;

        if (isAdd)
        {
            length = Count + 1;
        }
        else
        {
            length = Count - 1;
        }

        int[] newList = new int[length];
        for (int i = 0; i < Math.Min(Count, length); i++)
        {
            newList[i] = _items[i];
        }
        _items = newList;
    }
}