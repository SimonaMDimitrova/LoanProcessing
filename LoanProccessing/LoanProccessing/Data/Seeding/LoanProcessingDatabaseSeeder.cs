
using System.Data;

namespace LoanProccessing.Data.Seeding
{
    public class LoanProcessingDatabaseSeeder : ISeeder
    {
        public async Task SeedAsync(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection), "There is no connection!");
            }

            var seeders = new List<ISeeder>()
            {
                new LoanSeeder()
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(connection);
            }
        }
    }
}
