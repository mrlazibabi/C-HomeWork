MyStack demo = new MyStack(3);

//Stack: Đảm bảo dữ liệu bên trong chỉ có thể truy cập thông qua các phương thức Push, Pop, Peek.

public class MyStack
{
    private int[] _stackData; //set private field                
    private int _top;
    private int _maxSize;

    // Constructor
    public MyStack(int maxSize)
    {
        _maxSize = maxSize;
        _stackData = new int[maxSize];
        _top = -1; // Stack rỗng
    }

    // Thêm phần tử vào stack
    public void Push(int item)
    {
        if (_top == _maxSize - 1)
        {
            throw new InvalidOperationException("Stack is full");
        }
        _stackData[++_top] = item;
    }

    // Lấy và xóa phần tử ở đỉnh stack
    public int Pop()
    {
        if (_top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _stackData[_top--];
    }

    // Trả về phần tử ở đỉnh stack mà không xóa nó
    public int Peek()
    {
        if (_top == -1)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _stackData[_top];
    }

    // Trả về số lượng phần tử hiện tại trong stack
    private int Count => _top + 1; //Stack: Đảm bảo dữ liệu bên trong chỉ có thể truy cập thông qua các phương thức Push, Pop, Peek.

    // Đặt stack về trạng thái rỗng
    private void Reset() => _top = -1; //Stack: Đảm bảo dữ liệu bên trong chỉ có thể truy cập thông qua các phương thức Push, Pop, Peek.
}