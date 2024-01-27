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
    private readonly FillFlowContainer<DrawableCardContainer> cards;

    public CardTestScene()
    {
        Add(cards = new FillFlowContainer<DrawableCardContainer>
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.X,
            Height = 250,
            Spacing = new Vector2(5, 0),
            Direction = FillDirection.Horizontal
        });

        AddStep("Add all default types", () =>
        {
            addCard(Card.WildPlusFour);
            addCard(Card.WildSelect);
            addCard(Card.RedReverse);
            addCard(Card.Red0);
            addCard(Card.RedSkip);
        });

        AddStep("Add random default card", () => addCard((Card)Random.Shared.Next((int)Card.WildPlusFour)));
        AddStep("Add random textured card", () => addCard((Card)Random.Shared.Next((int)Card.WildPlusFour), CardSkin.Textured));
    }

    private void addCard(Card card, CardSkin skin = CardSkin.Default) =>
        cards.Add(new DrawableCardContainer(card, skin)
        {
            RelativeSizeAxes = Axes.Both,
            FillMode = FillMode.Fit,
            FillAspectRatio = 1 / 1.75f
        });
}
