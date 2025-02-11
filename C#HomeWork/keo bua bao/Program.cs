Console.OutputEncoding = System.Text.Encoding.UTF8;
try
{
    Console.WriteLine("Lua chon 1 trong 3 lua chon sau: keo = 1, bua = 2, bao = 3");
    Console.WriteLine("Nguoi choi lua chon: ");
    int playerChoice = Convert.ToInt32(Console.ReadLine());

    int computerChoice = Random.Shared.Next(1, 4);
    Console.WriteLine("Computer choice: " + computerChoice);

    Game game = new Game();
    string result =  game.KeoBuaBao(playerChoice, computerChoice);
    Console.WriteLine(result);
}
catch (Exception ex)
{
    Console.WriteLine($"Message: {ex.Message}"); ;
}


public class Game
{
    const int KEO = 1;
    const int BUA = 2;
    const int BAO = 3;

    public string KeoBuaBao(int playerChoice, int computerChoice)
    {
        if(playerChoice < 1 || playerChoice > 3)
        {
            throw new ArgumentException("Player Choice không hợp lệ.");
        }

        if(playerChoice == computerChoice)
        {
            return ("Draw!");
        }
        else if(playerChoice == BUA && computerChoice == KEO ||
                playerChoice == KEO && computerChoice == BAO ||
                playerChoice == BAO && computerChoice == BUA)
        {
            return ("PLayer Win!");
        }
        else
        {
            return("Computer win!");
        }
    }
}