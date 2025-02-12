

try
{
    AnagramChecker checker = new AnagramChecker();

    bool result1 = checker.AreAnagrams("listen", "silent");
    Console.WriteLine(result1); // true

    bool result2 = checker.AreAnagrams("hello", "world");
    Console.WriteLine(result2); // false

    bool result3 = checker.AreAnagrams("triangle", "integral");
    Console.WriteLine(result3); // true

    bool result4 = checker.AreAnagrams("night", "thing");
    Console.WriteLine(result4); // true
}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}


class AnagramChecker
{
    public bool AreAnagrams(string s1, string s2)
    {
        if(s1.Length != s2.Length)
        {
            return false;
        }

        char[] chars1 = s1.ToCharArray();
        char[] chars2 = s2.ToCharArray();

        Array.Sort(chars1);
        Array.Sort(chars2);

        return new string(chars1) == new string(chars2);
    }
}
