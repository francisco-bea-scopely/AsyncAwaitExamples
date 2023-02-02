using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MigrateEventBasedUserInterface
{
    public static class WebView2Extensions
    {
        static TaskCompletionSource<CoreWebView2NavigationCompletedEventArgs> taskCompletionSource = null!;

        public static Task<CoreWebView2NavigationCompletedEventArgs> Navigate(this WebView2 webView2, Uri source)
        {
            taskCompletionSource = new TaskCompletionSource<CoreWebView2NavigationCompletedEventArgs>();

            webView2.NavigationCompleted += WebView2_NavigationCompleted;
            webView2.Source = source;

            return taskCompletionSource.Task;
        }

        private static void WebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            var webView2 = sender as WebView2;
            if (webView2 is not null)
            {
                webView2.NavigationCompleted -= WebView2_NavigationCompleted;

                taskCompletionSource.SetResult(e);
            }
        }
    }
}
