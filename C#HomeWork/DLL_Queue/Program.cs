DLL_Queue queue = new DLL_Queue();
public class DLL_Queue
{
    private readonly DoublyLinkedList _list;

    public DLL_Queue()
    {
        _list = new DoublyLinkedList();
    }

    // Enqueue: Add an element to the rear of the queue (tail of the list)
    public void Enqueue(int item)
    {
        _list.InsertTail(item);
    }

    // Dequeue: Remove and return the front element of the queue (head of the list)
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

    // Front: Return the front element without removing it
    public int Front()
    {
        if (_list.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _list.GetHead().DataOfNode;
    }

    // IsEmpty: Check if the queue is empty
    public bool IsEmpty()
    {
        return _list.IsEmpty();
    }

    // Count: Return the number of elements in the queue
    public int Count()
    {
        return _list.Count();
    }
}