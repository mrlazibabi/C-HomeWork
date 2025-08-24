using System.Text.RegularExpressions;

Regex regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$");
string[] testEmails = new[]
{
  "john.doe@gmail.com",
  "user_123@company.co.uk",
  "@invalid-email",
   "no-at-symbol.com",
};

foreach (string email in testEmails)
{
    bool isValid = regex.IsMatch(email);
    Console.WriteLine($"Email: {email}, Valid: {isValid}");
}