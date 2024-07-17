using Dapper;
using System.Data;
using System.Data.SqlClient;
using TestCaseXp.Domain.DataAccess.Repositories;
using TestCaseXp.Domain.Models;

namespace TestCaseXp.Infrastructure.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _connection;

        public CustomerRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Customer GetByEmail(string email)
        {
            var sql = $@"SELECT * FROM Customer WHERE Email = '{email}';";
            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.QueryFirst<Customer>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public Customer GetById(int id)
        {
            var sql = $@"SELECT * FROM Customer WHERE ID = {id};";
            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.QueryFirst<Customer>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Insert(Customer entity)
        {
            var sql = $@"INSERT INTO [dbo].[Customer]
                           ([Name]
                           ,[CPF]
                           ,[Email]
                           ,[Password]
                           ,[CreatedAt])
                     VALUES
                           (@name
                           ,@cpf
                           ,@email
                           ,@password
                           ,@CreatedAt);";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql,new 
            {
                name = entity.Name,
                cpf = entity.CPF,
                email = entity.Email,
                password = entity.Password,
                createdAt = entity.CreatedAt
            });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }  

        public IEnumerable<Customer> GetAll()
        {
            var sql = $@"SELECT * FROM Customer;";
            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.Query<Customer>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
