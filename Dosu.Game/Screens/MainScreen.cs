using System.Collections.Generic;
using System.Linq;
using Dosu.Game.Objects.Cards;
using Dosu.Game.Objects.Cards.Drawables;
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
using osuTK.Graphics;

namespace Dosu.Game.Screens
{
    public partial class MainScreen : Screen
    {
        private const string username = "user_name";

        [Resolved]
        private Client client { get; set; } = null!;

        private List<Lobby> lobbies;
        private BasicTextBox action;
        private BasicTextBox value;
        private FillFlowContainer<DrawableCard> cards;
        private FillFlowContainer container;
        private DrawableCard topCard;
        private SpriteText cardCount;

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
                            Action = () =>
                            {
                                int? val = null;
                                if (int.TryParse(value.Text, out int result))
                                    val = result;
                                client.UpdateGame(new GameCommand(action.Text, val));
                            },
                            Text = "Update",
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.UpdateGame(new GameCommand("colorPicker", 0)),
                            BackgroundColour = Color4.Red,
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.UpdateGame(new GameCommand("colorPicker", 1)),
                            BackgroundColour = Color4.Gold,
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.UpdateGame(new GameCommand("colorPicker", 2)),
                            BackgroundColour = Color4.Lime,
                            Size = new Vector2(50)
                        },
                        new BasicButton
                        {
                            Action = () => client.UpdateGame(new GameCommand("colorPicker", 3)),
                            BackgroundColour = Color4.Aqua,
                            Size = new Vector2(50)
                        },
                        cardCount = new SpriteText
                        {
                            Font = FontUsage.Default.With(size: 30)
                        },
                        cards = new FillFlowContainer<DrawableCard>
                        {
                            RelativeSizeAxes = Axes.X,
                            Height = 150,
                            Spacing = new Vector2(5),
                            Direction = FillDirection.Full,
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
                // Logger.Log($"Direction: {state.Info?.Direction.ToString()}");
                Schedule(() =>
                {
                    if (state.Info != null)
                    {
                        cardCount.Text =
                            $"{string.Join(" | ", state.Info.Players.Select(p => $"{p.Username}: {p.CardCount}"))} => "
                            + $"Current: {state.Info.Players[state.Info.CurrentPlayerIndex].Username}";
                        updateTopCard(state.Info.LastDroppedCard);
                    }

                    if (state.Cards == null)
                        return;

                    List<DrawableCard> drawableCards = new List<DrawableCard>(state.Cards.Count);

                    cards.Clear();

                    for (var i = 0; i < state.Cards.Count; i++)
                    {
                        int cardIndex = i;
                        //DrawableCard drawableCard = builder.CreateCard(state.Cards[cardIndex]);
                        //drawableCard.Action = () => client.UpdateGame(new GameCommand("playCard", cardIndex));
                        //drawableCards.Add(drawableCard);
                    }

                    drawableCards.Sort((e1, e2) => e1.Card - e2.Card);

                    cards.AddRange(drawableCards);
                });
            };
            client.OnLobbyUpdate += lobby => Logger.Log($"Updated {lobby.Name}");

            client.Connect();
        }

        private void updateTopCard(Card newCard)
        {
            if (topCard != null)
                container.Remove(topCard, true);

            //topCard = builder.CreateCard(newCard);
            // topCard.Size = new Vector2(0.25f);
            // topCard.Action = () => client.UpdateGame(new GameCommand("draw", null));
            // container.Add(topCard);
        }
    }
}
