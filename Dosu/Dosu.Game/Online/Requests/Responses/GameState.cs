using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public class GameState
{
    [JsonPropertyName("gameinfo")]
    public Info Info { get; set; }

    [JsonPropertyName("hand")]
    public List<Card> Cards { get; set; }
}
