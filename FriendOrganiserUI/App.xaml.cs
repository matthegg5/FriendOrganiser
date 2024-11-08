using Autofac;
using FriendOrganiserUI.Startup;
using System.Net.Http;
using System.Windows;

namespace FriendOrganiserUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs exceptionEventArgs)
        {
            MessageBox.Show("Unexpected error, please contact your system administrator." 
                + Environment.NewLine + exceptionEventArgs.Exception.Message, "Unexpected error");

            exceptionEventArgs.Handled = true;
        }
    }

}
