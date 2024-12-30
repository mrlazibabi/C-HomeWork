Console.WriteLine("Lua chon 1 trong 3 lua chon sau: keo = 1, bua = 2, bao = 3");
Console.WriteLine("Nguoi choi lua chon: ");
int playerChoice = Convert.ToInt32(Console.ReadLine());

int computerChoice = Random.Shared.Next(1, 4);
Console.WriteLine("Computer choice: "+computerChoice);

if (playerChoice == 1 && computerChoice == 2)
{
    Console.WriteLine("Computer win!");
}
else if (playerChoice == 1 && computerChoice == 3)
{
    Console.WriteLine("You win!");
}
else if (playerChoice == 2 && computerChoice == 1)
{
    Console.WriteLine("You win!");
}
else if (playerChoice == 2 && computerChoice == 3)
{
    Console.WriteLine("Computer win!");
}
else if (playerChoice == 3 && computerChoice == 1)
{
    Console.WriteLine("Computer win!");
}
else if (playerChoice == 3 && computerChoice == 2)
{
    Console.WriteLine("You win!");
}
else if(playerChoice == computerChoice)
{
    Console.WriteLine("Draw");
}
else
{
    Console.WriteLine("Lam gi co vat nao dung cho so ban chon ???");
}