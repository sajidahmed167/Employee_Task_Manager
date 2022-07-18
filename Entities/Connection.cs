using System.Data.SqlClient;

namespace Employee_Task_Manager.Entities
{
    class Connection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server=localhost; Database=Taskmanager; Integrated Security=True;");
        }
    }
}
