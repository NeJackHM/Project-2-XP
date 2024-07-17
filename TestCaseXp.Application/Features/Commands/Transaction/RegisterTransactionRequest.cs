using MediatR;

namespace TestCaseXp.Application.Features.Commands.Transaction
{
    public class RegisterTransactionRequest : IRequest<RegisterTransactionResponse>
    {
        public bool IsFii { get; set; }
        public string CustomerEmail { get; set; }
        public bool Isbuying { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int DaysToExpirationDate { get; set; }
    }
}
