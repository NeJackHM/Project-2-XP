namespace TestCaseXp.Domain.Dtos
{
    public class TransactionReportDto
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string OperationType { get; set; }
    }
}
