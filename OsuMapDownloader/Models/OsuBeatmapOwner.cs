using Newtonsoft.Json;

namespace OsuMapDownloader.Models;

public class OsuBeatmapOwner {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }
}