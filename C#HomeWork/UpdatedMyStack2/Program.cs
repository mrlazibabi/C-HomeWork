AbstractStack stack = new MyStack(3);
stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine("Peek: " + stack.Peek());  // Expected: 3
Console.WriteLine("Count: " + stack.Count); // Expected: 3

Console.WriteLine("Pop: " + stack.Pop());   // Expected: 3
Console.WriteLine("Pop: " + stack.Pop());   // Expected: 2
Console.WriteLine("Pop: " + stack.Pop());   // Expected: 1
Console.WriteLine("Count: " + stack.Count); // Expected: 0

stack.Reset();

public abstract class AbstractStack
{
    public abstract void Push(int item);
    public abstract int Pop();
    public abstract int Peek();
    public abstract void Reset();

    // Thuộc tính để lấy số lượng phần tử hiện tại
    public abstract int Count { get; }
}

public class MyStack : AbstractStack
{
    private int[] _stackData;
    private int _top;
    private int _maxSize;

    // Constructor
    public MyStack(int maxSize)
    {
        _maxSize = maxSize;
        _stackData = new int[maxSize];
        _top = -1; // Stack rỗng
    }

    // Triển khai phương thức Push
    public override void Push(int item)
    {
        if (_top == _maxSize - 1)
        {
            throw new InvalidOperationException("Stack is full");
        }

        _top++;
        _stackData[_top] = item;
    }

    // Triển khai phương thức Pop
    public override int Pop()
    {
        if (_top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        int valueAtTop = _stackData[_top];
        _top--;
        return valueAtTop;
    }

    // Triển khai phương thức Peek
    public override int Peek()
    {
        if (_top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _stackData[_top];
    }

    // Triển khai thuộc tính Count
    public override int Count => _top + 1;

    // Ghi đè phương thức Reset
    public override void Reset()
    {
        _top = -1;
    }
}