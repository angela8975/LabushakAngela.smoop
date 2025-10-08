using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWPF_1
{
    /// <summary>
    /// Interaction logic for Task2.xaml
    /// </summary>
    public partial class Task2 : Page
    {
        public Task2()
        {
            InitializeComponent();
        }
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            Kyky.Visibility = Visibility.Collapsed;
        }
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            Kyky.Visibility = Visibility.Visible;
        }
        private void Task3_Click(object sender, RoutedEventArgs e)
        {
            Task3.Navigate(new Task3());
        }
    }
}
