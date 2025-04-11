namespace DeveloperBank
{
    /// <summary>
    /// Class này dùng để người dùng tương tác với dữ liệu và gửi yêu cầu tới BankQueueManager nơi xử lý logic
    /// </summary>
    public class BankUIConsole
    {
        private BankQueueManager bankQueueManager;

        public BankUIConsole()
        {
            bankQueueManager = new BankQueueManager();
        }

        public void InputCustomerAndAddToTheQueue() 
        {
            Console.WriteLine("=== Thêm khách hàng vào hàng đợi ===");
            Console.WriteLine("Nhập thông tin khách hàng:\n");

            Customer customer = new Customer();
            Console.Write("Tên: ");
            customer.FullName = GetValidStringInput();
            Console.Write("Số tiền cần rút: ");
            customer.WithDrawalAmount = GetValidDecimalInput();

            bankQueueManager.AddCustomerToTheQueue(customer);

            if (customer.WithDrawalAmount >= 500)
            {
                Console.WriteLine($"\nKhách hàng {customer.FullName} đã được thêm vào hàng đợi VIP");
                Console.WriteLine($"Số thứ tự là: {bankQueueManager.VIPQueue.QueueData.Tail.DataOfNode.Number}");
            }
            else
            {
                Console.WriteLine($"\nKhách hàng {customer.FullName} đã được thêm vào hàng đợi Thường");
                Console.WriteLine($"Số thứ tự là: {bankQueueManager.EconomyQueue.QueueData.Tail.DataOfNode.Number}");
            }
        }

        public void DisplayNextVIPCustomer()
        {
            Console.WriteLine("=== Gọi tên khách hàng kế tiếp (VIP) ===");
            Customer vipCustomer = bankQueueManager.GetNextVIPCustomer();
            if (vipCustomer == null)
            {
                Console.WriteLine("Không có khách hàng VIP nào trong hàng đợi.\n");
                return;
            }

            Console.WriteLine("Đến lượt khách hàng VIP: \n");
            Console.WriteLine($"Số thứ tự: {vipCustomer.Number}");
            Console.WriteLine($"Tên: {vipCustomer.FullName}");
            Console.WriteLine($"Số tiền cần rút: {vipCustomer.WithDrawalAmount}");
            Console.WriteLine($"\nĐã rút thành công số tiền: {vipCustomer.WithDrawalAmount} VND");
        }

        public void DisplayNextEconomyCustomer()
        {
            Console.WriteLine("=== Gọi tên khách hàng kế tiếp (Thường) ===");
            Customer economyCustomer = bankQueueManager.GetNextEconomyCustomer();
            if (economyCustomer == null)
            {
                Console.WriteLine("Không có khách hàng thường nào trong hàng đợi.\n");
                return;
            }

            Console.WriteLine("Đến lượt khách hàng Thường: \n");
            Console.WriteLine($"Số thứ tự: {economyCustomer.Number}");
            Console.WriteLine($"Tên: {economyCustomer.FullName}");
            Console.WriteLine($"Số tiền cần rút: {economyCustomer.WithDrawalAmount}");
            Console.WriteLine($"\nĐã rút thành công số tiền: {economyCustomer.WithDrawalAmount} VND");
        }

        public void DisplayNextReadyCustomer()
        {
            Console.WriteLine("=== Danh Sách Khách hàng sắp tới ===\n");
            NextReadyCustomer readyCustomer = bankQueueManager.GetNextReadyCustomer();

            Console.WriteLine("Hàng đợi VIP:\n");
            if (readyCustomer.VIPCustomers == null)
            {
                Console.WriteLine("Hiện tại không có VIP\n");
            }
            else
            {
                for (int i = 0; i < readyCustomer.VIPCustomers.Length; i++)
                {
                    if (readyCustomer.VIPCustomers[i] == null) continue;
                    Console.WriteLine($"{i + 1}. VIP{readyCustomer.VIPCustomers[i].Number} " +
                        $"- {readyCustomer.VIPCustomers[i].FullName}");
                }
            }

            Console.WriteLine("\nHàng đợi Thường:\n");
            if (readyCustomer.EconomyCustomers == null)
            {
                Console.WriteLine("Hiện tại không có Thường\n");
            }
            else
            {
                for (int i = 0; i < readyCustomer.EconomyCustomers.Length; i++)
                {
                    if (readyCustomer.EconomyCustomers[i] == null) continue;
                    Console.WriteLine($"{i + 1}. Eco{readyCustomer.EconomyCustomers[i].Number} " +
                        $"- {readyCustomer.EconomyCustomers[i].FullName}");
                }
            }

            if (readyCustomer.VIPQueueCount > 0)
            {
                Console.WriteLine($"\nTổng số khách VIP đang chờ: {readyCustomer.VIPQueueCount}");
            }
            if (readyCustomer.EconomyQueueCount > 0)
            {
                Console.WriteLine($"Tổng số khách thường đang chờ: {readyCustomer.EconomyQueueCount}");
            }
        }

        public void DisplayReport()
        {
            Console.WriteLine("=== Thống kê ===");
            ReportBank report = bankQueueManager.CaculationReport();

            Console.WriteLine("1. Danh sách khách đã rút:");
            if (report.CustomerCashOutSuccess != null)
            {
                for (int i = 0; i < report.CustomerCashOutSuccess.Length; i++)
                {
                    Customer customer = report.CustomerCashOutSuccess[i];
                    if (customer == null) continue;
                    string customerType = customer.WithDrawalAmount >= 500 ? "VIP" : "ECO";
                    Console.WriteLine($"\t{i + 1}. " +
                        $"{customerType}{customer.Number} - {customer.FullName} " +
                        $"- {customer.TransactionNumber} VND");
                }
            }

            Console.WriteLine($"\n2. Tổng tiền đã rút: {report.TotalAmountCashOut}");
            Console.WriteLine($"3. Tổng tiền trong hàng chờ: {report.TotalAmountInQueue}");
        }

        public void SearchTransaction()
        {
            Console.WriteLine("=== Tìm giao dịch ===");
            Console.Write("Số giao dịch: ");
            int transactionNum = GetValidIntInput();

            Customer result = bankQueueManager.SearchCustomerByNumber(transactionNum);
            if (result != null)
            {
                Console.WriteLine($"\nKhách hàng: {result.FullName} đã rút {result.WithDrawalAmount} VND");
            }
            else
            {
                Console.WriteLine($"\nSố giao dịch không tồn tại");
            }
        }

        public void LoadFiles()
        {
            Console.WriteLine("Đang lấy local files...");
            bankQueueManager.LoadFiles();
            Console.WriteLine("Tải thành công...");
            Console.WriteLine("Chương trình bắt đầu...");
        }

        #region Helper Methods
        private int GetValidIntInput()
        {
            int result;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Dữ liệu không hợp lệ, vui lòng nhập số nguyên.");
            }
        }

        private string GetValidStringInput()
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Dữ liệu không hợp lệ, vui lòng nhập lại.");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        private decimal GetValidDecimalInput()
        {
            decimal result;
            while (true)
            {
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out result) && result >= 0)
                {
                    return result;
                }
                Console.WriteLine("Dữ liệu không hợp lệ, vui lòng nhập số không âm.");
            }
        }
        #endregion
    }
}
