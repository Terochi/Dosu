using System.Text.Json.Serialization;

namespace Dosu.Game.Online;

public class Modifiers
{
    [JsonPropertyName("startingCardCount")]
    public int StartingCardCount { get; set; }

    [JsonPropertyName("fullGame")]
    public bool FullGame { get; set; }
}
