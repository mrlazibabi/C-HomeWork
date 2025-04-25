public class ReportBank : IReportBank
{
    public Customer[] CustomerCashOutSuccess { get; set; }

    public decimal TotalAmountCashOut { get; set; }
    public decimal TotalAmountInQueue { get; set; }
}
 