using System.Text.Json.Serialization;

namespace Dosu.Game.Online.Requests.Responses;

public record Popup(
        [property: JsonPropertyName("toast")] bool IsToast,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("icon")] string Icon,
        [property: JsonPropertyName("text")] string Text,
        [property: JsonPropertyName("timer")] int Timer,
        [property: JsonPropertyName("timerProgressBar")] bool TimerProgressBar,
        [property: JsonPropertyName("confirmButtonText")] string ConfirmButtonText
    );