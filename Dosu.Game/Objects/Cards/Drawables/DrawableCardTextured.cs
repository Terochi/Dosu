using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace Dosu.Game.Objects.Cards.Drawables;

public partial class DrawableCardTextured : DrawableCard
{
    private const int card_texture_width = 100;
    private const int card_texture_height = 150;

    public DrawableCardTextured(Card card)
        : base(card)
    {
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        InternalChild = new Sprite
        {
            RelativeSizeAxes = Axes.Both,
            Texture = new TextureRegion(textures.Get("dev-cards"),
                new RectangleI(
                    (int)Card.Type() * card_texture_width, (int)Card.Color() * card_texture_height,
                    card_texture_width, card_texture_height),
                WrapMode.None, WrapMode.None),
            TextureRelativeSizeAxes = Axes.Both
        };
    }
}
