using System.Windows;
using System.Windows.Controls;
using Employee_Task_Manager.Entities;

namespace Employee_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for AdminTaskCard.xaml
    /// </summary>
    public partial class AdminTaskCard : UserControl
    {
        public AdminTaskCard()
        {
            InitializeComponent();
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            int CurrentTaskID = (int)((System.Windows.FrameworkElement)sender).Tag;
            int rowsAffected = Task.DeleteTask(CurrentTaskID);
            if (rowsAffected > 0)
            {
                MessageBox.Show("Task Deleted Successfully !");
                //TaskList.Remove(CurrentTask);
                //DashboardPage dashboardPage = new DashboardPage();
                //MainWindow.mainFrame.Navigate(dashboardPage);
            }

        }
    }
}
