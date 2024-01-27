using osu.Framework.Graphics.Containers;

namespace Dosu.Game.Objects.Drawables;

public abstract partial class DrawableCard : ClickableContainer
{
    public readonly Card Card;

    protected DrawableCard(Card card)
    {
        Card = card;
    }
}
