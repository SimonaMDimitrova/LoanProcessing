namespace LoanProccessing.Data.Repositories;

using Models;

using Dapper;
using System.Data;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly IDbConnection connection;

    public InvoiceRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    protected string TableName => nameof(Invoice);

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        var sql = $"SELECT * FROM {TableName}";
        return await this.connection.QueryAsync<Invoice>(sql);
    }

    public async Task<Invoice> GetByIdAsync(int id)
    {
        string sql = $"SELECT * FROM {TableName} WHERE Id = @id";

        return await this.connection.QueryFirstOrDefaultAsync<Invoice>(sql, new { id });
    }

    public async Task<int> CreateAsync(Invoice entity)
    {
        string sql = $"INSERT INTO {TableName} (InvoiceNumber, Amount, LoanId) " +
                      "VALUES (@InvoiceNumber, @Amount, @LoanId)" +
                      "RETURNING Id;";

        return await this.connection.ExecuteScalarAsync<int>(sql, entity);
    }

    public async Task UpdateAsync(Invoice entity)
    {
        string sql = $"UPDATE {TableName}" +
                      "SET InvoiceNumber = @InvoiceNumber, " +
                          "Amount        = @Amount," +
                          "LoanId        = @LoanId" +
                      "WHERE Id = @Id";

        await this.connection.ExecuteAsync(sql, entity);
    }

    public async Task DeleteAsync(int id)
    {
        string sql = $"DELETE FROM {TableName} WHERE Id = @id";

        await this.connection.ExecuteAsync(sql, new { id });
    }
}
