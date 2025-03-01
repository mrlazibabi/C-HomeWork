using PlayerChoice;

Console.OutputEncoding = System.Text.Encoding.UTF8;
try
{
    Console.WriteLine("Lua chon 1 trong 3 lua chon sau: keo = 1, bua = 2, bao = 3");

    int playerChoice = Convert.ToInt32(Console.ReadLine());
    Choice playerSelectedChoice = (Choice)playerChoice;
    Console.WriteLine($"Nguoi choi lua chon: {playerSelectedChoice}");

    int computerChoice = Random.Shared.Next(1, 4);
    Choice computerSelectedChoice = (Choice)computerChoice;
    Console.WriteLine($"Computer choice: {computerSelectedChoice}");

    KeoBuaBao game = new KeoBuaBao();
    string result = game.CheckResult(playerSelectedChoice, computerSelectedChoice);
    Console.WriteLine(result);
}
catch (Exception ex)
{
    Console.WriteLine($"Message: {ex.Message}"); ;
}

public class KeoBuaBao
{
    public string CheckResult(Choice player1Choice, Choice player2Choice)
    {
        if (!Enum.IsDefined(typeof(Choice), player1Choice) || !Enum.IsDefined(typeof(Choice), player2Choice))
        {
            throw new ArgumentException("Choice invalid");
        }

        if(player1Choice == player2Choice)
        {
            return "Draw";
        }
        if((player1Choice == Choice.Scissor && player2Choice == Choice.Rock)
        || (player1Choice == Choice.Rock && player2Choice == Choice.Paper)
        || (player1Choice == Choice.Paper && player2Choice == Choice.Scissor))
        {
            return "Player 2 Win";
        }
        else
        {
            return "Player 1 Win";
        }
    }
}