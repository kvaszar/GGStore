﻿using GGStore.Domain.GameDomain;

namespace GGStore.Domain;

public class Genre
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required List<Game> Games { get; set; }
}