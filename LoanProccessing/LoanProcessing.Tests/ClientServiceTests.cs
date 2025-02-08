namespace LoanProcessing.Tests;

using LoanProccessing.Data.Models;
using LoanProccessing.Data.Repositories;
using LoanProccessing.Services;
using LoanProcessing.Tests.MockData;
using Moq;
using NUnit.Framework.Internal;

public class ClientServiceTests
{
    private Mock<IClientRepository> clientRepoMock;
    private List<Client> clients;

    private IClientService clientService;

    [SetUp]
    public void Setup()
    {
        this.clientRepoMock = new Mock<IClientRepository>();

        this.clientService = new ClientService(clientRepoMock.Object);

        // Insert your data here to be reused by all tests
        this.clients = LoanMockData.Loans.Select(x => x.Client).ToList();

        // Setup mocks with data
        this.clientRepoMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
               .ReturnsAsync((int id) => clients.FirstOrDefault(c => c.Id == id));
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public async Task CheckSucessfullyGettingOfMockData_GetByIdAsync(int id)
    {
        var expectedResult = id;

        var actualResult = await this.clientService.GetByIdAsync(id);

        Assert.That(expectedResult == actualResult.Id);
    }

    [Test]
    [TestCase(-5)]
    [TestCase(50)]
    public async Task GettingNonExistentClient_GetByIdAsync(int id)
    {
        var actualResult = await this.clientService.GetByIdAsync(id);

        Assert.IsNull(actualResult);
    }
}