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
    private FillFlowContainer<DrawableCard> cards;

    public CardTestScene()
    {
        var defaultBuilder = new DrawableCardDefaultBuilder();
        var texturedBuilder = new DrawableCardTexturedBuilder();
        Add(cards = new FillFlowContainer<DrawableCard>
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.X,
            Height = 200,
            Spacing = new Vector2(5, 0),
            Direction = FillDirection.Horizontal
        });

        AddStep("Add all default types", () =>
        {
            addCard(Card.WildPlusFour, defaultBuilder);
            addCard(Card.WildSelect, defaultBuilder);
            addCard(Card.RedReverse, defaultBuilder);
            addCard(Card.Red0, defaultBuilder);
            addCard(Card.RedSkip, defaultBuilder);
        });

        AddStep("Add random default card", () => addCard((Card)Random.Shared.Next((int)Card.WildPlusFour), defaultBuilder));
        AddStep("Add random textured card", () => addCard((Card)Random.Shared.Next((int)Card.WildPlusFour), texturedBuilder));
    }

    private void addCard(Card card, DrawableCardBuilder builder) =>
        cards.Add(builder.CreateCard(card).With(c => c.Height = cards.Height));
}
