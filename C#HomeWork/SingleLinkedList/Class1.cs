using System.Collections;

public interface ISingleLinkedList<K>
{
    void Add(K item);
    void Clear();
    bool Contains(K item);
    int IndexOf(K item);
    void Insert(int index, K item);
    bool Remove(K item);
    void RemoveAt(int index);
    K[] ToArray();
    int Count { get; }
}

public class SingleLinkedList<K> : ISingleLinkedList<K>, ICollection<K>
{
    private Node<K>? _head;
    private int _count;

    public SingleLinkedList()
    {
        _head = null;
        _count = 0;
    }

    public int Count { get { return _count; } }

    public bool IsReadOnly => false;

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
        return -1;
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

    public bool Remove(K item)
    {
        if (_head == null)
        {
            return false;
        }
        if (item == null)
        {
            throw new ArgumentNullException("Item to be removed cannot be null");
        }
        if (_head.Value.Equals(item))
        {
            _head = _head.Next;
            _count--;
            return true;
        }

        Node<K> current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value.Equals(item))
            {
                current.Next = current.Next.Next;
                _count--;
                return true;
            }
            current = current.Next;
        }
        return false;
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

    public void CopyTo(K[] array, int arrayIndex)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The list is empty");
        }
        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException("arrayIndex is out of range");
        }

        Node<K> current = _head;
        int i = arrayIndex;
        while (current != null && i < array.Length)
        {
            array[i] = current.Value;
            current = current.Next;
            i++;
        }
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
                    throw new InvalidOperationException("Enumerator chưa được khởi tạo hoặc đã kết thúc.");
                return _current.Value;
            }
        }

        object? IEnumerator.Current
        {
            get
            {
                if (_current == null || _index == 0)
                    throw new InvalidOperationException("Enumerator chưa được khởi tạo hoặc đã kết thúc.");
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