using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public record Endscreen(
    [property: JsonPropertyName("gameTime")]
    string GameTime,
    [property: JsonPropertyName("scoreboard")]
    List<GamePlayer> Scoreboard
);
