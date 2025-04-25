LinkedList linkedList = new LinkedList();

public abstract class AbstractLinkedList
{
    public abstract void InsertHead(int value);
    public abstract void InsertTail(int value);
    public abstract void InsertAfter(int target, int value);
    public abstract void InsertBefore(int target, int value);
    public abstract int Search(int value);
    public abstract int GetHead();
    public abstract int GetTail();
    public abstract int GetNode(int index);
    public abstract void Traverse();
    public abstract void RemoveHead();
    public abstract void RemoveTail();
    public abstract void Remove(int target);
    public abstract bool IsEmpty();
    public abstract void Clear();
}

public class LinkedList : AbstractLinkedList
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

    public override void InsertHead(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = _head;
        _head = newNode;
    }

    public override void Traverse()
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

    public override int Search(int value) // Tra ve index thay vi tra 1 Node
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

    public override bool IsEmpty()
    {
        return _head == null;
    }

    public override void Clear()
    {
        _head = null;
    }

    public override void InsertTail(int value)
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

    public override void InsertAfter(int target, int value)
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

    public override void RemoveHead()
    {
        if (_head is null)
        {
            return;
        }
        _head = _head.Next;
    }

    public override void Remove(int target)
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

    public override int GetHead() // Tra ve data thay vi tra ve 1 node
    {
        if (_head is null)
        {
            throw new InvalidOperationException("List is empty");
        }
        return _head.DataOfNode;
    }

    public override int GetTail() // Tra ve data thay vi tra ve 1 node
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

    public override void InsertBefore(int target, int value)
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

    public override void RemoveTail()
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

    public override int GetNode(int index) // Tra ve data thay vi tra ve 1 node
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