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
    /// Interaction logic for Task3.xaml
    /// </summary>
    public partial class Task3 : Page
    {
        public Task3()
        {
            InitializeComponent();
        }
        private void HideText_Click(object sender, RoutedEventArgs e)
        {
            incomingText.Visibility = Visibility.Hidden;
        }
        private void ShowText_Click(object sender, RoutedEventArgs e)
        {
            incomingText.Visibility = Visibility.Visible;
        }
        private void DeleteText_Click(object sender, RoutedEventArgs e)
        {
            incomingText.Clear();
        }
        private void Task4_Click(object sender, RoutedEventArgs e)
        {
            Task4.Navigate(new Task4());
        }
    }
}
