using System.Collections.Generic;
using System.Xml.Linq;
Queue queue = new Queue();
public class Queue
{
    private LinkedList DataOfQueue;

    public Queue()
    {
        DataOfQueue = new LinkedList();
    }

    public void Enqueue(int item)
    {
        DataOfQueue.InsertTail(new Node(item));
    }

    public int Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        int value = DataOfQueue.GetHead().DataOfNode;
        DataOfQueue.RemoveHead();
        return value;
    }

    public int Front()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        return DataOfQueue.GetHead().DataOfNode;
    }

    public bool IsEmpty()
    {
        return DataOfQueue.IsEmpty();
    }

    public int Count => DataOfQueue.Count();
}