using System;
using Dosu.Game.Objects;
using Dosu.Game.Objects.Drawables;
using Dosu.Game.Tests.Visual.Screens;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace Dosu.Game.Tests.Visual.Objects;

public partial class CardTestScene : DosuTestScene
{
    public CardTestScene()
    {
        FillFlowContainer<DrawableCard> cards;
        Add(cards = new FillFlowContainer<DrawableCard>
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.X,
            Height = 200,
            Spacing = new Vector2(5, 0),
            Direction = FillDirection.Horizontal
        });

        AddStep("Add random card", () => cards.Add(new DrawableCard((Card)Random.Shared.Next((int)Card.WildPlusFour))));
    }
}
