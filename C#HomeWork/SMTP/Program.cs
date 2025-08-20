using SMTP;
using System.Net.Mail;

OTP_Service otpService = new OTP_Service();
string inputOtp = string.Empty;
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("Enter your email address:");
    string recipientEmail = Console.ReadLine();

    if (string.IsNullOrEmpty(recipientEmail) || !IsValidEmail(recipientEmail))
    {
        Console.WriteLine("Email cannot be empty or invalid. Please try again.");
        continue;
    }

    try
    {
        string otp = await otpService.SendOTP(recipientEmail);
        Console.WriteLine($"An OTP has been sent to {recipientEmail}. Please enter the OTP:");
        inputOtp = Console.ReadLine();

        if (await otpService.VerifyOTP(recipientEmail, inputOtp))
        {
            Console.WriteLine("OTP verified successfully! Redirecting to password reset page...");
            isRunning = false;
        }
        else
        {
            Console.WriteLine("Invalid OTP or expired. Please try again.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();

static bool IsValidEmail(string email)
{
    try
    {
        MailAddress addr = new MailAddress(email);
        return addr.Address == email;
    }
    catch
    {
        return false;
    }
}