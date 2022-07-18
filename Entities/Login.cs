using System;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Runtime.Caching;

namespace Employee_Task_Manager.Entities
{
    public static class Login
    {
        public static Boolean UserLogin(string Username, string Password)
        {
            ObjectCache cache = MemoryCache.Default;
            SqlConnection sqlConnection = Connection.GetConnection();

            try
            {
                if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();
                String Query = "SELECT TOP 1 * from [dbo].[User] where Username=@Username and Password=@Password";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", Username);
                sqlCommand.Parameters.AddWithValue("@Password", Password);
                Boolean UserFound = false;
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // User found
                        UserFound = true;

                        // Cache the User for 2 hours
                        CacheItemPolicy policy = new CacheItemPolicy();
                        policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(2.0);

                        // Adding items to cache with expiration policy and the object value  
                        cache.Set("Username", reader[1].ToString(), policy);
                        cache.Set("UserId", reader[0].ToString(), policy);
                        cache.Set("Role", reader[3].ToString(), policy);

                    }
                }
                return UserFound;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Something went wrong, please try again");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
