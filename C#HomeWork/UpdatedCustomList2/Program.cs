public abstract class AbstractCustomList
{
    public abstract void Add(int item);
    public abstract void Remove(int item);
    public abstract void RemoveAt(int index);
    public abstract bool Contains(int item);
    public abstract void Clear();
    public abstract int[] ToArray();
    public abstract int IndexOf(int item);
    public abstract void Insert(int index, int item);
    public abstract int LastIndexOf(int item);
    public abstract bool IsEmpty();
}

public class CustomList : AbstractCustomList
{
    private int[] _items { get; set; } //set private field

    public CustomList(int _maxSize)
    {
        _items = new int[_maxSize];
    }

    public override void Add(int item)
    {
        ListResize();
        _items[Count - 1] = item;
    }

    public override void Remove(int item)
    {
        int index = IndexOf(item);

        if (index != -1)
        {
            RemoveAt(index);
        }
    }

    public override void RemoveAt(int index)
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

    public override bool Contains(int item) => IndexOf(item) != -1;

    public int Count => _items.Length;

    public override void Clear()
    {
        _items = new int[0];
    }

    public override int[] ToArray() => _items;

    public override int IndexOf(int item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[i] == item)
                return i;
        }
        return -1;
    }

    public override void Insert(int index, int item)
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

    public override int LastIndexOf(int item)
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            if (_items[i] == item)
                return i;
        }
        return -1;
    }

    public override bool IsEmpty() => Count == 0;

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