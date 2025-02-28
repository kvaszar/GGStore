using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using GGStore.Avalonia.Interfaces;
using GGStore.Avalonia.Services;
using GGStore.Avalonia.ViewModels;
using GGStore.Avalonia.Views;
using Microsoft.Extensions.DependencyInjection;

namespace GGStore.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            var services = new ServiceCollection();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<GamesTableViewModel>();
            services.AddSingleton<GenreTableViewModel>();

            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>(),
            });

            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider =>
                type => serviceProvider.GetRequiredService(type) as ViewModelBase ??
                        throw new NullReferenceException());

            var provider = services.BuildServiceProvider();

            desktop.MainWindow = provider.GetRequiredService<MainWindow>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}