namespace Dosu.Game.Online.Requests.Responses;

public class EditCommand : ICommand<bool>
{
    public string Action { get; set; }

    public bool Value { get; set; }
}
