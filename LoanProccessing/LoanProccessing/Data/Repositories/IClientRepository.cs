namespace LoanProccessing.Data.Repositories;

using Models;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllAsync();

    Task<Client> GetByIdAsync(int id);

    Task<int> CreateAsync(Client entity);

    Task UpdateAsync(Client entity);

    Task DeleteAsync(int id);
}
