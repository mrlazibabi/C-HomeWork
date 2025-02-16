using System.Text.Json;

public static class FileManager
{
    public static string filePath = @"E:\Net 7\Csharp101\làm c#\C#HomeWork\game_data.txt";

    public static GameData LoadData()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Không tìm thấy tệp dữ liệu. Sẽ tạo dữ liệu mới.");
                return new GameData();
            }

            string json = File.ReadAllText(filePath);
            GameData data = JsonSerializer.Deserialize<GameData>(json);

            if (data == null)
            {
                Console.WriteLine("Dữ liệu trong tệp bị lỗi. Sẽ tạo dữ liệu mới.");
                return new GameData();
            }

            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc tệp: " + ex.Message);
            return new GameData(); 
        }
    }

    public static void SaveData(GameData data)
    {
        try
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi lưu tệp: " + ex.Message);
        }
    }
}
