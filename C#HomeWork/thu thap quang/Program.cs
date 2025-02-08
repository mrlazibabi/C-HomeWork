Console.OutputEncoding = System.Text.Encoding.UTF8;

try
{
    Console.WriteLine("Hãy nhập số quặng đã đào được: ");
    int totalOres = int.Parse(Console.ReadLine());

    MineGold mineGold = new MineGold();
    int coins = mineGold.CalculatedGold(totalOres);
    Console.WriteLine("Tổng số xu vàng thu được: " + coins);
}
catch(FormatException)
{
    Console.WriteLine("Số quặng đã nhập không hợp lệ.");
}
catch (ArgumentException)
{
    Console.WriteLine("Số quặng phải lớn hơn 0!");
}
catch(Exception ex) {  Console.WriteLine(ex.ToString()); }


public class MineGold()
{
   public int CalculatedGold(int totalOres)
    {
        if (totalOres <= 0)
        {
            throw new ArgumentException();
        }

        int coins = 0;

        int ores = Math.Min(totalOres, 10);
        coins += ores * 10;
        totalOres -= ores;

        ores = Math.Min(totalOres, 5);
        coins += ores * 5;
        totalOres -= ores;

        ores = Math.Min(totalOres, 3);
        coins += ores * 2;
        totalOres -= ores;

        coins += totalOres * 1;

        return coins;
    }
}
