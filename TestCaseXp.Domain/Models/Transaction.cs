using TestCaseXp.Domain.Common;

namespace TestCaseXp.Domain.Models
{
    public class Transaction : BaseDomainModel
    {
        public int ProductId { get; set; } 
        public int CustomerId { get; set; } 
        public DateTime TransactionDate { get; set; }
        public DateTime DueDate { get; set; }
        public string OperationType { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}