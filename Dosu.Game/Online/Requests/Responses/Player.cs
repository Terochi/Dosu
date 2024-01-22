using Newtonsoft.Json;

namespace Dosu.Game.Online.Requests.Responses;

public record Player(
    [property: JsonProperty("username")]
    string Username,
    [property: JsonProperty("sid")] string SocketID
);
