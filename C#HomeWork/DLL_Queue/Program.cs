DLL_Queue queue = new DLL_Queue();
public class DLL_Queue
{
    private readonly DoublyLinkedList _list;

    public DLL_Queue()
    {
        _list = new DoublyLinkedList();
    }

    public void Enqueue(int item)
    {
        _list.InsertTail(item);
    }

    public int Dequeue()
    {
        if (_list.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var head = _list.GetHead();
        _list.RemoveHead();
        return head.DataOfNode;
    }

    public int Front()
    {
        if (_list.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _list.GetHead().DataOfNode;
    }

    public bool IsEmpty()
    {
        return _list.IsEmpty();
    }

    public int Count()
    {
        return _list.Count();
    }
}