using System.Data;
using System.Data.SqlClient;

namespace SentEmailsJob.Connection
{
    public class ConexionBD
    {
        private string connectionString = "Data Source=LAPTOP-EL92NMVT;Initial Catalog=XpTestCase;user id=sa;password=password123; TrustServerCertificate=True;";

        public SqlConnection ObtainConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void CloseConexion(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
