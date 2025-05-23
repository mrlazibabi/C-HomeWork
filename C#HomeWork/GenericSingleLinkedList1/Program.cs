
SingleLinkedList<int> list = new SingleLinkedList<int>();

// Test Add
Console.WriteLine("Testing Add:");
list.Add(1);
list.Add(2);
list.Add(3);
Console.WriteLine($"List: [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test InsertAtHead
Console.WriteLine("\nTesting InsertAtHead:");
list.InsertAtHead(0);
Console.WriteLine($"List: [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test Remove
Console.WriteLine("\nTesting Remove:");
list.Remove(2);
Console.WriteLine($"After Remove(2): [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test RemoveAt
Console.WriteLine("\nTesting RemoveAt:");
list.RemoveAt(1);
Console.WriteLine($"After RemoveAt(1): [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test Contains
Console.WriteLine("\nTesting Contains:");
Console.WriteLine($"Contains(3): {list.Contains(3)}");
Console.WriteLine($"Contains(5): {list.Contains(5)}");

// Test IndexOf
Console.WriteLine("\nTesting IndexOf:");
Console.WriteLine($"IndexOf(3): {list.IndexOf(3)}");
Console.WriteLine($"IndexOf(5): {list.IndexOf(5)}");

// Test Insert
Console.WriteLine("\nTesting Insert:");
list.Insert(1, 4);
Console.WriteLine($"After Insert(1, 4): [{string.Join(", ", list.ToArray())}], Count = {list.Count}");

// Test Clear
Console.WriteLine("\nTesting Clear:");
list.Clear();
Console.WriteLine($"After Clear: [{string.Join(", ", list.ToArray())}], Count = {list.Count}, IsEmpty: {list.IsEmpty()}");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

public class SingleLinkedList<T>
{
    public Node<T> head;
    private int count;

    public SingleLinkedList()
    {
        head = null;
        count = 0;
    }

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        count++;
    }

    public void InsertAtHead(T item)
    {
        Node<T> newNode = new Node<T>(item);
        newNode.Next = head;
        head = newNode;
        count++;
    }

    public void Remove(T item)
    {
        if (head == null) return;

        if (EqualityComparer<T>.Default.Equals(head.Value, item))
        {
            head = head.Next;
            count--;
            return;
        }

        Node<T> current = head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Value, item))
            {
                current.Next = current.Next.Next;
                count--;
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            head = head.Next;
            count--;
            return;
        }

        Node<T> current = head;
        for (int i = 0; i < index - 1; i++)
        {
            current = current.Next;
        }
        current.Next = current.Next.Next;
        count--;
    }

    public bool Contains(T item)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public int Count => count;

    public void Clear()
    {
        head = null;
        count = 0;
    }

    public T[] ToArray()
    {
        T[] array = new T[count];
        Node<T> current = head;
        for (int i = 0; i < count; i++)
        {
            array[i] = current.Value;
            current = current.Next;
        }
        return array;
    }

    public int IndexOf(T item)
    {
        Node<T> current = head;
        int index = 0;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                return index;
            }
            current = current.Next;
            index++;
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > count) throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            InsertAtHead(item);
            return;
        }

        Node<T> newNode = new Node<T>(item);
        Node<T> current = head;
        for (int i = 0; i < index - 1; i++)
        {
            current = current.Next;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
        count++;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}