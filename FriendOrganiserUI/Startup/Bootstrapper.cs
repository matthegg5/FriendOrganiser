using Autofac;
using FriendOrganiserUI.Services;
using FriendOrganiserUI.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace FriendOrganiserUI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            builder.RegisterType<LookupDataService>().As<ILookupDataService>();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();

            return builder.Build();
        }

        public IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()) // Set the base path to the current directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Load appsettings.json

            return builder.Build();

        }
    }
}
