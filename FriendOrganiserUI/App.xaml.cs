using Autofac;
using FriendOrganiserUI.Startup;
using System.Net.Http;
using System.Windows;
using Microsoft.Extensions.Configuration;

namespace FriendOrganiserUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AppSettings AppSettings { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var configuration = bootstrapper.BuildConfiguration();

            AppSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs exceptionEventArgs)
        {
            MessageBox.Show("Unexpected error, please contact your system administrator." 
                + Environment.NewLine + exceptionEventArgs.Exception.Message, "Unexpected error");

            exceptionEventArgs.Handled = true;

            this.Shutdown();
        }
    }

}
