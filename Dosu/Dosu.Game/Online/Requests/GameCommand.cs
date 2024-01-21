namespace Dosu.Game.Online.Requests;

public record GameCommand (
    string Action,
    int? Value
);