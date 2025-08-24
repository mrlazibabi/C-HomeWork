using Dumpify;
using System.Text.RegularExpressions;

Regex regex = new Regex(@"^\+[1-9]\d{9,11}$");
string[] testNumbers = new[]
{
    "+1234567890",    // Valid
    "+19876543210",   // Valid
    "+123",           // Invalid (too short)
    "1234567890",     // Invalid (missing '+')
    "+123456789012345" // Invalid (too long)
};

foreach (string numebr in testNumbers)
{
    bool isValid = regex.IsMatch(numebr);
    Console.WriteLine(new { numebr, isValid }.Dump());
}