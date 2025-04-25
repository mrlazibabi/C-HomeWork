using DeveloperBankCore;

public interface IBankQueueManager
{
    Queue CashOutSuccessQueue { get; }
    int CashOutSuccessQueueCount { get; }
    BinarySearchTree CashOutSuccessTree { get; }
    Queue EconomyQueue { get; }
    int EconomyQueueCount { get; }
    Queue VIPQueue { get; }
    int VIPQueueCount { get; }

    void AddCustomerToTheQueue(Customer customer);
    ReportBank CaculationReport();
    Customer GetNextEconomyCustomer();
    NextReadyCustomer GetNextReadyCustomer();
    Customer GetNextVIPCustomer();
    void LoadFiles();
    Customer SearchCustomerByNumber(int num);
}