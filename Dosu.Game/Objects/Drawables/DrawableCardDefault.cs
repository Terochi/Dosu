using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace Dosu.Game.Objects.Drawables;

public partial class DrawableCardDefault : DrawableCard
{
    private static readonly float diagonal_rotation = (float)MathHelper.RadiansToDegrees(Math.Atan(ASPECT_RATIO));

    public DrawableCardDefault(Card card)
        : this(card.Type(), card.Color())
    {
    }

    public DrawableCardDefault(CardType type, CardColor color)
        : base(type, color)
    {
        Masking = true;
        BorderThickness = 10;
        BorderColour = Colour4.White;
        CornerRadius = 20;
        CornerExponent = 2;

        FillMode = FillMode.Fit;
        RelativeSizeAxes = Axes.Both;
        FillAspectRatio = 1f / ASPECT_RATIO;

        string cardText = type.AsString();
        bool isLongText = cardText.Length > 3;

        Children = new Drawable[]
        {
            new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = color.AsColour4()
            },
            new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = cardText,
                Font = FontUsage.Default.With(size: isLongText ? 36 : 80),
                Rotation = isLongText ? diagonal_rotation : 0f,
                Colour = Colour4.White,
                Shadow = true
            }
        };
    }
}
