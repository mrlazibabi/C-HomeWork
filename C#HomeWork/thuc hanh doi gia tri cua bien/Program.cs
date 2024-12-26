Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Hãy nhập giá trị đầu tiên: ");
int value1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Hãy nhập giá trị thứ hai: ");
int value2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\nĐang thực hiện đổi thứ tự giữa 2 giá trị.....");
int temp;
temp = value1;
value1 = value2;
value2 = temp;

Console.WriteLine("\nĐây là sau khi đã đổi thứ tự giữa 2 giá trị: ");
Console.WriteLine("Giá trị value1 sau khi đổi: " + value1);
Console.WriteLine("Giá trị value2 sau khi đổi: " + value2);
