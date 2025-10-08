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
    /// Interaction logic for Task4.xaml
    /// </summary>
    public partial class Task4 : Page
    {
        public Task4()
        {
            InitializeComponent();
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Btn1.Visibility = Visibility.Collapsed;
            Btn3.Visibility = Visibility.Visible;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Btn2.Visibility = Visibility.Collapsed;
            Btn5.Visibility = Visibility.Visible;
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            Btn3.Visibility = Visibility.Collapsed;
            Btn4.Visibility = Visibility.Visible;
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            Btn4.Visibility = Visibility.Collapsed;
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            Btn5.Visibility = Visibility.Collapsed;
        }

        private void Task5_Click(object sender, RoutedEventArgs e)
        {
            Task5.Navigate(new Task5());
        }
    }
}
