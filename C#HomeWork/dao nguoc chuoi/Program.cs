
try
{
    StringReverser reverser = new StringReverser();

    string result1 = reverser.Reverse("123456");
    Console.WriteLine(result1); // 654321

    string result2 = reverser.Reverse("OpenAI");
    Console.WriteLine(result2); // IAnepO

    string result5 = reverser.Reverse("");
    Console.WriteLine(result5); // (chuỗi rỗng)

    string result6 = reverser.Reverse(null); // ArgumentNullException 
}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}


class StringReverser
{
    public string Reverse(string input)
    {
        if(input == null)
        {
            throw new ArgumentNullException("Day la 1 chuoi null");
        }
        
        string reverse = string.Empty;
        for(int i = input.Length-1; i >= 0; i--)
        {
            reverse += input[i];    
        }

        return reverse;
    }
}