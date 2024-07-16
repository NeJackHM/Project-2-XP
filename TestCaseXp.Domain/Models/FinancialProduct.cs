using TestCaseXp.Domain.Common;

namespace TestCaseXp.Domain.Models
{
    public class FinancialProduct : BaseDomainModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Interest { get; set; }
        public string ProductType { get; set; }
        public string Status { get; set; }
    }
}
