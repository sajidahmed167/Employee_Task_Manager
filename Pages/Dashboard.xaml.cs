using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Caching;
using Employee_Task_Manager.Entities;

namespace Employee_Task_Manager.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        ObjectCache cache = MemoryCache.Default;
        //ObservableCollection<Task> TaskList = new ObservableCollection<Task>();
        //ObservableCollection<User> UserList = new ObservableCollection<User>();

        public Dashboard()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        MainWindow MainWindow { get => Application.Current.MainWindow as MainWindow; }
        public string IsAdmin
        {
            get { return cache.Get("Role").ToString().Trim().ToLower() == "admin" ? "Visible" : "Hidden"; }
        }
        public string IsUser
        {
            get { return cache.Get("Role").ToString().Trim().ToLower() == "customer" ? "Visible" : "Hidden"; }
        }

        private void AddTaskPage(object sender, RoutedEventArgs e)
        {
            Task newTask = Task.CreateTask("", "", cache.Get("Username").ToString());
            AdminAddTask taskPage = new AdminAddTask(newTask);
            UserAddTask userTaskPage = new UserAddTask(newTask);

            if (cache.Get("Role").ToString().Trim().ToLower() == "admin") MainWindow.mainFrame.Navigate(taskPage);
            else MainWindow.mainFrame.Navigate(userTaskPage);
        }
    }
}
