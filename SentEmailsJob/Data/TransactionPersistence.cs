using Dapper;
using SentEmailsJob.Connection;
using System.Data;
using System.Data.SqlClient;
using SentEmailsJob.Dto;

namespace SentEmailsJob.Data
{
    public class TransactionPersistence
    {
        public IEnumerable<TransactionReportDto> GetTransactionReportByEmailAndDaysToExpirate(string email, int daysToExpirate)
        {
            var sql = $@"select
	                    t.Quantity,
	                    t.UnitPrice,
	                    t.OperationType,
	                    t.ProductName,
	                    t.TransactionDate,
                        t.DueDate,
	                    c.Name,
	                    c.Email,
	                    c.CPF,
	                    fp.Name as 'ProductType'
                    from Transactions t inner join Customer c
                    on t.CustomerId = c.Id inner join FinancialProduct fp
                    on fp.Id = t.ProductId
                    where c.Email = '{email}' and t.DueDate <= DATEADD(day, {daysToExpirate}, CURRENT_TIMESTAMP);";

            using SqlConnection connection = new ConexionBD().ObtainConnection();

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.Query<TransactionReportDto>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }
    }
}
