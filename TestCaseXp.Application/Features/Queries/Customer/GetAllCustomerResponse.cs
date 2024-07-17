namespace TestCaseXp.Application.Features.Queries.Customer
{
    public class GetAllCustomerResponse
    {
        public bool Success { get; set; }
        public List<CustomerData> CustomerData { get; set; }
    }
}
