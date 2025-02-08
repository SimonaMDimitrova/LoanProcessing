using System.Data;

namespace LoanProccessing.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(IDbConnection connection);
    }
}
