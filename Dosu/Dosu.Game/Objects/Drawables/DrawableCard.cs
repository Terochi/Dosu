using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace Dosu.Game.Objects.Drawables;

public partial class DrawableCard : ClickableContainer
{
    public readonly Card Card;

    private Box background;
    private SpriteText text;

    private const float aspect_ratio = 89f / 64f;
    private static readonly float diagonal_rotation = (float)MathHelper.RadiansToDegrees(Math.Atan(aspect_ratio));

    private Vector2 drawSizePrev = Vector2.Zero;

    public DrawableCard(Card card)
        : this(card.Type(), card.Color())
    {
    }

    public DrawableCard(CardType type, CardColor color)
    {
        Card = CardUtils.MakeCard(color, type);
        Masking = true;
        BorderThickness = 10;
        BorderColour = Colour4.White;
        CornerRadius = 20;
        CornerExponent = 2;

        FillMode = FillMode.Fit;
        RelativeSizeAxes = Axes.Both;
        FillAspectRatio = 1f / aspect_ratio;

        string cardText = type.AsString();
        bool isLongText = cardText.Length > 2;

        Children = new Drawable[]
        {
            background = new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = color.AsColour4()
            },
            text = new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = cardText,
                Font = FontUsage.Default.With(size: isLongText ? 36 : 60),
                Rotation = isLongText ? diagonal_rotation : 0f,
                Colour = Colour4.White,
                Shadow = true
            }
        };
    }
}
