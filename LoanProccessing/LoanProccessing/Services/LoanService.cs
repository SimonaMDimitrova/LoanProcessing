namespace LoanProccessing.Services;

using DTOs;
using Data.Repositories;
using Enums;

public class LoanService : ILoanService
{
    private readonly ILoanRepository loanRepository;
    private readonly IClientService clientService;
    private readonly IInvoiceService invoiceService;

    public LoanService(
        ILoanRepository loanRepository,
        IClientService clientService,
        IInvoiceService invoiceService)
    {
        this.loanRepository = loanRepository;
        this.clientService = clientService;
        this.invoiceService = invoiceService;
    }

    public async Task<IEnumerable<LoanDTO>> GetAllAsync()
    {
        var dbLoans = await this.loanRepository.GetAllAsync();

        var loans = new List<LoanDTO>();
        foreach (var dbLoan in dbLoans)
        {
            var loan = new LoanDTO()
            {
                Id = dbLoan.Id,
                Amount = dbLoan.Amount,
                LoanNumber = dbLoan.LoanNumber,
                Status = dbLoan.Status,
                RequestedOn = dbLoan.RequestedOn,
                Client = await this.clientService.GetByIdAsync(dbLoan.ClientId),
                Invoices = await this.invoiceService.GetAllByLoanIdAsync(dbLoan.Id)
            };

            loans.Add(loan);
        }

        return loans;
    }

    public async Task<IEnumerable<LoanSummary>> GetPaidAndAwaitingLoansSummaryAsync()
    {
        var dbLoans = await this.loanRepository
                                .GetAllAsync();

        var filteredDBLoans = dbLoans.Where(x => x.Status == LoanStatus.Paid.ToString()
                                              || x.Status == LoanStatus.AwaitingPayment.ToString());

        var amountOfAllLoans = filteredDBLoans.Sum(x => x.Amount);

        var result = filteredDBLoans
                        .Select(x => new LoanSummary()
                        {
                            LoanId = x.Id,
                            Amount = x.Amount,
                            PercentageOfAllAmountLoans = (x.Amount / amountOfAllLoans) * 100
                        });
        
        return result;
    }
}
