using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public class GamePlayer
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("cardCount")]
    public int CardCount { get; set; }

    [JsonPropertyName("nameplate")]
    public string Nameplate { get; set; }
}
