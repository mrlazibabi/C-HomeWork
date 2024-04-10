/// <summary>
/// Cấu trúc chứa dữ liệu thực sự
/// </summary>
public class LinkedList
{
    public Node Head { get; set; }

    public void InsertNodeToLast(Node node)
    {
        throw new NotImplementedException();
    }

    public Node GetFirstNodeAndRemove()
    {
        throw new NotImplementedException();
    }

    public Node[] GetFirstThreeNode()
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        throw new NotImplementedException();
    }

    public decimal TotalAmount()
    {
        throw new NotImplementedException();
    }
}

public class Node
{
    public Customer DataOfNode { get; set; }
    public Node NextNode { get; set; }
}