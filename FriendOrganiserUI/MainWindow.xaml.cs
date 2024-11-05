using FriendOrganiserUI.ViewModels;
using System.Windows;

namespace FriendOrganiserUI
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            Loaded += MainWindow_Loaded;
            _viewModel = viewModel;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
             await _viewModel.Load();
        }
    }
}