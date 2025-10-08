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
    /// Interaction logic for Task5.xaml
    /// </summary>
    public partial class Task5 : Page
    {
        public Task5()
        {
            InitializeComponent();
        }
        private void Calculate_CLick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(EnteringWeigth.Text, out double pounds))
            {
                double kg = pounds * 0.453592;
                Result.Text = $"{kg:F2}";
            } 
            else
            {
                Result.Text = "Input correct number";
            }
        }
        private void Task6_Click(object sender, RoutedEventArgs e)
        {
            Task6.Navigate(new Task6());
        }
    }
}
