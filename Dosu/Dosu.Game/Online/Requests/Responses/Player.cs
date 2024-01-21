using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public class Player
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("sid")]
    public string SockedID { get; set; }
}
