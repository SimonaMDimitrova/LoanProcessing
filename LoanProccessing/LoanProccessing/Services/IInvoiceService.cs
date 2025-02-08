namespace LoanProccessing.Services;

using DTOs;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDTO>> GetAllByLoanIdAsync(int loanId);
}
