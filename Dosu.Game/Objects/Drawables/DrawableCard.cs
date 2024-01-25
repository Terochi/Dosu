using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using osuTK;

namespace Dosu.Game.Objects.Drawables;

public abstract partial class DrawableCard : ClickableContainer
{
    // protected const float ASPECT_RATIO = 1.390625F;
    protected const float ASPECT_RATIO = 1.5F;

    public readonly Card Card;

    public override Vector2 Size => new(base.Size.X, base.Size.X * ASPECT_RATIO);

    public override float Height
    {
        get => Width * ASPECT_RATIO;
        set => base.Size = new Vector2(value / ASPECT_RATIO, value);
    }

    protected DrawableCard(Card card)
    {
        Card = card;
    }

    protected DrawableCard(CardType type, CardColor color)
    {
        Card = CardUtils.MakeCard(type, color);
    }

    protected override bool OnHover(HoverEvent e)
    {
        this.MoveToY(-20, 60, Easing.InQuad);

        return true;
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        this.MoveToY(0, 60, Easing.OutQuad);

        base.OnHoverLost(e);
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
