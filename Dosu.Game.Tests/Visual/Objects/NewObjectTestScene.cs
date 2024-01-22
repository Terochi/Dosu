using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using osuTK.Graphics;

namespace Dosu.Game.Tests.Visual.Objects;

public partial class NewObjectTestScene : TestScene
{
    public NewObjectTestScene()
    {
        Child = new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            AutoSizeAxes = Axes.Both,

            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Alpha = 0.2f,
                    Colour = Color4.Pink
                },
                new SpriteText { AllowMultiline = false, Text = "testtesttesttest" }
            }
        };
    }
}
