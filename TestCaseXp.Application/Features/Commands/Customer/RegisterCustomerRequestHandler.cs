using MediatR;
using TestCaseXp.Domain.DataAccess.Repositories;

namespace TestCaseXp.Application.Features.Commands.Customer
{
    public class RegisterCustomerRequestHandler : IRequestHandler<RegisterCustomerRequest, RegisterCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public RegisterCustomerRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<RegisterCustomerResponse> Handle(RegisterCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Domain.Models.Customer()
                {
                    Name = request.Name,
                    CPF = request.CPF,
                    CreatedAt = DateTime.UtcNow,
                    Email = request.Email,
                    Password = request.Password
                };

                var result = _customerRepository.Insert(customer);

                if (result != 1)
                    return new RegisterCustomerResponse { Success = false };

                return new RegisterCustomerResponse { Success = true };
            }
            catch (Exception)
            {
                return new RegisterCustomerResponse { Success = false };
            }
        }
    }
}
