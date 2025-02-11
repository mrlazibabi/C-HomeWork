

try
{
    CharacterCounter counter = new CharacterCounter();

    int count1 = counter.CountOccurrences("hello", 'l');
    Console.WriteLine(count1); // 2

    int count2 = counter.CountOccurrences("banana", 'a');
    Console.WriteLine(count2); // 3

    int count3 = counter.CountOccurrences("Mississippi", 's');
    Console.WriteLine(count3); // 4

    int count4 = counter.CountOccurrences("", 'a');
    Console.WriteLine(count4); // 0
}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}

class CharacterCounter
{
    public int CountOccurrences(string input, char character)
    {
        if(input == null)
        {
            throw new ArgumentNullException("input must not be null");
        }

        int count = 0;
        for(int i = 0; i < input.Length; i++)
        {
            if (character == input[i])
            {
                count++;
            }
        }
        return count;
    }
}