using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace WpfLinqApp 
{
    public partial class MainWindow : Window
    {
        public class Worker
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Education { get; set; }
            public string Specialty { get; set; }
            public int BirthYear { get; set; }
        }
        public class Salary
        {
            public int WorkerId { get; set; }
            public decimal FirstHalfYear { get; set; }
            public decimal SecondHalfYear { get; set; }
        }
        public class CombinedData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Education { get; set; }
            public string Specialty { get; set; }
            public int Age { get; set; }
            public decimal YearlySalary { get; set; }
            public decimal SecondHalfYear { get; set; }
        }
        private List<CombinedData> allData;
        private const char SEPARATOR = ';';

        public MainWindow()
        {
            InitializeComponent();
            LoadAllData(); 
        }
        private void LoadAllData()
        {
            try
            {
                List<Worker> workers = LoadWorkers("Workers.txt");
                List<Salary> salaries = LoadSalaries("Salary.txt");
                int currentYear = DateTime.Now.Year;
                var combinedQuery = from w in workers
                                    join s in salaries on w.Id equals s.WorkerId
                                    select new CombinedData
                                    {
                                        Id = w.Id,
                                        Name = w.Name,
                                        Education = w.Education,
                                        Specialty = w.Specialty,
                                        Age = currentYear - w.BirthYear,
                                        YearlySalary = s.FirstHalfYear + s.SecondHalfYear,
                                        SecondHalfYear = s.SecondHalfYear
                                    };
                allData = combinedQuery.ToList();
                // Показуємо всі дані в сітці при старті
                resultsGrid.ItemsSource = allData;
                UpdateStatus($"Успішно завантажено {allData.Count} записів.", Colors.Green);
            }
            catch (FileNotFoundException ex)
            {
                UpdateStatus($"ПОМИЛКА: Файл не знайдено! ({ex.FileName}). Переконайтеся, що файли лежать у папці 'bin/Debug...'", Colors.Red);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Критична помилка: {ex.Message}", Colors.Red);
            }
        }
        // 1. Вивести прізвища та ініціали співробітників, вік яких більше ніж 35 років.
        private void BtnQuery1_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDataLoaded())
            {
                var query = allData.Where(d => d.Age > 35)
                                 .Select(d => new
                                 {
                                     d.Name,
                                     d.Age
                                 });

                resultsGrid.ItemsSource = query.ToList();
                UpdateStatus($"Запит 1: Знайдено {query.Count()} співробітників > 35 років.", Colors.Black);
            }
        }
        // 2. Вивести ідентифікаційний код та фах співробітника з найбільшою зарплатою за друге півріччя.
        private void BtnQuery2_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDataLoaded())
            {
                var query = allData.OrderByDescending(d => d.SecondHalfYear)
                                 .Select(d => new
                                 {
                                     d.Id,
                                     d.Name,
                                     d.Specialty,
                                     d.SecondHalfYear
                                 })
                                 .FirstOrDefault(); // Беремо лише одного
                if (query != null)
                {
                    // Відображаємо одного співробітника (поміщаємо його у список)
                    resultsGrid.ItemsSource = new List<object> { query };
                    UpdateStatus($"Запит 2: Співробітник з max ЗП ({query.SecondHalfYear:C}): {query.Name}", Colors.Black);
                }
            }
        }
        // 3. Вивести прізвища, ініціали та вид освіти тих співробітників, зарплата яких за рік нижче середньої.
        private void BtnQuery3_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDataLoaded())
            {
                decimal averageYearlySalary = allData.Average(d => d.YearlySalary);
                var query = allData.Where(d => d.YearlySalary < averageYearlySalary)
                                 .Select(d => new
                                 {
                                     d.Name,
                                     d.Education,
                                     d.YearlySalary
                                 });
                resultsGrid.ItemsSource = query.ToList();
                UpdateStatus($"Запит 3: Знайдено {query.Count()} співробітників з ЗП нижче середньої ({averageYearlySalary:C}).", Colors.Black);
            }
        }
        // 4. Вивести прізвища усіх співробітників з вищою освітою та зарплатою не менше значення введеного користувачем.
        private void BtnQuery4_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckDataLoaded()) return;

            if (!decimal.TryParse(txtMinSalary.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal minSalaryInput))
            {
                UpdateStatus("Помилка: Введіть коректне число у поле 'Мін. зарплата'.", Colors.Red);
                return;
            }
            var query = allData.Where(d =>
                                    d.Education.Trim().Equals("вища", StringComparison.OrdinalIgnoreCase) &&
                                    d.YearlySalary >= minSalaryInput)
                                 .Select(d => new
                                 {
                                     d.Name,
                                     d.Education,
                                     d.YearlySalary
                                 });
            resultsGrid.ItemsSource = query.ToList();
            UpdateStatus($"Запит 4: Знайдено {query.Count()} співробітників з вищою освітою та ЗП >= {minSalaryInput:C}.", Colors.Black);
        }
        // --- Допоміжні методи ---
        private bool CheckDataLoaded()
        {
            if (allData == null || !allData.Any())
            {
                UpdateStatus("Помилка: Дані не завантажені. Перевірте файли.", Colors.Red);
                return false;
            }
            return true;
        }
        private void UpdateStatus(string message, Color color)
        {
            statusBarText.Text = message;
            statusBarText.Foreground = new SolidColorBrush(color);
        }
        public static List<Worker> LoadWorkers(string filePath)
        {
            var workers = new List<Worker>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split(SEPARATOR);
                if (parts.Length == 5)
                {
                    workers.Add(new Worker
                    {
                        Id = int.Parse(parts[0].Trim()),
                        Name = parts[1].Trim(),
                        Education = parts[2].Trim(),
                        Specialty = parts[3].Trim(),
                        BirthYear = int.Parse(parts[4].Trim())
                    });
                }
            }
            return workers;
        }
        public static List<Salary> LoadSalaries(string filePath)
        {
            var salaries = new List<Salary>();
            var lines = File.ReadAllLines(filePath);
            var culture = CultureInfo.InvariantCulture; // Для парсингу чисел з крапкою 
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split(SEPARATOR);
                if (parts.Length == 3)
                {
                    salaries.Add(new Salary
                    {
                        WorkerId = int.Parse(parts[0].Trim()),
                        FirstHalfYear = decimal.Parse(parts[1].Trim(), culture),
                        SecondHalfYear = decimal.Parse(parts[2].Trim(), culture)
                    });
                }
            }
            return salaries;
        }
    }
}
