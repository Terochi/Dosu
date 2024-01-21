using System.Collections.Generic;
using Dosu.Game.Objects;

namespace Dosu.Game.Online.Requests.Responses;

public class GameState
{
    public Info Info { get; set; }
    public List<Card> Cards { get; set; }
}
