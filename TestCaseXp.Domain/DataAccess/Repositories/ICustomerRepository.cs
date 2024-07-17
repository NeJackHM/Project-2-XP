using TestCaseXp.Domain.DataAccess.Repositories.Base;
using TestCaseXp.Domain.Models;

namespace TestCaseXp.Domain.DataAccess.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Customer GetByEmail(string email);
    }
}
