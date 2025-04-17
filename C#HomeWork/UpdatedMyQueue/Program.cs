MyQueue queue = new MyQueue(3);
queue.Enqueue(10);
queue.Enqueue(20);
queue.Enqueue(30);

Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());


public class MyQueue
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

    public void Enqueue(int item)
    {
        if (_tail == _maxQueue - 1)
        {
            throw new InvalidOperationException("Queue is full");
        }
        _tail++;
        _item[_tail] = item;
    }

    public int Dequeue()
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

    private int Front() //Chỉ cho phép thao tác với dữ liệu thông qua các phương thức Enqueue, Dequeue.
    {
        if (_tail == -1)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return _item[0];
    }

    private int Count => _tail + 1; //Chỉ cho phép thao tác với dữ liệu thông qua các phương thức Enqueue, Dequeue.

    private void Reset() => _tail = -1; //Chỉ cho phép thao tác với dữ liệu thông qua các phương thức Enqueue, Dequeue.
}