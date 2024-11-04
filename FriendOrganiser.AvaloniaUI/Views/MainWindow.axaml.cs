using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using FriendOrganiserUI.ViewModel;

namespace FriendOrganiser.AvaloniaUI.Views;

public partial class MainWindow : Window
{
    public readonly MainViewModel _viewModel;
    public MainWindow(MainViewModel viewModel)
    {
        //InitializeComponent();
        DataContext = viewModel;
        Loaded += MainWindow_Loaded;
        _viewModel = viewModel;
    }

    private async void MainWindow_Loaded(object? sender, RoutedEventArgs e)
    {
        await _viewModel.Load();
    }
}