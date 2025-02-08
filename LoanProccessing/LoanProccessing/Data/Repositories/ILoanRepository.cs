namespace LoanProccessing.Data.Repositories;

using Models;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAllAsync();

    Task<Loan> GetByIdAsync(int id);

    Task<int> CreateAsync(Loan entity);

    Task UpdateAsync(Loan entity);

    Task DeleteAsync(int id);
}
