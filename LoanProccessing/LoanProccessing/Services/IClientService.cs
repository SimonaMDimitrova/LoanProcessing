namespace LoanProccessing.Services;

using DTOs;

public interface IClientService
{
    Task<ClientDTO> GetByIdAsync(int id);
}
