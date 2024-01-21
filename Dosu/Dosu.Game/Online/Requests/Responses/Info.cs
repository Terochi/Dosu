using System.Collections.Generic;
using System.Text.Json.Serialization;
using Dosu.Game.Objects;

namespace Dosu.Game.Online.Requests.Responses;

public record Info(
    [property: JsonPropertyName("drawPileCount")]
    int DrawPileCount,
    [property: JsonPropertyName("dropPileLast")]
    Card LastDroppedCard,
    [property: JsonPropertyName("players")]
    IReadOnlyList<GamePlayer> Players,
    [property: JsonPropertyName("lockin")] IReadOnlyList<GamePlayer> LockedIn,
    [property: JsonPropertyName("currentPlayerIndex")]
    int CurrentPlayerIndex,
    [property: JsonPropertyName("direction")]
    bool Clockwise,
    [property: JsonPropertyName("animation")]
    int AnimationIndex
)
{
    public Direction Direction => Clockwise ? Direction.Clockwise : Direction.CounterClockwise;
}
