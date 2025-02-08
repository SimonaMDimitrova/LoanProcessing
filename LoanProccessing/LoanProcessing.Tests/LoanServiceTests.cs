namespace LoanProcessing.Tests;

using MockData;

using LoanProccessing.Data.Models;
using LoanProccessing.Data.Repositories;
using LoanProccessing.Services;

using Moq;
using NUnit.Framework.Internal;
using LoanProccessing.Enums;

public class LoanServiceTests
{
    private Mock<IClientRepository> clientRepoMock;
    private List<Client> clients;

    private Mock<IInvoiceRepository> invoiceRepoMock;
    private List<Invoice> invoices;

    private Mock<ILoanRepository> loanRepoMock;
    private List<Loan> loans;

    private ILoanService loanService;
    private IInvoiceService invoiceService;
    private IClientService clientService;

    [SetUp]
    public void Setup()
    {
        this.clientRepoMock = new Mock<IClientRepository>();
        this.invoiceRepoMock = new Mock<IInvoiceRepository>();
        this.loanRepoMock = new Mock<ILoanRepository>();

        this.clientService = new ClientService(clientRepoMock.Object);
        this.invoiceService = new InvoiceService(invoiceRepoMock.Object);
        this.loanService = new LoanService(loanRepoMock.Object, clientService, invoiceService);

        // Insert mock data for loans with nested client information
        this.loans = LoanMockData.Loans;
        this.clients = this.loans.Select(x => x.Client).ToList();
        this.invoices = this.loans.SelectMany(x => x.Invoices).ToList();

        // Setup mocks with data
        this.clientRepoMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => clients.FirstOrDefault(c => c.Id == id));

        this.invoiceRepoMock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(() => this.invoices);

        this.loanRepoMock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(() => this.loans);
    }

    [Test]
    public async Task CheckIfAllLoansAreRetrieved_GetAllAsync()
    {
        var expectedResult = this.loans.Count();

        var actualResult = await this.loanService.GetAllAsync();

        Assert.That(expectedResult == actualResult.Count());
    }

    [Test]
    public async Task CheckIfAllLoansAreRetrievedFilteredByStatusPaidAndAwaiting_GetPaidAndAwaitingLoansSummaryAsync()
    {
        var expectedResult = this.loans.Where(x => x.Status == LoanStatus.Paid.ToString()
                                                || x.Status == LoanStatus.AwaitingPayment.ToString())
                                       .Count();

        var actualResult = await this.loanService.GetPaidAndAwaitingLoansSummaryAsync();

        Assert.That(expectedResult == actualResult.Count());
    }
}
