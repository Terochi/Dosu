using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dosu.Game.Online.Requests.Responses;

public record Endscreen(
    [property: JsonProperty("gameTime")]
    string GameTime,
    [property: JsonProperty("scoreboard")]
    List<GamePlayer> Scoreboard
);
