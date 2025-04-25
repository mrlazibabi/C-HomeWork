public interface ILinkedList
{
    Node Head { get; set; }
    Node Tail { get; set; }

    int Count();
    Node[] GetAllNode();
    Node GetFirstNodeAndRemove();
    Node[] GetFirstThreeNode();
    void InsertNodeToLast(Node node);
    decimal TotalAmount();
}