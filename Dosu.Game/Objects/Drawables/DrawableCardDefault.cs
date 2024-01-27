using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Layout;
using osuTK;

namespace Dosu.Game.Objects.Drawables;

public partial class DrawableCardDefault : DrawableCard
{
    private const float center_scale = 0.375f;
    private const float corner_scale = 0.125f;

    private readonly LayoutValue layoutCache = new LayoutValue(Invalidation.DrawSize);

    public DrawableCardDefault(Card card)
        : base(card)
    {
        AddLayout(layoutCache);
    }

    protected override void Update()
    {
        base.Update();

        if (layoutCache.IsValid) return;

        load();

        layoutCache.Validate();
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        float height = DrawRectangle.Height;
        float border = height * 0.05f;
        InternalChildren = new[]
        {
            new Container
            {
                Masking = true,
                BorderThickness = border,
                BorderColour = Colour4.White,
                CornerRadius = border * 2,

                RelativeSizeAxes = Axes.Both,

                Child = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Card.Color().AsColour4()
                }
            },
            new Container
            {
                RelativeSizeAxes = Axes.Both,
                Padding = new MarginPadding(border * 1.5f),
                Children = new[]
                {
                    CardFont.GetCardFontDrawable(Card, height * center_scale, true).With(d =>
                    {
                        d.Anchor = Anchor.Centre;
                        d.Origin = Anchor.Centre;
                        d.Colour = Colour4.White;
                    }),
                    CardFont.GetCardFontDrawable(Card, height * corner_scale, true).With(d =>
                    {
                        d.Anchor = Anchor.TopLeft;
                        d.Origin = Anchor.TopLeft;
                        d.Colour = Colour4.White;
                    }),
                    CardFont.GetCardFontDrawable(Card, height * corner_scale, true).With(d =>
                    {
                        d.Anchor = Anchor.BottomRight;
                        d.Origin = Anchor.TopLeft;
                        d.Colour = Colour4.White;
                        d.Rotation = 180;
                    })
                }
            }
        };
    }
}

internal static class CardFont
{
    public static Drawable GetCardFontDrawable(Card card, float height, bool shadow = false)
    {
        var type = card.Type();

        IconUsage? icon = null;

        switch (type)
        {
            case CardType.Select:
                icon = FontAwesome.Solid.Expand;
                break;

            case CardType.Reverse:
                icon = FontAwesome.Solid.SyncAlt;
                break;

            case CardType.Skip:
                icon = FontAwesome.Solid.Ban;
                break;
        }

        if (icon != null)
        {
            return new SpriteIcon
            {
                Icon = icon.Value,
                Size = new Vector2(height),
                Shadow = shadow,
                ShadowOffset = new Vector2(0.0f, height * 0.06f * 1.5f)
            };
        }

        return new SpriteText
        {
            Text = type.AsString(),
            Font = FrameworkFont.Regular.With(size: height * 1.5f, weight: "Bold"),
            Shadow = shadow,
            Margin = new MarginPadding { Top = -height * .25f, Bottom = -height * .25f }
        };
    }
}
