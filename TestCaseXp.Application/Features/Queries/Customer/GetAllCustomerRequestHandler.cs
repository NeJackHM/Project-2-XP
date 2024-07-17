using MediatR;
using TestCaseXp.Domain.DataAccess.Repositories;

namespace TestCaseXp.Application.Features.Queries.Customer
{
    public class GetAllCustomerRequestHandler : IRequestHandler<GetAllCustomerRequest, GetAllCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetAllCustomerResponse> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
        {
            var customers = _customerRepository.GetAll();

            var customerData = new List<CustomerData>();

            foreach (var customer in customers)
            {
                customerData.Add(new CustomerData
                {
                    CPF = customer.CPF,
                    Email = customer.Email,
                    Name = customer.Name,
                    Password = customer.Password
                });
            }

            if (customerData.Any())
                return new GetAllCustomerResponse { Success = true, CustomerData = customerData };

            return new GetAllCustomerResponse { Success = false };
        }
    }
}
