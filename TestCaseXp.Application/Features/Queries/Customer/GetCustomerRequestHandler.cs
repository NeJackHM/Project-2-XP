using MediatR;
using TestCaseXp.Domain.DataAccess.Repositories;

namespace TestCaseXp.Application.Features.Queries.Customer
{
    public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.GetByEmail(request.Email);

            var customerData = new CustomerData
            {
                CPF = customer.CPF,
                Email = customer.Email,
                Name = customer.Name,
                Password = customer.Password
            };

            if (customer != null)
                return new GetCustomerResponse { Success = true, CustomerData = customerData };

            return new GetCustomerResponse { Success = false };
        }
    }
}
