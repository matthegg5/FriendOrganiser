using Autofac;
using FriendOrganiser.AvaloniaUI.Views;
using FriendOrganiserUI.Data;
using FriendOrganiserUI.ViewModel;

namespace FriendOrganiserUI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();

            return builder.Build();
        }
    }
}