public interface IReportBank
{
    Customer[] CustomerCashOutSuccess { get; set; }
    decimal TotalAmountCashOut { get; set; }
    decimal TotalAmountInQueue { get; set; }
}