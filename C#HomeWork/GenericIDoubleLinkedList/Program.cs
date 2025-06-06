DoubleLinkedList<int> list = new DoubleLinkedList<int>();

// Test InsertHead and Traverse
list.InsertHead(new Node<int>(1));
list.InsertHead(new Node<int>(2));
Console.WriteLine("InsertHead: ");
list.Traverse(); // Expected: 2 1

// Test InsertTail
list.InsertTail(new Node<int>(3));
Console.WriteLine("InsertTail: ");
list.Traverse(); // Expected: 2 1 3

// Test InsertAfter
list.InsertAfter(1, 4);
Console.WriteLine("InsertAfter: ");
list.Traverse(); // Expected: 2 1 4 3

// Test RemoveHead
list.RemoveHead();
Console.WriteLine("RemoveHead: ");
list.Traverse(); // Expected: 1 4 3

// Test RemoveTail
list.RemoveTail();
Console.WriteLine("RemoveTail: ");
list.Traverse(); // Expected: 1 4

// Test Clear
list.Clear();
Console.WriteLine("Clear: ");
list.Traverse(); // Expected: (empty)
Console.WriteLine($"Count: {list.Count}"); // Expected: 0

public interface IDoubleLinkedList<T>
{
    void InsertHead(Node<T> node);
    void InsertTail(Node<T> node);
    void InsertAfter(int target, T value);
    void RemoveHead();
    void Remove(T target);
    void RemoveTail();
    Node<T> GetHead();
    Node<T> GetTail();
    Node<T> GetNode(int index);
    Node<T> Search(T value);
    bool IsEmpty();
    void Clear();
    void Traverse();
    int Count { get; }
    Node<T> Tail { get; }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Previous { get; set; }
    public Node(T value)
    {
        Value = value;
        Next = null;
        Previous = null;
    }
}

public class DoubleLinkedList<T> : IDoubleLinkedList<T>
{
    private Node<T> _head;
    private int _count;

    public DoubleLinkedList()
    {
        _head = null;
        _count = 0;
    }

    public int Count { get { return _count; } }

    public Node<T> Tail
    {
        get
        {
            if (_head == null)
            {
                return null;
            }
            Node<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }
    }

    public void InsertHead(Node<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException("Node to be inserted cannot be null");
        }
        node.Next = _head;
        if (_head != null)
        {
            _head.Previous = node;
        }
        _head = node;
        _count++;
    }

    public void InsertTail(Node<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException("Node to be inserted cannot be null");
        }

        if (_head == null)
        {
            _head = node;
        }
        else
        {
            Node<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
            node.Previous = current;
        }
        _count++;
    }

    public void InsertAfter(int target, T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Value to be inserted cannot be null");
        }
        if (target < 0 || target >= _count)
        {
            throw new ArgumentOutOfRangeException("Target index is out of range");
        }

        Node<T> newNode = new Node<T>(value);
        Node<T> current = _head;
        for (int i = 0; i < target; i++)
        {
            current = current.Next;
        }
        newNode.Next = current.Next;
        newNode.Previous = current;
        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }

        current.Next = newNode;
        _count++;
    }

    public void RemoveHead()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The list is empty");
        }
        _head = _head.Next;
        if (_head != null)
        {
            _head.Previous = null;
        }

        _count--;
    }

    public void Remove(T target)
    {
        if (_head == null)
        {
            return;
        }
        if (target == null)
        {
            throw new ArgumentNullException("Target to be removed cannot be null");
        }

        Node<T> current = _head;
        while (current != null)
        {
            if (current.Value.Equals(target))
            {
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                _count--;
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveTail()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        if (_head.Next == null)
        {
            _head = null;
        }
        else
        {
            Node<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Previous.Next = null;
        }
        _count--;
    }

    public Node<T> GetHead()
    {
        return _head;
    }

    public Node<T> GetTail()
    {
        if (_head == null)
        {
            return null;
        }
        Node<T> current = _head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        return current;
    }

    public Node<T> GetNode(int index)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range");
        }

        Node<T> current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current;
    }

    public Node<T> Search(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Value to be searched cannot be null");
        }

        Node<T> current = _head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public bool IsEmpty()
    {
        return _head == null;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
    }

    public void Traverse()
    {
        Node<T> current = _head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}