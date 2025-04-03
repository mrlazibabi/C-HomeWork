using System.Collections.Generic;
using System.Xml.Linq;

MyStack stack = new MyStack();
public class MyStack
{
    private LinkedList DataOfStack;

    public MyStack()
    {
        DataOfStack = new LinkedList();
    }

    /// <summary>
    /// Thêm một phần tử vào đỉnh Stack.
    /// </summary>
    public void Push(int item)
    {
        DataOfStack.InsertHead(new Node(item));
    }

    /// <summary>
    /// Lấy và xóa phần tử ở đỉnh Stack.
    /// </summary>
    public int Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        int value = DataOfStack.GetHead().DataOfNode;
        DataOfStack.RemoveHead();
        return value;
    }

    /// <summary>
    /// Lấy phần tử ở đỉnh Stack mà không xóa.
    /// </summary>
    public int Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return DataOfStack.GetHead().DataOfNode;
    }

    /// <summary>
    /// Kiểm tra xem Stack có rỗng không.
    /// </summary>
    public bool IsEmpty()
    {
        return DataOfStack.IsEmpty();
    }

    /// <summary>
    /// Trả về số lượng phần tử hiện tại trong Stack.
    /// </summary>
    public int Count => DataOfStack.Count();

    /// <summary>
    /// Đưa stack về trạng thái rỗng.
    /// </summary>
    public void Reset()
    {
        DataOfStack.Clear();
    }
}
