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

public abstract class DrawableCardBuilder
{
    public abstract DrawableCard CreateCard(Card card);
}

public class DrawableCardDefaultBuilder : DrawableCardBuilder
{
    public override DrawableCard CreateCard(Card card)
    {
        return new DrawableCardDefault(card);
    }
}

public class DrawableCardTexturedBuilder : DrawableCardBuilder
{
    public override DrawableCard CreateCard(Card card)
    {
        return new DrawableCardTextured(card);
    }
}
