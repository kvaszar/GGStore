using GGStore.Avalonia.ViewModels;

namespace GGStore.Avalonia.Interfaces;

public interface INavigationService
{
    public ViewModelBase CurrentViewModel { get; }
    void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
}