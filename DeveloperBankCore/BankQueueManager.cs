using DeveloperBankCore;

using System.Text.Json;

/// <summary>
/// Sử lý logic của chương trình
/// </summary>
public class BankQueueManager
{
    //private const string DATA_DIRECTORY = "Data";
    private const string ECO_FILE_PATH_JSON = @".\EcoQueue.json";
    private const string VIP_FILE_PATH_JSON = @".\VIPQueue.json"; 
    private const string REPORT_FILE_PATH_JSON = @".\Report.json";

    private JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };

    public Queue EconomyQueue { get; private set; }
    public Queue VIPQueue { get; private set; }
    public Queue CashOutSuccessQueue { get; private set; }
    public BinarySearchTree CashOutSuccessTree { get; private set; }

    public int VIPQueueCount => VIPQueue.Count;
    public int EconomyQueueCount => EconomyQueue.Count;
    public int CashOutSuccessQueueCount => CashOutSuccessQueue.Count;

    public BankQueueManager()
    {
        EconomyQueue = new Queue();
        VIPQueue = new Queue();
        CashOutSuccessQueue = new Queue();
        CashOutSuccessTree = new BinarySearchTree();
    }

    public void AddCustomerToTheQueue(Customer customer)
    {
        if (customer.WithDrawalAmount >= 500)
        {
            VIPQueue.Enqueue(customer);
            SaveCustomersToFile(VIP_FILE_PATH_JSON, QueueToCustomers(VIPQueue));
        }
        else
        {
            EconomyQueue.Enqueue(customer);
            SaveCustomersToFile(ECO_FILE_PATH_JSON, QueueToCustomers(EconomyQueue));
        }
    }

    public Customer GetNextVIPCustomer()
    {
        Customer customer = VIPQueue.Dequeue();
        SaveCustomersToFile(VIP_FILE_PATH_JSON, QueueToCustomers(VIPQueue));
        if (customer != null)
        {
            customer.TransactionNumber = GenerateTransactionNumber();
            CashOutSuccessQueue.Enqueue(customer);
            CashOutSuccessTree.Insert(customer);
        }
        return customer;
    }

    public Customer GetNextEconomyCustomer()
    {
        Customer customer = EconomyQueue.Dequeue();
        SaveCustomersToFile(ECO_FILE_PATH_JSON, QueueToCustomers(EconomyQueue));
        if (customer != null)
        {
            customer.TransactionNumber = GenerateTransactionNumber();
            CashOutSuccessQueue.Enqueue(customer);
            CashOutSuccessTree.Insert(customer);
        }
        return customer;
    }

    public NextReadyCustomer GetNextReadyCustomer()
    {
        return new NextReadyCustomer
        {
            VIPCustomers = VIPQueue.GetFirst3Node(),
            EconomyCustomers = EconomyQueue.GetFirst3Node(),
            VIPQueueCount = VIPQueue.Count,
            EconomyQueueCount = EconomyQueue.Count,
        };
    }

    public ReportBank CaculationReport()
    {
        ReportBank report = new ReportBank
        {
            CustomerCashOutSuccess = CashOutSuccessQueue.GetAllNode(),
            TotalAmountCashOut = CashOutSuccessQueue.CalculatedMoneyInQueue(),
            TotalAmountInQueue = VIPQueue.CalculatedMoneyInQueue() + EconomyQueue.CalculatedMoneyInQueue(),
        };

        SaveReportToFile(report);
        return report;
    }

    public void LoadFiles()
    {
        EconomyQueue = CustomersToQueue(JsonToCustomers(LoadFromFile(ECO_FILE_PATH_JSON)));
        VIPQueue = CustomersToQueue(JsonToCustomers(LoadFromFile(VIP_FILE_PATH_JSON)));
        CashOutSuccessQueue = CustomersToQueue(JsonToReportBank(LoadFromFile(REPORT_FILE_PATH_JSON))?.CustomerCashOutSuccess);
        CashOutSuccessTree = CustomersToTree(CashOutSuccessQueue.GetAllNode());
    }

    public Customer SearchCustomerByNumber(int num)
    {
        return CashOutSuccessTree.Search(num);
    }

    private static int transactionCounter = 0;
    private int GenerateTransactionNumber()
    {
        string datePart = DateTime.Now.ToString("ddMMy");
        transactionCounter++;
        return int.Parse(datePart + transactionCounter.ToString("D3"));
    }

    #region File IO
    private Customer[] QueueToCustomers(Queue queue)
    {
        if (queue == null || queue.Count == 0)
            return Array.Empty<Customer>();

        Customer[] customers = new Customer[queue.Count];
        Node current = queue.QueueData.Head;
        int index = 0;

        while (current != null)
        {
            customers[index] = current.DataOfNode;
            current = current.NextNode;
            index++;
        }
        return customers;
    }

    private Queue CustomersToQueue(Customer[] customers)
    {
        Queue queue = new Queue();
        if (customers == null || customers.Length == 0)
            return queue;

        foreach (Customer customer in customers)
        {
            queue.Enqueue(customer);
        }
        return queue;
    }

    private BinarySearchTree CustomersToTree(Customer[] customers)
    {
        BinarySearchTree bst = new BinarySearchTree();
        if (customers == null || customers.Length == 0)
            return bst;

        for (int i = 0; i < customers.Length; i++)
        {
            if (customers[i] != null)
                bst.Insert(customers[i]);
        }
        return bst;
    }

    private void SaveCustomersToFile(string filePathJson, Customer[] customers)
    {
        if (string.IsNullOrWhiteSpace(filePathJson))
            throw new ArgumentException("Tên file không hợp lệ", nameof(filePathJson));

        if (customers == null)
            throw new ArgumentNullException("Không có ai trong hàng chờ", nameof(customers));

        try
        {
            string json = JsonSerializer.Serialize(customers, serializerOptions);
            File.WriteAllText(filePathJson, json);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Lỗi lưu file: {ex.Message}");
        }
    }

    private void SaveReportToFile(ReportBank report)
    {
        if (string.IsNullOrWhiteSpace(REPORT_FILE_PATH_JSON))
            throw new ArgumentException("File rỗng: ", nameof(REPORT_FILE_PATH_JSON));

        if (report == null)
            throw new ArgumentNullException(nameof(report), "Report rỗng");

        try
        {
            string json = JsonSerializer.Serialize(report, serializerOptions);
            File.WriteAllText(REPORT_FILE_PATH_JSON, json);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Lỗi lưu file: {ex.Message}");
        }
    }

    private string LoadFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                return string.Empty;
            }
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
            return string.Empty;
        }
    }

    private Customer[] JsonToCustomers(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return Array.Empty<Customer>();

        try
        {
            return JsonSerializer.Deserialize<Customer[]>(json, serializerOptions) ?? Array.Empty<Customer>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Lỗi JSON Deserialization: {ex.Message}");
            return Array.Empty<Customer>();
        }
    }

    private ReportBank JsonToReportBank(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return null;

        try
        {
            return JsonSerializer.Deserialize<ReportBank>(json, serializerOptions);
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Lỗi JSON Deserialization: {ex.Message}");
            return null;
        }
    }
    #endregion
}

