LinkedList linkedList = new LinkedList();
public class LinkedList
{
    public Node Head { get; set; }
    public Node Tail { get; set; } 

    public void InsertHead(Node node)
    {
        node.Next = Head;
        Head = node;
        if (Tail == null) //If list empty, set Tail to new node
        {
            Tail = node;
        }
    }

    public void InsertTail(Node node)
    {
        if (Head is null)
        {
            Head = node;
            Tail = node;
            return;
        }

        Tail.Next = node;
        Tail = node;
    }

    public void InsertAfter(int target, Node node)
    {
        Node targetNode = Search(target);

        if (targetNode is null)
        {
            throw new InvalidOperationException($"Cannot find node with value {target}");
        }

        node.Next = targetNode.Next;
        targetNode.Next = node;

        if (targetNode == Tail)
        {
            Tail = node;
        }
    }

    public void InsertBefore(int target, int value)
    {
        if (Head is null)
        {
            throw new InvalidOperationException("List is empty");
        }

        if (Head.DataOfNode == target)
        {
            InsertHead(new Node(value));
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

    public void RemoveHead()
    {
        if (Head is null)
        {
            return;
        }
        Head = Head.Next;
        if (Head is null) 
        {
            Tail = null;
        }
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
            Tail = null;
            return;
        }

        Node current = Head;
        while (current.Next.Next is not null)
        {
            current = current.Next;
        }
        current.Next = null;
        Tail = current; 
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
            if (Head is null)
            {
                Tail = null;
            }
            return;
        }

        Node current = Head;
        while (current.Next is not null)
        {
            if (current.Next.DataOfNode == target)
            {
                current.Next = current.Next.Next;
                if (current.Next is null)
                {
                    Tail = current;
                }
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
        return Tail;
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
        Tail = null;
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