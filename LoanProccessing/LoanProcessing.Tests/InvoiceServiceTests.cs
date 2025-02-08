namespace LoanProcessing.Tests;

using MockData;

using LoanProccessing.Data.Models;
using LoanProccessing.Data.Repositories;
using LoanProccessing.Services;

using Moq;
using NUnit.Framework.Internal;

public class InvoiceServiceTests
{
    private Mock<IInvoiceRepository> invoiceRepoMock;
    private List<Invoice> invoices;
    
    private IInvoiceService invoiceService;

    [SetUp]
    public void Setup()
    {
        this.invoiceRepoMock = new Mock<IInvoiceRepository>();

        this.invoiceService = new InvoiceService(invoiceRepoMock.Object);

        // Insert mock data for loans with nested client information
        this.invoices = LoanMockData.Loans
                                    .SelectMany(x => x.Invoices).ToList();

        // Setup mocks with data
        this.invoiceRepoMock.Setup(repo => repo.GetAllAsync())
               .ReturnsAsync(() => this.invoices);
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(20)]
    public async Task CheckIfInvoicesCountIsCorrect_GetAllByLoanIdAsync(int loanId)
    {
        var expectedResult = this.invoices.Where(x => x.LoanId == loanId).Count();

        var actualResult = await this.invoiceService.GetAllByLoanIdAsync(loanId);

        Assert.That(expectedResult == actualResult.Count());
    }
}
