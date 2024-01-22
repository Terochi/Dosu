using osu.Framework.Graphics.Containers;

namespace Dosu.Game.Objects.Drawables;

public abstract partial class DrawableCard : ClickableContainer
{
    // protected const float ASPECT_RATIO = 89f / 64f;
    protected const float ASPECT_RATIO = 1.5F;

    public readonly Card Card;

    protected DrawableCard(Card card)
    {
        Card = card;
    }

    protected DrawableCard(CardType type, CardColor color)
    {
        Card = CardUtils.MakeCard(type, color);
    }
}

public abstract class DrawableCardBuilder
{
    public abstract DrawableCard CreateCard(Card card);
    public abstract DrawableCard CreateCard(CardType type, CardColor color);
}

public class DrawableCardDefaultBuilder : DrawableCardBuilder
{
    public override DrawableCard CreateCard(Card card)
    {
        return new DrawableCardDefault(card);
    }

    public override DrawableCard CreateCard(CardType type, CardColor color)
    {
        return new DrawableCardDefault(type, color);
    }
}

public class DrawableCardTexturedBuilder : DrawableCardBuilder
{
    public override DrawableCard CreateCard(Card card)
    {
        return new DrawableCardTextured(card);
    }

    public override DrawableCard CreateCard(CardType type, CardColor color)
    {
        return new DrawableCardTextured(type, color);
    }
}
