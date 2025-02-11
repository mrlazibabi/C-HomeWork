

try
{
    PalindromeChecker checker = new PalindromeChecker();

    bool result1 = checker.IsPalindrome("madam");
    Console.WriteLine(result1); // true

    bool result2 = checker.IsPalindrome("hello");
    Console.WriteLine(result2); // false

    bool result3 = checker.IsPalindrome("racecar");
    Console.WriteLine(result3); // true

    bool result6 = checker.IsPalindrome(null); // ArgumentNullException 
}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}

class PalindromeChecker
{
    public bool IsPalindrome(string input)
    {
        
        if (input == null)
        {
            throw new ArgumentNullException("input must not be null");
        }

        string reverse = string.Empty;
        for (int i = input.Length -1; i >=0; i--)
        {
            reverse += input[i];
        }

        bool result = false;
        string palindrome = input;
        if (reverse.Equals(palindrome))
        {
            result = true;
        }

        return result;   
    }
}