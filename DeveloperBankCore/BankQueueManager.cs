/// <summary>
/// Sử lý logic của chương trình
/// </summary>
public class BankQueueManager
{
    /// <summary>
    /// Hằng đợi khách hàng thường
    /// </summary>
    public Queue EconomyQueue { get; set; }

    /// <summary>
    /// Hằng đợi của khách hàng VIP
    /// </summary>
    public Queue VIPQueue { get; set; }

    /// <summary>
    /// Danh sách khách hàng rút tiền thành công
    /// </summary>
    public LinkedList CustomerSuccessCashOut { get; set; }

    public int VIPQueueCount => VIPQueue.Count;
    public int EconomyQueueCount => EconomyQueue.Count;

    public BankQueueManager()
    {
        EconomyQueue = new Queue();
        VIPQueue = new Queue();
    }

    /// <summary>
    /// 1.Thêm khách hàng mới vào hàng đợi.
    /// </summary>
    /// <param name="customer"></param>
    public void AddCustomerToTheQueue(Customer customer)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 2.Gọi tên khách hàng kế tiếp (VIP)
    /// </summary>
    /// <returns></returns>
    public Customer GetNextVIPCustomer()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 3.Gọi tên khách hàng kế tiếp (Thường).
    /// </summary>
    /// <returns></returns>
    public Customer GetNextEconomyCustomer()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 4. Lấy ra danh sách Khách hàng sắp tới.
    /// </summary>
    public NextReadyCustomer GetNextReadyCustomer()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 5.Thống kê về hệ thống
    /// </summary>
    public ReportBank CaculationReport()
    {
        throw new NotImplementedException();
    }
}

