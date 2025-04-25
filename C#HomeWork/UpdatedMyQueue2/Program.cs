MyQueue queue = new MyQueue(3);
queue.Enqueue(10);
queue.Enqueue(20);
queue.Enqueue(30);

Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());

public abstract class AbstractMyQueue
{
    public abstract void Enqueue(int item);
    public abstract int Dequeue();
    public abstract int Front();
    public abstract int Count { get; }
    public abstract void Reset();

}

public class MyQueue : AbstractMyQueue
{
    private int[] _item; //set private field
    private int _tail;
    private int _maxQueue;

    public MyQueue(int size)
    {
        _maxQueue = size;
        _item = new int[_maxQueue];
        _tail = -1;
    }

    public override void Enqueue(int item)
    {
        if (_tail == _maxQueue - 1)
        {
            throw new InvalidOperationException("Queue is full");
        }
        _tail++;
        _item[_tail] = item;
    }

    public override int Dequeue()
    {
        if (_tail == -1)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        int frontItem = _item[0];

        for (int i = 1; i <= _tail; i++)
        {
            _item[i - 1] = _item[i];
        }

        _tail--;
        return frontItem;
    }

    public override int Front()
    {
        if (_tail == -1)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return _item[0];
    }

    public override int Count => _tail + 1;

    public override void Reset() => _tail = -1;
}
