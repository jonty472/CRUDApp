using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CRUDApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDatabaseConnection();
            CreateTask();
        }
        


        static void TestDatabaseConnection()
        {
            string connectionString = "Server=DESKTOP-7O5A39Q\\SQLEXPRESS ;Integrated Security=true; Database=TaskDatabase;";
            
            string commandText = 
                "INSERT INTO Tasks (ID, Task)" +
                "VALUES (@ID, @Task)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = 1;
                command.Parameters.Add("@Task", System.Data.SqlDbType.Char).Value = "Washing";

                try
                {
                    conn.Open();
                    command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }

        static void CreateTask()
        {
            string commandText = "INSERT INTO Tasks (ID, Task)" +
                   "VALUES (1, Washing)";


        }
    }
}