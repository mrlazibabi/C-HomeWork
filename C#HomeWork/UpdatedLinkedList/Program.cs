LinkedList linkedList = new LinkedList();

//LinkedList: Che giấu chi tiết nội bộ như nút (node) và chỉ cung cấp các phương thức cần thiết để thao tác với danh sách liên kết.

public class LinkedList
{
    private class Node //set class private
    {
        public int DataOfNode { get; set; }
        public Node Next { get; set; }
        public Node(int value)
        {
            DataOfNode = value;
        }
    }
    private Node _head; //set private field

    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = _head;
        _head = newNode;
    }

    public void Traverse()
    {
        Node current = _head;

        while (current is not null)
        {
            Console.WriteLine(current.DataOfNode);
            current = current.Next;
        }
    }

    public int Count()
    {
        int count = 0;
        Node current = _head;

        while (current is not null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public int Search(int value) // Tra ve index thay vi tra 1 Node
    {
        Node current = _head;
        int index = 0;

        while (current is not null)
        {
            if (current.DataOfNode == value)
            {
                return index;
            }
            current = current.Next;
            index++;
        }
        return -1;
    }

    public bool IsEmpty()
    {
        return _head == null;
    }

    public void Clear()
    {
        _head = null;
    }

    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (_head is null)
        {
            _head = newNode;
            return;
        }

        Node current = _head;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public void InsertAfter(int target, int value)
    {
        int targetNode = Search(target); // Tra ve index thay vi tra 1 Node

        if (targetNode == -1)
        {
            throw new InvalidOperationException($"Cannot find node with value {target}");
        }

        Node current = _head;
        for (int i = 0; i < targetNode; i++)
        {
            current = current.Next;
        }
        Node newNode = new Node(value);
        newNode.Next = current.Next;
        current.Next = newNode;
    }

    public void RemoveHead()
    {
        if (_head is null)
        {
            return;
        }
        _head = _head.Next;
    }

    public void Remove(int target)
    {
        if (_head is null)
        {
            return;
        }

        if (_head.DataOfNode == target)
        {
            _head = _head.Next;
            return;
        }

        Node current = _head;
        while (current.Next is not null)
        {
            if (current.Next.DataOfNode == target)
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public int GetHead() // Tra ve data thay vi tra ve 1 node
    {
        if (_head is null)
        {
            throw new InvalidOperationException("List is empty");
        }
        return _head.DataOfNode;
    }

    public int GetTail() // Tra ve data thay vi tra ve 1 node
    {
        if (_head is null)
        {
            throw new InvalidOperationException("List is empty");
        }
        Node current = _head;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        return current.DataOfNode;
    }

    public void InsertBefore(int target, int value)
    {
        if (_head is null)
        {
            throw new InvalidOperationException("List is empty");
        }

        if (_head.DataOfNode == target)
        {
            InsertHead(value);
            return;
        }

        Node current = _head;
        while (current.Next is not null)
        {
            if (current.Next.DataOfNode == target)
            {
                Node newNode = new Node(value);
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }
            current = current.Next;
        }

        throw new InvalidOperationException($"Cannot find node with value {target}");
    }

    public void RemoveTail()
    {
        if (_head is null)
        {
            return;
        }

        if (_head.Next is null)
        {
            _head = null;
            return;
        }

        Node current = _head;
        while (current.Next.Next is not null)
        {
            current = current.Next;
        }
        current.Next = null;
    }

    public int GetNode(int index) // Tra ve data thay vi tra ve 1 node
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative");
        }

        Node current = _head;
        int currentIndex = 0;

        while (current is not null)
        {
            if (currentIndex == index)
            {
                return current.DataOfNode;
            }
            current = current.Next;
            currentIndex++;
        }
        throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
    }
}