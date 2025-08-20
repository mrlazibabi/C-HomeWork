Authen authen = new Authen();
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
            Console.Write("Enter username: ");
            string regUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string regPassword = Console.ReadLine();
            if (authen.Register(regUsername, regPassword))
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Username already exists.");
            }
            break;
        case "2":
            Console.Write("Enter username: ");
            string loginUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string loginPassword = Console.ReadLine();
            if (authen.Login(loginUsername, loginPassword))
            {
                Console.WriteLine("Login successful!");
                return; // Exit the loop on successful login
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
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