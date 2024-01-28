using osu.Framework.Graphics.Containers;

namespace Dosu.Game.Objects.Cards.Drawables;

public abstract partial class DrawableCard : Container
{
    public readonly Card Card;

    protected DrawableCard(Card card)
    {
        Card = card;
    }
}
