using DeveloperBank;
using DeveloperBankCore;
using System.Text.Json;

/// <summary>
/// class này dùng để hiển thị và điều hướng yêu cầu của người dùng
/// </summary>
public class BankController
{
    private BankUIConsole bankUIConsole;

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
        Console.WriteLine("6. Tìm giao dịch theo số giao dịch");
        Console.WriteLine("7. Thoát chương trình");
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
                    Console.Clear();
                    bankUIConsole.InputCustomerAndAddToTheQueue();
                    break;
                case "2":
                    Console.Clear();
                    bankUIConsole.DisplayNextVIPCustomer();
                    break;
                case "3":
                    Console.Clear();
                    bankUIConsole.DisplayNextEconomyCustomer();
                    break;
                case "4":
                    Console.Clear();
                    bankUIConsole.DisplayNextReadyCustomer();
                    break;
                case "5":
                    Console.Clear();
                    bankUIConsole.DisplayReport();
                    break;
                case "6":
                    Console.Clear();
                    bankUIConsole.SearchTransaction();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập một lựa chọn hợp lệ.");
                    break;
            }

            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public void LoadFiles()
    {
        bankUIConsole.LoadFiles();
    }
}

