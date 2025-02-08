namespace LoanProccessing.DTOs;

public class LoanDTO
{
    public int Id { get; set; }

    public string LoanNumber { get; set; }

    public string Status { get; set; }

    public decimal Amount { get; set; }

    public DateTime RequestedOn { get; set; }

    public ClientDTO Client { get; set; }

    public IEnumerable<InvoiceDTO> Invoices { get; set; }
}
