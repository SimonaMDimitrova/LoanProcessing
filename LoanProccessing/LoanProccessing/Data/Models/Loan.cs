namespace LoanProccessing.Data.Models;

public class Loan : ModelBase
{
    public Loan()
    {
        this.Invoices = new List<Invoice>();
    }

    public string LoanNumber { get; set; }

    public string Status { get; set; }

    public decimal Amount { get; set; }

    public DateTime RequestedOn { get; set; }

    public int ClientId { get; set; }

    public Client Client { get; set; }

    public List<Invoice> Invoices { get; set; }
}
