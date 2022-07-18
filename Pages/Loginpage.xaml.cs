using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Runtime.Caching;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Employee_Task_Manager.Entities;

namespace Employee_Task_Manager.Pages
{
    /// <summary>
    /// Interaction logic for Loginpage.xaml
    /// </summary>
    public partial class Loginpage : Page
    {
        public Loginpage()
        {
            InitializeComponent();

            LoginButton.Username = txtUsername.Text;
            LoginButton.Password = txtPassword.Password;
        }

        private void UsernameUpdated(object sender, TextChangedEventArgs e)
        {
            LoginButton.Username = txtUsername.Text;
        }

        private void PasswordUpdated(object sender, RoutedEventArgs e)
        {
            LoginButton.Password = txtPassword.Password;
        }
    }
}
