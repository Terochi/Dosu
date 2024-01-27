using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Utils;
using osuTK;

namespace Dosu.Game.Objects.Drawables;

public partial class CircularFlowContainer : CircularFlowContainer<Drawable>
{
}

public partial class CircularFlowContainer<T> : FlowContainer<T>
    where T : Drawable
{
    private Vector2 size;
    private const float max_inbetween_space = 50;

    public override float Height
    {
        get => size.Y;
        set
        {
            if (size.Y == value)
                return;

            if (value <= 0)
                return;

            size.Y = value;

            InvalidateLayout();
        }
    }

    public override float Width
    {
        get => size.X;
        set
        {
            if (size.X == value)
                return;

            if (value < 0)
                return;

            size.X = value;

            InvalidateLayout();
        }
    }

    public override Vector2 Size
    {
        get => size;
        set
        {
            Width = value.X;
            Height = value.Y;
        }
    }

    protected override IEnumerable<Vector2> ComputeLayoutPositions()
    {
        var children = FlowingChildren.ToArray();
        int childCount = children.Length;
        if (childCount == 0)
            yield break;

        //bool shouldBeBiggerArc = Height * 2f >= Width;
        float width = Width;
        //if (shouldBeBiggerArc) width -= Height;
        float circleRadius = (4 * Height * Height + width * width) / (8 * Height);
        float arc = 2f * MathF.Asin(width / (2f * circleRadius));
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
                (MathF.Cos(angle) * circleRadius + Width  * 0.5f),
                -(MathF.Sin(angle) * circleRadius - circleRadius));
        }
    }
}
