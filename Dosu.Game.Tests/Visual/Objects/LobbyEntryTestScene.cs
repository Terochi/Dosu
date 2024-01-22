using System;
using Dosu.Game.Objects.Drawables;
using Dosu.Game.Online.Requests.Responses;
using Dosu.Game.Tests.Visual.Screens;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace Dosu.Game.Tests.Visual.Objects;

public partial class LobbyEntryTestScene : DosuTestScene
{
    public LobbyEntryTestScene()
    {
        FillFlowContainer<DrawableLobbyEntry> lobbies;
        int height = 150;
        Add(lobbies = new FillFlowContainer<DrawableLobbyEntry>
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            Spacing = new Vector2(0, 5),
            Direction = FillDirection.Vertical
        });

        AddSliderStep("height", 50, 300, 150, h => height = h);
        AddStep("Add lobby", () => lobbies.Add(new DrawableLobbyEntry(new Lobby(null, 0, ArraySegment<Player>.Empty, null, false, null))
        {
            RelativeSizeAxes = Axes.X,
            Height = height
        }));
    }
}
