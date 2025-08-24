using System.Text.RegularExpressions;

Regex regex = new Regex(@"^(http|https|ftp)://[a-z0-9-]+(\.[a-z0-9-]+)+(/([a-z0-9-_.]+(/[a-z0-9-_.]+)*)?)?$", RegexOptions.IgnoreCase);
string[] testUrls = new[]
{
            "https://example.com/home",
            "ftp://files.server.net/downloads/file.txt",
            "htt://example.com",
            "https:/example.com"
        };

foreach (string url in testUrls)
{
    bool isMatch = regex.IsMatch(url);
    Console.WriteLine($"URL: {url} - Match: {isMatch}");
}