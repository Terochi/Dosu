using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dosu.Game.Online;

public static class Client
{
    private static SocketIOClient.SocketIO io;

    private static SocketIOClient.SocketIO client
    {
        get
        {
            if (io == null) initialize();
            return io;
        }
    }

    public static Task Connect()
    {
        return client.ConnectAsync();
    }

    public static Task Disconnect()
    {
        return client.DisconnectAsync();
    }

    public static event Action<List<Lobby>> OnLobbyList;
    public static event Action OnLobbyLeave;
    public static event Action OnLobbyJoin;
    public static event Action<Lobby> OnLobbyUpdate;
    public static event Action<EditCommand> OnEdit;
    public static event Action<GameState> OnGameUpdate;
    public static event Action<Popup> OnPopup;

    public static Task CreateLobby(string lobbyName, string username)
    {
        return client.EmitAsync("serverCreateLobby", lobbyName, username);
    }

    public static Task RefreshLobbies()
    {
        return client.EmitAsync("serverRefreshLobby");
    }

    public static Task JoinLobby(string lobbyId, string username)
    {
        return client.EmitAsync("serverJoinLobby", lobbyId, username);
    }

    public static Task LeaveLobby()
    {
        return client.EmitAsync("serverLeaveLobby");
    }

    public static Task KickPlayer(string username)
    {
        return client.EmitAsync("serverLeaveLobby", username);
    }

    public static Task StartGame()
    {
        return client.EmitAsync("serverGameStart");
    }

    public static Task StopGame()
    {
        return client.EmitAsync("serverGameStop");
    }

    public static Task RestartGame()
    {
        return client.EmitAsync("serverGameRestart");
    }

    public static Task UpdateGame(GameCommand command)
    {
        return client.EmitAsync("serverGameUpdate", command.Action, command.Value);
    }

    private static void initialize()
    {
        io = new SocketIOClient.SocketIO("http://pawele.possessed.us/");

        io.On("clientLobbyList", response => OnLobbyList?.Invoke(response.GetValue<List<Lobby>>()));
        io.On("clientEdit", response => OnEdit?.Invoke(response.GetValue<EditCommand>()));
        io.On("clientLeaveLobby", _ => OnLobbyLeave?.Invoke());
        io.On("clientJoinedLobby", _ => OnLobbyJoin?.Invoke());
        io.On("clientPopup", response => OnPopup?.Invoke(response.GetValue<Popup>()));
        io.On("clientUpdateLobby", response => OnLobbyUpdate?.Invoke(response.GetValue<Lobby>()));
        io.On("clientGameUpdate", response => OnGameUpdate?.Invoke(response.GetValue<GameState>()));
    }
}
