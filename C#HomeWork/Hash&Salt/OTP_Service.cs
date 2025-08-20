using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Net.Mail;


public class OTP_Service
{
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly string _smtpUser = "anhltse170584@fpt.edu.vn";
    private readonly string _smtpPassword = "igme tsjk hvez ccbu";
    private readonly int _otpExpiryMinutes = 1;
    private readonly string _mockApiUrl = "https://68a45a1bc123272fb9b25b33.mockapi.io/otp";

    private async Task SendEmail(string toEmail, string subject, string body)
    {
        using (SmtpClient client = new SmtpClient(_smtpServer, _smtpPort))
        {
            client.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
            client.EnableSsl = true;

            using (MailMessage mailMessage = new MailMessage(_smtpUser, toEmail, subject, body))
            {
                await client.SendMailAsync(mailMessage);
            }
        }
    }

    public async Task<string> SendOTP(string recipientEmail)
    {
        string otp = GenerateOTP();
        string subject = "Your One-Time Password (OTP)";
        string body = $"Your OTP is: {otp}. It will expire in {_otpExpiryMinutes} minutes.";

        await SendEmail(recipientEmail, subject, body);
        await SaveOtpToMockApi(otp, recipientEmail);

        return otp;
    }

    private string GenerateOTP()
    {
        Random random = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] otpArray = new char[6];

        for (int i = 0; i < 6; i++)
        {
            otpArray[i] = chars[random.Next(chars.Length)];
        }

        return new string(otpArray);
    }

    private async Task SaveOtpToMockApi(string otp, string email)
    {
        using (HttpClient client = new HttpClient())
        {
            object otpData = new
            {
                otp = otp,
                email = email,
                expiryTime = DateTime.UtcNow.AddMinutes(_otpExpiryMinutes).ToString("o")
            };

            HttpResponseMessage response = await client.PostAsJsonAsync(_mockApiUrl, otpData);
            response.EnsureSuccessStatusCode();
        }
    }

    public async Task<bool> VerifyOTP(string email, string inputOtp)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync($"{_mockApiUrl}?email={email}");
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            OTPData[] otps = JsonConvert.DeserializeObject<OTPData[]>(json);

            if (otps != null)
            {
                OTPData otpRecord = Array.Find(otps, o => o.otp == inputOtp && DateTime.Parse(o.expiryTime) > DateTime.UtcNow);
                if (otpRecord != null)
                {
                    await client.DeleteAsync($"{_mockApiUrl}/{otpRecord.Id}");
                    return true;
                }
            }
            return false;
        }
    }
}

public class OTPData
{
    public string Id { get; set; }
    public string otp { get; set; }
    public string email { get; set; }
    public string expiryTime { get; set; }
}