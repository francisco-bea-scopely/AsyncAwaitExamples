using Microsoft.Web.WebView2.Core;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MigrateEventBasedUserInterface
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
            await webView.Navigate(new Uri("https://www.scopely.com/"));

            await Task.Delay(TimeSpan.FromSeconds(2));
            await webView.Navigate(new Uri("https://www.scopely.com/en/games/yahtzee-with-buddies"));

            await Task.Delay(TimeSpan.FromSeconds(2));
            await webView.Navigate(new Uri("https://scopely.helpshift.com/hc/en/32-yahtzee-with-buddies/"));

            await Task.Delay(TimeSpan.FromSeconds(2));
            MessageBox.Show("Customer suppport sent");
        }
    }
}
