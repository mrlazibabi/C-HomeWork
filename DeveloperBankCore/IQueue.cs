public interface IQueue
{
    int Count { get; }
    LinkedList QueueData { get; set; }

    decimal CalculatedMoneyInQueue();
    Customer Dequeue();
    void Enqueue(Customer customer);
    Customer[] GetAllNode();
    Customer[] GetFirst3Node();
}