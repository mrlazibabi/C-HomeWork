
Bank bank = new Bank();
BankAccount account1 = new BankAccount("Nguyen Van A", "a@example.com", 1000, 1);
BankAccount account2 = new BankAccount("Tran Thi B", "b@example.com", 2000, 2);
Manager manager = new Manager("Le Van C", "c@example.com", 5000, 3, 10000);

bank.AddAccount(account1);
bank.AddAccount(account2);
bank.AddAccount(manager);

account1.Deposit(500);
account1.MakePurchase(200);
Console.WriteLine($"Tài khoản {account1.Name}, Số dư: {account1.Balance}"); // Số dư: 1300

Console.WriteLine($"Lương tổng của {manager.Name}: {manager.GetTotalCompensation()}"); // Lương: 15000

bank.DisplayAllAccounts();

public class Bank
{
    private List<BankAccount> _accounts; // private: Đóng gói danh sách tài khoản

    public Bank()
    {
        _accounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount account) // public: Giao diện công khai
    {
        if (account == null)
            throw new ArgumentNullException(nameof(account));
        _accounts.Add(account);
    }

    public void DisplayAllAccounts() // public: Giao diện công khai
    {
        foreach (var account in _accounts)
        {
            Console.WriteLine($"Tên: {account.Name}, Email: {account.Email}, Số dư: {account.Balance}, ID: {account.EmployeeId}");
        }
    }
}

public class BankAccount
{
    private string _name; // private field: Đóng gói
    private string _email; // private field: Đóng gói
    private decimal _balance; // private field: Đóng gói
    internal int EmployeeId; // internal: Truy cập trong assembly

    public BankAccount(string name, string email, decimal initialBalance, int employeeId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên không được để trống.", nameof(name));
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new ArgumentException("Email không hợp lệ.", nameof(email));
        if (initialBalance < 0)
            throw new ArgumentException("Số dư ban đầu không thể âm.", nameof(initialBalance));
        if (employeeId <= 0)
            throw new ArgumentException("ID nhân viên phải lớn hơn 0.", nameof(employeeId));
        _name = name;
        _email = email;
        _balance = initialBalance;
        EmployeeId = employeeId;
    }

    public string Name // public property: Kiểm soát truy cập
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên không được để trống.");
            _name = value;
        }
    }

    public string Email // public property: Kiểm soát truy cập
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Email không hợp lệ.");
            _email = value;
        }
    }

    public decimal Balance // public property: Chỉ đọc
    {
        get => _balance;
    }

    public void Deposit(decimal amount) // public method: Kiểm soát sửa đổi _balance
    {
        if (amount <= 0)
            throw new ArgumentException("Số tiền nạp phải lớn hơn 0.");
        _balance += amount;
    }

    public void MakePurchase(decimal amount) // public method: Kiểm soát sửa đổi _balance
    {
        if (amount <= 0)
            throw new ArgumentException("Số tiền rút phải lớn hơn 0.");
        if (amount > _balance)
            throw new ArgumentException("Số dư không đủ.");
        _balance -= amount;
    }
}

public class Manager : BankAccount // Lớp con để minh họa protected
{
    protected decimal _baseSalary; // protected: Lớp con truy cập được

    public Manager(string name, string email, decimal initialBalance, int employeeId, decimal baseSalary)
        : base(name, email, initialBalance, employeeId)
    {
        if (baseSalary < 0)
            throw new ArgumentException("Lương cơ bản không thể âm.", nameof(baseSalary));
        _baseSalary = baseSalary;
    }

    public decimal GetTotalCompensation()
    {
        return _baseSalary + Balance; // Truy cập Balance (public) và _baseSalary (protected)
    }
}

