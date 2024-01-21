using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dosu.Game.Online;

public class Lobby
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("maxPlayers")]
    public int MaxPlayers { get; set; }

    [JsonPropertyName("players")]
    public List<Player> Players { get; set; }

    [JsonPropertyName("modifiers")]
    public Modifiers Modifiers { get; set; }

    [JsonPropertyName("started")]
    public bool Started { get; set; }

    [JsonPropertyName("_id")]
    public string ID { get; set; }
}
