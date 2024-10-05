using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestAvaloniaApp.Models;

namespace TestAvaloniaApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<GameModel> _games = [];
    private readonly HttpRequestMessage _request = new(HttpMethod.Get, "http://localhost:5080/Game");
    private readonly HttpClient _httpClient = new();

    [RelayCommand]
    private async Task FetchGames()
    {
        using var response = await _httpClient.SendAsync(_request);
        var content = await response.Content.ReadAsStringAsync() ?? throw new NullReferenceException();
        var gamesModel = JsonSerializer.Deserialize<List<GameModel>>(content)
                        ?? throw new Exception();
        Games = new ObservableCollection<GameModel>(gamesModel);
    }
}