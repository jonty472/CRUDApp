using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CRUDApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool showMenu = true;

            while (showMenu)
            {
                showMenu = MainMenu();
            }
            ShowTasks();
        }

        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Add Task");
            Console.WriteLine("2) Remove Task");
            Console.WriteLine("3) Exit");


            switch (Console.ReadLine())
            {
                case "1":
                    CreateTask();
                    return true;

                case "2":
                    RemoveTask();
                    return true;

                case "3":
                    return false;
            }

            return true;

        }
        
        static void ShowTasks()
        {

            string TaskTable = "SELECT * FROM Tasks";
            using (SqlConnection conn = new SqlConnection(DBConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(TaskTable, conn);

                conn.Open();

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                da.Dispose();

                foreach (DataRow dr in dt.Rows)
                {
                    foreach(var item in dr.ItemArray)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
        }

        static void CreateTask()
        {
            
            string commandText = 
                "INSERT INTO Tasks (TaskDescription)" +
                "VALUES (@TaskDescription)";
            string connectionString = DBConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.Add("@TaskDescription", System.Data.SqlDbType.VarChar).Value = "Cleaning";

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

        static void RemoveTask()
        {
            Console.WriteLine("Delete what task: ");
            using (SqlConnection conn = new SqlConnection(DBConnectionString()))
            {
                string commandText = "DELETE FROM TABLE Tasks WHERE @TaskDescription";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.Add("@TaskDescription");
            }
        }
        static string DBConnectionString()
        {
            return "Server=DESKTOP-7O5A39Q\\SQLEXPRESS ;Integrated Security=true; Database=TasksDatabase;";
        }
    }
}