using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics.Containers;
using osu.Framework.Utils;
using osuTK;

namespace Dosu.Game.Objects.Drawables;

public partial class DrawableHand : FlowContainer<DrawableCardContainer>
{
    private const float max_inbetween_space = 50;

    protected override IEnumerable<Vector2> ComputeLayoutPositions()
    {
        var children = FlowingChildren.ToArray();
        int childCount = children.Length;
        if (childCount == 0)
            yield break;

        //bool shouldBeBiggerArc = DrawHeight * 2f >= DrawWidth;
        //if (shouldBeBiggerArc) DrawWidth -= DrawHeight;
        float circleRadius = (4 * DrawHeight * DrawHeight + DrawWidth * DrawWidth) / (8 * DrawHeight);
        float arc = 2f * MathF.Asin(DrawWidth / (2f * circleRadius));
        //if (shouldBeBiggerArc) arc = MathF.Tau - arc;

        float arcDelta = arc / (childCount + 1);

        float angle0 = (MathF.PI + arc) * 0.5f;

        float length = arc * circleRadius;
        float lengthDelta = length / (childCount + 1);

        if (lengthDelta > max_inbetween_space)
        {
            float newArc = max_inbetween_space * (childCount + 1) / circleRadius;
            arcDelta = newArc / (childCount + 1);
            angle0 -= (arc - newArc) * 0.5f;
        }

        for (var i = 0; i < children.Length; i++)
        {
            var child = children[i];

            float angle = angle0 - (i + 1) * arcDelta;
            child.Rotation = 90f - MathUtils.RadiansToDegrees(angle);
            yield return new Vector2(
                (MathF.Cos(angle) * circleRadius + DrawWidth * 0.5f),
                -(MathF.Sin(angle) * circleRadius - circleRadius));
        }
    }
}
