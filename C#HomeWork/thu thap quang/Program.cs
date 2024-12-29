Console.WriteLine("Hay nhap so quang da dao duoc: ");   
int totalOres = Convert.ToInt32(Console.ReadLine());
int coins = 0;

int ores = Math.Min(totalOres, 10);
coins += ores*10;       
totalOres -= ores;

ores = Math.Min(totalOres, 5);
coins += ores*5;      
totalOres -= ores;               

ores = Math.Min(totalOres, 3);
coins += ores*2;     
totalOres -= ores;

coins += totalOres*1;         

Console.WriteLine("Tong so xu vang thu duoc: " + coins);
