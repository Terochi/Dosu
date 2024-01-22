using Newtonsoft.Json;

namespace Dosu.Game.Online.Requests.Responses;

public record Modifiers(
    [property: JsonProperty("startingCardCount")]
    int StartingCardCount,
    [property: JsonProperty("fullGame")]
    bool FullGame
);
