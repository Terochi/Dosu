using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public record Modifiers (
    [property: JsonPropertyName("startingCardCount")] int StartingCardCount,
    [property: JsonPropertyName("fullGame")] bool FullGame
);
