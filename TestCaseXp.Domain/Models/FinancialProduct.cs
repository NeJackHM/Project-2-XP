using TestCaseXp.Domain.Common;

namespace TestCaseXp.Domain.Models
{
    public class FinancialProduct : BaseDomainModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
