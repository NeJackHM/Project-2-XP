using TestCaseXp.Domain.Common;

namespace TestCaseXp.Domain.Models
{
    public class Customer : BaseDomainModel
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
