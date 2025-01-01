const int Bau = 1;
const int Cua = 2;
const int Tom = 3;
const int Ca = 4;
const int Ga = 5;
const int Huou = 6;

Console.WriteLine("Chon 1 loai cuoc: 1.Bau  2.Cua  3.Tom  4.Ca  5.Ga  6.Huou");
int yourChoice = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("So tien muon cuoc: ");
int yourBet = Convert.ToInt32(Console.ReadLine());

int computerChoice1 = Random.Shared.Next(1, 7);
int computerChoice2 = Random.Shared.Next(1, 7);
int computerChoice3 = Random.Shared.Next(1, 7);
Console.WriteLine($"May tinh chon: {computerChoice1}, {computerChoice2}, {computerChoice3}");

int count = 0;
if( yourChoice == computerChoice1 )
    count++;
if( yourChoice == computerChoice2 )
    count++;
if( yourChoice == computerChoice3 )
    count++;

if (count >0)
{
    count++;
    yourBet *= count;
    Console.WriteLine($"Ban thang {yourBet} tien cuoc");
}
else
{
    Console.WriteLine("Ban xui roi....");
}



