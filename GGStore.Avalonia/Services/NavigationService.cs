using System;
using CommunityToolkit.Mvvm.ComponentModel;
using GGStore.Avalonia.Interfaces;
using GGStore.Avalonia.ViewModels;

namespace GGStore.Avalonia.Services;

public partial class NavigationService(Func<Type, ViewModelBase> viewModelFactory)
    : ObservableObject, INavigationService
{
    [ObservableProperty] private ViewModelBase? _currentViewModel;

    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase =>
        CurrentViewModel = viewModelFactory.Invoke(typeof(TViewModel));
}