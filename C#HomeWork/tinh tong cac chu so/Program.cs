int number;

do
{
    Console.Write("Hay nhap mot so nguyen duong: ");
    number = Convert.ToInt32(Console.ReadLine());

    int sum = 0;
    int temp = number;

    while (temp > 0)
    {
        //lay chu so cuoi cung roi cong vao sum
        sum += temp % 10; 

        //bo chu so cuoi cung
        temp /= 10;       
    }

    Console.WriteLine($"Tong cac chu so cua {number} la: {sum}");
    break; 
} while (true);
