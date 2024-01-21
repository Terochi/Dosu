using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace Dosu.Game.Objects.Drawables;

public partial class DrawableCardTextured : DrawableCard
{
    private const int cardWidth = 100;
    private const int cardHeight = 150;

    public DrawableCardTextured(Card card)
        : base(card)
    {
        Masking = true;
        BorderThickness = 10;
        BorderColour = Colour4.White;
        CornerRadius = 20;
        CornerExponent = 2;
    }

    public DrawableCardTextured(CardType type, CardColor color)
        : this(CardUtils.MakeCard(type, color))
    {
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        FillMode = FillMode.Fit;
        RelativeSizeAxes = Axes.Both;
        FillAspectRatio = 1f / ASPECT_RATIO;

        Children = new Drawable[]
        {
            new Sprite
            {
                RelativeSizeAxes = Axes.Both,
                Texture = new TextureRegion(textures.Get("cards"),
                    new RectangleI((int)Card.Type() * cardWidth, (int)Card.Color() * cardHeight, cardWidth, cardHeight),
                    WrapMode.None, WrapMode.None),
                TextureRelativeSizeAxes = Axes.Both
            }
        };
    }
}
