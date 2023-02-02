using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncUserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var t1 = await ReadFileAsStringAsync("t1.txt");
            var t2 = await ReadFileAsStringAsync("t2.txt");
            var t3 = await ReadFileAsStringAsync("t3.txt");

            var text = $"{t1}, {t2}, {t3}";

            Title = text;
            MessageBox.Show($"{t1}, {t2}, {t3}");
        }

        private async Task<string> ReadFileAsStringAsync(string fileName)
        {
            await Task.Delay(3000);
            return await File.ReadAllTextAsync(fileName);
        }
    }
}
