using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Windows;

namespace Employee_Task_Manager.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string RoleColor { get; set; }
        User(String Username, String Role, int UserID)
        {
            this.Username = Username;
            this.Role = Role.Trim();
            this.RoleColor = this.Role == "ADMIN" ? "Gold" : this.Role == "MANAGER" ? "Silver" : "Brown";
            this.UserID = UserID;
        }

        public static User CreateUser(String Username, String Role, int UserID = 0)
        {
            return new User(Username, Role, UserID);
        }

        public static ObservableCollection<User> GetUsers(int RoleID = 0)
        {
            ObservableCollection<User> UserList = new ObservableCollection<User>();
            SqlConnection sqlConnection = Connection.GetConnection();
            ObjectCache cache = MemoryCache.Default;
            try
            {
                int UserID = Convert.ToInt32(cache.Get("UserRole"));
                if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();
                String Query = "SELECT * from [User] INNER JOIN [Role] on [User].[Role] = [Role].[RoleID] where [UserID] <> @UserID";
                if (RoleID != 0) Query = "SELECT * from [User] INNER JOIN [Role] on [User].[Role] = [Role].[RoleID] where [Role]=@RoleID and [UserID] <> @UserID";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@UserID", UserID);
                if (RoleID != 0) sqlCommand.Parameters.AddWithValue("@RoleID", RoleID);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserList.Add(User.CreateUser(reader[1].ToString(), reader[6].ToString(), Convert.ToInt32(reader[0])));
                    }
                }

                return UserList;
            }
            catch
            {
                MessageBox.Show("Something went wrong, please try again");
                return UserList;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
