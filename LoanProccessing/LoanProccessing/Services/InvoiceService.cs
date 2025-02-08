namespace LoanProccessing.Services;

using DTOs;
using Data.Repositories;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository invoiceRepository;

    public InvoiceService(IInvoiceRepository invoiceRepository)
    {
        this.invoiceRepository = invoiceRepository;
    }

    public async Task<IEnumerable<InvoiceDTO>> GetAllByLoanIdAsync(int loanId)
    {
        var dbInvoices = await invoiceRepository.GetAllAsync();

        var result = dbInvoices
                        .Where(x => x.LoanId == loanId)
                        .Select(x => new InvoiceDTO
                        {
                            Id = x.Id,
                            Amount = x.Amount,
                            InvoiceNumber = x.InvoiceNumber
                        });

        return result;
    }
}
