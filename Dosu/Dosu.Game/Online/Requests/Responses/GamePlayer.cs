using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public record GamePlayer (
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("cardCount")] int CardCount,
        [property: JsonPropertyName("nameplate")] string Nameplate
    );