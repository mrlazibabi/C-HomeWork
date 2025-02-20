using System.Text.Json;

public static class FileManager
{
    public static readonly string filePath = @"E:\Net 7\Csharp101\làm c#\C#HomeWork\game_data.txt";

    public static GameData LoadData()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Không tìm thấy tệp dữ liệu, tạo dữ liệu mới.");
                return new GameData();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("Tạo dữ liệu mới.");
                return new GameData();
            }

            GameData data = JsonSerializer.Deserialize<GameData>(json);
            
            if (data == null)
            {
                return new GameData();
            }
            else
            {
                return data;
            }
        }
        catch (JsonException)
        {
            Console.WriteLine("Dữ liệu trong tệp bị lỗi.");
            return new GameData();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
            return new GameData(); 
        }
    }

    public static void SaveData(GameData data)
    {
        try
        {
            string directory = Path.GetDirectoryName(filePath); //dam bao thu muc ton tai
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi lưu tệp: " + ex.Message);
        }
    }
}
