using TuDienAnhViet;

Console.OutputEncoding = System.Text.Encoding.UTF8;
bool isWorking = true;
DictionaryUI dictionaryUI = new DictionaryUI();

while (isWorking)
{
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1 - Add");
    Console.WriteLine("2 - Search");
    Console.WriteLine("3 - Remove");
    Console.WriteLine("4 - List all words");
    Console.WriteLine("5 - Clear console");
    Console.WriteLine("Press any key to close");
    Console.Write("Your choice: ");

    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                dictionaryUI.Add();
                break;
            case 2:
                dictionaryUI.Search();
                break;
            case 3:
                dictionaryUI.Remove();
                break;
            case 4:
                dictionaryUI.GetDictionary();
                break;
            case 5:
                Console.Clear();
                break;
            default:
                isWorking = false;
                break;
        }
    }
    else
    {
        isWorking = false; // Thoát nếu nhập không phải số
    }
}