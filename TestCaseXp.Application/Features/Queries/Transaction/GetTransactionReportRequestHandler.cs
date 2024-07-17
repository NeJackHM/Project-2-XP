using MediatR;
using TestCaseXp.Domain.DataAccess.Repositories;

namespace TestCaseXp.Application.Features.Queries.Transaction
{
    public class GetTransactionReportRequestHandler : IRequestHandler<GetTransactionReportRequest, GetTransactionReportResponse>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionReportRequestHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<GetTransactionReportResponse> Handle(GetTransactionReportRequest request, CancellationToken cancellationToken)
        {
            var transactionReportData = _transactionRepository.GetTransactionReportByEmail(request.Email);

            var transactionData = new List<TransactionData>();

            foreach (var transaction in transactionReportData)
            {
                transactionData.Add(new TransactionData
                {
                    CPF = transaction.CPF,
                    Email = transaction.Email,
                    Name = transaction.Name,
                    TransactionDate = transaction.TransactionDate,
                    DueDate = transaction.DueDate,
                    OperationType = transaction.OperationType,
                    ProductName = transaction.ProductName,
                    ProductType = transaction.ProductType,
                    Quantity = transaction.Quantity,
                    UnitPrice = transaction.UnitPrice,
                    TotalAmount = transaction.UnitPrice * transaction.Quantity,
                });
            }

            if (transactionData.Any())
                return new GetTransactionReportResponse { Success = true, TransactionReportData = transactionData };

            return new GetTransactionReportResponse { Success = false };
        }
    }
}
