using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Caching;
using System.Windows;

namespace Employee_Task_Manager.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Status { get; set; }

        Task(int TaskId, String Title, String Description, String Owner, String Status = "To-do")
        {
            this.Title = Title.Trim();
            this.Description = Description.Trim();
            this.Owner = Owner;
            this.Status = Status;
            this.TaskId = TaskId;
        }

        public static Task CreateTask(String Title, String Description, String Owner, int TaskId = 0, String Status = "To-do")
        {
            return new Task(TaskId, Title, Description, Owner, Status);
        }

        public static ObservableCollection<Task> GetTasks(string Role)
        {
            ObservableCollection<Task> TaskList = new ObservableCollection<Task> { };
            SqlConnection sqlConnection = Connection.GetConnection();
            ObjectCache cache = MemoryCache.Default;
            string Owner = cache.Get("Username").ToString();

            try
            {
                sqlConnection.Open();
                String Query = "SELECT * from [dbo].[Task]";
                if (Role == "customer")
                {
                    Query = "SELECT * from [dbo].[Task] where [Owner] = @Owner ";
                }
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Owner", Owner);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TaskList.Add(Task.CreateTask(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[0]), reader[4].ToString()));
                    }
                }
                sqlConnection.Close();
                return TaskList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching tasks");
                return TaskList;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
        }

        public Boolean Save()
        {
            // Validations
            if (this.Title.Length < 1)
            {
                MessageBox.Show("Task Title is Required");
                return false;
            }
            if (this.Description.Length < 1)
            {
                MessageBox.Show("Task Description is required");
                return false;
            }

            SqlConnection sqlConnection = Connection.GetConnection();

            try
            {
                if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();
                String Query = "INSERT INTO [dbo].[Task](Name, Description, Owner, Status) values(@Title, @Description, @Owner, @Status)";
                //String Query = "Name = @Title, Description = @Description, Owner = @Owner, Status = @Status where TaskId = @TaskId";
                //if (this.TaskId == 1) Query = "INSERT INTO [Task](Name,Description,Owner) OUTPUT INSERTED.[TaskID] VALUES(@TaskTitle, @TaskDescription, @ownerID)";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Title", Title);
                sqlCommand.Parameters.AddWithValue("@Description", Description);
                sqlCommand.Parameters.AddWithValue("@Owner", Owner);
                sqlCommand.Parameters.AddWithValue("@Status", Status);

                if (this.TaskId == 0)
                {
                    int CurrentTaskID = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@TaskId", this.TaskId);
                    int RowsAffected = sqlCommand.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong, please try again");
                return false;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
        }

        public static int DeleteTask(int TaskId)
        {
            int rowsAffected = 0;
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            const string caption = "Form Closing";
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this task?", caption, buttons);
            SqlConnection sqlConnection = Connection.GetConnection();

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();
                    String Query = "DELETE from [dbo].[Task] where [TaskId] = @TaskId";
                    SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@TaskId", TaskId);
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                }
            }
            return rowsAffected;

        }
    }
}
