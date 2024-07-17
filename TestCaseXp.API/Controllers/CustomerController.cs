using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestCaseXp.Application.Features.Commands.Customer;
using TestCaseXp.Application.Features.Queries.Customer;

namespace TestCaseXp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{email}", Name = "GetCustomer")]
        public async Task<IActionResult> GetById(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            var response = await _mediator.Send(new GetCustomerRequest { Email = email });

            if (response.Success == false)
                return BadRequest("Cliente não encontrado");

            return Ok(response);
        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCustomerRequest());

            if (response.Success == false)
                return BadRequest();

            return Ok(response);
        }

        [HttpPost(Name = "RegisterCustomer")]
        public async Task<IActionResult> Insert([FromBody] RegisterCustomerRequest registerCustomerRequest)
        {
            var response = await _mediator.Send(registerCustomerRequest);

            if (response.Success == false)
                return BadRequest("Erro ao momento de registro de cliente.");

            return Ok(response);
        }
    }
}
