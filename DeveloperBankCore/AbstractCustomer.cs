public abstract class CustomerBase
{
    public abstract string FullName { get; set; }
    public abstract int Number { get; set; }
    public abstract int TransactionNumber { get; set; }
    public abstract decimal WithDrawalAmount { get; set; }
}