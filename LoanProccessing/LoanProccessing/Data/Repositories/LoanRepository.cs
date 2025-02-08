namespace LoanProccessing.Data.Repositories;

using Models;

using Dapper;
using System.Data;

public class LoanRepository : ILoanRepository
{
    private readonly IDbConnection connection;

    public LoanRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    protected string TableName => nameof(Loan);

    public async Task<IEnumerable<Loan>> GetAllAsync()
    {
        var sql = $"SELECT * FROM {TableName}";
        return await this.connection.QueryAsync<Loan>(sql);
    }

    public async Task<Loan> GetByIdAsync(int id)
    {
        string sql = $"SELECT * FROM {TableName} WHERE Id = @id";

        return await this.connection.QueryFirstOrDefaultAsync<Loan>(sql, new { id });
    }

    public async Task<int> CreateAsync(Loan entity)
    {
        string sql = $"INSERT INTO {TableName} (LoanNumber, Status, Amount, RequestedOn, ClientId) " +
                      "VALUES (@LoanNumber, @Status, @Amount, @RequestedOn, @ClientId)" +
                      "RETURNING Id;";

        return await this.connection.ExecuteScalarAsync<int>(sql, entity);
    }

    public async Task UpdateAsync(Loan entity)
    {
        string sql = $"UPDATE {TableName}" +
                      "SET LoanNumber    = @LoanNumber, " +
                          "Status        = @Status," +
                          "Amount        = @Amount" +
                          "RequestedOn   = @RequestedOn" +
                          "ClientId      = @ClientId" +
                      "WHERE Id = @Id";

        await this.connection.ExecuteAsync(sql, entity);
    }

    public async Task DeleteAsync(int id)
    {
        string sql = $"DELETE FROM {TableName} WHERE Id = @id";

        await this.connection.ExecuteAsync(sql, new { id });
    }
}
