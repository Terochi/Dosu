using System.Collections.Generic;
using System.Linq;
using Dosu.Game.Objects;
using Dosu.Game.Objects.Drawables;
using Dosu.Game.Online;
using Dosu.Game.Online.Requests;
using Dosu.Game.Online.Requests.Responses;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
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
        private FillFlowContainer<DrawableCard> cards;
        private FillFlowContainer container;
        private DrawableCard topCard;

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
                container = new FillFlowContainer
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
                            Action = () => client.KickPlayer("username"),
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
                            Action = () => {
                                int? value = null;
                                if (int.TryParse(this.value.Text, out int result))
                                    value = result;
                                client.UpdateGame(new GameCommand (action.Text, value));
                            },
                            Text = "Update",
                            Size = new Vector2(50)
                        },
                        cards = new FillFlowContainer<DrawableCard>
                        {
                            RelativeSizeAxes = Axes.X,
                            Height = 150,
                            Spacing = new Vector2(5, 0),
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
            client.OnEndscreen += endscreen => Logger.Log($"Game ended! time: {endscreen.GameTime}, winner: {endscreen.Scoreboard.FirstOrDefault()?.Username}");
            client.OnGameUpdate += state =>
            {
                Logger.Log($"Direction: {state.Info?.Direction.ToString()}");
                Schedule(() =>
                {
                    if (state.Info != null)
                    {
                        updateTopCard(state.Info.LastDroppedCard);
                    }

                    if (state.Cards == null)
                        return;

                    cards.Clear();

                    for (var i = 0; i < state.Cards.Count; i++)
                    {
                        int cardIndex = i;
                        cards.Add(new DrawableCard(state.Cards[cardIndex])
                        {
                            Action = () => client.UpdateGame(new GameCommand("playCard", cardIndex))
                        });
                    }
                });
            };
            client.OnLobbyUpdate += lobby => Logger.Log($"Updated {lobby.Name}");

            client.Connect();
        }

        private void updateTopCard(Card newCard)
        {
            if (topCard != null)
                container.Remove(topCard, true);

            container.Add(topCard = new DrawableCard(newCard)
            {
                Size = new Vector2(0.25f)
            });
        }
    }
}
