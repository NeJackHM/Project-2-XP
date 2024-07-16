using TestCaseXp.Domain.Common;

namespace TestCaseXp.Domain.Models
{
    public class Transaction : BaseDomainModel
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
