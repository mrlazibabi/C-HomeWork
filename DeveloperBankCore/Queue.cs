/// <summary>
/// Logic queue, thêm vào cuối bốc ra đầu
/// </summary>
public class Queue
{
    public LinkedList QueueData { get; set; }

    public Queue()
    {
        QueueData = new LinkedList(); // khởi tạo chỗ chứa dữ liệu queue
    }

    public int Count => QueueData.Count(); // số lượng khách hàng trong queue

    public void Enqueue(Customer customer)
    {
        // TODO: Thêm customer vào cuối hàng đợi.
        Node newNode = new Node
        {
            DataOfNode = customer,
        };

        QueueData.InsertNodeToLast(newNode);
    }

    public Customer Dequeue()
    {
        // TODO: Lấy và xóa khách hàng ở đầu hàng đợi.
        Node node = QueueData.GetFirstNodeAndRemove();
       
        throw new NotImplementedException();
    }


    public Customer[] GetFirst3Node()
    {
        // TODO: lấy ra 3 phần tử gần nhất trong queue
        Node[] nextThreeCustomer = QueueData.GetFirstThreeNode();
        throw new NotImplementedException();
    }

    public decimal CalculatedMoneyInQueue()
    {
        // TODO: Tổng tiền trong queue
        throw new NotImplementedException();
    }
}
