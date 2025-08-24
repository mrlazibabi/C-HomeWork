using System.Text.RegularExpressions;

Regex regex = new Regex(@"^Product: ([a-zA-Z0-9\- ]+), Code: ([A-Z]+\d+), Price: (\$\d+(?:\.\d{2})?)$", RegexOptions.IgnoreCase);
string[] testProducts = new[]
{
            "Product: Laptop Dell XPS 15, Code: DL12345, Price: $1599.99",
            "Product: iPhone 15 Pro Max, Code: IP5678, Price: $1199",
            "Product: MacBook Air, Price: $999",
            "Product: Tablet, Code: TAB001"
        };

foreach (string product in testProducts)
{
    bool isMatch = regex.IsMatch(product);
    Console.WriteLine($"S: {product} - Match: {isMatch}");
}