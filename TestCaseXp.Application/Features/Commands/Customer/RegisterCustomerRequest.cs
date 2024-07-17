using MediatR;

namespace TestCaseXp.Application.Features.Commands.Customer
{
    public class RegisterCustomerRequest : IRequest<RegisterCustomerResponse>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
