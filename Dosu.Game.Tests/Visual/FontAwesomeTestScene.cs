using System;
using System.Linq;
using System.Reflection;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using osuTK;

namespace Dosu.Game.Tests.Visual;

public partial class FontAwesomeTestScene : TestScene
{
    private FillFlowContainer<SpriteIcon> icons;

    public FontAwesomeTestScene()
    {
        Add(icons = new FillFlowContainer<SpriteIcon>
        {
            RelativeSizeAxes = Axes.Both,
            Spacing = new Vector2(2)
        });

        AddStep("show solid", () => showCategory(typeof(FontAwesome.Solid)));
        AddStep("show regular", () => showCategory(typeof(FontAwesome.Regular)));
        AddStep("show brands", () => showCategory(typeof(FontAwesome.Brands)));
    }

    private void showCategory(Type category)
    {
        icons.Clear();

        foreach (var (name, icon) in category
                                     .GetProperties(BindingFlags.Public | BindingFlags.Static)
                                     .ToDictionary(f => f.Name,
                                         f => (IconUsage)f.GetValue(null)!))
        {
            icons.Add(new SpriteIcon
            {
                Name = name,
                Icon = icon,
                Size = new Vector2(20)
            });
        }
    }
}
