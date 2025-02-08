namespace LoanProccessing.Controllers;

using DTOs;
using Services;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanService loanService;

    public LoanController(ILoanService loanService)
    {
        this.loanService = loanService;
    }

    [HttpGet("GetAllAsync")]
    public async Task<IEnumerable<LoanDTO>> GetAllAsync()
    {
        return await this.loanService.GetAllAsync();
    }

    [HttpGet("GetPaidAndAwaitingLoansSummary")]
    public async Task<IEnumerable<LoanSummary>> GetPaidAndAwaitingLoansSummary()
    {
        return await this.loanService.GetPaidAndAwaitingLoansSummaryAsync();
    }
}
