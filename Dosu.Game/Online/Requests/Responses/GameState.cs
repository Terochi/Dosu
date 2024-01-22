using System.Collections.Generic;
using Dosu.Game.Objects;

namespace Dosu.Game.Online.Requests.Responses;

public record GameState(
    Info Info,
    List<Card> Cards
);
