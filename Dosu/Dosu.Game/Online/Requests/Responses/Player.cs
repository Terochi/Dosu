using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public record Player (
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("sid")] string SocketID
);
