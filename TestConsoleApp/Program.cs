using System.Text.Json;
using System.Text.Json.Serialization;
using TestConsoleApp;

using var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5080/Game");
var httpClient = new HttpClient();
using HttpResponseMessage response = await httpClient.SendAsync(request);
string content = await response.Content.ReadAsStringAsync();
var gamesModel = JsonSerializer.Deserialize<List<GameModel>>(content) 
    ?? throw new Exception();

foreach (var gameModel in gamesModel)
{
    Console.WriteLine($"Название игры: {gameModel.Title}");
    Console.WriteLine($"Описание игры: {gameModel.Description}");
}

Console.ReadLine();


namespace TestConsoleApp
{
    class GameModel
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("description")]
        public required string Description { get; set; }

        [JsonPropertyName("publisher")]
        public required string Publisher { get; set; }

        [JsonPropertyName("dateRelease")]
        public required DateOnly DateRelease { get; set; } 
    }
}