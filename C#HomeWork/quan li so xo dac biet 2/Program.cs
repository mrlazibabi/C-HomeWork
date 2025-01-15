Console.OutputEncoding = System.Text.Encoding.UTF8;
LotteryMenu menu = new LotteryMenu();
menu.Menu();

class LotteryMenu
{
    public void Menu()
    {
        LotteryManagerUI manager = new LotteryManagerUI();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Xem tập hợp số đã được lưu.");
            Console.WriteLine("2. Thêm một số mới vào tập hợp.");
            Console.WriteLine("3. Thoát chương trình.");
            Console.Write("Chọn một tùy chọn: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.DisplayNumbers();
                    break;
                case "2":
                    manager.InputNewNumber();
                    break;
                case "3":
                    running = false;
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }
}

public class LotteryManagerUI
{
    public LotteryManager lotteryManager = new LotteryManager();

    public void DisplayNumbers()
    {
        int[] winningNumbers = lotteryManager.GetWinningNumbers();

        if (winningNumbers.Length == 0)
        {
            Console.WriteLine("Danh sách trúng giải hiện đang trống!");
        }
        else
        {
            Console.WriteLine("Các số trúng giải đã lưu:");
            foreach (int number in winningNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }

    public void InputNewNumber()
    {
        Console.Write("Hãy nhập số bạn muốn thêm: ");
        if (int.TryParse(Console.ReadLine(), out int newNumber))
        {
            lotteryManager.AddNumber(newNumber);
        }
        else
        {
            Console.WriteLine("Số không hợp lệ. Vui lòng nhập lại.");
        }
    }
}

public class LotteryManager
{
    public int[] winningNumbers = new int[0];

    public int[] GetWinningNumbers()
    {
        return winningNumbers;
    }

    public void AddNumber(int number)
    {
        foreach (int newNumber in winningNumbers)
        {
            if (newNumber == number)
            {
                Console.WriteLine("Số này đã tồn tại trong danh sách!");
                return;
            }
        }

        Array.Resize(ref winningNumbers, winningNumbers.Length + 1);
        winningNumbers[winningNumbers.Length - 1] = number;

        Console.WriteLine($"Đã thêm số {number} vào danh sách.");
    }
}