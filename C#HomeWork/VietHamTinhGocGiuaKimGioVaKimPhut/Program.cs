Clock clock = new Clock();

try
{
    Console.WriteLine(clock.CalculateAngleBetweenClockHands(2, 30));
    Console.WriteLine(clock.CalculateAngleBetweenClockHands(23,55));
    Console.WriteLine(clock.CalculateAngleBetweenClockHands(8, 15));
}
catch (Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}
public class Clock
{
    public double CalculateAngleBetweenClockHands(int hour, int minute)
    {
        if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
        {
            throw new ArgumentException("Hour or Minute is Invalid!");
        }

        // Chuyển giờ về phạm vi 0-11 (đồng hồ 12 giờ)
        if (hour >= 12)
        {
            hour -= 12;
        }

        
        double minuteAngle = minute * 6;// Mỗi phút kim phút quay 6 độ (360 độ / 60 phút)
        double hourAngle = (hour * 30) + (minute * 0.5); // Mỗi giờ kim giờ quay 30 độ (360 độ / 12 giờ) + di chuyển thêm 0.5 độ mỗi phút

        double angle = Math.Abs(hourAngle - minuteAngle);

        // Lấy góc nhỏ hơn 
        return Math.Min(angle, 360 - angle);
    }
}