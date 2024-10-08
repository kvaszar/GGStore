using System.Text.Json;
using System.Text.Json.Serialization;

//using var requestGet = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7292/Game");
//var httpClientGet = new HttpClient();
//using HttpResponseMessage response = await httpClientGet.SendAsync(requestGet);
//string content = await response.Content.ReadAsStringAsync();
//var gamesModel = JsonSerializer.Deserialize<List<GameModel>>(content)
//    ?? throw new Exception();

//foreach (var gameModel in gamesModel)
//{
//    Console.WriteLine($"Название игры: {gameModel.Title}");
//    Console.WriteLine($"Описание игры: {gameModel.Description}");
//}

//var httpClientDelete = new HttpClient();
//var responseDelete = await httpClientDelete.DeleteAsync($"https://localhost:7292/Game/{4}");


//var companyForCreation = new GameDto
//{
//    Title = "Death Stranding",
//    Description = "Необычно",
//    IdGenres = [1, 2],
//    Publisher = "Японцы",
//    DateRelease = new DateOnly(2022, 10, 8),
//};

//var company = JsonSerializer.Serialize(companyForCreation);
//var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
//var responsePost = await httpClientDelete.PostAsync("https://localhost:7292/Game", requestContent);
//responsePost.EnsureSuccessStatusCode();
//var contentPost = await responsePost.Content.ReadAsStringAsync();
//var createdCompany = JsonSerializer.Deserialize<int>(contentPost);


//var companyForCreation = new GameDto
//{
//    Title = "Death Stranding1111",
//    Description = "Необычно",
//    IdGenres = [1, 2],
//    Publisher = "Японцы",
//    DateRelease = new DateOnly(2022, 10, 8),
//};
//var company = JsonSerializer.Serialize(companyForCreation);
//var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
//var response = await new HttpClient().PutAsync("https://localhost:7292/Game?id=3", requestContent);
//response.EnsureSuccessStatusCode();

using var requestGet = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7292/Game/3");
var httpClientGet = new HttpClient();
using HttpResponseMessage response = await httpClientGet.SendAsync(requestGet);
string content = await response.Content.ReadAsStringAsync();
var gamesModel = JsonSerializer.Deserialize<GameModel>(content)
    ?? throw new Exception();

Console.ReadLine();

public class GameDto
{
    public required string Title { get; set; }
    public required string? Description { get; set; }
    public required List<int> IdGenres { get; set; }
    public required string Publisher { get; set; }
    public required DateOnly DateRelease { get; set; }
}

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