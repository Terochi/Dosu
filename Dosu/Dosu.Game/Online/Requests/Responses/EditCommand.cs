namespace Dosu.Game.Online.Requests.Responses;

public record EditCommand (
    string Action,
    bool Value
);