using Dapper;
using SentEmailsJob.Connection;
using SentEmailsJob.Entities;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace SentEmailsJob.Data
{
    public class EmailControlPersistence
    {
        public int InsertEmailControl(EmailControl emailControl)
        {
            var sql = $@"INSERT INTO [dbo].[EmailControl]
                               ([CustomerId]
                               ,[NumberOfTransactionsSent]
                               ,[Address]
                               ,[Subject]
                               ,[ProcessDate])
                         VALUES
                               (@CustomerId
                               ,@NumberOfTransactionsSent
                               ,@Address
                               ,@Subject
                               ,@ProcessDate);";

            using SqlConnection connection = new ConexionBD().ObtainConnection();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql, new
            {
                CustomerId = emailControl.CustomerId,
                NumberOfTransactionsSent = emailControl.NumberOfTransactionsSent,
                Address = emailControl.Address,
                Subject = emailControl.Subject,
                ProcessDate = emailControl.ProcessDate
            });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }
    }
}
