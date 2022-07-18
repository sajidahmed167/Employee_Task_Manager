using System.Windows.Controls;
using Employee_Task_Manager.Entities;

namespace Employee_Task_Manager.Pages
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class UserAddTask : Page
    {
        public UserAddTask(Task task)
        {
            this.TaskTitle = task.Title;
            this.Description = task.Description;
            InitializeComponent();
            this.DataContext = this;

            SaveTaskButton.task = task;
        }
        public string TaskTitle { get; set; }
        public string Description { get; set; }

        private void TaskTitleUpdated(object sender, TextChangedEventArgs e)
        {
            SaveTaskButton.task.Title = txtTitle.Text;
        }

        private void TaskDescriptionUpdated(object sender, TextChangedEventArgs e)
        {
            SaveTaskButton.task.Description = txtDescription.Text;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaveTaskButton.task.Status = (e.AddedItems[0] as ComboBoxItem).Content as string;
        }
    }
}
