DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

public abstract class AbstractDoublyLinkedList
{
    public abstract string Traverse();
    public abstract void InsertHead(int value);
    public abstract void InsertTail(int value);
    public abstract void InsertAfter(int target, int value);
    public abstract void InsertBefore(int target, int value);
    public abstract void RemoveHead();
    public abstract void RemoveTail();
    public abstract void Remove(int target);
    public abstract Node Search(int value);
    public abstract Node GetNode(int index);
    public abstract Node GetHead();
    public abstract Node GetTail();
    public abstract int Count();
    public abstract bool IsEmpty();
    public abstract void Clear();
}

public class DoublyLinkedList : AbstractDoublyLinkedList
{
    public Node Head { get; set; } // Mặc định nó sẽ null
    public Node Tail { get; set; }

    public override string Traverse()
    {
        Node current = Head;
        string result = "";
        while (current is not null)
        {
            result += current.DataOfNode + " ";
            current = current.Next;
        }
        return result.Trim();
    }

    public override void InsertHead(int value)
    {
        Node newNode = new Node(value);
        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }
    }

    public override void InsertTail(int value)  // 1 2 3 [4] null
    {
        Node newNode = new Node(value);
        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
        }
    }

    public override void InsertAfter(int target, int value) // 1 2 3 [6] 
    {
        Node targetNode = Search(target);
        if (targetNode is null)
        {
            throw new InvalidOperationException($"Can't find target node with value {target}");
        }

        Node newNode = new Node(value);
        newNode.Next = targetNode.Next;
        if (targetNode.Next is not null)
        {
            targetNode.Next.Previous = newNode;
        }
        else
        {
            Tail = newNode; // Update Tail 
        }
        targetNode.Next = newNode;
        newNode.Previous = targetNode;
    }

    public override void InsertBefore(int target, int value) // 1 2 [6] 3 
    {
        Node targetNode = Search(target);
        if (targetNode is null)
        {
            throw new InvalidOperationException($"Can't find target node with value {target}");
        }

        Node newNode = new Node(value);
        newNode.Previous = targetNode.Previous;
        newNode.Next = targetNode;
        if (targetNode.Previous is not null)
        {
            targetNode.Previous.Next = newNode;
        }
        else
        {
            Head = newNode;
        }
        targetNode.Previous = newNode;

    }

    public override void RemoveHead()
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
        else
        {
            Head.Previous = null;
        }
    }

    public override void RemoveTail()
    {
        if (Tail is null)
        {
            return;
        }

        Tail = Tail.Previous;
        if (Tail is null)
        {
            Head = null;
        }
        else
        {
            Tail.Next = null;
        }
    }

    public override void Remove(int target)  //1 2 3 [4] 6
    {
        if (Head is null)
        {
            return;
        }

        Node current = Head;
        while (current is not null)
        {
            if (current.DataOfNode == target)
            {
                if (current == Head)
                {
                    RemoveHead();
                    return;
                }
                else if (current == Tail)
                {
                    RemoveTail();
                    return;
                }
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    return;
                }
            }
            current = current.Next;
        }
    }

    public override Node Search(int value)
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

    public override Node GetNode(int index)
    {
        if (Head == null || index < 0)
        {
            return null;
        }

        Node current = Head;
        int i = 0;
        while (current is not null && i < index)
        {
            i++;
            current = current.Next;
        }
        return current;
    }

    public override Node GetHead()
    {
        if (Head is null)
        {
            return null;
        }
        return Head;
    }

    public override Node GetTail()
    {
        if (Tail is null)
        {
            return null;
        }
        return Tail;
    }

    public override int Count()
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

    public override bool IsEmpty()
    {
        return Head == null;
    }

    public override void Clear()
    {
        Head = null;
        Tail = null;
    }
}

public class Node
{
    public int DataOfNode { get; set; } // Chứa dữ liệu của Node có thể là bất cứ kiểu gì
    public Node Next { get; set; } // Tham chiếu đến Node tiếp theo
    public Node Previous { get; set; } // Tham chiếu đến Node trước đó

    public Node(int value)
    {
        DataOfNode = value;
        Next = null;
        Previous = null;
    }
}