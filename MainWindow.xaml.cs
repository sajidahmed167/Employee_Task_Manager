using System;
using System.Windows;

namespace Employee_Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new Uri("/Pages/Homepage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
