using TestCaseXp.Domain.DataAccess.Repositories.Base;
using TestCaseXp.Domain.Dtos;
using TestCaseXp.Domain.Models;

namespace TestCaseXp.Domain.DataAccess.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<TransactionReportDto> GetTransactionReportByEmail(string email);
    }
}
