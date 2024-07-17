using Dapper;
using System.Data;
using System.Data.SqlClient;
using TestCaseXp.Domain.DataAccess.Repositories;
using TestCaseXp.Domain.Dtos;
using TestCaseXp.Domain.Models;

namespace TestCaseXp.Infrastructure.DataAccess.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDbConnection _connection;

        public TransactionRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TransactionReportDto> GetTransactionReportByEmail(string email)
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
                    where c.Email = '{email}';";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.Query<TransactionReportDto>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Insert(Transaction entity)
        {
            var sql = $@"INSERT INTO [dbo].[Transactions]
                           ([ProductId]
                           ,[CustomerId]
                           ,[TransactionDate]
                           ,[DueDate]
                           ,[ProductName]
                           ,[OperationType]
                           ,[UnitPrice]
                           ,[Quantity]
                           ,[CreatedAt])
                        VALUES
                           (@ProductId
                           ,@CustomerId
                           ,@TransactionDate
                           ,@DueDate
                           ,@ProductName
                           ,@OperationType
                           ,@UnitPrice
                           ,@Quantity
                           ,@CreatedAt)";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql, new
            {
                ProductId = entity.ProductId,
                CustomerId = entity.CustomerId,
                TransactionDate = entity.TransactionDate,
                DueDate = entity.DueDate,
                ProductName = entity.ProductName,
                OperationType = entity.OperationType,
                UnitPrice = entity.UnitPrice,
                Quantity = entity.Quantity,
                CreatedAt = entity.CreatedAt
            });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
