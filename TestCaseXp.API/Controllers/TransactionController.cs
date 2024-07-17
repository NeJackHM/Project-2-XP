using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestCaseXp.Application.Features.Commands.Transaction;
using TestCaseXp.Application.Features.Queries.Customer;
using TestCaseXp.Application.Features.Queries.Transaction;

namespace TestCaseXp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "RegisterTransaction")]
        public async Task<IActionResult> Insert([FromBody] RegisterTransactionRequest registerTransactionRequest)
        {
            var response = await _mediator.Send(registerTransactionRequest);

            if (response.Success == false)
                return BadRequest("Erro ao momento de registro de transação.");

            return Ok(response);
        }

        [HttpGet("{email}", Name = "GetTransactionsReportByEmail")]
        public async Task<IActionResult> GetAllTransactions(string email)
        {
            var response = await _mediator.Send(new GetTransactionReportRequest() { Email = email });

            if (response.Success == false)
                return BadRequest();

            return Ok(response);
        }
    }
}
