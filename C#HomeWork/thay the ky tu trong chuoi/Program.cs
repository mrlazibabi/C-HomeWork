


try
{
    CharacterReplacer replacer = new CharacterReplacer();

    string result1 = replacer.ReplaceCharacters("hello", 'l', 'x');
    Console.WriteLine(result1); // Output: hexxo

    string result2 = replacer.ReplaceCharacters("banana", 'a', 'o');
    Console.WriteLine(result2); // Output: bonono

    string result3 = replacer.ReplaceCharacters("Mississippi", 'i', 'a');
    Console.WriteLine(result3); // Output: Massassappa

    string result4 = replacer.ReplaceCharacters("abc", 'd', 'e');
    Console.WriteLine(result4); // Output: abc (no change)
}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}
class CharacterReplacer
{
    public string ReplaceCharacters(string input, char oldChar, char newChar)
    {
        if (input == null)
        {
            throw new ArgumentNullException("input must not be null");
        }

        //return input.Replace(oldChar, newChar);

        char[] chars = input.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if(chars[i] == oldChar)
            {
                chars[i] = newChar;
            }
        }
        return new string(chars);
    }
}