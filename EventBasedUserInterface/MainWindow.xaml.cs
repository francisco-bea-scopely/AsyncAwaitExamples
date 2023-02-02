using Microsoft.Web.WebView2.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EventBasedUserInterface
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
            webView.NavigationCompleted += Scopely_NavigationCompleted;
            webView.Source = new Uri("https://www.scopely.com/");
        }

        private async void Scopely_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            webView.NavigationCompleted -= Scopely_NavigationCompleted;
            webView.NavigationCompleted += Yahtzee_NavigationCompleted;
            webView.Source = new Uri("https://www.scopely.com/en/games/yahtzee-with-buddies");
        }

        private async void Yahtzee_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            webView.NavigationCompleted -= Yahtzee_NavigationCompleted;
            webView.NavigationCompleted += CustomerSupport_NavigationCompleted;
            webView.Source = new Uri("https://scopely.helpshift.com/hc/en/32-yahtzee-with-buddies/");
        }

        private async void CustomerSupport_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            webView.NavigationCompleted -= CustomerSupport_NavigationCompleted;

            MessageBox.Show("Customer suppport sent");
        }
    }
}
