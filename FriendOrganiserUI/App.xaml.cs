using Autofac;
using FriendOrganiserUI.Data;
using FriendOrganiserUI.Startup;
using FriendOrganiserUI.ViewModel;
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
    }

}
