namespace TestCaseXp.Application.Features.Queries.Customer
{
    public class GetCustomerResponse
    {
        public bool Success { get; set; }
        public CustomerData CustomerData { get; set; }
    }

    public class CustomerData
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
