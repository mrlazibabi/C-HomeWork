Console.OutputEncoding = System.Text.Encoding.UTF8;

bool isActive = true;
GameData data = FileManager.LoadData();

while (isActive)
{
    Console.WriteLine("\n==== Trò Chơi Đoán Số ====");
    Console.WriteLine("1. Bắt đầu chơi");
    Console.WriteLine("2. Xem kỷ lục");
    Console.WriteLine("3. Thoát");
    Console.Write("Hãy chọn một chức năng từ menu bằng cách nhập số tương ứng: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            PlayGame(data);
            break;
        case "2":
            ShowRecords(data);
            break;
        case "3":
            isActive = false;
            Console.WriteLine("Cảm ơn bạn đã chơi! Hẹn gặp lại.");
            break;
        default:
            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại.");
            break;
    }
}

void PlayGame(GameData data)
{
    Console.Write("Nhập tên của bạn: ");
    string playerName = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(playerName))
    {
        Console.WriteLine("Tên không hợp lệ");
        return;
    }

    int targetNumber = Random.Shared.Next(1, 11);
    int attempts = 0;
    int guess = 0;

    do
    {
        Console.Write("Nhập một số từ 1 đến 10: ");
        bool isValid = int.TryParse(Console.ReadLine(), out guess);

        if (isValid && guess >= 1 && guess <= 10)
        {
            attempts++;

            if (guess < targetNumber)
            {
                Console.WriteLine("Số cần tìm lớn hơn số của bạn.");
            }
            else if (guess > targetNumber)
            {
                Console.WriteLine("Số cần tìm bé hơn số của bạn.");
            }

        }
        else
        {
            Console.WriteLine("Vui lòng nhập một số hợp lệ!");
        }

    } while (guess != targetNumber);

    Console.WriteLine($"Chúc mừng {playerName}, bạn đã đoán đúng sau {attempts} lần!");

    data.AddHistory(new Record(playerName, attempts));

    if (data.record == null || attempts < data.record.attempts)
    {
        data.record = new Record(playerName, attempts);
        Console.WriteLine($"Bạn đã lập kỷ lục mới với {attempts} lần đoán!");
    }

    FileManager.SaveData(data);
}

void ShowRecords(GameData data)
{
    Console.WriteLine("\n===== Kỷ Lục Hiện Tại =====");
    if (data.record == null)
    {
        Console.WriteLine("Chưa có kỷ lục nào được lưu.");
    }
    else
    {
        Console.WriteLine($"Kỷ lục: {data.record.name} - {data.record.attempts} lần đoán.");
    }

    Console.WriteLine("\n===== Lịch Sử Các Lần Chơi =====");
    if (data.history.Length == 0)
    {
        Console.WriteLine("Chưa có lịch sử chơi.");
    }
    else
    {
        foreach (Record entry in data.history)
        {
            Console.WriteLine($"{entry.name} - {entry.attempts} lần đoán");
        }
    }
}
