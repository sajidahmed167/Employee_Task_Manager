using System.Windows.Controls;
using System.Runtime.Caching;
using System.Collections.ObjectModel;

namespace Employee_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : UserControl
    {
        ObjectCache cache = MemoryCache.Default;
        public UserDashboard()
        {
            InitializeComponent();
            this.DataContext = this;
            TaskCard_Loaded();
        }
        public string Role { get; set; } = "NA";
        public string ShouldRenderCustomer
        {
            get { return Role == cache.Get("Role").ToString()?.Trim().ToLower() ? "Visible" : "Hidden"; }
        }
        private void TaskCard_Loaded()
        {
            string Role = "customer";

            if (cache.Get("Role").ToString()?.Trim().ToLower() == Role)
            {
                ObservableCollection<Entities.Task> TaskList = Entities.Task.GetTasks(Role);
                UsersTaskListItems.ItemsSource = TaskList;
            }
        }
    }
}
