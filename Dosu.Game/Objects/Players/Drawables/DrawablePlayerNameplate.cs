using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace Dosu.Game.Objects.Players.Drawables;

public partial class DrawablePlayerNameplate : Container
{
    public readonly Bindable<string> PlayerName = new Bindable<string>("Guest");
    public readonly Bindable<string> PlayerTitle = new Bindable<string>();
    public readonly Bindable<int> CardCount = new Bindable<int>(0);
    private SpriteText nameText;
    private SpriteText titleText;
    private SpriteText cardCountText;


    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {

        Child = new Container()
        {
            Size = new Vector2(0.5f, 1),
            RelativeSizeAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Child = new Container()
            {
                FillMode = FillMode.Fit,
                FillAspectRatio = 250 / 75f,
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {

                    new Sprite()
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Texture = textures.Get("dev-nameplate"),

                    },
                    nameText = new SpriteText()
                    {
                        Font = FrameworkFont.Regular.With(size: 40f),
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                        Margin = new MarginPadding() { Left = 20, Top = 20},
                    },
                    titleText = new SpriteText()
                    {
                        Font = FrameworkFont.Regular.With(size: 30f, weight: "Bold"),
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        Margin = new MarginPadding() { Left = 20 },
                    },
                    cardCountText = new SpriteText()
                    {
                        Font = FrameworkFont.Regular.With(size: 40f),
                        RelativeAnchorPosition = new Vector2(0.70f, 0.76f),
                        Origin = Anchor.CentreRight,
                    }
                }
            },
        };



        PlayerName.BindValueChanged(name =>
        {
            nameText.Text = name.NewValue;
        }, true);

        PlayerTitle.BindValueChanged(title =>
        {
            if (string.IsNullOrEmpty(title.NewValue))
                titleText.Text = "";
            else
                titleText.Text = "TITLE: " + title.NewValue;
        }, true);

        CardCount.BindValueChanged(count =>
        {
            cardCountText.Text = count.NewValue.ToString();
        }, true);
    }
}
