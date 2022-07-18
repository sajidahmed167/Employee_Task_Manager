using Employee_Task_Manager.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Employee_Task_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AdminAddTask.xaml
    /// </summary>
    public partial class AdminAddTask : Page
    {
        public AdminAddTask(Task task)
        {
            this.TaskTitle = task.Title;
            this.Description = task.Description;
            InitializeComponent();
            this.DataContext = this;

            SaveTaskButton.task = task;
            FillComboBox();
        }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public void FillComboBox()
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from [dbo].[User]", sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbAssignTo.ItemsSource = dt.DefaultView;
                cbAssignTo.DisplayMemberPath = "Username";
                cbAssignTo.SelectedValuePath = "Username";
                cmd.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
        private void ComboBox_SelectionChangedAssignee(object sender, SelectionChangedEventArgs e)
        {
            SaveTaskButton.task.Owner = ((System.Windows.Controls.Primitives.Selector)sender).SelectedValue as string;
        }
    }
}
