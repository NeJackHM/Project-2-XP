namespace TestCaseXp.Application.Features.Queries.Transaction
{
    public class GetTransactionReportResponse
    {
        public bool Success { get; set; }
        public List<TransactionData> TransactionReportData { get; set; }
    }

    public class TransactionData
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string OperationType { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
