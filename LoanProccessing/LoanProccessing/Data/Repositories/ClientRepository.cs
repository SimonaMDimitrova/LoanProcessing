namespace LoanProccessing.Data.Repositories;

using Models;

using Dapper;
using System.Data;

public class ClientRepository : IClientRepository
{
    private readonly IDbConnection connection;

    public ClientRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    protected string TableName => nameof(Client);

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        var sql = $"SELECT * FROM {TableName}";
        return await this.connection.QueryAsync<Client>(sql);
    }

    public async Task<Client> GetByIdAsync(int id)
    {
        string sql = $"SELECT * FROM {TableName} WHERE Id = @id";

        return await this.connection.QueryFirstOrDefaultAsync<Client>(sql, new { id });
    }

    public async Task<int> CreateAsync(Client entity)
    {
        string sql = $"INSERT INTO {TableName} (FirstName, SecondName, LastName) " +
                      "VALUES (@FirstName, @SecondName, @LastName)" +
                      "RETURNING Id;";

        return await this.connection.ExecuteScalarAsync<int>(sql, entity);
    }

    public async Task UpdateAsync(Client entity)
    {
        string sql = $"UPDATE {TableName}" +
                      "SET FirstName    = @FirstName, " +
                          "SecondName   = @SecondName," +
                          "LastName     = @LastName" +
                      "WHERE Id = @Id";

        await this.connection.ExecuteAsync(sql, entity);
    }

    public async Task DeleteAsync(int id)
    {
        string sql = $"DELETE FROM {TableName} WHERE Id = @id";

        await this.connection.ExecuteAsync(sql, new { id });
    }
}
