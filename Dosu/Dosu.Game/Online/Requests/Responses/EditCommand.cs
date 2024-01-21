using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public class EditCommand : ICommand<bool>
{
    [JsonPropertyName("action")]
    public string Action { get; set; }

    [JsonPropertyName("value")]
    public bool Value { get; set; }
}
