LinkedList linkedList = new LinkedList();

public class LinkedList
{
    public Node Head { get; set; }

    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = Head;
        Head = newNode;
    }

    public void Traverse()
    {
        Node current = Head;

        while (current is not null)
        {
            Console.WriteLine(current.DataOfNode);
            current = current.Next;
        }
    }

    public int Count()
    {
        int count = 0;
        Node current = Head;

        while (current is not null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public Node Search(int value)
    {
        Node current = Head;

        while (current is not null)
        {
            if (current.DataOfNode == value)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public bool IsEmpty()
    {
        return Head == null;
    }

    public void Clear()
    {
        Head = null;
    }

    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (Head is null)
        {
            Head = newNode;
            return;
        }

        Node current = Head;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public void InsertAfter(int target, int value)
    {
        Node targetNode = Search(target);

        if (targetNode is null)
        {
            throw new InvalidOperationException($"Cannot find node with value {target}");
        }

        Node newNode = new Node(value);
        newNode.Next = targetNode.Next;
        targetNode.Next = newNode;
    }

    public void RemoveHead()
    {
        if (Head is null)
        {
            return;
        }
        Head = Head.Next;
    }

    public void Remove(int target)
    {
        if (Head is null)
        {
            return;
        }

        if (Head.DataOfNode == target)
        {
            Head = Head.Next;
            return;
        }

        Node current = Head;
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

    public Node GetHead()
    {
        return Head;
    }

    public Node GetTail()
    {
        if (Head is null)
        {
            return null;
        }

        Node current = Head;
        while (current.Next is not null)
        {
            current = current.Next;
        }
        return current;
    }

    public void InsertBefore(int target, int value)
    {
        if (Head is null)
        {
            throw new InvalidOperationException("List is empty");
        }

        if (Head.DataOfNode == target)
        {
            InsertHead(value);
            return;
        }

        Node current = Head;
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
        if (Head is null)
        {
            return;
        }

        if (Head.Next is null)
        {
            Head = null;
            return;
        }

        Node current = Head;
        while (current.Next.Next is not null)
        {
            current = current.Next;
        }
        current.Next = null;
    }

    public Node GetNode(int index)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException("Index cannot be negative");
        }

        Node current = Head;
        int currentIndex = 0;

        while (current is not null)
        {
            if (currentIndex == index)
            {
                return current;
            }
            current = current.Next;
            currentIndex++;
        }

        throw new ArgumentOutOfRangeException("Index out of range");
    }
}

public class Node
{
    public int DataOfNode { get; set; }
    public Node Next { get; set; }
    public Node(int value)
    {
        DataOfNode = value;
    }
}