using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace DeadlockUserInterface
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = ReadFileAsync("t1.txt").Result;

            MessageBox.Show(text);
        }

        private async Task<string> ReadFileAsync(string path)
        {
            return await File.ReadAllTextAsync(path);
        }
    }
}
