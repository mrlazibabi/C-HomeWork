using System.Security.Cryptography;

public class Authen
{
    private List<string> emails = new List<string>();
    private List<string> passwords = new List<string>();
    
    public bool Register(string eamil, string password)
    {
        if (emails.Contains(eamil))
        {
            return false; 
        }
        string salt = GenerateSalt();
        string hashedPassword = HashPassword(password, salt);
        emails.Add(eamil);
        passwords.Add(hashedPassword + ":" + salt); 
        return true;
    }

    public bool Login(string email, string password)
    {
        int index = emails.IndexOf(email);
        if (index == -1)
        {
            return false; 
        }
        string[] storedData = passwords[index].Split(':');
        string storedHash = storedData[0];
        string salt = storedData[1];
        string hashedPassword = HashPassword(password, salt);
        return storedHash == hashedPassword; 
    }

    public string GenerateSalt()
    {
        byte[] salt = new byte[16];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }

    public string HashPassword(string password, string salt)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string saltedPassword = password + salt;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}