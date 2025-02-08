namespace LoanProccessing.Data.Repositories;

using Models;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetAllAsync();

    Task<Invoice> GetByIdAsync(int id);

    Task<int> CreateAsync(Invoice entity);

    Task UpdateAsync(Invoice entity);

    Task DeleteAsync(int id);
}
