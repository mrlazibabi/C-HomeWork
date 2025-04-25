/// <summary>
/// Logic queue, thêm vào cuối bốc ra đầu
/// </summary>
public class Queue : IQueue
{
    public LinkedList QueueData { get; set; }

    public Queue()
    {
        QueueData = new LinkedList();
    }

    public int Count => QueueData.Count();

    public void Enqueue(Customer customer)
    {
        if (QueueData.Count() > 0)
        {
            customer.Number = QueueData.Tail.DataOfNode.Number + 1;
        }
        else
        {
            customer.Number = 1;
        }

        Node newNode = new Node
        {
            DataOfNode = customer,
        };

        QueueData.InsertNodeToLast(newNode);
    }

    public Customer Dequeue()
    {
        if (QueueData.Count() == 0) return null;
        Node node = QueueData.GetFirstNodeAndRemove();
        return node.DataOfNode;
    }

    public Customer[] GetFirst3Node()
    {
        Node[] nextThreeNode = QueueData.GetFirstThreeNode();
        if (nextThreeNode == null) return null;

        Customer[] nextThreeCustomer = new Customer[nextThreeNode.Length];
        for (int i = 0; i < nextThreeNode.Length; i++)
        {
            nextThreeCustomer[i] = nextThreeNode[i].DataOfNode;
        }
        return nextThreeCustomer;
    }

    public Customer[] GetAllNode()
    {
        Node[] allNode = QueueData.GetAllNode();
        if (allNode == null) return null;

        Customer[] allCustomer = new Customer[allNode.Length];
        for (int i = 0; i < allNode.Length; i++)
        {
            allCustomer[i] = allNode[i].DataOfNode;
        }
        return allCustomer;
    }

    public decimal CalculatedMoneyInQueue()
    {
        return QueueData.TotalAmount();
    }
}
 