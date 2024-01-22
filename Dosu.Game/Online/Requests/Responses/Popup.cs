using Newtonsoft.Json;

namespace Dosu.Game.Online.Requests.Responses;

public record Popup(
    [property: JsonProperty("toast")] bool IsToast,
    [property: JsonProperty("title")] string Title,
    [property: JsonProperty("icon")] string Icon,
    [property: JsonProperty("text")] string Text,
    [property: JsonProperty("timer")] int Timer,
    [property: JsonProperty("timerProgressBar")]
    bool TimerProgressBar,
    [property: JsonProperty("confirmButtonText")]
    string ConfirmButtonText
);
