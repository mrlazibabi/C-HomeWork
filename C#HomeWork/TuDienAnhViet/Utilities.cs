using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TuDienAnhViet
{
    public class Utilities<T>
    {
        public static T ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new InvalidOperationException("Invalid path");

            if (!File.Exists(path))
            {
                // Tạo file trống nếu không tồn tại
                File.WriteAllText(path, JsonSerializer.Serialize(new Dictionary<string, string>(), new JsonSerializerOptions { WriteIndented = true }));
            }

            string jsonString = File.ReadAllText(path);
            if (string.IsNullOrEmpty(jsonString))
                throw new ArgumentNullException("Path contains empty file");

            return JsonSerializer.Deserialize<T>(jsonString) ?? throw new InvalidOperationException("Deserialization failed");
        }

        public static void WriteFile(string path, T value)
        {
            if (string.IsNullOrEmpty(path))
                throw new InvalidOperationException("Invalid path");

            string jsonString = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
        }
    }
}
