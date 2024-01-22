using Newtonsoft.Json;

namespace Dosu.Game.Online.Requests.Responses;

public record GamePlayer(
    [property: JsonProperty("username")]
    string Username,
    [property: JsonProperty("cardCount")]
    int CardCount,
    [property: JsonProperty("nameplate")]
    string Nameplate
);
