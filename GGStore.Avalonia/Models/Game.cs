using System;
using System.Text.Json.Serialization;

namespace GGStore.Avalonia.Models;

public class Game
{
    [JsonPropertyName("id")] public required int Id { get; set; }

    [JsonPropertyName("title")] public required string Title { get; set; }

    [JsonPropertyName("description")] public required string Description { get; set; }

    [JsonPropertyName("publisher")] public required string Publisher { get; set; }

    [JsonPropertyName("dateRelease")] public required DateOnly DateRelease { get; set; }
}