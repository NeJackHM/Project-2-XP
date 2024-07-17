using MediatR;
using TestCaseXp.Domain.Constants;
using TestCaseXp.Domain.DataAccess.Repositories;
using TestCaseXp.Domain.Enums;

namespace TestCaseXp.Application.Features.Commands.Transaction
{
    public class RegisterTransactionRequestHandler : IRequestHandler<RegisterTransactionRequest, RegisterTransactionResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;

        public RegisterTransactionRequestHandler(ICustomerRepository customerRepository, ITransactionRepository transactionRepository)
        {
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<RegisterTransactionResponse> Handle(RegisterTransactionRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerRepository.GetByEmail(request.CustomerEmail);

                if (customer == null)
                    return new RegisterTransactionResponse { Success = false };

                int productId = request.IsFii ? (int)PropuctType.Fii : (int)PropuctType.Acao;
                string operationType = request.Isbuying ? OperationTypeConstants.BUY : OperationTypeConstants.SALE;
                DateTime dueDate = DateTime.UtcNow.AddDays(request.DaysToExpirationDate);

                var transaction = new Domain.Models.Transaction()
                {
                    CreatedAt = DateTime.UtcNow,
                    CustomerId = customer.Id,
                    Quantity = request.Quantity,
                    OperationType = operationType,
                    ProductName = request.ProductName,
                    TransactionDate = DateTime.UtcNow,
                    DueDate = dueDate,
                    UnitPrice = request.UnitPrice,
                    ProductId = productId
                };

                var result = _transactionRepository.Insert(transaction);

                if (result != 1)
                    return new RegisterTransactionResponse { Success = false };

                return new RegisterTransactionResponse { Success = true };
            }
            catch (Exception)
            {
                return new RegisterTransactionResponse { Success = false };
            }
        }
    }
}
