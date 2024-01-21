namespace Dosu.Game.Online.Requests;

public class GameCommand : ICommand<int>
{
    public string Action { get; set; }

    public int Value { get; set; }
}
