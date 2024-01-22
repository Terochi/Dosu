using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dosu.Game.Online.Requests.Responses;

public record Lobby(
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("maxPlayers")]
    int MaxPlayers,
    [property: JsonProperty("players")]
    IReadOnlyList<Player> Players,
    [property: JsonProperty("modifiers")]
    Modifiers Modifiers,
    [property: JsonProperty("started")]
    bool Started,
    [property: JsonProperty("_id")] string ID
);
