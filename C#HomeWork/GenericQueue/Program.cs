MyQueue<int> queue = new MyQueue<int>(3);

// Test Enqueue
Console.WriteLine("Testing Enqueue:");
queue.Enqueue(1);
Console.WriteLine($"After Enqueue(1), Count = {queue.Count}, Front = {queue.Front()}");
queue.Enqueue(2);
Console.WriteLine($"After Enqueue(2), Count = {queue.Count}, Front = {queue.Front()}");
queue.Enqueue(3);
Console.WriteLine($"After Enqueue(3), Count = {queue.Count}, Front = {queue.Front()}");

// Test Enqueue đầy
try
{
    queue.Enqueue(4);
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Exception: {e.Message}");
}

// Test Dequeue
Console.WriteLine("\nTesting Dequeue:");
int item = queue.Dequeue();
Console.WriteLine($"Dequeued item = {item}, Count = {queue.Count}, Front = {queue.Front()}");
item = queue.Dequeue();
Console.WriteLine($"Dequeued item = {item}, Count = {queue.Count}, Front = {queue.Front()}");

// Test Dequeue rỗng
try
{
    item = queue.Dequeue();
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Exception: {e.Message}");
}

// Test Front
Console.WriteLine("\nTesting Front:");
queue.Enqueue(5);
Console.WriteLine($"After Enqueue(5), Front = {queue.Front()}");

// Test Clear
Console.WriteLine("\nTesting Clear:");
queue.Clear();
Console.WriteLine($"After Clear, Count = {queue.Count}");

// Test Front rỗng
try
{
    Console.WriteLine($"Front = {queue.Front()}");
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Exception: {e.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

public class MyQueue<T>
{
    private T[] items;
    private int maxSize;
    private int count;
    private int front;
    private int rear;

    public MyQueue(int maxQueue)
    {
        maxSize = maxQueue;
        items = new T[maxSize];
        count = 0;
        front = 0;
        rear = -1;
    }

    public void Enqueue(T item)
    {
        if (count == maxSize) throw new InvalidOperationException("Queue is full");
        rear = (rear + 1) % maxSize;
        items[rear] = item;
        count++;
    }

    public T Dequeue()
    {
        if (count == 0) throw new InvalidOperationException("Queue is empty");
        T item = items[front];
        front = (front + 1) % maxSize;
        count--;
        return item;
    }

    public T Front()
    {
        if (count == 0) throw new InvalidOperationException("Queue is empty");
        return items[front];
    }

    public void Clear()
    {
        count = 0;
        front = 0;
        rear = -1;
    }

    public int Count => count;
}
