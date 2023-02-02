using System.IO;
using System.Threading;
using System.Windows;

namespace HangUserInterface
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
            var t1 = ReadFileAsString("t1.txt");
            var t2 = ReadFileAsString("t2.txt");
            var t3 = ReadFileAsString("t3.txt");

            var text = $"{t1}, {t2}, {t3}";
            
            Title = text;
            MessageBox.Show($"{t1}, {t2}, {t3}");
        }

        private string ReadFileAsString(string fileName)
        {
            Thread.Sleep(3000);
            return File.ReadAllText(fileName);
        }
    }
}
