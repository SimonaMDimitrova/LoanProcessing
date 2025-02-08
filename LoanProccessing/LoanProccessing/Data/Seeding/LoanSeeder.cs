using LoanProccessing.Data.Models;
using LoanProccessing.Data.Repositories;
using System.Data;
using System.Text.Json;

namespace LoanProccessing.Data.Seeding
{
    public class LoanSeeder : ISeeder
    {
        public async Task SeedAsync(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection), "There is no connection!");
            }

            var loanRepository = new LoanRepository(connection);
            var clientRepository = new ClientRepository(connection);
            var invoiceRepository = new InvoiceRepository(connection);

            string filePath = "Data\\Seeding\\Datasets\\loans.json";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            string jsonString = File.ReadAllText(filePath);
            List<Loan> loans = JsonSerializer.Deserialize<List<Loan>>(jsonString);

            foreach (var loan in loans)
            {
                loan.ClientId = await clientRepository.CreateAsync(loan.Client);
                loan.Client.Id = loan.ClientId;

                loan.Id = await loanRepository.CreateAsync(loan);

                foreach (var invoice in loan.Invoices)
                {
                    invoice.LoanId = loan.Id;

                    await invoiceRepository.CreateAsync(invoice);
                }
            }
        }
    }
}
