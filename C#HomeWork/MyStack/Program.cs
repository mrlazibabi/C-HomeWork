MyStack demo = new MyStack(3);
demo.Push(1);
demo.Push(2);
demo.Push(3);
Console.WriteLine("Peek: " + demo.Peek());
Console.WriteLine("Count: " + demo.Count);

Console.WriteLine("Pop: " + demo.Pop());
Console.WriteLine("Pop: " + demo.Pop());
Console.WriteLine("Pop: " + demo.Pop());
Console.WriteLine("Count: " + demo.Count);

demo.Push(4);
demo.Push(5);
Console.WriteLine("Pop: " + demo.Pop());
Console.WriteLine("Pop: " + demo.Pop());
Console.WriteLine("Count: " + demo.Count);

public class MyStack
{
    public int[] StackData;
    public int Top;
    public int MaxSize;

    public MyStack(int maxSize)
    {
        MaxSize = maxSize;
        StackData = new int[maxSize];
        Top = -1;
    }

    public void Push(int item)
    {
        if (Top == MaxSize - 1)
        {
            throw new InvalidOperationException("Stack is full");
        }
        StackData[++Top] = item; ;
    }

    public int Pop()
    {
        if (Top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return StackData[Top--];
    }

    public int Peek()
    {
        if (Top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return StackData[Top];
    }

    public int Count => Top + 1;

    public void Reset() => Top = -1;
}