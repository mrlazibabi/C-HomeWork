LongestUniqueSubstringFinder finder = new LongestUniqueSubstringFinder();

string result1 = finder.LongestUniqueSubstring("abcabcbb");
Console.WriteLine(result1); // Output: abc

string result2 = finder.LongestUniqueSubstring("bbbbb");
Console.WriteLine(result2); // Output: b

string result3 = finder.LongestUniqueSubstring("pwwkew");
Console.WriteLine(result3); // Output: wke

string result4 = finder.LongestUniqueSubstring("dvdf");
Console.WriteLine(result4); // Output: vdf
try
{

}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}

class LongestUniqueSubstringFinder
{
    public string LongestUniqueSubstring(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("input must not be null");
        }

        string longestSubstring = string.Empty;
        string currentSubstring = string.Empty;

        foreach (char character in input)
        {
            int index = currentSubstring.IndexOf(character);
            if (index != -1)
            {
                currentSubstring = currentSubstring.Substring(index + 1);
            }

            currentSubstring += character;

            if (currentSubstring.Length > longestSubstring.Length)
            {
                longestSubstring = currentSubstring;
            }
        }

        return longestSubstring;
    }
}