using System.Text.Json.Serialization;

namespace Dosu.Game.Online;

public class Popup
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("confirmButtonText")]
    public string ConfirmButtonText { get; set; }

    [JsonPropertyName("timer")]
    public int Timer { get; set; }

    [JsonPropertyName("timerProgressBar")]
    public bool TimerProgressBar { get; set; }

    [JsonPropertyName("toast")]
    public bool IsToast { get; set; }
}
