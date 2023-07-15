using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CRUDApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDatabaseConnection();
        }



        static void TestDatabaseConnection()
        {
            string connectionString = "";

            using SqlConnection connection = new SqlConnection(connectionString);
            
            connection.Open();

        }
    }
}