using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;

namespace Dosu.Game.Objects.Drawables;

public partial class DrawableCardContainer : Container<DrawableCard>
{
    private const double animation_duration = 60;

    private readonly DrawableCard drawableCard;

    // protected const float ASPECT_RATIO = 1.390625F;
    protected const float ASPECT_RATIO = 1.5F;

    public DrawableCardContainer(Card card, CardSkin skin = CardSkin.Default)
    {
        InternalChild = drawableCard = createDrawableCard(card, skin).With(c =>
        {
            c.Anchor = c.Origin = Anchor.BottomCentre;
            c.RelativeSizeAxes = Axes.Both;
            c.FillMode = FillMode.Fit;
            c.FillAspectRatio = 1f / ASPECT_RATIO;
        });
    }

    private DrawableCard createDrawableCard(Card card, CardSkin skin)
    {
        return skin switch
        {
            CardSkin.Default => new DrawableCardDefault(card),
            CardSkin.Textured => new DrawableCardTextured(card),
            _ => throw new ArgumentOutOfRangeException(nameof(skin), skin, null)
        };
    }

    protected override bool OnHover(HoverEvent e)
    {
        drawableCard.MoveToY(drawableCard.DrawHeight - DrawHeight, animation_duration, Easing.InQuad);

        return true;
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        drawableCard.MoveToY(0, animation_duration, Easing.OutQuad);

        base.OnHoverLost(e);
    }
}
