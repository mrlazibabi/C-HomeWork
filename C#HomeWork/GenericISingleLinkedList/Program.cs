using System.Collections;

SingleLinkedList<int> list = new SingleLinkedList<int>();

// Test Add and ToArray
list.Add(1);
list.Add(2);
list.Add(3);
Console.WriteLine($"Add: {string.Join(", ", list.ToArray())}"); // Expected: 1, 2, 3
Console.WriteLine($"Count: {list.Count}"); // Expected: 3

// Test Insert
list.Insert(1, 4); // List: 1 -> 4 -> 2 -> 3
Console.WriteLine($"Insert: {string.Join(", ", list.ToArray())}"); // Expected: 1, 4, 2, 3

// Test Contains and IndexOf
Console.WriteLine($"Contains 4: {list.Contains(4)}"); // Expected: True
Console.WriteLine($"IndexOf 4: {list.IndexOf(4)}"); // Expected: 1

// Test Remove
list.Remove(4); // List: 1 -> 2 -> 3
Console.WriteLine($"Remove 4: {string.Join(", ", list.ToArray())}"); // Expected: 1, 2, 3

// Test RemoveAt
list.RemoveAt(0); // List: 2 -> 3
Console.WriteLine($"RemoveAt 0: {string.Join(", ", list.ToArray())}"); // Expected: 2, 3

// Test Clear
list.Clear();
Console.WriteLine($"Clear: {string.Join(", ", list.ToArray())}"); // Expected: (empty)
Console.WriteLine($"Count: {list.Count}"); // Expected: 0

public interface ISingleLinkedList<T>
{
    void Add(T item);
    void Clear();
    bool Contains(T item);
    int IndexOf(T item);
    void Insert(int index, T item);
    void Remove(T item);
    void RemoveAt(int index);
    T[] ToArray();
    int Count { get; }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; } 
    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}

public class SingleLinkedList<K> : ISingleLinkedList<K>, IEnumerable<K>
{
    private Node<K>? _head; 
    private int _count;

    public SingleLinkedList()
    {
        _head = null;
        _count = 0;
    }

    public int Count { get { return _count; } }

    public void Add(K item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("item to be added cannot be null");
        }

        Node<K> newNode = new Node<K>(item);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node<K> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        _count++;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
    }

    public bool Contains(K item)
    {
        if (_head == null)
        {
            return false;
        }
        if (item == null)
        {
            throw new ArgumentNullException("Item to be checked cannot be null");
        }

        Node<K> current = _head;
        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public int IndexOf(K item)
    {
        if (_head == null)
        {
            return -1;
        }
        if (item == null)
        {
            throw new ArgumentNullException("Item to be checked cannot be null");
        }

        Node<K> current = _head;
        int index = 0;

        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return index;
            }
            current = current.Next;
            index++;
        }
        return -1; //không tìm thấy
    }

    public void Insert(int index, K item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Item to be inserted cannot be null");
        }
        if (index < 0 || index > _count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range");
        }

        Node<K> newNode = new Node<K>(item);
        if (index == 0)
        {
            newNode.Next = _head;
            _head = newNode;
        }
        else
        {
            Node<K> current = _head!;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next!;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        _count++;
    }

    public void Remove(K item)
    {
        if (_head == null)
        {
            return;
        }
        if (item == null)
        {
            throw new ArgumentNullException("Item to be removed cannot be null");
        }
        if (_head.Value.Equals(item))
        {
            _head = _head.Next;
            _count--;
            return;
        }

        Node<K> current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value.Equals(item))
            {
                current.Next = current.Next.Next;
                _count--;
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveAt(int index)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The list is empty");
        }
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range");
        }
        if (index == 0)
        {
            _head = _head.Next;
            _count--;
            return;
        }

        Node<K> current = _head!;
        for (int i = 0; i < index - 1; i++)
        {
            current = current.Next!;
        }
        current.Next = current.Next?.Next;
        _count--;
    }

    public K[] ToArray()
    {
        K[] result = new K[_count];
        if (_head == null)
        {
            return result;
        }

        Node<K> current = _head;
        for (int i = 0; i < _count; i++)
        {
            result[i] = current.Value;
            current = current.Next;
        }
        return result;
    }

    public IEnumerator<K> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public struct Enumerator : IEnumerator<K>
    {
        private readonly SingleLinkedList<K> _list;
        private Node<K>? _current; 
        private int _index;

        internal Enumerator(SingleLinkedList<K> list)
        {
            _list = list;
            _current = null;
            _index = 0;
        }

        public K Current
        {
            get
            {
                if (_current == null || _index == 0)
                {
                    throw new InvalidOperationException("Enumerator chưa được khởi tạo hoặc đã kết thúc.");
                }
                    
                return _current.Value;
            }
        }

        object? IEnumerator.Current
        {
            get
            {
                if (_current == null || _index == 0)
                {
                    throw new InvalidOperationException("Enumerator chưa được khởi tạo hoặc đã kết thúc.");
                }
                
                return _current.Value;
            }
        }

        public bool MoveNext()
        {
            if (_index >= _list.Count)
            {
                _current = null;
                return false;
            }
            if (_index == 0)
            {
                _current = _list._head;
            }
            else
            {
                _current = _current?.Next;
            }
            _index++;
            return _current != null;
        }

        public void Reset()
        {
            _current = null;
            _index = 0;
        }

        public void Dispose()
        {

        }
    }
}
