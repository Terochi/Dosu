using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;

namespace Dosu.Game.Objects.Drawables;

public partial class DrawableCardContainer : Container<DrawableCard>
{
    private const double animation_duration = 60;

    // protected const float ASPECT_RATIO = 1.390625F;
    protected const float ASPECT_RATIO = 1.5F;
    protected override Container<DrawableCard> Content { get; }

    public DrawableCardContainer()
    {
        InternalChild = Content = new Container<DrawableCard>
        {
            RelativeSizeAxes = Axes.Both,
            FillMode = FillMode.Fit,
            FillAspectRatio = 1f / ASPECT_RATIO,
            Anchor = Anchor.BottomCentre,
            Origin = Anchor.BottomCentre,
        };
    }

    protected override bool OnHover(HoverEvent e)
    {
        Content.MoveToY(-20, animation_duration, Easing.InQuad);

        return true;
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        Content.MoveToY(0, animation_duration, Easing.OutQuad);

        base.OnHoverLost(e);
    }
}
