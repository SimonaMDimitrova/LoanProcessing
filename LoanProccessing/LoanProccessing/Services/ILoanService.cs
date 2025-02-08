namespace LoanProccessing.Services;

using DTOs;

public interface ILoanService
{
    Task<IEnumerable<LoanDTO>> GetAllAsync();

    Task<IEnumerable<LoanSummary>> GetPaidAndAwaitingLoansSummaryAsync();
}
