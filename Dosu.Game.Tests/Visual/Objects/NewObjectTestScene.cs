using System;
using Dosu.Game.Objects;
using Dosu.Game.Objects.Drawables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;
using osuTK;

namespace Dosu.Game.Tests.Visual.Objects;

public partial class NewObjectTestScene : TestScene
{
    private CircularFlowContainer cards;

    public NewObjectTestScene()
    {
        var defaultBuilder = new DrawableCardDefaultBuilder();
        var texturedBuilder = new DrawableCardTexturedBuilder();

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
                cards = new CircularFlowContainer
                {
                    Size = new Vector2(400, 50),
                    //RelativeSizeAxes = Axes.Both
                }
            }
        };

        AddStep("Add random default card", () => addCard((Card)Random.Shared.Next((int)Card.WildPlusFour), defaultBuilder));
        AddStep("Add random textured card", () => addCard((Card)Random.Shared.Next((int)Card.WildPlusFour), texturedBuilder));
    }

    private void addCard(Card card, DrawableCardBuilder builder)
    {
        Container drawableCard;
        cards.Add(drawableCard = new Container
        {
            Child = builder.CreateCard(card).With(c =>
            {
                c.Origin = Anchor.BottomCentre;
                c.Height = 100;
            })
        });
        cards.ChangeChildDepth(drawableCard, -(float)card);
        cards.SetLayoutPosition(drawableCard, (float)card);
    }
}
