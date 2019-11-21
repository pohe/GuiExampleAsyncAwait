using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GuiExampleAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// http://richnewman.wordpress.com/2012/12/03/tutorial-asynchronous-programming-async-and-await-for-beginners/
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }

        private void ButtonDoItSyncClicked(object sender, RoutedEventArgs e)
        {
            String str = LongRunningMethod("synchronous");
            OutputLabel.Content = "Was working (but does not show)";
            OutputLabel.Content = str;
        }

        private void ButtonClearClicked(object sender, RoutedEventArgs e)
        {
            OutputLabel.Content = "";
        }

        private void ButtonDoItAsyncClicked(object sender, RoutedEventArgs e)
        {
            CallLongRunningMethod();
            OutputLabel.Content = "Working ...";
        }

        private async void CallLongRunningMethod()
        {
            string result = await LongRunningMethodAsync(" asynchronous");
            OutputLabel.Content = result;
        }

        private static Task<string> LongRunningMethodAsync(string message)
        {
            return Task.Run<string>(() => LongRunningMethod(message));
        }

        private static string LongRunningMethod(string message)
        {
            Thread.Sleep(2000); // to make the method long running ...
            return "Hello " + message;
        }
    }
}
