using System.Collections.Generic;
using Newtonsoft.Json;
using Dosu.Game.Objects.Cards;

namespace Dosu.Game.Online.Requests.Responses;

public record Info(
    [property: JsonProperty("drawPileCount")]
    int DrawPileCount,
    [property: JsonProperty("dropPileLast")]
    Card LastDroppedCard,
    [property: JsonProperty("players")]
    IReadOnlyList<GamePlayer> Players,
    [property: JsonProperty("lockin")] IReadOnlyList<GamePlayer> LockedIn,
    [property: JsonProperty("currentPlayerIndex")]
    int CurrentPlayerIndex,
    [property: JsonProperty("direction")]
    bool Clockwise,
    [property: JsonProperty("animation")]
    int AnimationIndex
)
{
    public Direction Direction => Clockwise ? Direction.Clockwise : Direction.CounterClockwise;
}
