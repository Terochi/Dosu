using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public record Lobby (
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("maxPlayers")] int MaxPlayers,
    [property: JsonPropertyName("players")] IReadOnlyList<Player> Players,
    [property: JsonPropertyName("modifiers")] Modifiers Modifiers,
    [property: JsonPropertyName("started")] bool Started,
    [property: JsonPropertyName("_id")] string ID
);

