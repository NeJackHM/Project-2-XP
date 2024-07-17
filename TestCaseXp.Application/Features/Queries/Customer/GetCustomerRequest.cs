using MediatR;

namespace TestCaseXp.Application.Features.Queries.Customer
{
    public class GetCustomerRequest : IRequest<GetCustomerResponse>
    {
        public string Email { get; set; }
    }
}
