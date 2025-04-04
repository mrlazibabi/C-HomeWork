using System.Runtime.InteropServices;

DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
public class DoublyLinkedList
{
    public Node Head { get; set; } // Mặc định nó sẽ null
    public Node Tail { get; set; }

    public String Traverse()
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

    public void InsertHead(int value)
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

    public void InsertTail(int value)  // 1 2 3 [4] null
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

    public void InsertAfter(int target, int value) // 1 2 3 [6] 
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

    public void InsertBefore(int target, int value)// 1 2 [6] 3 
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
        else
        {
            Head.Previous = null;
        }
    }

    public void RemoveTail()
    {
        if(Tail is null)
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

    public void Remove(int target)  //1 2 3 [4] 6
    {
        if(Head is null)
        {
            return;
        }

        Node current = Head;
        while(current is not null)
        {
            if(current.DataOfNode == target)
            {
                if(current == Head)
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

    public Node GetNode(int index)
    {
        if(Head == null || index < 0)
        {
            return null;
        }

        Node current = Head;
        int i = 0;
        while(current is not null && i < index)
        {
            i++;
            current = current.Next;
        }
        return current;
    }

    public Node GetHead()
    {
        if(Head is null)
        {
            return null;
        }
        return Head;
    }

    public Node GetTail()
    {
        if(Tail is null)
        {
            return null;
        }
        return Tail;
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

    public bool IsEmpty()
    {
        return Head == null;
    }

    public void Clear()
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