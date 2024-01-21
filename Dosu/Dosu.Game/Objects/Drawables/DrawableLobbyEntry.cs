using System.Collections.Generic;
using Dosu.Game.Online.Requests.Responses;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace Dosu.Game.Objects.Drawables;

public partial class DrawableLobbyEntry : Container
{
    private readonly string id;
    private Bindable<string> name = new Bindable<string>();
    private BindableInt maxPlayers = new BindableInt();
    private BindableList<Player> players = new BindableList<Player>();
    private Bindable<Modifiers> modifiers = new Bindable<Modifiers>();
    private BindableBool started = new BindableBool();

    private Circle activeCircle;

    public DrawableLobbyEntry(Lobby initialState)
    {
        id = initialState.ID;

        updateState(initialState);
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        Children = new Drawable[]
        {
            new Container
            {
                RelativeSizeAxes = Axes.Both,
                Masking = true,
                CornerRadius = 30,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.Gray
                    },
                    new FillFlowContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        Direction = FillDirection.Horizontal,
                        Origin = Anchor.CentreLeft,
                        Anchor = Anchor.CentreLeft,
                        Children = new Drawable[]
                        {
                            new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                FillAspectRatio = 1,
                                FillMode = FillMode.Fit,
                                Margin = new MarginPadding(20),
                                Scale = new Vector2(0.375f),
                                Origin = Anchor.CentreLeft,
                                Anchor = Anchor.CentreLeft,
                                Children = new[]
                                {
                                    new Circle
                                    {
                                        Colour = Colour4.White,
                                        FillAspectRatio = 1,
                                        FillMode = FillMode.Fit,
                                        RelativeSizeAxes = Axes.Both,
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                    },
                                    activeCircle = new Circle
                                    {
                                        Colour = Colour4.Red,
                                        FillAspectRatio = 1,
                                        FillMode = FillMode.Fit,
                                        RelativeSizeAxes = Axes.Both,
                                        Scale = new Vector2(0.85f),
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                    }
                                }
                            },
                            new SpriteText
                            {
                                Text = "Placeholder lobby",
                                Font = FontUsage.Default.With(size: 50),
                                Anchor = Anchor.CentreLeft,
                                Origin = Anchor.CentreLeft,
                            }
                        }
                    },
                    new FillFlowContainer
                    {
                        RelativeSizeAxes = Axes.Both,
                        Direction = FillDirection.Horizontal,
                        Children = new Drawable[]
                        {
                            new Container
                            {
                                Anchor = Anchor.CentreRight,
                                Origin = Anchor.CentreRight,
                                FillAspectRatio = 1,
                                FillMode = FillMode.Fit,
                                AutoSizeAxes = Axes.X,
                                RelativeSizeAxes = Axes.Y,
                                Children = new Drawable[]
                                {
                                    new Box
                                    {
                                        Colour = Colour4.White,
                                        RelativeSizeAxes = Axes.Both
                                    },
                                    new SpriteText
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Text = "1/4",
                                        Colour = Colour4.Black,
                                    }
                                }
                            }
                        }
                    }
                },
            }
        };
    }

    private void updateState(Lobby lobby)
    {
        name.Value = lobby.Name;
        maxPlayers.Value = lobby.MaxPlayers;
        players.ReplaceRange(0, players.Count, lobby.Players ?? new List<Player>
        {
            Capacity = 0
        });
        modifiers.Value = lobby.Modifiers;
        started.Value = lobby.Started;
    }
}
