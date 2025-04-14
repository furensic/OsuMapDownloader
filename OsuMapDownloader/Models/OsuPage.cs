using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuPage {
    [JsonProperty("html")]
    public string Html { get; set; }

    [JsonProperty("raw")]
    public string Raw { get; set; }
}