namespace DeveloperBank
{
    /// <summary>
    /// Class này dùng để người dùng tương tác với dữ liệu và gửi yêu cầu tới BankQueueManager nơi xử lý logic
    /// </summary>
    public class BankUIManager
    {
        public BankQueueManager bankQueueManager;
        public BankUIManager()
        {
            bankQueueManager = new BankQueueManager();
        }

        public void InputCustomerAndAddToTheQueue()
        {
            Console.WriteLine("nhập dữ liệu từ người dùng");

            Customer customer = new Customer();

            bankQueueManager.AddCustomerToTheQueue(customer);
        }

        /// <summary>
        /// 2.Gọi tên khách hàng kế tiếp (VIP)
        /// </summary>
        /// <returns></returns>
        public void DisplayNextVIPCustomer()
        {
            Console.WriteLine("Gọi tên khách hàng kế tiếp (VIP)");
            Customer vipCustomer = bankQueueManager.GetNextVIPCustomer();

            // TODO: hiển thị thông tin khách hàng được gọi ra
        }

        /// <summary>
        /// 3.Gọi tên khách hàng kế tiếp (Thường).
        /// </summary>
        /// <returns></returns>
        public void DisplayNextEconomyCustomer()
        {
            Console.WriteLine("3.Gọi tên khách hàng kế tiếp (Thường).");
            Customer economy = bankQueueManager.GetNextEconomyCustomer();

            // TODO: hiển thị thông tin khách hàng được gọi ra
        }

        /// <summary>
        /// 4.Khách hàng sắp tới.
        /// </summary>
        public void DisplayNextReadyCustomer()
        {
            Console.WriteLine("4.Khách hàng sắp tới.");
            NextReadyCustomer readyCustomer = bankQueueManager.GetNextReadyCustomer();

            // TODO: hiển thị thông tin khách hàng chuẩn bị được gọi ra
        }

        /// <summary>
        /// 5.Thống kê
        /// </summary>
        public void DisplayReport()
        {
            Console.WriteLine("5.Thống kê");
            var report = bankQueueManager.CaculationReport();
            // TODO: hiển thị thông tin report
        }
    }
}
