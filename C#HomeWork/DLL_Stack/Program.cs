DLL_Stack stack = new DLL_Stack();
public class DLL_Stack
{
    private readonly DoublyLinkedList _list;

    public DLL_Stack()
    {
        _list = new DoublyLinkedList();
    }

    public void Push(int item)
    {
        _list.InsertTail(item);
    }

    public int Pop()
    {
        if (_list.IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        var tail = _list.GetTail();
        _list.RemoveTail();
        return tail.DataOfNode;
    }

    public int Peek()
    {
        if (_list.IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _list.GetTail().DataOfNode;
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