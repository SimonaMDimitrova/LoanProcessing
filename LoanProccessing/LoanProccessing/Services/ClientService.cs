namespace LoanProccessing.Services;

using DTOs;
using Data.Repositories;

public class ClientService : IClientService
{
    private readonly IClientRepository clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<ClientDTO> GetByIdAsync(int id)
    {
        var dbClient = await this.clientRepository.GetByIdAsync(id);

        if (dbClient == null)
        {
            return null;
        }

        return new()
        {
            Id = dbClient.Id,
            FirstName = dbClient.FirstName,
            SecondName = dbClient.SecondName,
            LastName = dbClient.LastName
        };
    }
}
