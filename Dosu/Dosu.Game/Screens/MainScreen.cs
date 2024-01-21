using System.Collections.Generic;
using System.Linq;
using Dosu.Game.Online;
using Dosu.Game.Online.Requests;
using Dosu.Game.Online.Requests.Responses;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osuTK;

namespace Dosu.Game.Screens
{
    public partial class MainScreen : Screen
    {
        private const string username = "test_user";

        [Resolved]
        private Client client { get; set; } = null!;

        private List<Lobby> lobbies;
        private BasicTextBox action;
        private BasicTextBox value;
        private FillFlowContainer<SpriteText> cards;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Colour4.Black
                },
                new FillFlowContainer
                {
                    Spacing = Vector2.One,
                    Children = new Drawable[]
                    {
                        new BasicButton
                        {
                            Action = () => client.StartGame(),
                            Text = "Start",
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.LeaveLobby(),
                            Text = "Leave",
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.CreateLobby("lobbyname", username),
                            Text = "Create",
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.RefreshLobbies(),
                            Text = "Refresh",
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.JoinLobby(lobbies.FirstOrDefault()?.ID, username),
                            Text = "Join",
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.KickPlayer(username),
                            Text = "Kick",
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.StopGame(),
                            Text = "Stop",
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.RestartGame(),
                            Text = "Restart",
                            Size = new Vector2(50)
                        },
                        action = new BasicTextBox
                        {
                            Size = new Vector2(200, 50),
                            PlaceholderText = "Action"
                        },
                        value = new BasicTextBox
                        {
                            Size = new Vector2(200, 50),
                            PlaceholderText = "Value"
                        },
                        new BasicButton
                        {
                            Action = () => client.UpdateGame(new GameCommand { Action = action.Text, Value = int.Parse(value.Text) }),
                            Text = "Update",
                            Size = new Vector2(50)
                        },
                        cards = new FillFlowContainer<SpriteText>
                        {
                            RelativeSizeAxes = Axes.X,
                            Height = 100,
                            Spacing = Vector2.One,
                            Direction = FillDirection.Horizontal
                        }
                    },
                    RelativeSizeAxes = Axes.Both,
                    Direction = FillDirection.Full
                }
            };

            client.OnLobbyJoin += () => Logger.Log("Joined");
            client.OnLobbyLeave += () => Logger.Log("Left");
            client.OnLobbyList += lobbies =>
            {
                this.lobbies = lobbies;
                Logger.Log($"First lobby: {lobbies.FirstOrDefault()?.Name}");
            };
            client.OnEdit += command => Logger.Log($"Command: {command.Action}");
            client.OnPopup += popup => Logger.Log($"Popup: {popup.Text}");
            client.OnGameUpdate += state =>
            {
                Logger.Log($"Direction: {state.Info?.Direction.ToString()}");
                Schedule(() =>
                {
                    var hand = state.Cards;
                    if (hand == null)
                        return;

                    if (state.Info != null)
                        hand.Add(state.Info.LastDroppedCard);

                    cards.Clear();

                    foreach (Card card in hand)
                    {
                        cards.Add(new SpriteText
                        {
                            RelativeSizeAxes = Axes.Y,
                            Width = 67,
                            Colour = card.Color().AsColour4(),
                            Text = card.Type().AsString()
                        });
                    }
                });
            };
            client.OnLobbyUpdate += lobby => Logger.Log($"Updated {lobby.Name}");

            client.Connect();
        }
    }
}
