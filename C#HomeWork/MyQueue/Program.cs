MyQueue queue = new MyQueue(3);
queue.Enqueue(10);
queue.Enqueue(20);
queue.Enqueue(30);

Console.WriteLine(queue.Front());
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Count);
queue.Reset();
Console.WriteLine(queue.Count);

public class MyQueue
{
    public int[] Item;
    public int Tail;
    public int MaxQueue;

    public MyQueue(int size)
    {
        MaxQueue = size;
        Item = new int[MaxQueue];
        Tail = -1;
    }

    public void Enqueue(int item)
    {
        if (Tail == MaxQueue - 1)
        {
            throw new InvalidOperationException("Queue is full");
        }
        Tail++;
        Item[Tail] = item;
    }

    public int Dequeue()
    {
        if (Tail == -1)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        int frontItem = Item[0];

        for(int i = 1; i <= Tail; i++)
        {
            Item[i - 1] = Item[i];
        }

        Tail--;
        return frontItem;
    }

    public int Front()
    {
        if (Tail == -1)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return Item[0];
    }

    public int Count => Tail + 1;

    public void Reset() => Tail = -1;
}