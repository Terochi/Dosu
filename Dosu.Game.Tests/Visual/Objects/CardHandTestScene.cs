using System;
using Dosu.Game.Objects;
using Dosu.Game.Objects.Drawables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;
using osuTK;

namespace Dosu.Game.Tests.Visual.Objects;

public partial class CardHandTestScene : TestScene
{
    private readonly DrawableHand cards;

    public CardHandTestScene()
    {
        Child = new Container
        {
            Anchor = Anchor.BottomCentre,
            Origin = Anchor.BottomCentre,
            RelativePositionAxes = Axes.Y,
            Size = new Vector2(400, 50),
            Y = -0.2f,
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Colour4.Red
                },
                cards = new DrawableHand
                {
                    RelativeSizeAxes = Axes.Both
                }
            }
        };

        AddStep("Add random default card", () => addCard((Card)Random.Shared.Next((int)Card.WildPlusFour)));
        AddStep("Add random textured card", () => addCard((Card)Random.Shared.Next((int)Card.WildPlusFour), CardSkin.Textured));
    }

    private void addCard(Card card, CardSkin skin = CardSkin.Default)
    {
        DrawableCardContainer drawableCard;
        cards.Add(drawableCard = new DrawableCardContainer(card, skin)
        {
            Origin = Anchor.BottomCentre,
            Size = new Vector2(67, 125),
        });
        cards.ChangeChildDepth(drawableCard, -(float)card);
        cards.SetLayoutPosition(drawableCard, (float)card);
    }
}
