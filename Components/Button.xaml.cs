using System;
using System.Data.SqlClient;
using System.Runtime.Caching;
using System.Windows;
using System.Windows.Controls;
using Employee_Task_Manager.Entities;

namespace Employee_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for Button.xaml
    /// </summary>
    public partial class Button : UserControl
    {
        ObjectCache cache = MemoryCache.Default;
#pragma warning disable CS8618
        public Button()
#pragma warning restore CS8618
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public string Title { get; set; }
        public string Action { get; set; }

        // For Login
        public string Username { get; set; }
        public string Password { get; set; }

        // For Task Operations
        public Task task { get; set; }
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Status { get; set; }
        public string SetBackgroudColor { get; set; } = "#00CC9C";
        public string SetBorderBrushColor { get; set; } = "#00CC9C";

#pragma warning disable CS8603
        MainWindow MainWindow { get => Application.Current.MainWindow as MainWindow; }
#pragma warning restore CS8603

        private void OnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e);
            SqlConnection sqlConnection = Connection.GetConnection();
            string Owner = Convert.ToString(cache.Get("Username"));

            switch (Action)
            {
                case "GetStarted":
                    MainWindow.mainFrame.Navigate(new Uri("/Pages/Loginpage.xaml", UriKind.RelativeOrAbsolute));
                    break;

                case "Login":
                    try
                    {
                        Boolean UserFound = Login.UserLogin(Username, Password);
                        if (UserFound) MainWindow.mainFrame.Navigate(new Uri("/Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
                        else MessageBox.Show("Username or Password Incorrect, please try again");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show("Something went wrong, please try again");
                    }

                    break;

                case "AddTask":
                    try
                    {
                        Boolean AdditionSuccess = task.Save();
                        if (AdditionSuccess) MainWindow.mainFrame.Navigate(new Uri("/Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
                        else MessageBox.Show("Adding failed. Please try again!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show("Something went wrong, please try again");
                    }
                    break;
                case "Cancel":
                    MainWindow.mainFrame.Navigate(new Uri("/Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
                    break;

                default:
                    MainWindow.mainFrame.Navigate(new Uri("/Pages/Loginpage.xaml", UriKind.RelativeOrAbsolute));
                    break;
            }
        }
    }
}
