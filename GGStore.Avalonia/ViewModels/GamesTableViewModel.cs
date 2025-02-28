using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GGStore.Avalonia.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GGStore.Avalonia.ViewModels;

public partial class GamesTableViewModel : ViewModelBase
{
    private const string ApiBaseAddress = "http://localhost:5080";

    private HashSet<Game> _dbGames = [];
    private readonly List<int> _gameIdsToRemove = [];
    [ObservableProperty] private ObservableCollection<Game> _games = [];
    private readonly HttpClient _httpClient = new();

    [RelayCommand]
    private async Task FetchGamesAsync()
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"{ApiBaseAddress}/Game");
        using var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync() ?? throw new NullReferenceException();
        var games = JsonSerializer.Deserialize<HashSet<Game>>(content)
                    ?? throw new Exception();
        _dbGames = games;
        Games = new ObservableCollection<Game>(games);
    }

    [RelayCommand]
    private async Task UpdateGamesAsync()
    {
        foreach (var gameId in _gameIdsToRemove)
        {
            await DeleteGameAsync(gameId);
        }
        var changedGames = Games.Where(game =>
            _dbGames.Any(dbGame => game.Title != dbGame.Title ||
                                   game.Description != dbGame.Description ||
                                   game.Publisher != dbGame.Publisher ||
                                   game.DateRelease != dbGame.DateRelease));
        foreach (var game in changedGames)
        {
            var serializedGame = JsonSerializer.Serialize(game);
            using var requestContent = new StringContent(serializedGame, Encoding.UTF8, "application/json");
            using var putResponse =
                await _httpClient.PutAsync($"{ApiBaseAddress}/Game?id={game.Id}", requestContent);
            putResponse.EnsureSuccessStatusCode();
        }
    }


    private async Task DeleteGameAsync(int id) => await _httpClient.DeleteAsync($"{ApiBaseAddress}/Game?id={id}");

    [RelayCommand]
    private void RemoveGame(int id)
    {
        Games.Remove(Games.Single(g => g.Id == id));
        _gameIdsToRemove.Add(id);
    }
}