
try
{
    DuplicateRemover remover = new DuplicateRemover();

    string result1 = remover.RemoveDuplicates("helloo ol");
    Console.WriteLine(result1); // 'helo '

    string result2 = remover.RemoveDuplicates("programming");
    Console.WriteLine(result2); // progamin

    string result3 = remover.RemoveDuplicates("OpenAI");
    Console.WriteLine(result3); // OpenAI

    string result6 = remover.RemoveDuplicates(null); // ArgumentNullException 
}
catch(Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}    

class DuplicateRemover
{
    public string RemoveDuplicates(string input)
    {
        if(input == null)
        {
            throw new ArgumentNullException("input must not be null");       
        }

        string newString = string.Empty;
        for(int i = 0; i < input.Length; i++)
        {
            if(!newString.Contains(input[i]))
            {
                newString += input[i];
            }
        }
        return newString;
    }
}
