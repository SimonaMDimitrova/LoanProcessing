namespace LoanProccessing.Data.Models;

public class Invoice : ModelBase
{
    public string InvoiceNumber { get; set; }

    public decimal Amount { get; set; }

    public int? LoanId { get; set; }

    public Loan Loan { get; set; }
}
