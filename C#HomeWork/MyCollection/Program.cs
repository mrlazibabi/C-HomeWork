using System;

class Program
{
    static void Main()
    {
        // Tạo một MyCollection
        MyCollection<string> collection = new MyCollection<string>();

        // Thêm phần tử
        collection.Add("Manago");
        collection.Add("Apple");
        collection.Add("Banana");
        Console.WriteLine($"Count: {collection.Count}"); // Expected: 3
        Console.WriteLine($"Contains Apple: {collection.Contains("Apple")}"); // Expected: True

        // Sử dụng foreach để duyệt
        Console.WriteLine("Items:");
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }

        // Xóa phần tử
        Console.WriteLine($"Remove Apple: {collection.Remove("Apple")}"); // Expected: True
        Console.WriteLine($"Count after Remove: {collection.Count}"); // Expected: 2

        // Copy to array
        string[] array = new string[2];
        collection.CopyTo(array, 0);
        Console.WriteLine($"Copied array: {string.Join(", ", array)}"); // Expected: Manago, Banana

        // Clear
        collection.Clear();
        Console.WriteLine($"Count after Clear: {collection.Count}"); // Expected: 0
    }
}