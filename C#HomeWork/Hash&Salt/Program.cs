Authen authen = new Authen();
OTP_Service otpService = new OTP_Service();
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("Welcome to the Authentication System!");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");
    Console.Write("Please select an option: ");
    
    string choice = Console.ReadLine();
    
    switch (choice)
    {
        case "1":
            Console.Write("Enter email: ");
            string regUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string regPassword = Console.ReadLine();
            if (authen.Register(regUsername, regPassword))
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Email already exists.");
            }
            break;
        case "2":
            Console.Write("Enter email: ");
            string loginEmail = Console.ReadLine();
            Console.Write("Enter password: ");
            string loginPassword = Console.ReadLine();
            if (authen.Login(loginEmail, loginPassword))
            {
                Console.WriteLine("Login successful! Sending OTP for verification...");
                string otp = await otpService.SendOTP(loginEmail); // Gửi OTP
                Console.Write("Enter the OTP sent to your email: ");
                string userOtp = Console.ReadLine();
                if (await otpService.VerifyOTP(loginEmail, userOtp))
                {
                    Console.WriteLine("OTP verified! Authentication completed.");
                }
                else
                {
                    Console.WriteLine("Invalid or expired OTP.");
                }
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
            }
            break;
        case "3":
            isRunning = false;
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}