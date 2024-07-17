using System.Data.SqlClient;
using System.Data;
using SentEmailsJob.Entities;
using SentEmailsJob.Connection;
using Dapper;

namespace SentEmailsJob.Data
{
    public class CustomerPersistence
    {
        public IEnumerable<Customer> GetAll()
        {
            var sql = $@"SELECT * FROM Customer;";
            using SqlConnection connection = new ConexionBD().ObtainConnection();

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.Query<Customer>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }
    }
}
