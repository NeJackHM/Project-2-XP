using MediatR;

namespace TestCaseXp.Application.Features.Queries.Transaction
{
    public class GetTransactionReportRequest : IRequest<GetTransactionReportResponse>
    {
        public string Email { get; set; }
    }
}
