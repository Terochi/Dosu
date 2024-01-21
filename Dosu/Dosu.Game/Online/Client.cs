#define LOCALHOST

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dosu.Game.Objects;
using Dosu.Game.Online.Requests;
using Dosu.Game.Online.Requests.Responses;

namespace Dosu.Game.Online;

public class Client
{
#if LOCALHOST
    private const string uri = "http://localhost:3000/";
#else
    private const string uri = "http://pawele.possessed.us/";
#endif

    private SocketIOClient.SocketIO io;

    private SocketIOClient.SocketIO client
    {
        get
        {
            if (io == null) initialize();
            return io;
        }
    }

    public Task Connect()
    {
        return client.ConnectAsync();
    }

    public Task Disconnect()
    {
        return client.DisconnectAsync();
    }

    public event Action OnConnect;
    public event Action OnDisconnect;
    public event Action<string> OnError;
    public event Action OnPing;
    public event Action<TimeSpan> OnPong;
    public event Action<int> OnReconnect;
    public event Action<int> OnReconnectTry;
    public event Action<string> OnReconnectError;
    public event Action OnReconnectFail;

    public event Action<List<Lobby>> OnLobbyList;
    public event Action OnLobbyLeave;
    public event Action OnLobbyJoin;
    public event Action<Lobby> OnLobbyUpdate;
    public event Action<EditCommand> OnEdit;
    public event Action<GameState> OnGameUpdate;
    public event Action<Popup> OnPopup;
    public event Action<Endscreen> OnEndscreen;

    public Task CreateLobby(string lobbyName, string username)
    {
        return client.EmitAsync("serverCreateLobby", lobbyName, username);
    }

    public Task RefreshLobbies()
    {
        return client.EmitAsync("serverRefreshLobby");
    }

    public Task JoinLobby(string lobbyId, string username)
    {
        return client.EmitAsync("serverJoinLobby", lobbyId, username);
    }

    public Task LeaveLobby()
    {
        return client.EmitAsync("serverLeaveLobby");
    }

    public Task KickPlayer(string username)
    {
        return client.EmitAsync("serverLeaveLobby", username);
    }

    public Task StartGame()
    {
        return client.EmitAsync("serverGameStart");
    }

    public Task StopGame()
    {
        return client.EmitAsync("serverGameStop");
    }

    public Task RestartGame()
    {
        return client.EmitAsync("serverGameRestart");
    }

    public Task UpdateGame(GameCommand command)
    {
        return client.EmitAsync("serverGameUpdate", command.Action, command.Value);
    }

    private void initialize()
    {
        io = new SocketIOClient.SocketIO(uri);

        io.On("clientLobbyList", response => OnLobbyList?.Invoke(response.GetValue<List<Lobby>>()));
        io.On("clientEdit", response => OnEdit?.Invoke(new EditCommand(response.GetValue<string>(), response.GetValue<bool>(1))));
        io.On("clientLeaveLobby", _ => OnLobbyLeave?.Invoke());
        io.On("clientJoinedLobby", _ => OnLobbyJoin?.Invoke());
        io.On("clientPopup", response => OnPopup?.Invoke(response.GetValue<Popup>()));
        io.On("clientEndscreen", response => OnEndscreen?.Invoke(response.GetValue<Endscreen>()));
        io.On("clientUpdateLobby", response => OnLobbyUpdate?.Invoke(response.GetValue<Lobby>()));
        io.On("clientGameUpdate", response => OnGameUpdate?.Invoke(new GameState(response.GetValue<Info>(), response.GetValue<List<Card>>(1))));

        io.OnConnected += (_, _) => OnConnect?.Invoke();
        io.OnDisconnected += (_, _) => OnDisconnect?.Invoke();
        io.OnError += (_, errorMessage) => OnError?.Invoke(errorMessage);
        io.OnPing += (_, _) => OnPing?.Invoke();
        io.OnPong += (_, span) => OnPong?.Invoke(span);
        io.OnReconnected += (_, attemptCount) => OnReconnect?.Invoke(attemptCount);
        io.OnReconnectAttempt += (_, attemptCount) => OnReconnectTry?.Invoke(attemptCount);
        io.OnReconnectError += (_, exception) => OnReconnectError?.Invoke(exception.Message);
        io.OnReconnectFailed += (_, _) => OnReconnectFail?.Invoke();
    }
}
