using LoanProccessing.Data.Models;

namespace LoanProcessing.Tests.MockData
{
    public static class LoanMockData
    {
        public static List<Loan> Loans = new List<Loan>
        {
            new Loan
            {
                Id = 1,
                Amount = 1200,
                LoanNumber = "200001",
                Status = "Paid",
                RequestedOn = DateTime.Parse("2024-02-01T12:00:00Z"),
                Client = new Client
                {
                    Id = 1,
                    FirstName = "Michael",
                    SecondName = "A.",
                    LastName = "Johnson"
                },
                Invoices = new List<Invoice>
                {
                    new Invoice { Id = 1, Amount = 400, InvoiceNumber = "9001", LoanId = 1 }
                }
            },
            new Loan
            {
                Id = 2,
                Amount = 2200,
                LoanNumber = "200002",
                Status = "Paid",
                RequestedOn = DateTime.Parse("2024-02-02T14:30:00Z"),
                Client = new Client
                {
                    Id = 2,
                    FirstName = "Sophie",
                    SecondName = "B.",
                    LastName = "Martinez"
                },
                Invoices = new List<Invoice>
                {
                    new Invoice { Id = 2, Amount = 700, InvoiceNumber = "9002", LoanId = 2 }
                }
            },
            new Loan
            {
                Id = 3,
                Amount = 3500,
                LoanNumber = "200003",
                Status = "AwaitingPayment",
                RequestedOn = DateTime.Parse("2024-02-03T09:45:00Z"),
                Client = new Client
                {
                    Id = 3,
                    FirstName = "Daniel",
                    SecondName = "C.",
                    LastName = "Smith"
                },
                Invoices = new List<Invoice>()
            },
            new Loan
            {
                Id = 4,
                Amount = 1800,
                LoanNumber = "200004",
                Status = "AwaitingPayment",
                RequestedOn = DateTime.Parse("2024-02-04T11:15:00Z"),
                Client = new Client
                {
                    Id = 4,
                    FirstName = "Emma",
                    SecondName = "D.",
                    LastName = "Williams"
                },
                Invoices = new List<Invoice>
                {
                    new Invoice { Id = 3, Amount = 500, InvoiceNumber = "9003", LoanId = 4 }
                }
            },
            new Loan
            {
                Id = 5,
                Amount = 2800,
                LoanNumber = "200005",
                Status = "Created",
                RequestedOn = DateTime.Parse("2024-02-05T16:20:00Z"),
                Client = new Client
                {
                    Id = 5,
                    FirstName = "Liam",
                    SecondName = "E.",
                    LastName = "Brown"
                },
                Invoices = new List<Invoice>()
            },
            new Loan
            {
                Id = 6,
                Amount = 1500,
                LoanNumber = "200006",
                Status = "Created",
                RequestedOn = DateTime.Parse("2024-02-06T10:10:00Z"),
                Client = new Client
                {
                    Id = 6,
                    FirstName = "Olivia",
                    SecondName = "F.",
                    LastName = "Garcia"
                },
                Invoices = new List<Invoice>
                {
                    new Invoice { Id = 4, Amount = 300, InvoiceNumber = "9004", LoanId = 6 }
                }
            }
        };
    }
}