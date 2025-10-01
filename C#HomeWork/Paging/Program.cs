using Paging;
using System.Net.NetworkInformation;
Console.OutputEncoding = System.Text.Encoding.UTF8;
LearnPaging learnPaging = new LearnPaging();
int pageSize = 10;
int pageIndex = 0;
int totalPages = learnPaging.TotalPages(pageSize);

while (true)
{
    Console.Clear();
    Console.WriteLine("===== MENU =====");
    Console.WriteLine("1. Cài đặt số phần tử trong mỗi trang (mặc định 10)");
    Console.WriteLine("2. Chuyển đến trang kế tiếp");
    Console.WriteLine("3. Chuyển đến trang trước đó");
    Console.WriteLine("4. Thoát");
    Console.Write("Chọn: ");

    string choice = Console.ReadLine();
    switch (choice)
    {
        case"1":
            Console.Write("Nhập số phần tử trong mỗi trang: ");
            if (int.TryParse(Console.ReadLine(), out int newSize) && newSize > 0)
            {
                pageSize = newSize;
                pageIndex = 0; 
                totalPages = learnPaging.TotalPages(pageSize);
            }
            else
            {
                Console.WriteLine("Giá trị không hợp lệ. Nhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
            break;

        case"2":
            if (pageIndex < totalPages - 1)
            {
                pageIndex++;
            }
            break;

        case"3":
            if (pageIndex > 0)
            {
                pageIndex--;
            }
            break;

        case"4":
            return;
    }

    List<int> pageData = learnPaging.Paging(pageIndex, pageSize);
    Console.WriteLine($"\nTrang {pageIndex + 1}/{learnPaging.TotalPages(pageSize)}:");
    Console.WriteLine(string.Join(", ", pageData));
    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
    Console.ReadKey();
}
