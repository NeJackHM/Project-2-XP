namespace SentEmailsJob.Entities
{
    public class EmailControl
    {
        public int CustomerId { get; set; }
        public int NumberOfTransactionsSent { get; set; }
        public string Address { get; set; }
        public string Subject { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
