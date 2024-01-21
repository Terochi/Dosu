using System.Collections.Generic;
using System.Text.Json.Serialization;
using Dosu.Game.Objects;

namespace Dosu.Game.Online.Requests.Responses;

public class Info
{
    [JsonPropertyName("drawPileCount")]
    public int DrawPileCount { get; set; }

    [JsonPropertyName("dropPileLast")]
    public Card LastDroppedCard { get; set; }

    [JsonPropertyName("players")]
    public List<GamePlayer> Players { get; set; }

    [JsonPropertyName("currentPlayerIndex")]
    public int CurrentPlayerIndex { get; set; }

    [JsonPropertyName("direction")]
    private bool clockwise { get; set; }

    public Direction Direction => clockwise ? Direction.Clockwise : Direction.CounterClockwise;

    [JsonPropertyName("animation")]
    public int AnimationIndex { get; set; }
}
