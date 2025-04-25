/// <summary>
/// Cấu trúc chứa dữ liệu thực sự
/// </summary>
public class LinkedList : ILinkedList
{
    public Node Head { get; set; }
    public Node Tail { get; set; }
    private int count;

    public void InsertNodeToLast(Node node)
    {
        if (Tail == null)
        {
            Head = Tail = node;
        }
        else
        {
            Tail.NextNode = node;
            Tail = node;
        }
        count++;
    }

    public Node GetFirstNodeAndRemove()
    {
        if (Head == null) return null;

        Node firstNode = Head;
        Head = Head.NextNode;

        if (Head == null)
        {
            Tail = null;
        }

        count--;
        return firstNode;
    }

    public Node[] GetFirstThreeNode()
    {
        int size = Math.Min(3, count);
        if (size == 0) return null;

        Node[] result = new Node[size];
        Node current = Head;

        for (int i = 0; i < size; i++)
        {
            result[i] = current;
            current = current.NextNode;
        }
        return result;
    }

    public Node[] GetAllNode()
    {
        Node[] result = new Node[count];
        Node current = Head;
        for (int i = 0; i < count; i++)
        {
            result[i] = current;
            current = current.NextNode;
        }
        return result;
    }

    public int Count()
    {
        return count;
    }

    public decimal TotalAmount()
    {
        decimal totalAmount = 0;
        Node current = Head;
        while (current != null)
        {
            totalAmount += current.DataOfNode.WithDrawalAmount;
            current = current.NextNode;
        }
        return totalAmount;
    }
}

public class Node 
{
    public Customer DataOfNode { get; set; }
    public Node NextNode { get; set; }
}
