using DeveloperBank;

/// <summary>
/// class này dùng để hiển thị và điều hướng yêu cầu của người dùng
/// </summary>
public class BankController
{
    public BankUIConsole bankUIConsole { get; set; }

    public BankController()
    {
        bankUIConsole = new BankUIConsole();
    }

    public void DisplayMenu()
    {
        Console.WriteLine("----------- Quản lý Hàng đợi Ngân hàng -----------");
        Console.WriteLine("1. Thêm khách hàng vào hàng đợi");
        Console.WriteLine("2. Gọi tên khách hàng VIP tiếp theo");
        Console.WriteLine("3. Gọi tên khách hàng Thường tiếp theo");
        Console.WriteLine("4. Hiển thị khách hàng sắp tới");
        Console.WriteLine("5. Thống kê");
        Console.WriteLine("6. Thoát chương trình");
        Console.Write("Nhập lựa chọn của bạn: ");
    }

    public void Start()
    {
        while (true)
        {
            DisplayMenu();

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    bankUIConsole.InputCustomerAndAddToTheQueue();
                    break;
                case "2":
                    bankUIConsole.DisplayNextVIPCustomer();
                    break;
                case "3":
                    bankUIConsole.DisplayNextEconomyCustomer();
                    break;
                case "4":
                    bankUIConsole.DisplayNextReadyCustomer();
                    break;
                case "5":
                    bankUIConsole.DisplayReport();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập một lựa chọn hợp lệ.");
                    break;
            }

            Console.WriteLine();
        }
    }

}

