using CommunityToolkit.Mvvm.ComponentModel;
using GGStore.Avalonia.Interfaces;

namespace GGStore.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public INavigationService NavigationService { get; }

    public MainWindowViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.NavigateTo<GamesTableViewModel>();
    }
}