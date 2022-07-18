using System.Windows.Controls;
using System.Runtime.Caching;
using System.Collections.ObjectModel;

namespace Employee_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : UserControl
    {
        ObjectCache cache = MemoryCache.Default;
        public AdminDashboard()
        {
            InitializeComponent();
            this.DataContext = this;
            TaskCard_Loaded();
        }
        public string Role { get; set; } = "NA";
        public string ShouldRenderAdmin
        {
            get { return Role == cache.Get("Role").ToString()?.Trim().ToLower() ? "Visible" : "Hidden"; }
        }
        private void TaskCard_Loaded()
        {
            string Role = "admin";
            if(cache.Get("Role").ToString()?.Trim().ToLower() == Role)
            {
                ObservableCollection<Entities.Task> TaskList = Entities.Task.GetTasks(Role);
                TaskListItems.ItemsSource = TaskList;

                //TaskList.Remove(CurrentTask);
                //DashboardPage dashboardPage = new DashboardPage();
            }
        }
    }
}
