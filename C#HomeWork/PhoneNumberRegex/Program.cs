using Dumpify;
using System.Text.RegularExpressions;

Regex regex = new Regex(@"^\+[1-9]\d{1,11}$");
string[] testNumbers = new[]
{
    "+1234567890",    // Valid
    "+19876543210",   // Valid
    "+123",           // Invalid (too short)
    "1234567890",     // Invalid (missing '+')
    "+123456789012345" // Invalid (too long)
};

MatchCollection[] results = testNumbers
    .Select(number => regex.Matches(number))
    .ToArray();

foreach (MatchCollection result in results)
{
    result.Dump();
}