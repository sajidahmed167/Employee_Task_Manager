using System;
using System.Runtime.Caching;
using System.Windows;
using System.Windows.Controls;

namespace Employee_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for Navbar.xaml
    /// </summary>
    public partial class Navbar : UserControl
    {
        ObjectCache cache = MemoryCache.Default;
        public Navbar()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        MainWindow MainWindow { get => Application.Current.MainWindow as MainWindow; }
        public string RenderButton { get; set; } = "false";
        public string ShouldRender
        {
            get { return RenderButton == "true" ? "Visible" : "Hidden"; }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            // remove user from Cache
            cache.Remove("Username");
            cache.Remove("Id");
            cache.Remove("Role");
            MainWindow.mainFrame.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
