namespace Dosu.Game;

public interface ICommand<T>
{
    public string Action { get; protected set; }

    public T Value { get; protected set; }
}
