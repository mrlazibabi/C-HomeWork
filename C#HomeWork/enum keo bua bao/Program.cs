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

    RockPaperScissor game = new RockPaperScissor();
    string result = game.DetermineWinner(playerSelectedChoice, computerSelectedChoice);
    Console.WriteLine(result);
}
catch (Exception ex)
{
    Console.WriteLine($"Message: {ex.Message}"); ;
}

public enum Choice
{
    Scissor = 1,
    Rock,
    Paper
}

public class RockPaperScissor()
{
    public string DetermineWinner(Choice playerChoice, Choice computerChoice)
    {
        if (playerChoice <(Choice)1 || playerChoice>(Choice)3)
        {
            throw new ArgumentException("Invalid choice");
        }
        

        if (playerChoice == Choice.Paper)
        {
            return ("Draw");
        }
        else if(computerChoice == Choice.Paper && playerChoice == Choice.Scissor ||
           computerChoice == Choice.Rock && playerChoice == Choice.Paper ||
           computerChoice == Choice.Scissor && playerChoice == Choice.Rock)
        {
            return ("You Win");
        }
        else
        {
            return ("You lose");
        }
    }
}